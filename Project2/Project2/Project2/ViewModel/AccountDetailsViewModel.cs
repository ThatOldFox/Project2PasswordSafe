using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.ViewModel
{

    class AccountDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Model.DecryptedAccount account = new Model.DecryptedAccount();
        public string AccountName
        {
            get
            {
                return account.AccountName;
            }
            set
            {
                account.AccountName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AccountName"));
                }
            }
        }
        public string AccountUsername
        {
            get
            {
                return account.Username;
            }
            set
            {
                account.Username = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Username"));
                }
            }
        }
        public string AccountPassword
        {
            get
            {
                return account.Password;
            }
            set
            {
                account.Password = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }
    }
}
