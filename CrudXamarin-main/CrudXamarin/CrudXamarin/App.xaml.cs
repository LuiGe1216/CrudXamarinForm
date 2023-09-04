using CrudXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin
{
    public partial class App : Application
    {
        public static MasterDetailPage masterDet { get; set; }
        public App()
        {
            InitializeComponent();


            MainPage = new MainPage ();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
