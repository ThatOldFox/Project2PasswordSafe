using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class AddAccount : ContentPage
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        public void AddToDb(object sender, EventArgs e)
        {
            Data.Database db = new Data.Database();
            db.AddPasswordToDb();
        }

    }
}
