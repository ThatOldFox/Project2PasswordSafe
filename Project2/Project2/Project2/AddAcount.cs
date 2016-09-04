using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class AddAcount : ContentPage
    {
        public AddAcount()
        {
            int ButtonHeight = 70;
            int Buttonwidth = 100;
            int entryHeight = 40;

            this.Title = "Password Safe";
            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };
            var emailLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };
            var userLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };
            var passwordLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal, Spacing = 8 };



            var Title = new Label() { WidthRequest = Buttonwidth, Text = "Add Account", HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, TextColor = Color.White };

            var lblAccountName = new Label() { WidthRequest = Buttonwidth, Text = "Account Name", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtAccountName = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter an Account Name", HorizontalOptions = LayoutOptions.FillAndExpand };

            var lblUser = new Label() { WidthRequest = Buttonwidth, Text = "Username", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtUser = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter a Username", HorizontalOptions = LayoutOptions.FillAndExpand };

            var lblPass = new Label() { WidthRequest = Buttonwidth, Text = "Password", HorizontalTextAlignment = TextAlignment.Start, FontSize = 16, TextColor = Color.White };
            var txtPass = new Entry() { HeightRequest = entryHeight, WidthRequest = Buttonwidth, Placeholder = "Enter a Password", HorizontalOptions = LayoutOptions.FillAndExpand };


            var btnAddAccount = new Button() { HeightRequest = ButtonHeight, WidthRequest = Buttonwidth, Text = "Add Account", HorizontalOptions = LayoutOptions.FillAndExpand, BorderWidth = 1, BorderRadius = 2 };


            HostLayout.Children.Add(Title);

            emailLayout.Children.Add(lblAccountName);
            emailLayout.Children.Add(txtAccountName);

            userLayout.Children.Add(lblUser);
            userLayout.Children.Add(txtUser);

            passwordLayout.Children.Add(lblPass);
            passwordLayout.Children.Add(txtPass);

            HostLayout.Children.Add(emailLayout);
            HostLayout.Children.Add(userLayout);
            HostLayout.Children.Add(passwordLayout);

            HostLayout.Children.Add(btnAddAccount);

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;

            Content = HostLayout;
        }
    }
}
