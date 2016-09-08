using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        async void OnAccountSelected(object selected, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            else
            {
                var accountVM = new ViewModel.AccountDetailsViewModel();
                accountVM.account = (Model.Account)e.SelectedItem;

                var accountDetailsPage = new View.ViewPassword();
                accountDetailsPage.BindingContext = accountVM;
                await Navigation.PushAsync(accountDetailsPage);

            }

            
        }
    }
}
