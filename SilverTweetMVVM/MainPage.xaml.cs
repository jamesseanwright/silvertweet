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
using GalaSoft.MvvmLight.Messaging;

namespace SilverTweetMVVM
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
            Messenger.Default.Register<string>(this, (animation) => onReceiveMessage(animation));
        }

        private void onReceiveMessage(string message)
        {
            if (message.Equals("begin"))
            {
                animStoryboard.Begin();
            }
            else
            {
                animStoryboard.Stop();
            }
        }
    }
}
