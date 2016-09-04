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
            int ButtonHeight = 70;
            int Buttonwidth = 100;
            this.Title = "Login";

            var HostLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Padding = 20, BackgroundColor = Color.Teal };





            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.BackgroundColor = Color.Teal;
            Content = HostLayout;
        }
    }
}
