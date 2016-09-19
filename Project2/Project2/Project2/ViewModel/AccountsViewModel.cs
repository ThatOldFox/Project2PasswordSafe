/*References
 * - Seridonio,P,2016,Cryptography Shared Code,Xamarin, Retrieved 10/09/2016 
 *   https://forums.xamarin.com/discussion/64399/cryptography-shared-code
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.Model;

namespace Project2.ViewModel
{
    class AccountsViewModel
    {
        public ObservableCollection<Model.DecryptedAccount> Accounts { get; set; }

        public AccountsViewModel()
        {
            /*Accounts = new ObservableCollection<Model.Account>(
               new Model.Account[] {
                   new Model.Account { AccountName = "Facebook", Username = "Jack" , Password = "JACKJACK"},
                   new Model.Account { AccountName = "Deakin", Username = "Nbabinal" , Password = "Poisewoid"},
                   new Model.Account { AccountName = "GMail", Username = "Dmills@google.com" , Password = "1234" }
               }
               );*/
            FetchDataAsync();
        }
        public void FetchDataAsync()
        {
            Data.AccountDataAccessService adas = new Data.AccountDataAccessService();
            List<Account> list = adas.GetAllAccounts();
            List<DecryptedAccount>  decryptedList = DecryptList(list);
            Accounts = new ObservableCollection<DecryptedAccount>(decryptedList);
        }


        private List<DecryptedAccount> DecryptList(List<Account> list)
        {
            List<DecryptedAccount> decryptedList = new List<DecryptedAccount>();
            foreach(Account a in list)
            {
                decryptedList.Add(new DecryptedAccount { id = a.id, Username = Data.Crypto.DecryptFromBytes(a.Username), AccountName = Data.Crypto.DecryptFromBytes(a.AccountName), Password = Data.Crypto.DecryptFromBytes(a.Password) }); //Seridonio,2016
            }
            return decryptedList;
        }
    }
}
