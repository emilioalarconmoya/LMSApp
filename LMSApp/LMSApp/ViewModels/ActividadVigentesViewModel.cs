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
    using System.Linq;

    public class ActividadVigentesViewModel : BaseViewModel
    {

        private int rutUsuario = (int)Application.Current.Properties["RutUsuario"];
        private int codEmpresa = (int)Application.Current.Properties["CodEmpresa"];

        private ApiService apiService;

        private ObservableCollection<ActividadVigentesItemViewModel> actividadVigentes;


        private bool isRefreshing;
        private ActividadVigentesItemViewModel actividadVigentesItemViewModel;

        public ObservableCollection<ActividadVigentesItemViewModel> ActividadVigentes
        {
            get { return this.actividadVigentes; }
            set { this.SetValue(ref this.actividadVigentes, value); }

        }

        public ActividadVigentesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadActividadVigentes();
        }

        public ActividadVigentesViewModel(ActividadVigentesItemViewModel actividadVigentesItemViewModel)
        {
            this.actividadVigentesItemViewModel = actividadVigentesItemViewModel;
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

            //int rut = (int)Application.Current.Properties["RutUsuario"];
            var response = await this.apiService.GetList<ActividadVigente>(url, "/api", "/ActividadVigentes?RutUsuario=" + rutUsuario + "&DiasEspera=0&CodEmpresa=" + codEmpresa  + "&horaZona=-4");
            if(!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<ActividadVigente>)response.Result;
            this.ActividadVigentes = new ObservableCollection<ActividadVigentesItemViewModel>(this.ToActividadVigentesItemViewModel(list));
            this.IsRefreshing = false;
        }

        #region metodos
        private IEnumerable<ActividadVigentesItemViewModel> ToActividadVigentesItemViewModel(List<ActividadVigente> list)
        {
            return list.Select(x => new ActividadVigentesItemViewModel
            {
                CodActividadUsuario = x.CodActividadUsuario,
                CodActividad = x.CodActividad,
                Nombre = x.Nombre,
                Objetivos = x.Objetivos,
                Imagen = x.Imagen,
                FechaFin = x.FechaFin,
                FechaInicio = x.FechaInicio,
                CodTipo = x.CodTipo,
                CodEstado = x.CodEstado,
                Asistencia = x.Asistencia,
                Estado = x.Estado,
                Vigente = x.Vigente,
                NotaFinal = x.NotaFinal,
                MostrarCertificado = x.MostrarCertificado,
                ComunicaSence = x.ComunicaSence,
                FlagNuevaConexion = x.FlagNuevaConexion,
                RutTutor = x.RutTutor,
                CodActividadTutor = x.CodActividadTutor,
            });
        }
        #endregion

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadActividadVigentes);
            }
        }





    }
 }
