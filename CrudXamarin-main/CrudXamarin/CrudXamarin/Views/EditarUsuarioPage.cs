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
    public class EditarUsuarioPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nombresEntry;
        private Entry _apellidosEntry;
        private Entry _dniEntry;
        private Entry _celularEntry;
        private Entry _correoEntry;
        private Button _button;

        User _user = new User();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");

        public EditarUsuarioPage()
        {
            this.Title = "Editar usuario";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<User>().OrderBy(x => x.nombres).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "Id";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nombresEntry = new Entry();
            _nombresEntry.Keyboard = Keyboard.Text;
            _nombresEntry.Placeholder = "Nombres";
            stackLayout.Children.Add(_nombresEntry);

            _apellidosEntry = new Entry();
            _apellidosEntry.Keyboard = Keyboard.Text;
            _apellidosEntry.Placeholder = "Apellidos";
            stackLayout.Children.Add(_apellidosEntry);

            _dniEntry = new Entry();
            _dniEntry.Keyboard = Keyboard.Numeric;
            _dniEntry.MaxLength = 9;
            _dniEntry.Placeholder = "DNI";
            stackLayout.Children.Add(_dniEntry);

            _celularEntry = new Entry();
            _celularEntry.Keyboard = Keyboard.Numeric;
            _celularEntry.MaxLength = 9;
            _celularEntry.Placeholder = "Celular";
            stackLayout.Children.Add(_celularEntry);

            _correoEntry = new Entry();
            _correoEntry.Keyboard = Keyboard.Text;
            _correoEntry.Placeholder = "Correo";
            stackLayout.Children.Add(_correoEntry);

            _button = new Button();
            _button.Text = "Actualizar usuario";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            User user = new User()
            {
                id = Convert.ToInt32(_idEntry.Text),
                nombres = _nombresEntry.Text,
                apellidos = _apellidosEntry.Text,
                dni = Convert.ToInt32(_dniEntry.Text),
                celular = Convert.ToInt32(_celularEntry.Text),
                correo = _correoEntry.Text,
            };
            db.Update(user);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _user = (User)e.SelectedItem;
            _idEntry.Text = _user.id.ToString();
            _nombresEntry.Text = _user.nombres;
            _apellidosEntry.Text = _user.apellidos;
            _dniEntry.Text = _user.dni.ToString();
            _celularEntry.Text = _user.celular.ToString();
            _correoEntry.Text = _user.correo;

        }
    }
}