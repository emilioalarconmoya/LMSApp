namespace LMSApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using View;
    using LMSApp.Services;
    using LMSApp.Common.Models;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    public class LoginViewModel : BaseViewModel
    {
        #region atributos
        private string usuarioName;
        private string password;
        private bool isRunning;
        private bool isEnable;
        private ApiService apiService;
        private bool isRefreshing;
        private ObservableCollection<Usuario> usuario;
        #endregion

        #region propiedades
        public ObservableCollection<Usuario> Usuario
        {
            get { return this.usuario; }
            set { this.SetValue(ref this.usuario, value); }

        }

        public string UsuarioName
        {
            get { return this.usuarioName; }
            set { SetValue(ref this.usuarioName, value); }
        }
        public string Password 
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemenbered { get; set; }
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }

        #endregion

        #region constructores

        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRemenbered = true;
            this.IsEnable = true;
        }
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }

        public async void Login()
        {
            if(string.IsNullOrEmpty(this.usuarioName))
            {
                await Application.Current.MainPage.DisplayAlert("Atención", "Debe Ingresar el nombre usuario.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Atención", "Debe Ingresar la contraseña", "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnable = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSucces)
            {
                this.isRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
                this.IsEnable = true;
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            //la validacion de conexion a internet tambien permite que demore un poco para poder cargar las keys que se encuentran en el App.xaml


            var response = await this.apiService.GetList<Usuario>(url, "/api", "/Usuarios?Rut=" + this.usuarioName.Trim());
            if (!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<Usuario>)response.Result;
            this.Usuario = new ObservableCollection<Usuario>(list);
            this.IsRefreshing = false;



            if (this.Usuario[0].RutUsuario != Utiles.RutUsrALng(usuarioName.Trim()) || Utiles.Encriptar(this.Password) != this.Usuario[0].Password.Trim())
            {
                this.IsRunning = false;
                this.IsEnable = true;

                await Application.Current.MainPage.DisplayAlert("Atención", "Usuario o contraseña incorrecto.", "Aceptar");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnable = true;

            this.UsuarioName = string.Empty;
            this.Password = string.Empty;

            Application.Current.Properties["RutUsuario"] = this.Usuario[0].RutUsuario;
            Application.Current.Properties["CodEmpresa"] = this.Usuario[0].CodEmpresa;

            //MainViewModel.GetInstance().HistorialAlumnos = new HistorialAlumnosViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new HistorialAlumnoPage()));
            MainViewModel.GetInstance().ActividadVigentes = new ActividadVigentesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ActividadVigentesPage()));
        }

        #endregion

    }
}
