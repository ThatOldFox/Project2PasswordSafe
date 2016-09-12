using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Data;
using System.Threading;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        async void AddUser(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;
            string UserName = txtUsername.Text;
            string Email = txtEmail.Text;
            bool InvalidCredentials = false;
            bool error = false;

            Regex UserPass = new Regex("^[a-zA-Z0-9]*$");
            Regex AccountUser = new Regex("^[a-zA-Z0-9]*$");
            Match test = AccountUser.Match(UserName);
            if (!test.Success)
            {
                InvalidCredentials = true;
                error = true;
            }

            test = UserPass.Match(Password);
            if (!test.Success)
            {
                InvalidCredentials = true;
                error = true;
            }

            //http://emailregex.com/
            Regex EmailCheck = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

            test = EmailCheck.Match(Email);
            if(!test.Success)
            {
                InvalidCredentials = true;
                error = true;
            }

            if (InvalidCredentials == false)
            {
                Database DB = new Database();
                error = await DB.Register(Email, UserName, Password);
            }
           
            

            if (error == false)
            {
                //On Regester also need a way of storing a variable for the username for inserting into accounts 
                Navigation.InsertPageBefore(new MainPage(UserName), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }
            else
            {
                LblError.Text = "Error Username/Password must be AlphaNumeric";
            }
        }
    }
}
