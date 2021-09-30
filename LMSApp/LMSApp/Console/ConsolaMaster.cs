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
            this.apiService = new ApiService();
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
                    LogConexion logConexion = new LogConexion()
                    {
                        CodActividadUsuario = codActividadUsuario,
                        CodUnidad = codUnidad,
                        Inicio = datoUltimoLogConexionsList[0].Inicio,
                        Fin = DateTime.Now,
                        FlagTerminada = datoUltimoLogConexionsList[0].FlagTerminada,
                        TiempoRestanteSegunto = datoUltimoLogConexionsList[0].TiempoRestanteSegundo,
                        PasoUltimaVisita = datoUltimoLogConexionsList[0].PasoUltimaVisita,
                        Cerrada = true,
                        CodEmpresa = codEmpresa,
                    };
                    var response = await this.apiService.Put(url, "/api", "/DatoUltimoLogConexions", logConexion);
                }

                if(actividadUsuarioList[0].CodEstado == 3)
                {
                    double Asistencia = CalculaAsistencia(actividadUsuarioList[0].TotalUnidades, actividadUsuarioList[0].UnidadesTerminadas);
                    double Nota = CalculaNota(NotaMin, NotaMax, NotaAprb, Exig, PuntajeTotal, PuntajeObtenido);

                    actividadUsuarioList[0].NotaFinal = Convert.ToDecimal(Nota);
                    if (Asistencia > 100)
                    {
                        Asistencia = 100;
                    }
                    actividadUsuarioList[0].Asistencia = Convert.ToDecimal(Asistencia);

                    if (Asistencia == 100)
                    {
                        actividadUsuarioList[0].CodEstado = 3;
                        actividadUsuarioList[0].FinReal = DateTime.Now;
                        actividadUsuarioList[0].HoraFinReal = DateTime.Now;
                        if (unidadList[0].CodTipoUnidad == 2) //si es evaluacion, mostrar mensaje de nota
                        {
                            if (Nota >= NotaAprb) //objActivUsr.NotaMinima'
                            {
                                actividadUsuarioList[0].FlagEstadoAprobacion = true;
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Nota", "alert('Has finalizado la actividad aprobando con nota: " + Math.Round(objActivUsr.NotaFinal, 2).ToString() + "');", true);
                            }
                            else
                            {
                                actividadUsuarioList[0].FlagEstadoAprobacion = false;
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Nota", "alert('Has finalizado la actividad reprobando con nota: " + Math.Round(objActivUsr.NotaFinal, 2).ToString() + "');", true);
                            }
                        }
                        else
                        {
                            if (Nota > 0)
                            {
                                if (Nota >= NotaAprb) //objActivUsr.NotaMinima'
                                {
                                    actividadUsuarioList[0].FlagEstadoAprobacion = true;
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Nota", "alert('Has finalizado la actividad aprobando con nota: " + Math.Round(objActivUsr.NotaFinal, 2).ToString() + "');", true);
                                }
                                else
                                {
                                    actividadUsuarioList[0].FlagEstadoAprobacion = false;
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Nota", "alert('Has finalizado la actividad reprobando con nota: " + Math.Round(objActivUsr.NotaFinal, 2).ToString() + "');", true);
                                }
                            }
                            else
                            {
                                actividadUsuarioList[0].FlagEstadoAprobacion = true;
                            }

                            //objActivUsr.FlagEstadoAprobacion = true;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Nota", "alert('Has finalizado la actividad.');", true);
                        }
                        //if (Convert.ToInt16(Session["codEncuestaSatis"]) > 0)
                        //{
                        //    CargarEncuesta();
                        //    if (!Convert.ToBoolean(ViewState["realizoEncuesta"]))
                        //    {
                        //        EnviarEncuesta();
                        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "$(function() { AbrirModalEncuesta(); });", true);
                        //    }

                        //}

                    }
                    var response = await this.apiService.Put(url, "/api", "/ActividadUsuarios", actividadUsuarioList[0]);
                }
            }
        }
        public static Double CalculaNota(Double NotaMin, Double NotaMax, Double NotaAprob, Double Exig, int PtjeTotal, int PtjeObtenido)
        {
            double Nota = 0.0;

            double PtjeExigido = PtjeTotal * (Exig / 100);

            if (PtjeObtenido < PtjeExigido)
            {
                Nota = ((NotaAprob - NotaMin) * (PtjeObtenido / ((Exig / 100) * PtjeTotal))) + NotaMin;
            }
            else
            {
                Nota = (NotaMax - NotaAprob) * ((PtjeObtenido - ((Exig / 100) * PtjeTotal)) / (PtjeTotal * (1 - (Exig / 100)))) + NotaAprob;
            }
            if (Double.IsNaN(Nota))
                Nota = 0;

            return Nota;
        }
        public static Double CalculaAsistencia(int TotalUnidades, int UnidadesTerminadas)
        {
            double Asistencia = 0.0;

            Asistencia = (UnidadesTerminadas * 100) / TotalUnidades;

            return Asistencia;
        }
    }
}
