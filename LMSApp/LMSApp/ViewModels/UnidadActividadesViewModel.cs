﻿namespace LMSApp.ViewModels
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
    using System.Data;

    public class UnidadActividadesViewModel : BaseViewModel
    {

        #region atributos
        private ApiService apiService;
        private ObservableCollection<UnidadActividadesItemViewModel> unidadesActividadesItem;
        private List<UnidadesActividad> unidadesActividades;
        private bool isRefreshing;
        private string filter;
        //private List<UnidadesActividad> unidadesActividadList;
        private string nombreActividad;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private decimal notaAprobacion;
        private decimal asistencia;
        private string nombreImagen;
        private bool isEnable;

        private int codActividadUsuario = (int)Application.Current.Properties["CodActividadUsuario"];
        #endregion

        #region Propiedades
        public ObservableCollection<UnidadActividadesItemViewModel> UnidadesActividades
        {
            get { return this.unidadesActividadesItem; }
            set { this.SetValue(ref this.unidadesActividadesItem, value); }

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

        public string NombreImagen
        {
            get { return this.nombreActividad; }
            set { this.SetValue(ref this.nombreActividad, value); }
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
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { this.SetValue(ref this.isEnable, value); }
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

            unidadesActividades = (List<UnidadesActividad>)response.Result;
            this.UnidadesActividades = new ObservableCollection<UnidadActividadesItemViewModel>(this.ToUnidadActividadesItemViewModel(unidadesActividades));
            this.IsRefreshing = false;

            this.NombreActividad = this.unidadesActividades[0].NombreActividad;
            this.FechaInicio = this.unidadesActividades[0].FechaInicio;
            this.FechaFin = this.unidadesActividades[0].FechaFin;
            this.NotaAprobacion = this.unidadesActividades[0].NotaAprobacion;
            this.Asistencia = this.unidadesActividades[0].Asistencia;

            //for (int i = 0; i < UnidadesActividades.Count; i++)
            //{

            //    DataTable dtUnidades = 
            //    //if(UnidadesActividades[i].NivelPrerequisito !=0)
            //    //{
            //    //    if(UnidadesActividades[i].OrdenRelativo == UnidadesActividades[i].NivelPrerequisito)
            //    //    {

            //    //    }
            //    //}
            //    //else
            //    //{

            //    //}
            //}

            


        }

        private IEnumerable<UnidadActividadesItemViewModel> ToUnidadActividadesItemViewModel(List<UnidadesActividad> list)
        {
            return list.Select(x => new UnidadActividadesItemViewModel
            {
                CodActividadUsuario = x.CodActividadUsuario,
                CodUnidad = x.CodUnidad,
                Nombre = x.Nombre,
                OrdenRelativo = x.OrdenRelativo,
                NivelPrerequisito = x.NivelPrerequisito,
                AvisaTermino = x.AvisaTermino,
                CodTipoUnidad = x.CodTipoUnidad,
                Archivo = x.Archivo,
                NumeroVisitas = x.NumeroVisitas,
                TiempoConexion = x.TiempoConexion,
                UltimaVisita = x.UltimaVisita,
                Terminada = x.Terminada,
                IdForo = x.IdForo,
                TemasForos = x.TemasForos,
                Descripcion = x.Descripcion,
                NombreActividad = x.NombreActividad,
                FechaInicio = x.FechaInicio,
                FechaFin = x.FechaFin,
                NotaAprobacion = x.NotaAprobacion,
                Asistencia = x.Asistencia,
                FlagNuevaConexion = x.FlagNuevaConexion,
                RutOtec = x.RutOtec,
                Token = x.Token,
                RutUsuario = x.RutUsuario,
                IdRegistroSence = x.IdRegistroSence,
                FlagActivo = x.FlagActivo,
                FechaHora = x.FechaHora,
                CodActividad = x.CodActividad,
                RutTutor = x.RutTutor,
                CodActividadTutor = x.CodActividadTutor,
                NotaFinal = x.NotaFinal,
                FlagEstadoAprobacion = x.FlagEstadoAprobacion,
                Mensaje = x.Mensaje,
                Nivel = x.Nivel,
                MinutosEvaluacion = x.MinutosEvaluacion,
            });
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
