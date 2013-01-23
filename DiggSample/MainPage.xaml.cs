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

namespace SilverTweet
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel(); 
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
                DisplayTweets(e.Result);
            }
        }

        private void DisplayTweets(string data)
        {
            JsonObject json = (JsonObject) JsonValue.Parse(data);
            JsonArray results = (JsonArray) json["results"];

            var tweets = from tweet in results
                    select new Tweet
                    {
                        User = (string)tweet["from_user"],
                        ProfileImage = (string)tweet["profile_image_url"],
                        Text = (string)tweet["text"]
                    };

            var tweetObs = new ObservableCollection<Tweet>(tweets);

            TweetList.SelectedIndex = -1;
            this.DataContext = tweetObs;
            
        }
    }
}
