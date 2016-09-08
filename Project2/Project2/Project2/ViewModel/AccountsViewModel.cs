using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.ViewModel
{
    class AccountsViewModel
    {
        public ObservableCollection<Model.Account> Accounts {get;set;}

        public AccountsViewModel()
        {
            Accounts = new ObservableCollection<Model.Account>(
                new Model.Account[] {
                    new Model.Account { AccountName = "Facebook", Username = "Jack" , Password = "JACKJACK"},
                    new Model.Account { AccountName = "Deakin", Username = "Nbabinal" , Password = "Poisewoid"},
                    new Model.Account { AccountName = "GMail", Username = "Dmills@google.com" , Password = "1234" }
                }
                );
        }
    }
}
