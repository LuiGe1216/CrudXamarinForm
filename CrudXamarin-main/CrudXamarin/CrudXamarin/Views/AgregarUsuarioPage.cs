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
    public class AgregarUsuarioPage : ContentPage
    {
        private Entry _nombresEntry;
        private Entry _apellidosEntry;
        private Entry _dniEntry;
        private Entry _celularEntry;
        private Entry _correoEntry;
        private Button _guardarButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");

        public AgregarUsuarioPage()
        {
            this.Title = "Agregar Usuario";
            StackLayout stackLayout = new StackLayout();

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
            _dniEntry.MaxLength = 8;
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

            _guardarButton = new Button();
            _guardarButton.Text = "Agregar usuario";
            _guardarButton.Clicked += _guardarButton_Clicked;
            stackLayout.Children.Add(_guardarButton);

            Content = stackLayout;
        }

        private async void _guardarButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<User>();

            var maxPk = db.Table<User>().OrderByDescending(c => c.id).FirstOrDefault();

            User user = new User()
            {
                id = (maxPk == null ? 1 : maxPk.id + 1),
                nombres = _nombresEntry.Text,
                apellidos = _apellidosEntry.Text,
                dni = Convert.ToInt32(_dniEntry.Text),
                celular = Convert.ToInt32(_celularEntry.Text),
                correo = _correoEntry.Text,
            };

            db.Insert(user);
            await DisplayAlert(null, "Usuario guardado correctamente", "Ok");
            await Navigation.PopAsync();
        }
    }
}