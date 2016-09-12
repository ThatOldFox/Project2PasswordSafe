using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Data;

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

            Database DB = new Database();
            bool error = await DB.Login(UserName, PassWord);

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
                //Alert User
            }
        }

        async void Register(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Register(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}
