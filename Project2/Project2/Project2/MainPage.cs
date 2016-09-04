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
            int Buttonwidth = 100;

            this.Title = "Home";
            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };
            var Title = new Label() { WidthRequest = Buttonwidth, Text = "Password Safe", HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, TextColor = Color.White }; 
            var AddPassword = new Button() {HeightRequest = ButtonHeight , WidthRequest = Buttonwidth, Text = "Add Password", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
            var ViewPasswords = new Button() { HeightRequest = ButtonHeight, WidthRequest = Buttonwidth, Text = "View Passwords", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
            var EditPasswords = new Button() { HeightRequest = ButtonHeight, WidthRequest = Buttonwidth, Text = "Edit Passwords", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
            var EncryptString = new Button() { HeightRequest = ButtonHeight, WidthRequest = Buttonwidth, Text = "Encrypt String", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };

            HostLayout.Children.Add(Title);
            HostLayout.Children.Add(AddPassword);
            HostLayout.Children.Add(ViewPasswords);
            HostLayout.Children.Add(EditPasswords);
            HostLayout.Children.Add(EncryptString);

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;

            Content = HostLayout;
           
        }
    }
}
