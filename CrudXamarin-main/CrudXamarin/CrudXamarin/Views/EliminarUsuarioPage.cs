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
    public class EliminarUsuarioPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        User _user = new User();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");

        public EliminarUsuarioPage()
        {
            this.Title = "Eliminar usuario";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<User>().OrderBy(x => x.nombres).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Eliminar usuario";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _user = (User)e.SelectedItem;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<User>().Delete(x => x.id == _user.id);
            await Navigation.PopAsync();
        }
    }
}