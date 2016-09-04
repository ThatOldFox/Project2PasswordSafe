using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class Encrypt : ContentPage
    {
        public Encrypt()
        {
            int ButtonHeight = 70;
            int Buttonwidth = 100;
            int entryHeight = 40;

            this.Title = "Password Safe";
            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };
            var passwordLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };

            var Title = new Label() { WidthRequest = Buttonwidth, Text = "Password Encryption", HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, TextColor = Color.White };

            var lblPass = new Label() { WidthRequest = Buttonwidth, Text = "Password", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtPass = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter a password to encrypt", HorizontalOptions = LayoutOptions.FillAndExpand };

            var btnEncrypt = new Button() { HeightRequest = ButtonHeight, WidthRequest = Buttonwidth, Text = "Encrypt", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };

            HostLayout.Children.Add(Title);


            passwordLayout.Children.Add(lblPass);
            passwordLayout.Children.Add(txtPass);

            HostLayout.Children.Add(passwordLayout);

            HostLayout.Children.Add(btnEncrypt);


            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;

            Content = HostLayout;
        }
    }
}
