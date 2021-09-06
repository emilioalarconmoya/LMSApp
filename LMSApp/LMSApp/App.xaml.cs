using LMSApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMSApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ActividadVigentesPage();
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
