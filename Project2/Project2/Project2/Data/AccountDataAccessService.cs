
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project2.Data
{
    class AccountDataAccessService
    {
        public SQLiteConnection DBConnection;
        /*public SQLiteConnection DBConnection
        {
            get { return _DBConnection; }
            set { _DBConnection = value; }
        }*/
        public AccountDataAccessService()
        {

            DBConnection = DependencyService.Get<ISQLite>().GetConnection();
            DBConnection.CreateTable<Model.Account>();

            DBConnection.DeleteAll<Model.Account>();
            DBConnection.Insert(new Model.Account{ id=1, AccountName = "Facebook", Username = "Jack", Password = "JACKJACK" });
            DBConnection.Insert(new Model.Account { id = 2, AccountName = "Deakin", Username = "Nbabinal", Password = "Poisewoid" });
            DBConnection.Insert(new Model.Account { id = 3, AccountName = "GMail", Username = "Dmills@google.com", Password = "1234" });

        }
        public List<Model.Account> GetAllAccounts()
        {
            return  DBConnection.Table<Model.Account>().ToList();
        }
        public void AddAccount(Model.Account newAccount)
        {
            DBConnection.Insert(newAccount);
        }
    }
}
