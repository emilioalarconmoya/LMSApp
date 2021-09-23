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
    using System.Data;
    using View;

    public class EvaluacionViewModel : BaseViewModel
    {
        #region atributos
        private ApiService apiService;
        private ObservableCollection<PreguntaUnidad> preguntaUnidads;
        //private List<UnidadesActividad> unidadesActividades;
        private bool isRefreshing;
        //private string filter;
        private List<PreguntaUnidad> preguntaUnidadList;
        //private string nombreActividad;
        //private DateTime fechaInicio;
        //private DateTime fechaFin;
        //private decimal notaAprobacion;
        //private decimal asistencia;
        //private string nombreImagen;
        //private bool isEnable;

        private int codUnidad = (int)Application.Current.Properties["CodUnidad"];
        #endregion

        #region propiedades
        public ObservableCollection<PreguntaUnidad> PreguntaUnidads
        {
            get { return this.preguntaUnidads; }
            set { this.SetValue(ref this.preguntaUnidads, value); }

        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }

        #endregion

        #region constructores

        public EvaluacionViewModel()
        {
            this.apiService = new ApiService();
            this.LoadEvaluacion();
        }

        #endregion

        #region metodos
        public async void LoadEvaluacion()
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


            var response = await this.apiService.GetList<PreguntaUnidad>(url, "/api", "/PreguntaUnidads?codUnidad=" + codUnidad);
            if (!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            preguntaUnidadList = (List<PreguntaUnidad>)response.Result;

            for (int i = 0; i < preguntaUnidadList.Count; i++)
            {
                var responsePregunta = await this.apiService.GetList<Pregunta>(url, "/api", "/Preguntas?codPregunta=" + preguntaUnidadList[i].CodPregunta);
                preguntaUnidadList[i].Pregunta = (List<Pregunta>)responsePregunta.Result;
                                
                var responseAlternativa = await this.apiService.GetList<Alternativa>(url, "/api", "/Alternativas?codPregunta=" + preguntaUnidadList[i].CodPregunta);
                preguntaUnidadList[i].Pregunta[0].Alternativa = (List<Alternativa>)responseAlternativa.Result;

            }
            
            this.PreguntaUnidads = new ObservableCollection<PreguntaUnidad>(preguntaUnidadList);
            this.IsRefreshing = false;

            
            

            //this.NombreActividad = this.unidadesActividades[0].NombreActividad;
            //this.FechaInicio = this.unidadesActividades[0].FechaInicio;
            //this.FechaFin = this.unidadesActividades[0].FechaFin;
            //this.NotaAprobacion = this.unidadesActividades[0].NotaAprobacion;
            //this.Asistencia = this.unidadesActividades[0].Asistencia;

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

        //private IEnumerable<UnidadActividadesItemViewModel> ToUnidadActividadesItemViewModel(List<UnidadesActividad> list)
        //{
        //    return list.Select(x => new UnidadActividadesItemViewModel
        //    {
        //        CodActividadUsuario = x.CodActividadUsuario,
        //        CodUnidad = x.CodUnidad,
        //        Nombre = x.Nombre,
        //        OrdenRelativo = x.OrdenRelativo,
        //        NivelPrerequisito = x.NivelPrerequisito,
        //        AvisaTermino = x.AvisaTermino,
        //        CodTipoUnidad = x.CodTipoUnidad,
        //        Archivo = x.Archivo,
        //        NumeroVisitas = x.NumeroVisitas,
        //        TiempoConexion = x.TiempoConexion,
        //        UltimaVisita = x.UltimaVisita,
        //        Terminada = x.Terminada,
        //        IdForo = x.IdForo,
        //        TemasForos = x.TemasForos,
        //        Descripcion = x.Descripcion,
        //        NombreActividad = x.NombreActividad,
        //        FechaInicio = x.FechaInicio,
        //        FechaFin = x.FechaFin,
        //        NotaAprobacion = x.NotaAprobacion,
        //        Asistencia = x.Asistencia,
        //        FlagNuevaConexion = x.FlagNuevaConexion,
        //        RutOtec = x.RutOtec,
        //        Token = x.Token,
        //        RutUsuario = x.RutUsuario,
        //        IdRegistroSence = x.IdRegistroSence,
        //        FlagActivo = x.FlagActivo,
        //        FechaHora = x.FechaHora,
        //        CodActividad = x.CodActividad,
        //        RutTutor = x.RutTutor,
        //        CodActividadTutor = x.CodActividadTutor,
        //        NotaFinal = x.NotaFinal,
        //        FlagEstadoAprobacion = x.FlagEstadoAprobacion,
        //        Mensaje = x.Mensaje,
        //        Nivel = x.Nivel,
        //        MinutosEvaluacion = x.MinutosEvaluacion,
        //    });
        //}
        #endregion

    }
}
