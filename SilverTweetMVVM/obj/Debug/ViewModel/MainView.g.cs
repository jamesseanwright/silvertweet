﻿#pragma checksum "C:\Users\Administrator.WIN7\Documents\Visual Studio 2010\Projects\SilverTweetMVVM\SilverTweetMVVM\ViewModel\MainView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A86E6891229E2D1EB9119553B95FD4AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SilverTweetMVVM {
    
    
    public partial class MainView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard animStoryboard;
        
        internal System.Windows.Controls.Image ImgLogo;
        
        internal System.Windows.Controls.TextBox TxtSearch;
        
        internal System.Windows.Controls.Button BtnSearch;
        
        internal System.Windows.Controls.ListBox TweetList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SilverTweetMVVM;component/ViewModel/MainView.xaml", System.UriKind.Relative));
            this.animStoryboard = ((System.Windows.Media.Animation.Storyboard)(this.FindName("animStoryboard")));
            this.ImgLogo = ((System.Windows.Controls.Image)(this.FindName("ImgLogo")));
            this.TxtSearch = ((System.Windows.Controls.TextBox)(this.FindName("TxtSearch")));
            this.BtnSearch = ((System.Windows.Controls.Button)(this.FindName("BtnSearch")));
            this.TweetList = ((System.Windows.Controls.ListBox)(this.FindName("TweetList")));
        }
    }
}

