using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //connect to DB and send query
            Data.Database db = new Data.Database();
            bool error = await db.UpdateAccount(_UserName, lblAccountName.Text, txtUsername.Text, txtPassword.Text );

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
                lblResult.Text = "Error updating account - Check Connection";
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
                lblResult.Text = "Error deleting account - Check Connection";
            }
        }
    }
}
