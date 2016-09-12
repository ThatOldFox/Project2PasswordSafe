using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Project2.Model;

namespace Project2.Data
{
    class Database
    {

        HttpClient Client = new HttpClient();
        List<DecryptedAccount> Accounts = null;
        string baseURL = "http://192.168.1.4:34592/api/conferencesessions/";

        #region Account Edits
        public async Task<bool> AddPasswordToDb(string Username, string Password, string AccountName, string UserAccount)
        {
            bool error = false;
            try
            {

                string URL = baseURL + UserAccount + "/" + AccountName + "/" + Username + "/" + Password;
                var response = await Client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch(Exception e)
            {
                error = true;
            }

            return error;
        }
        /// <summary>
        /// Deletes the account credentials in the database
        /// </summary>
        /// <param name="UserAccount">The user account that this delete will apply to</param>
        /// <param name="AccountName">The account to be deleted</param>
        /// <returns>Error</returns>
        async public Task<bool> DeleteAccount(string UserAccount, string AccountName)
        {
            //Delete Account
            bool error = false;
            string URL = baseURL+"GetDelete/"+UserAccount+"/"+AccountName;
            try
            {
                var response = await Client.GetAsync(URL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch(Exception e)
            {
                error = true;
            }

            return error;
        }
        /// <summary>
        /// Updates the account credentials in the database
        /// </summary>
        /// <param name="UserAccount">The users account that this update applies to</param>
        /// <param name="AccountName"> the account to update</param>
        /// <param name="UserName">The username to be updated to</param>
        /// <param name="Password">The password to be updated to</param>
        /// <returns>Error</returns>
        async public Task<bool> UpdateAccount(string UserAccount, string AccountName, string UserName, string Password)
        {
            bool error = false;
            string URL = baseURL + "GetUpdate/"+ UserAccount + "/"+ AccountName + "/"+UserName+"/"+Password;
            try
            {
                var response = await Client.GetAsync(URL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch(Exception e)
            {
                error = true;
            }
            return error;
        }
        #endregion

        #region Login Register
        public async Task<bool> Register(string Email, string UserName, string PassWord)
        {
            bool error = false;
            List<string> res = new List<string>();
            //replace email usename pass with variables
            string URL = baseURL + Email + "/" + UserName + "/" + PassWord;
            try
            {
                var response = await Client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<bool>(content);
                    //delete previous user SQLite data
                    AccountDataAccessService adas = new AccountDataAccessService();
                    adas.DBConnection.DeleteAll<Account>();
                    //set new user login for offline mode
                    Login login = new Login() { User = UserName };
                    adas.AddLogin(login);
                }
            }
            catch(Exception e)
            {
                error = true;
            }

            return error;
        }

        public async Task<bool> Login(string UserName, string PassWord)
        {
            bool error = false;
            //replace username and pass
            string URL = baseURL + "getLogin/" + UserName + "/" + PassWord;
            try
            {
                var response = await Client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch(Exception e)
            {
                error = false;
            }
            return error;

        }
        #endregion

        #region Get Accounts
        public async Task<bool> GetAccounts(string UserName)
        {
            bool error = false;
            List<string> res = new List<string>();
            //replace email usename pass with variables
            string URL = baseURL+ UserName;
            try
            {


                var response = await Client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    Accounts = JsonConvert.DeserializeObject<List<DecryptedAccount>>(content);
                    AccountDataAccessService adas = new AccountDataAccessService();
                    adas.DBConnection.DeleteAll<Account>();
                    foreach (DecryptedAccount a in Accounts)
                    {
                        adas.AddAccount(new Account() { AccountName = Crypto.EncryptToBytes(a.AccountName), Username = Crypto.EncryptToBytes(a.Username), Password = Crypto.EncryptToBytes(a.Password) });
                    }
                }
                else
                {
                    error = true;
                }
            }
            catch(Exception e)
            {
                error = true;
            }
            return error;

        }

        #endregion
    }
}
