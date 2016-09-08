using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Model
{
    class Account
    {
        public string AccountName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account()
        {

        }

        public Account(string AccountName, string Username, string Password)
        {
            this.AccountName = AccountName;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
