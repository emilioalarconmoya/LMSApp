using GalaSoft.MvvmLight.Command;
using LMSApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LMSApp.ViewModels
{
    public class MenuItemViewModel
    {
        #region atributos
        public string Icono { get; set; }
        public string Titulo { get; set; }
        public string Pagina { get; set; }
        #endregion

        #region commnands

        public ICommand GotoCommand
        {
            get
            {
                return new RelayCommand(Goto);
            }
        }

        [Obsolete]
        private async void Goto()
        {
            if(this.Pagina == "LoginPage")
            {
                MainViewModel.GetInstance().Login = new LoginViewModel();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if(this.Pagina == "ActividadVigentesPage")
            {
                MainViewModel.GetInstance().ActividadVigentes = new ActividadVigentesViewModel();
                Application.Current.MainPage = new NavigationPage(new ActividadVigentesPage());
            }
            else if (this.Pagina == "HistorialAlumnoPage")
            {
                MainViewModel.GetInstance().HistorialAlumnos = new HistorialAlumnosViewModel();
                App.Master.IsPresented = false;
                await App.Navigator.PushAsync(new HistorialAlumnoPage());
            }


        }
        #endregion
    }
}
