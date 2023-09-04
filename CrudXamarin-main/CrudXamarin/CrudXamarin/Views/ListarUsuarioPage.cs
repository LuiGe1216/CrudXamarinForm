using CrudXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CrudXamarin.Views
{
    public class ListarUsuarioPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
        public ListarUsuarioPage()
        {
            this.Title = "Listar usuarios";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<User>().OrderBy(x => x.nombres).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}