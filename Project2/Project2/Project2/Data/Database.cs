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
        List<Account> ConferenceSessions = null;
        async public void AddPasswordToDb()
        {
            string n = "test";

            string Url1 = "http://10.0.0.61:34592/api/conferencesessions/" + n + "/" + n + "/" + n + "/" + n;
            var response = await Client.GetAsync(Url1);
        }
    }
}
