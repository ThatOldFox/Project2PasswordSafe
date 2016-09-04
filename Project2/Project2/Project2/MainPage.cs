using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            int ButtonHeight = 70;
            int ButtonWidth = 100;

            this.Title = "Password Safe";
            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };
            var LblTitle = new Label() { WidthRequest = ButtonWidth, Text = "Password Safe", HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, TextColor = Color.White }; 
            var BtnAddPassword = new Button() {HeightRequest = ButtonHeight , WidthRequest = ButtonWidth, Text = "Add Password", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
            var BtnViewPasswords = new Button() { HeightRequest = ButtonHeight, WidthRequest = ButtonWidth, Text = "View Passwords", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
            var BtnEncryptString = new Button() { HeightRequest = ButtonHeight, WidthRequest = ButtonWidth, Text = "Encrypt String", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };

            HostLayout.Children.Add(LblTitle);
            HostLayout.Children.Add(BtnAddPassword);
            HostLayout.Children.Add(BtnViewPasswords);
            HostLayout.Children.Add(BtnEncryptString);

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;

            Content = HostLayout;
           
        }
    }
}
