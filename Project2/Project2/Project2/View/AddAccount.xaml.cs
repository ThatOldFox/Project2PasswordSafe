using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            else
            {
                //notify some error occured
            }
        }

    }
}
