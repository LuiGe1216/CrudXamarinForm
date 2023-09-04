using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void btnCrud_Clicked(object sender, EventArgs e)
        {
            App.masterDet.IsPresented = false;
            await App.masterDet.Detail.Navigation.PushAsync(new AgregarUsuarioPage());
        }

        private async void btnListar_Clicked(object sender, EventArgs e)
        {
            App.masterDet.IsPresented = false;
            await App.masterDet.Detail.Navigation.PushAsync(new ListarUsuarioPage());
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            App.masterDet.IsPresented = false;
            await App.masterDet.Detail.Navigation.PushAsync(new EditarUsuarioPage());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            App.masterDet.IsPresented = false;
            await App.masterDet.Detail.Navigation.PushAsync(new EliminarUsuarioPage());
        }
    }
}