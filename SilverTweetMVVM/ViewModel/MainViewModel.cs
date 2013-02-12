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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using SilverTweetMVVM.DataService;
using SilverTweetMVVM.Model;

namespace SilverTweetMVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }

        TwitterDataService api = new TwitterDataService();

        public RelayCommand<string> GetTweetsCommand { get; set; }
        public RelayCommand SendAnimationCommand { get; set; }

        private ObservableCollection<Tweet> _tweets;
        public ObservableCollection<Tweet> Tweets
        {
            get { return _tweets; }
            set
            {
                _tweets = value;
                RaisePropertyChanged("Tweets");
            }
        }

        public MainViewModel()
        {
            _tweets = new ObservableCollection<Tweet>();
            GetTweetsCommand = new RelayCommand<string>(GetTweets);
        }

        public async void GetTweets(string query)
        {
            Loading = true;

            try
            {
                Tweets = await api.Search(query);
            }
            catch (WebException ex)
            {
                Tweet tweet = new Tweet();
                tweet.User = ex.Message;
                tweet.Text = ex.InnerException.ToString();
                tweet.ProfileImage = "../Resources/error.png";
                Tweets.Add(tweet);
            }

            Loading = false;
        }
    }
}
