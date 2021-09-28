namespace LMSApp.Console
{
    using LMSApp.Common.Models;
    using LMSApp.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xamarin.Forms;

    public class ConsolaMaster
    {
        private ApiService apiService;
        private List<ActividadUsuario> actividadUsuarioList;
        private List<ActividadCapac> actividadCapacsList;
        private List<Unidad> unidadList;
        private List<DatoUltimoLogConexion> datoUltimoLogConexionsList;
        public async void CierraLog(int codEmpresa, int codUnidad, int codActividadUsuario)
        {

            var connection = await this.apiService.CheckConnection();
            if (codUnidad != 0)
            {
                double NotaMin = 0.0;
                double NotaMax = 0.0;
                double NotaAprb = 0.0;
                double Exig = 0.0;
                int PuntajeTotal = 0;
                int PuntajeObtenido = 0;

                connection = await this.apiService.CheckConnection();
                if (!connection.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
                }

                var url = Application.Current.Resources["UrlAPI"].ToString();
                //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml

                //actividad usuario
                var ResponseActividadUsuario = await this.apiService.GetList<ActividadUsuario>(url, "/api", "/ActividadUsuarios?codActividadUsuario=" + codActividadUsuario);
                if (!ResponseActividadUsuario.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ResponseActividadUsuario.Message, "Aceptar");
                    return;
                }
                actividadUsuarioList = (List<ActividadUsuario>)ResponseActividadUsuario.Result;

                //actividad
                var ResponeseActividad = await this.apiService.GetList<ActividadCapac>(url, "/api", "/ActividadCapacs?codActividad=" + actividadUsuarioList[0].CodActividad);
                if (!ResponeseActividad.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ResponeseActividad.Message, "Aceptar");
                    return;
                }
                actividadCapacsList = (List<ActividadCapac>)ResponeseActividad.Result;

                //unidad
                var ResponseUnidad = await this.apiService.GetList<Unidad>(url, "/api", "/Unidads?codUnidad=" + codUnidad);
                if (!ResponseUnidad.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ResponseUnidad.Message, "Aceptar");
                    return;
                }
                unidadList = (List<Unidad>)ResponseUnidad.Result;


                NotaMin = Convert.ToDouble(actividadCapacsList[0].NotaMinima);
                NotaMax = Convert.ToDouble(actividadCapacsList[0].NotaMaxima);
                NotaAprb = Convert.ToDouble(actividadCapacsList[0].NotaAprobacion);
                Exig = Convert.ToDouble(actividadCapacsList[0].Exigencia); 
                if (unidadList[0].NumeroPreguntaAleatoria > 0)
                {
                    PuntajeTotal = (unidadList[0].NumeroPreguntaAleatoria * 10);
                }
                else
                {
                    PuntajeTotal = actividadUsuarioList[0].PuntajeMaximo;
                }

                PuntajeObtenido = actividadUsuarioList[0].PuntajeObtenido;

                //datosLogConexion
                var ResponeseDatosLogConexion = await this.apiService.GetList<DatoUltimoLogConexion>(url, "/api", "/DatoUltimoLogConexions?codActividadUsuario=" + codActividadUsuario + "&codUnidad=" + codUnidad + "&codEmpresa=" + codEmpresa);
                if (!ResponeseDatosLogConexion.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ResponeseDatosLogConexion.Message, "Aceptar");
                    return;
                }
                datoUltimoLogConexionsList = (List<DatoUltimoLogConexion>)ResponeseDatosLogConexion.Result;

                if(datoUltimoLogConexionsList.Count>0)
                {
                    //var response = await this.apiService.Post(url, "/api", "/DatoUltimoLogConexions", evaluacion);
                }
            }
        }
    }
}
