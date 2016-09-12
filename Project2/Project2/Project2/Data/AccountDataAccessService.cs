
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
    /// <summary>
    /// Handles SQLite interactions
    /// </summary>
    class AccountDataAccessService
    {

        public SQLiteConnection DBConnection;
        /// <summary>
        /// Constructor
        /// </summary>
        public AccountDataAccessService()
        {
            //SQLite connection
            DBConnection = DependencyService.Get<ISQLite>().GetConnection();
            //create sqlite tables
            DBConnection.CreateTable<Model.Account>();
            DBConnection.CreateTable<Model.Login>();
           

        }
        /// <summary>
        /// Method to get accounts from SQlite database
        /// </summary>
        /// <returns>Returns list of accounts from SQlite database</returns>
        public List<Model.Account> GetAllAccounts()
        {
            return  DBConnection.Table<Model.Account>().ToList();
        }
        /// <summary>
        /// Add an account to the SQLite database
        /// </summary>
        /// <param name="newAccount">the account credentials to add to the DB</param>
        public void AddAccount(Model.Account newAccount)
        {
            DBConnection.Insert(newAccount);
        }
        /// <summary>
        /// Sets login paramater for SQLite database
        /// </summary>
        /// <param name="newLogin">the user to login to the app</param>
        public void AddLogin(Model.Login newLogin)
        {
            DBConnection.Insert(newLogin);
        }
        /// <summary>
        /// Retrieves login status
        /// </summary>
        /// <returns>the user that has logged in previously</returns>
        public List<Model.Login> GetLogin()
        {
            return DBConnection.Table<Model.Login>().ToList();
        }
        /// <summary>
        /// Deletes everything in the SQLite database, and then re pulls all data
        /// </summary>
        /// <param name="UserName">the username of the expected data</param>
        public async void Resync(string UserName)
        {
            DBConnection.DeleteAll<Model.Account>();
            Data.Database Db = new Data.Database();
            bool error = await Db.GetAccounts(UserName);
        }

    }
}
