﻿using System;
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

namespace SilverTweetMVVM
{
    public class MainPageViewModel : ViewModelBase
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

        TwitterAPI api = new TwitterAPI();

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

        public MainPageViewModel()
        {
            _tweets = new ObservableCollection<Tweet>();
            GetTweetsCommand = new RelayCommand<string>(GetTweets);
        }

        public async void GetTweets(string query)
        {
            Messenger.Default.Send("begin");
            Loading = true;
            Tweets = await api.Search(query);
            Loading = false;
            Messenger.Default.Send("stop");

        }
    }
}