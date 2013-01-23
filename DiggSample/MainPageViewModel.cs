using System;
using MVVM;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

namespace SilverTweet
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _query;

        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _SearchCommand;
            }
        }

        public MainPageViewModel()
        {
            _SearchCommand = new DelegateCommand<string>(null);
        }

        private void DownloadTweets(object sender, RoutedEventArgs e)
        {
            string twitterUrl = String.Format("http://search.twitter.com/search.json?q={0}", TxtSearch.Text);
            WebClient twitterService = new WebClient();
            twitterService.DownloadStringCompleted += new DownloadStringCompletedEventHandler(TwitterService_DownloadStoriesCompleted);
            twitterService.DownloadStringAsync(new Uri(twitterUrl));
        }

        public void TwitterService_DownloadStoriesCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                CreateTweetsList(e.Result);
            }
        }

        private void CreateTweetsList(string data)
        {
            JsonObject json = (JsonObject)JsonValue.Parse(data);
            JsonArray results = (JsonArray)json["results"];

            var tweets = from tweet in results
                         select new Tweet
                         {
                             User = (string)tweet["from_user"],
                             ProfileImage = (string)tweet["profile_image_url"],
                             Text = (string)tweet["text"]
                         };

            var tweetObs = new ObservableCollection<Tweet>(tweets);
        }
  
    }
}
