using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class Register : ContentPage
    {
        public Register()
        {
            int ButtonHeight = 70;
            int Buttonwidth = 100;
            int entryHeight = 40;

            this.Title = "Registration";
            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };
            var emailLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };
            var userLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };
            var passwordLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };



            var Title = new Label() { WidthRequest = Buttonwidth, Text = "Register", HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, TextColor = Color.White };

            var lblEmail = new Label() { WidthRequest = Buttonwidth, Text = "Email", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtEmail = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter an email address", HorizontalOptions = LayoutOptions.FillAndExpand};

            var lblUser = new Label() { WidthRequest = Buttonwidth, Text = "Username", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtUser = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter a username", HorizontalOptions = LayoutOptions.FillAndExpand };

            var lblPass = new Label() { WidthRequest = Buttonwidth, Text = "Password", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtPass = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter a password", HorizontalOptions = LayoutOptions.FillAndExpand };


            var btnRegister = new Button() { HeightRequest = ButtonHeight, WidthRequest = Buttonwidth, Text = "Register", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };
           

            HostLayout.Children.Add(Title);

            emailLayout.Children.Add(lblEmail);
            emailLayout.Children.Add(txtEmail);

            userLayout.Children.Add(lblUser);
            userLayout.Children.Add(txtUser);

            passwordLayout.Children.Add(lblPass);
            passwordLayout.Children.Add(txtPass);

            HostLayout.Children.Add(emailLayout);
            HostLayout.Children.Add(userLayout);
            HostLayout.Children.Add(passwordLayout);

            HostLayout.Children.Add(btnRegister);

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;

            Content = HostLayout;
        }
    }
}
