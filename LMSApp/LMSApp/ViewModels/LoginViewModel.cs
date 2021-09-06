namespace LMSApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region eventos
       
        #endregion

        #region atributos
        private string password;
        private bool isRunning;
        private bool isEnable;
        #endregion

        #region propiedades
        public string Usuario { get; set; }
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

       

        public async void Login()
        {
            if(string.IsNullOrEmpty(this.Usuario))
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

            if(this.Usuario != "123456" || this.Password != "23456")
            {
                this.IsRunning = false;
                this.IsEnable = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos.", "Aceptar");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnable = true;

            await Application.Current.MainPage.DisplayAlert("Error", "Ingreso correcto", "Aceptar");
        }

        #endregion

    }
}
