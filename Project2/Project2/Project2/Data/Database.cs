using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Data
{
    class Database
    {
        public void Db()
        {
            HttpClient Client = new HttpClient();
            Uri Url = new Uri("http://www.deakin.edu.au/~jgallop/PasswordSafeBackend/getAccounts.php");
        }
    }
}
