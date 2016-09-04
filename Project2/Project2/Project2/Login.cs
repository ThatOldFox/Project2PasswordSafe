using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class Login : ContentPage
    {
        public Login()
        {
            int Height = 70;
            int Width = 100;
            this.Title = "Password Safe";

            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };
            var LblTitle = new Label() { WidthRequest = Width, Text = "Login", HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, TextColor = Color.White };
            var LblUserName = new Label() { WidthRequest = Width, Text = "Username", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var TxtUsername = new Entry() { WidthRequest = Width, Placeholder = "Enter A Username"};
            var LblPassword = new Label() { WidthRequest = Width, Text = "Password", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var TxtPassword = new Entry() { WidthRequest = Width, Placeholder = "Enter A Password" };// change to nathans type
            var BtnLogin = new Button() { HeightRequest = Height, WidthRequest = Width, Text = "Login", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
            var BtnRegister = new Button() { HeightRequest = Height, WidthRequest = Width, Text = "Register", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };

            HostLayout.Children.Add(LblTitle);
            HostLayout.Children.Add(LblUserName);
            HostLayout.Children.Add(TxtUsername);
            HostLayout.Children.Add(LblPassword);
            HostLayout.Children.Add(TxtPassword);
            HostLayout.Children.Add(BtnLogin);
            HostLayout.Children.Add(BtnRegister);


            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;
            Content = HostLayout;
        }
    }
}
