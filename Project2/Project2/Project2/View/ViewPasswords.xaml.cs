using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class ViewPasswords : ContentPage
    {
        public ViewPasswords()
        {
            InitializeComponent();
        }

        async void OnAccountSelected(object selected, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewPassword());
        }
    }
}
