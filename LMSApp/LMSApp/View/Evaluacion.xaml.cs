namespace LMSApp.View
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	using LMSApp.ViewModels;
    using LMSApp.Services;
    using System.Collections.ObjectModel;
    using LMSApp.Common.Models;
    using LMSApp.Utiles;
    using LMSApp.Console;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Evaluacion : ContentPage
	{
        #region atributos
        private ApiService apiService;
        private List<PreguntaUnidad> preguntaUnidadList;
        private List<PreguntaEvaluada> preguntaEvaluadas;
        private List<ActividadUsuario> actividadUsuarioList;
        private List<Common.Models.Evaluacion> preguntaEvaluacion;
        private int codUnidad = (int)Application.Current.Properties["CodUnidad"];
        private int codActividadUsuario = (int)Application.Current.Properties["CodActividadUsuario"];
        private int codEmpresa = (int)Application.Current.Properties["CodEmpresa"];
        #endregion


        public Evaluacion ()
		{
			InitializeComponent();
			this.apiService = new ApiService();
			CargarEva();
		}
		private async void CargarEva()
        {
            var connection = await this.apiService.CheckConnection();
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


            var response = await this.apiService.GetList<PreguntaEvaluada>(url, "/api", "/PreguntaEvaluadas?codUnidad=" + codUnidad + "&codActividadUsaurio=" + codActividadUsuario + "&codEmpresa=" + codEmpresa);
            if (!response.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            preguntaEvaluadas = (List<PreguntaEvaluada>)response.Result;




            
            if(preguntaEvaluadas.Count>0)
            {
                for (int i = 0; i < preguntaEvaluadas.Count; i++)
                {
                    var responsePregunta = await this.apiService.GetList<Pregunta>(url, "/api", "/Preguntas?codPregunta=" + preguntaEvaluadas[i].CodPregunta);
                    preguntaEvaluadas[i].Pregunta = (List<Pregunta>)responsePregunta.Result;

                    var responseAlternativa = await this.apiService.GetList<Alternativa>(url, "/api", "/Alternativas?codPregunta=" + preguntaEvaluadas[i].CodPregunta);
                    preguntaEvaluadas[i].Pregunta[0].Alternativa = (List<Alternativa>)responseAlternativa.Result;

                }

                for (int i = 0; i < preguntaEvaluadas.Count; i++)
                {
                    var pregunta = new Label()
                    {
                        Text = preguntaEvaluadas[i].Pregunta[0].Texto,
                        Padding = new Thickness(5, 0, 5, 0)

                    };
                    var codPregunta = new Label()
                    {
                        Text = preguntaEvaluadas[i].Pregunta[0].CodPregunta.ToString(),
                        IsVisible = false


                    };
                    var codCorrecta = new Label()
                    {
                        Text = preguntaEvaluadas[i].Pregunta[0].CodCorrecta.ToString(),
                        IsVisible = false
                    };
                    contenedorPreguntas.Children.Add(pregunta);
                    contenedorPreguntas.Children.Add(codPregunta);

                    var responsePreguntaEvaluacion= await this.apiService.GetList<Common.Models.Evaluacion>(url, "/api", "/Evaluacions?codActividadUsaurio=" + codActividadUsuario + "&codUnidad=" + codUnidad + 
                                                                                            "&codPregunta=" + preguntaEvaluadas[i].Pregunta[0].CodPregunta + "&codEmpresa=" + codEmpresa);
                    preguntaEvaluacion = (List<Common.Models.Evaluacion>)responsePreguntaEvaluacion.Result;
                    var alternativa = new RadioButton();
                    for (int j = 0; j < preguntaEvaluadas[i].Pregunta[0].Alternativa.Count; j++)
                    {
                        alternativa = new RadioButton()
                        {
                            Content = preguntaEvaluadas[i].Pregunta[0].Alternativa[j].TextoAlternativa,
                            Value = (j + 1),
                            GroupName = (i + 1).ToString(),
                            IsEnabled = false

                        };
                        if (preguntaEvaluacion[0].TextoRespuesta == alternativa.Value.ToString())
                        {
                            alternativa.IsChecked = true;
                        }

                        contenedorPreguntas.Children.Add(alternativa);
                    }
                }
                await DisplayAlert("ATENCIÓN", "Has finalizado la evalución con nota: " + Math.Round(actividadUsuarioList[0].NotaFinal, 1).ToString(), "Aceptar");
            }
            else
            {
                connection = await this.apiService.CheckConnection();
                if (!connection.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
                }

                url = Application.Current.Resources["UrlAPI"].ToString();
                //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml


                response = await this.apiService.GetList<PreguntaUnidad>(url, "/api", "/PreguntaUnidads?codUnidad=" + codUnidad);
                if (!response.IsSucces)
                {
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
                for (int i = 0; i < preguntaUnidadList.Count; i++)
                {
                    var pregunta = new Label()
                    {
                        Text = preguntaUnidadList[i].Pregunta[0].Texto,
                        Padding = new Thickness(5, 0, 5, 0),
                        FontAttributes = FontAttributes.Bold,

                    };
                    var codPregunta = new Label()
                    {
                        Text = preguntaUnidadList[i].Pregunta[0].CodPregunta.ToString(),
                        IsVisible = false


                    };
                    var codCorrecta = new Label()
                    {
                        Text = preguntaUnidadList[i].Pregunta[0].CodCorrecta.ToString(),
                        IsVisible = false
                    };
                    contenedorPreguntas.Children.Add(pregunta);
                    contenedorPreguntas.Children.Add(codPregunta);
                    //contenedorPreguntas.Children.Add(codCorrecta);
                    //var stlAlternativas = new StackLayout();

                    var alternativa = new RadioButton();
                    for (int j = 0; j < preguntaUnidadList[i].Pregunta[0].Alternativa.Count; j++)
                    {
                        alternativa = new RadioButton()
                        {
                            Content = preguntaUnidadList[i].Pregunta[0].Alternativa[j].TextoAlternativa,
                            Value = (j + 1),
                            GroupName = (i + 1).ToString()

                        };

                        contenedorPreguntas.Children.Add(alternativa);
                    }
                }

                Button btnEnviar = new Button
                {
                    Text = "Enviar",
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.White,
                    BackgroundColor = Color.Navy,
                    FontSize = 10
                };
                btnEnviar.Clicked += (sende, args) =>
                {
                    Enviar();

                };

                contenedorPreguntas.Children.Add(btnEnviar);
            }
        }

        private async void Enviar()
        {
            try
            {
                var textcontenedorPreguntas = contenedorPreguntas.Children;
                var textcontenedoralternativas = contenedorPreguntas.Children;
                int contRadioButton = 0;
                int contTmp = 0;
                var url = Application.Current.Resources["UrlAPI"].ToString();
                //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml
                //bool salir;
                //BFPREGUNTAUNIDAD objBFPU = new BFPREGUNTAUNIDAD();
                //BFPREGUNTA objBFPR = new BFPREGUNTA();
                //DLPREGUNTA objDLPR = new DLPREGUNTA();
                //List<EPREGUNTAUNIDAD> objEPU = new List<EPREGUNTAUNIDAD>();
                List<Common.Models.Evaluacion> Listevaluacions = new List<Common.Models.Evaluacion>();
                //Common.Models.Evaluacion objEvaluacion = new Common.Models.Evaluacion();
                foreach (Xamarin.Forms.View viewPre in textcontenedorPreguntas.ToList())
                {
                    if (viewPre.GetType() == typeof(Xamarin.Forms.Label))
                    {
                        Label lb = (Label)viewPre;
                        if (FuncionesUtiles.IsValidInteger(lb.Text))
                        {
                            foreach (Xamarin.Forms.View viewAlt in textcontenedoralternativas.ToList())
                            {
                                if (viewAlt.GetType() == typeof(Xamarin.Forms.RadioButton))
                                {
                                    contRadioButton = contRadioButton++;
                                    RadioButton rbt = (RadioButton)viewAlt;
                                    if (rbt.IsChecked)
                                    {
                                        Common.Models.Evaluacion objEvaluacion = new Common.Models.Evaluacion();
                                        objEvaluacion.CodActividadUsuario = codActividadUsuario;
                                        objEvaluacion.CodPregunta = Convert.ToInt16(lb.Text);
                                        objEvaluacion.Codunidad = codUnidad;
                                        objEvaluacion.Comentarios = "";
                                        objEvaluacion.EstaIncluida = true;
                                        objEvaluacion.FechaHora = DateTime.Now;
                                        objEvaluacion.NumeroIntentos = 1;
                                        objEvaluacion.CodEmpresa = codEmpresa;
                                        objEvaluacion.AvisaTermino = true;
                                        List<PreguntaUnidad> preguntaUnidads = preguntaUnidadList.Where(x => x.CodUnidad == codUnidad).ToList();
                                        //objEPU = objBFPU.PreguntasUnidad(codUni);
                                        //var responseRespuesta = this.apiService.GetList<RespuestaCorrecta>(url, "/api", "/Preguntas?codPregunta=" + Convert.ToInt32(lb.Text)).ToString(); //objDLPR.RespuestaCorrecta(Convert.ToInt32(lb.Text)).ToString();
                                        //respuestaCorrecta = (List<RespuestaCorrecta>)responseRespuesta.re;
                                        var responseRespuesta = await this.apiService.GetList<RespuestaCorrecta>(url, "/api", "/RespuestaCorrectas?codPregunta=" + Convert.ToInt32(lb.Text)); //objDLPR.RespuestaCorrecta(Convert.ToInt32(lb.Text)).ToString();
                                        List<RespuestaCorrecta> respuestaCorrectas = (List<RespuestaCorrecta>)responseRespuesta.Result;
                                        string CodCorrecta = respuestaCorrectas[0].CodCorrecta.ToString();
                                        string Respuesta = rbt.Value.ToString();

                                        if (CodCorrecta == Respuesta)
                                        {
                                            objEvaluacion.Puntaje = preguntaUnidads[0].PuntajeMax;
                                        }
                                        else
                                        {
                                            objEvaluacion.Puntaje = 0;
                                        }
                                        objEvaluacion.TextoRespuesta = rbt.Value.ToString();
                                        Listevaluacions.Add(objEvaluacion);
                                        //objListEvaluacion.Add(objEvaluacion);
                                        break;

                                    }
                                    textcontenedoralternativas.Remove(viewAlt);

                                }
                                contTmp = contRadioButton;
                            }
                        }

                    }
                    textcontenedorPreguntas.Remove(viewPre);

                }
                bool blnTodasRespondidas = true;
                //BFEVALUACION objBFEvaluacion = new BFEVALUACION();
                foreach (Common.Models.Evaluacion obj in Listevaluacions)
                {
                    if (obj.TextoRespuesta == "")
                    {
                        blnTodasRespondidas = false;
                    }
                }
                if (blnTodasRespondidas == true)
                {
                    for (int i = 0; i < Listevaluacions.Count; i++)
                    {
                        Common.Models.Evaluacion evaluacion = Listevaluacions[i];
                        var response = await this.apiService.Post(url, "/api", "/Evaluacions", evaluacion);
                    }
                    //EEVALUACION objEvaluacion2 = new EEVALUACION();
                    //objEvaluacion2.CodActivUsr = codActUsr;
                    //objEvaluacion2.CodUnidad = codUni;
                    ////se eliminan las evlauciones para ingresarlas nuevamente.
                    //objBFEvaluacion.Delete(objEvaluacion2);
                    ////ingresamos la evalaucion
                    //objBFEvaluacion.GuardarEvaluacion(objListEvaluacion);

                    //BFLOGCONEXION objBFLogConexion = new BFLOGCONEXION();
                    //objBFLogConexion.SetTerminoUnidad(codActUsr, Convert.ToInt32(codUni), objSessionUsuario.CodEmpresa);

                    ////Session["EnEvalOEncues"] = "0";
                    ////if(Convert.ToInt16(ViewState["codEncuestaSatis"])>0)
                    ////{
                    ////    EnviarEncuesta();
                    ////}

                    ConsolaMaster objConsolaMaster = new ConsolaMaster();
                    objConsolaMaster.CierraLog(codEmpresa, codUnidad, codActividadUsuario);

                    CargarEva();
                }
                else
                {
                    CargarEva();
                    await Application.Current.MainPage.DisplayAlert("ATENCIÓN", "ATENCION: Debe contestar todas las preguntas.", "Aceptar");
                }


            }
            catch (Exception)
            {
                await DisplayAlert("ATENCIÓN", "El sistema ha presentado un inconveniente, favor intentar más tarde.", "Aceptar");
            }

        }

    }
}