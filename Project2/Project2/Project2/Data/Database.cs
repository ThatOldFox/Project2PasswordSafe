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
        List<Account> Accounts = null;


        #region Account Edits
        public async Task<bool> AddPasswordToDb(string Username, string Password, string AccountName, string UserAccount)
        {
            bool error = false;
            string URL = "http://10.0.0.61:34592/api/conferencesessions/" + UserAccount + "/" + AccountName + "/" + Username + "/" + Password;
            var response = await Client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                error = JsonConvert.DeserializeObject<bool>(content);
            }
            return error;
        }

        async public void DeleteAccount()
        {
            //replace AccountName and pass
            string URL = "http://10.0.0.61:34592/api/conferencesessions/AccountName/Password";
            var response = await Client.GetAsync(URL);
        }

        async public void UpdateAccount()
        {
            //replace AccountName and pass
            string URL = "http://10.0.0.61:34592/api/conferencesessions/AccountName/Password";
            var response = await Client.GetAsync(URL);
        }
        #endregion

        #region Login Register
        public async Task<bool> Register(string Email, string UserName, string PassWord)
        {
            bool error = false;
            List<string> res = new List<string>();
            //replace email usename pass with variables
            string URL = "http://10.0.0.61:34592/api/conferencesessions/" + Email + "/" + UserName + "/" + PassWord;
            var response = await Client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                error = JsonConvert.DeserializeObject<bool>(content);
            }

            return error;
        }

        public async Task<bool> Login(string UserName, string PassWord)
        {
            bool error = false;
            //replace username and pass
            string URL = "http://10.0.0.61:34592/api/conferencesessions/getLogin/" + UserName + "/" + PassWord;
            var response = await Client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                error = JsonConvert.DeserializeObject<bool>(content);
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
            string URL = "http://10.0.0.61:34592/api/conferencesessions/"+ UserName;
            var response = await Client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Accounts = JsonConvert.DeserializeObject<List<Account>>(content);
            }
            else
            {
                error = true;
            }

            return error;


        }


        #endregion
    }
}
