
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Model
{
    public class DecryptedAccount
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string AccountName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string User { get; set; }

        public DecryptedAccount()
        {

        }

        public DecryptedAccount(string AccountName, string Username, string Password)
        {
            this.AccountName = AccountName;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
