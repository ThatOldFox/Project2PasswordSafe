using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;


namespace Project2.Data
{
    class Database
    {

        HttpClient Client = new HttpClient();

        async public void Db()
        {
           
            string Url = "http://www.deakin.edu.au/~jgallop/PasswordSafeBackend/getAccounts.php";

            var UserAccount = "Dummy";
            var AccountName = "Dummy";
            var Username = "Dummy";
            var Password = "Dummy";

            var response = await Client.GetAsync(Url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
