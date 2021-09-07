using LMSApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMSApp
{
    public partial class App : Application
    {

        #region Constructores
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        #endregion

        #region Metodos
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        #endregion

    }
}
