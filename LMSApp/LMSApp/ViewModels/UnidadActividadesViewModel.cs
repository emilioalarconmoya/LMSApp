using System;
using System.Collections.Generic;
using System.Text;

namespace LMSApp.ViewModels
{
    using LMSApp.Common;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Common.Models;
    using Xamarin.Forms;
    using System.Windows;
    using LMSApp.Services;
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;
    public class UnidadActividadesViewModel : BaseViewModel
    {

        #region atributos
        private ApiService apiService;
        private ObservableCollection<UnidadesActividad> unidadesActividades;
        private bool isRefreshing;
        private string filter;
        private List<UnidadesActividad> unidadesActividadList;
        private string nombreActividad;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private decimal notaAprobacion;
        private decimal asistencia;

        private int codActividadUsuario = (int)Application.Current.Properties["CodActividadUsuario"];
        #endregion

        #region Propiedades
        public ObservableCollection<UnidadesActividad> UnidadesActividades
        {
            get { return this.unidadesActividades; }
            set { this.SetValue(ref this.unidadesActividades, value); }

        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }

        public string NombreActividad
        {
            get { return this.nombreActividad; }
            set { this.SetValue(ref this.nombreActividad, value); }
        }

        public DateTime FechaInicio
        {
            get { return this.fechaInicio; }
            set { this.SetValue(ref this.fechaInicio, value); }
        }

        public DateTime FechaFin
        {
            get { return this.fechaFin; }
            set { this.SetValue(ref this.fechaFin, value); }
        }

        public decimal NotaAprobacion
        {
            get { return this.notaAprobacion; }
            set { this.SetValue(ref this.notaAprobacion, value); }
        }

        public decimal Asistencia
        {
            get { return this.asistencia; }
            set { this.SetValue(ref this.asistencia, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.SetValue(ref this.filter, value);
                //this.Search();
            }

        }
        #endregion

        #region constructores

        public UnidadActividadesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadUnidades();
        }

        #endregion
        #region metodos
        private async void LoadUnidades()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSucces)
            {
                this.isRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml

            
            var response = await this.apiService.GetList<UnidadesActividad>(url, "/api", "/UnidadesActividades?codActividadUsuario=" + codActividadUsuario);
            if (!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            this.unidadesActividadList = (List<UnidadesActividad>)response.Result;
            this.UnidadesActividades = new ObservableCollection<UnidadesActividad>(this.unidadesActividadList);
            this.IsRefreshing = false;

            this.NombreActividad = this.UnidadesActividades[0].NombreActividad;
            this.FechaInicio = this.UnidadesActividades[0].FechaInicio;
            this.FechaFin = this.UnidadesActividades[0].FechaFin;
            this.NotaAprobacion = this.UnidadesActividades[0].NotaAprobacion;
            this.Asistencia = this.UnidadesActividades[0].Asistencia;
        }
        #endregion

        #region commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadUnidades);
            }
        }
        #endregion

    }
}
