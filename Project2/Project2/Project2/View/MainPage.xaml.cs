/*references
 *- Ford,K,2015,Xamarin.Forms removing a page,StackOverFlow,Retrived 08/09/2016
 *  http://stackoverflow.com/questions/29042792/xamarin-forms-removing-a-page
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class MainPage : ContentPage
    {
        private string _UserName;
        

        public MainPage(string UserName)
        {
            InitializeComponent();
            _UserName = UserName;
           
        }

        async void ViewPasswordClick(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewPasswords(_UserName));
        }

        async void AddPasswordClick(object Sender, EventArgs e)
        {

            await Navigation.PushAsync(new View.AddAccount(_UserName));
        }
        async void BtnSyncClick(object Sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new SyncWithApi(_UserName), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }

        async void LogoutClick(object Sender, EventArgs e)
        {
            Data.AccountDataAccessService adas = new Data.AccountDataAccessService();
            adas.DBConnection.DeleteAll<Model.Login>();
            Navigation.InsertPageBefore(new Login(), this);
            await Navigation.PopAsync().ConfigureAwait(false); //(Ford,2016)
        }

    }
}
