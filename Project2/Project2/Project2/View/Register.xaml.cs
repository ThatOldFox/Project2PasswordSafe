using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Data;
using System.Threading;

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

            Database DB = new Database();
            bool error = await DB.Register(Email, UserName, Password);

            if (error == false)
            {
                //On Regester also need a way of storing a variable for the username for inserting into accounts 
                Navigation.InsertPageBefore(new MainPage(UserName), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }
            else
            {
                //Alert User
                lblResult.Text = "Failed to register - Check connection";
            }
        }
    }
}
