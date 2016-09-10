using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Project2.Data;
using System.IO;
using Project2.Droid;
using Xamarin.Forms;
using SQLite.Net;

[assembly: Dependency(typeof (DBConnection))]
namespace Project2.Droid
{
    public class DBConnection : ISQLite
    {
        public DBConnection() { }
        public SQLiteConnection GetConnection()
        {
            var filename = "Accounts.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, filename);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
        /*public DBConnection() { }
        public SQLite.SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "AccountSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteAsyncConnection(path);
            // Return the database connection
            return conn;
        }*/
    }
}