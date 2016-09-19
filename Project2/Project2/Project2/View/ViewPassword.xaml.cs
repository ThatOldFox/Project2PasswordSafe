using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class ViewPassword : ContentPage
    {
        private string _UserName;
        public ViewPassword(string UserName)
        {
            InitializeComponent();
            _UserName = UserName;
        }

        /// <summary>
        /// Button click to update account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void BtnUpdate(object sender, EventArgs e)
        {
            bool error = false;

            Regex UserPass = new Regex("^[a-zA-Z0-9]*$+");
            Regex AccountUser = new Regex("^[a-zA-Z0-9]*$+");
            bool InvalidCredentials = false;

            Match test = AccountUser.Match(txtUsername.Text);
            if (!test.Success)
            {
                InvalidCredentials = true;
                error = true;
            }

            test = UserPass.Match(txtPassword.Text);
            if (!test.Success)
            {
                InvalidCredentials = true;
                error = true;
            }

            if (InvalidCredentials == false)
            {
                Data.Database db = new Data.Database();
                error = await db.UpdateAccount(_UserName, lblAccountName.Text, txtUsername.Text, txtPassword.Text);
            }

            //connect to DB and send query
         
            if (error == false)
            {
                //notify user the account was Updated
                Data.AccountDataAccessService adas = new Data.AccountDataAccessService();
                //resync database
                adas.Resync(_UserName);
                //go back to main menu
                Navigation.InsertPageBefore(new MainPage(_UserName), this); 
                await Navigation.PopToRootAsync();
            }
            else
            {
                //notify some error occured
                lblResult.Text = "Error updating account";
            }
        }
        /// <summary>
        /// Button click to delete account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void BtnDelete(object sender, EventArgs e)
        {

            Data.Database db = new Data.Database();
            bool error = await db.DeleteAccount(_UserName, lblAccountName.Text);

            if (error == false)
            {
                //notify user the account was added
                Data.AccountDataAccessService adas = new Data.AccountDataAccessService();
                //resync with the database
                adas.Resync(_UserName);
                //go back to main menu
                Navigation.InsertPageBefore(new MainPage(_UserName), this);
                await Navigation.PopToRootAsync();
            }
            else
            {
                //notify some error occured
                lblResult.Text = "Error deleting account";
            }
        }
    }
}
