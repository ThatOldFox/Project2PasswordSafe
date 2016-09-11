
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Model
{
    public class Account
    {
        [PrimaryKey]
        public int id { get; set; }
        public byte[] AccountName { get; set; }
        public byte[] Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] User { get; set; }

        public Account()
        {

        }

        public Account(byte[] AccountName, byte[] Username, byte[] Password)
        {
            this.AccountName = AccountName;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
