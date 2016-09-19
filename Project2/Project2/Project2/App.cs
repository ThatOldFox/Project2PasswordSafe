using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Project2
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            Data.AccountDataAccessService adas = new Data.AccountDataAccessService();
            List<Model.Login> login = adas.GetLogin();
            if (login.Count == 1)
            {
                var NP = new NavigationPage(new View.SyncWithApi(login[0].User));
                MainPage = NP;
            }
            else if (login.Count > 1)
            {
                adas.DBConnection.DeleteAll<Model.Login>();
                var NP = new NavigationPage(new View.Login());
                MainPage = NP;
            }
            else
            {
                var NP = new NavigationPage(new View.Login());
                MainPage = NP;
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
