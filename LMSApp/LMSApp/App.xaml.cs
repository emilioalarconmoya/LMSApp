using LMSApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LMSApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        [Obsolete]
        public static MasterPage Master { get; internal set; }

        #region Constructores
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
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
