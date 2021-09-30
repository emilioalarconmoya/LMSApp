namespace LMSApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using LMSApp.Common;
    using LMSApp.Common.Models;
    using LMSApp.Services;
    using LMSApp.View;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Windows.Input;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class UnidadActividadesItemViewModel : UnidadesActividad
    {
        private ApiService apiService;
        private List<ActividadUsuario> actividadUsuarioList;
        private int codEmpresa = (int)Application.Current.Properties["CodEmpresa"];
        private List<DatoUltimoLogConexion> datoUltimoLogConexionsList;
        public ICommand SelectUnidadCommand
        {
            get
            {
                return new RelayCommand(SelectUnidad);
            }
        }

        private async void SelectUnidad()
        {
            this.apiService = new ApiService();
            Application.Current.Properties["CodUnidad"] = this.CodUnidad;
            Application.Current.Properties["Archivo"] = this.Archivo;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml

            //actividad usuario
            var ResponseActividadUsuario = await this.apiService.GetList<ActividadUsuario>(url, "/api", "/ActividadUsuarios?codActividadUsuario=" + this.CodActividadUsuario);
            if (!ResponseActividadUsuario.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ResponseActividadUsuario.Message, "Aceptar");
                return;
            }
            actividadUsuarioList = (List<ActividadUsuario>)ResponseActividadUsuario.Result;

            if (actividadUsuarioList[0].FlagComunicaSence)
            {
                
            }
            else
            {
                LogConexion logConexion = new LogConexion()
                {
                    CodActividadUsuario = this.CodActividadUsuario,
                    CodUnidad = this.CodUnidad,
                    Inicio = DateTime.Now,
                    Fin = DateTime.Now.AddMinutes(3),
                    Dispositivo = DeviceInfo.Platform.ToString(),
                    Browser = "App",
                };

                string hostName = Dns.GetHostName(); //obtengo el nombre del host
                string LocationIP = Dns.GetHostAddresses(hostName).GetValue(1).ToString(); //obtengo la ip
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        LocationIP = ip.ToString();// esta es nuestra ip
                        break;
                    }
                }
                logConexion.Ip = LocationIP;

                //datosLogConexion
                var ResponeseDatosLogConexion = await this.apiService.GetList<DatoUltimoLogConexion>(url, "/api", "/DatoUltimoLogConexions?codActividadUsuario=" + this.CodActividadUsuario + "&codUnidad=" + this.CodUnidad + "&codEmpresa=" + codEmpresa);
                if (!ResponeseDatosLogConexion.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ResponeseDatosLogConexion.Message, "Aceptar");
                    return;
                }
                datoUltimoLogConexionsList = (List<DatoUltimoLogConexion>)ResponeseDatosLogConexion.Result;

                if(datoUltimoLogConexionsList.Count>0)
                {
                    logConexion.FlagTerminada = datoUltimoLogConexionsList[0].FlagTerminada;
                    logConexion.TiempoRestanteSegunto = datoUltimoLogConexionsList[0].TiempoRestanteSegundo;
                    logConexion.PasoUltimaVisita = datoUltimoLogConexionsList[0].PasoUltimaVisita;
                    logConexion.Cerrada = false;
                }
                else
                {
                    logConexion.FlagTerminada = false;
                    logConexion.TiempoRestanteSegunto = 0;
                    logConexion.PasoUltimaVisita = 0;
                    logConexion.Cerrada = false;
                }
                if (!this.AvisaTermino)
                {
                    logConexion.FlagTerminada = true;
                }
                logConexion.CodEmpresa = codEmpresa;

                var response = await this.apiService.Post(url, "/api", "/LogConexions", logConexion);
            }

            if (this.CodTipoUnidad == 1)
            {
                MainViewModel.GetInstance().ContendorUams = new ContendorUamsViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ContenedorUam()));
            }
            else if(this.CodTipoUnidad == 2)
            {
                //MainViewModel.GetInstance().Evaluaciones = new EvaluacionViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LMSApp.View.Evaluacion()));
            }
            else if (this.CodTipoUnidad == 3)
            {
                MainViewModel.GetInstance().Encuestas = new EncuestaViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new Encuesta()));
            }

        }
    }
}
