namespace LMSApp.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Common.Models;
    using Xamarin.Forms;
    using System.Windows;
    using LMSApp.Services;
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class ActividadVigentesViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<ActividadVigente> actividadVigentes;


        private bool isRefreshing;

        public ObservableCollection<ActividadVigente> ActividadVigentes
        {
            get { return this.actividadVigentes; }
            set { this.SetValue(ref this.actividadVigentes, value); }

        }

        public ActividadVigentesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadActividadVigentes();
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }

        private async void LoadActividadVigentes()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSucces)
            {
                this.isRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml


            var response = await this.apiService.GetList<ActividadVigente>(url, "/api", "/ActividadVigentes?RutUsuario=100&DiasEspera=0&CodEmpresa=1&horaZona=-4");
            if(!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<ActividadVigente>)response.Result;
            this.ActividadVigentes = new ObservableCollection<ActividadVigente>(list);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadActividadVigentes);
            }
        }





    }
 }
