using System;
using System.IO;
using System.Collections.Generic;
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

namespace DiggSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string twitterUrl = String.Format("http://search.twitter.com/search.json?q={0}", TxtSearch.Text);
            WebClient twitterService = new WebClient();
            twitterService.DownloadStringCompleted += new DownloadStringCompletedEventHandler(TwitterService_DownloadStoriesCompleted);
            twitterService.DownloadStringAsync(new Uri(twitterUrl));
        }

        private void TwitterService_DownloadStoriesCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                DisplayTweets(StringToStream(e.Result));
            }
        }

        private MemoryStream StringToStream(string toConvert)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return new MemoryStream(encoding.GetBytes(toConvert));
        }

        private void DisplayTweets(MemoryStream data)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(APIResponse));
            APIResponse response = (APIResponse) serializer.ReadObject(data);

            var tweets = from tweet in response.results
                          select new Tweet
                          {
                              User = (string) tweet["from_user_name"],
                              ProfileImage = (string) tweet["profile_image_url"],
                              Text = (string) tweet["text"],
                              CreatedAt = new DateTime()
                          };

            TweetList.SelectedIndex = -1;
            TweetList.ItemsSource = tweets;
        }
    }
}
