using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void BtnEncryptStringClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Encrypt());
        }

        async void ViewPasswordClick(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewPasswords());
        }

        async void AddPasswordClick(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.AddAccount());
        }

    }
}
