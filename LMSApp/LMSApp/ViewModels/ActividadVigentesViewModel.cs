namespace LMSApp.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Common.Models;
    using Xamarin.Forms;
    using System.Windows;
    using LMSApp.Services;
    using System;

    public class ActividadVigentesViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<ActividadVigente> actividadVigentes;
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

        private async void LoadActividadVigentes()
        {
            var response = await this.apiService.GetList<ActividadVigente>("https://lmsappapi.azurewebsites.net", "/api", "/ActividadVigentes?RutUsuario=100&DiasEspera=0&CodEmpresa=1&horaZona=-4");
            if(!response.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<ActividadVigente>)response.Result;
            this.ActividadVigentes = new ObservableCollection<ActividadVigente>(list);
        }
            

    }
 }
