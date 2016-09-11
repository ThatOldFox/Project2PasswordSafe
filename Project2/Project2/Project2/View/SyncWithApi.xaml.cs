using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Data;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class SyncWithApi : ContentPage
    {
        public SyncWithApi(string Username)
        {
            InitializeComponent();
            syncAndLoad(Username);
        }

        async void syncAndLoad(string Username)
        {
            Database Db = new Database();
            bool error = await Db.GetAccounts(Username);


            if(error == false)
            {
                //online mode
                Navigation.InsertPageBefore(new MainPage(Username), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }
            else
            {
                //offline mode
                Navigation.InsertPageBefore(new MainPage(Username), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }


        }
    }
}
