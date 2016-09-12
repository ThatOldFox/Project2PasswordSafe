﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Data;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class AddAccount : ContentPage
    {
        private string _UserAccount;

        public AddAccount(string UserAccount)
        {
            InitializeComponent();
            _UserAccount = UserAccount;
        }

        async void AddToDb(object sender, EventArgs e)
        {

            Data.Database db = new Data.Database();
            bool error = await db.AddPasswordToDb(txtUsername.Text, txtPassword.Text, txtAccountName.Text, _UserAccount);

            if(error == false)
            {
                //notify user the account was added
                Data.AccountDataAccessService adas = new Data.AccountDataAccessService();
                adas.AddAccount(new Model.Account{ AccountName = Crypto.EncryptToBytes(txtAccountName.Text), Username = Crypto.EncryptToBytes(txtUsername.Text), Password = Crypto.EncryptToBytes(txtPassword.Text) });
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtAccountName.Text = "";
                lblResult.Text = "Account details saved";
            }
            else
            {
                //notify some error occured
                lblResult.Text = "Error adding account";
            }
        }

    }
}
