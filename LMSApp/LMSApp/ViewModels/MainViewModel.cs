namespace LMSApp.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public ActividadVigentesViewModel ActividadVigentes { get; set; }

        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
    }
}
