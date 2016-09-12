﻿using System;
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
        private string _UserName;
        public ViewPasswords(string UserName)
        {
            InitializeComponent();
            _UserName = UserName;
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
                accountVM.account = (Model.DecryptedAccount)e.SelectedItem;

                var accountDetailsPage = new View.ViewPassword(_UserName);
                accountDetailsPage.BindingContext = accountVM;
                await Navigation.PushAsync(accountDetailsPage);

            }

            
        }
    }
}
