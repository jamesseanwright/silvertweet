using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;

namespace SilverTweetMVVM.Behaviours
{
    public class ImageAnimationTrigger : TargetedTriggerAction<Storyboard>
    {
        protected override void Invoke(object parameter)
        {
            if (Target == null)
                return;

            if (parameter is DependencyPropertyChangedEventArgs)
            {
                DependencyPropertyChangedEventArgs args = (DependencyPropertyChangedEventArgs)parameter;

                if ((bool)args.NewValue)
                    Target.Begin();
                else
                    Target.Stop();
            }
            else if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs args = (RoutedEventArgs)parameter;

                if (!(args.OriginalSource as Button).IsEnabled)
                    Target.Begin();
                else
                    Target.Stop();
            }
        }
    }
}
