namespace LMSApp.ViewModels
{
    public class MainViewModel
    {
        #region views
        public LoginViewModel Login { get; set; }
        public ActividadVigentesViewModel ActividadVigentes { get; set; }

        public HistorialAlumnosViewModel HistorialAlumnos { get; set; }
        #endregion


        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
