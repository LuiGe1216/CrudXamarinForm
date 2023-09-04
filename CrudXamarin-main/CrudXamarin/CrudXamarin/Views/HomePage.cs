using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CrudXamarin.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Agregar usuario";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Listar usuario";
            button.Clicked += Button_Listar_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Editar usuario";
            button.Clicked += Button_Editar_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Eliminar usuario";
            button.Clicked += Button_Eliminar_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarUsuarioPage());
        }

        private async void Button_Listar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarUsuarioPage());
        }

        private async void Button_Editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarUsuarioPage());
        }

        private async void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarUsuarioPage());
        }
    }
}