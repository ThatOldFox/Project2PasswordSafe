using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project2.Data;
using System.IO;
using System;
using Xamarin.Forms;
using Project2.iOS;
using SQLite.Net;

[assembly: Dependency(typeof(DBConnection))]
namespace Project2.iOS
{
    public class DBConnection : ISQLite
    {
        public DBConnection() { }
        public SQLiteConnection GetConnection()
        {
            var filename = "Accounts.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(documentPath, filename);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}