using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading.Tasks;

namespace SilverTweetMVVM
{
    public class TwitterAPI
    {
        public async Task<ObservableCollection<Tweet>> Search(string query)
        {
            string twitterUrl = String.Format("http://search.twitter.com/search.json?q={0}", query);
            WebClient twitterService = new WebClient();
            string data = await twitterService.DownloadStringTaskAsync(new Uri(twitterUrl));

            JsonObject json = (JsonObject)JsonValue.Parse(data);
            JsonArray results = (JsonArray)json["results"];

            var tweets = from tweet in results
                         select new Tweet
                         {
                             User = (string)tweet["from_user"],
                             ProfileImage = (string)tweet["profile_image_url"],
                             Text = (string)tweet["text"]
                         };

            return new ObservableCollection<Tweet>(tweets);
        }
    }
}
