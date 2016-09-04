using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class ViewPasswords : ContentPage
    {
        public ViewPasswords()
        {
            this.Title = "Password Safe";
            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };

            List<string> test = new List<string>();
            
            //PlaceHolder Code
            for(int i = 0; i < 10; i++)
            {
                test.Add("Placeholder " + i + "");
            }

            var ListView = new ListView() {ItemsSource = test };

            HostLayout.Children.Add(ListView);

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;

            Content = HostLayout;


        }
    }
}
