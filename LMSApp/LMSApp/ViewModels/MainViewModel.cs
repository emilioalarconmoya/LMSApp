using System;
using System.Collections.ObjectModel;

namespace LMSApp.ViewModels
{
    public class MainViewModel
    {
        #region views
        public LoginViewModel Login { get; set; }
        public ActividadVigentesViewModel ActividadVigentes { get; set; }
        public HistorialAlumnosViewModel HistorialAlumnos { get; set; }
        public UnidadActividadesViewModel UnidadesActividades { get; set; }
        public ContendorUamsViewModel ContendorUams { get; set; }
        //public EvaluacionViewModel Evaluaciones { get; set; }
        public EncuestaViewModel Encuestas { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        #endregion


        public MainViewModel()
        {
            instance = this;
            this.LoadMenu();
            this.Login = new LoginViewModel();
        }

        #region metodos
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            this.Menu.Add(new MenuItemViewModel
            {
                Icono = "ic_home",
                Titulo="Inicio",
                Pagina= "ActividadVigentesPage",
            });

            this.Menu.Add(new MenuItemViewModel
            {
                Icono = "ic_history",
                Titulo = "Historial",
                Pagina = "HistorialAlumnoPage",
            });

            this.Menu.Add(new MenuItemViewModel
            {
                Icono = "ic_exit_to_app",
                Titulo = "Cerrar Sesión",
                Pagina = "LoginPage",
            });
        }
        #endregion

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
