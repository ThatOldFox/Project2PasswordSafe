using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Data;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async void login(object sender, EventArgs e)
        {

            string UserName = txtUsername.Text;
            string PassWord = txtPassword.Text;
            bool InvalidCredentials = false;
            bool error = false;

            Regex UserPass = new Regex("^[a-zA-Z0-9]*$");
            Regex AccountUser = new Regex("^[a-zA-Z0-9]*$");

            Match test = AccountUser.Match(UserName);
            if(!test.Success)
            {
                InvalidCredentials = true;
            }

            test = UserPass.Match(PassWord);
            if(!test.Success)
            {
                InvalidCredentials = true;
            }

            if (InvalidCredentials == false)
            {
                Database DB = new Database();
                error = await DB.Login(UserName, PassWord);
            }


            if (error == true)
            {
                //On Regester also need a way of storing a variable for the username for inserting into accounts 
                //new user login object
                Model.Login login = new Model.Login() {User = UserName};
                AccountDataAccessService adas = new AccountDataAccessService();
                //store login
                adas.AddLogin(login);
                //navigate to sync screen
                Navigation.InsertPageBefore(new SyncWithApi(UserName), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }
            else
            {
                LblError.Text = "Username/Password Was Incorrect";
            }
        }

        async void Register(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Register(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}
