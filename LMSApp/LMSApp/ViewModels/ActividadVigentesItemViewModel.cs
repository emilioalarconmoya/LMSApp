namespace LMSApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using LMSApp.Common.Models;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;
    using LMSApp.Services;

    public class ActividadVigentesItemViewModel : ActividadVigente
    {
        #region atributos

        //private ApiService apiSerice;
        #endregion

        #region commands
        public ICommand SelectActividadVigenteCommand
        {
            get
            {
                return new RelayCommand(SelectUnidadActividad);
            }
        }

        private async void SelectUnidadActividad()
        {
            //ActividadVigentesViewModel actividadVigentesViewModel = new ActividadVigentesViewModel(this);
            Application.Current.Properties["CodActividadUsuario"] = this.CodActividadUsuario;
            MainViewModel.GetInstance().UnidadesActividades = new UnidadActividadesViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new UnidadActividadesPage()));
        }
        #endregion
    }
}
