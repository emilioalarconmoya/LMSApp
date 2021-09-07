namespace LMSApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using LMSApp.Common.Models;
    using LMSApp.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class HistorialAlumnosViewModel : BaseViewModel
    {
        #region atributos
        private ApiService apiService;
        private ObservableCollection<HistorialAlumno> historialAlumnos;
        private bool isRefreshing;
        private string filter;
        private List<HistorialAlumno> historialAlumnoList;
        #endregion

        #region Propiedades
        public ObservableCollection<HistorialAlumno> HistorialAlumnos
        {
            get { return this.historialAlumnos; }
            set { this.SetValue(ref this.historialAlumnos, value); }

        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }

        public string Filter
        {
            get { return this.filter; }
            set 
            { 
                this.SetValue(ref this.filter, value);
                this.Search();
            }

        }
        #endregion

        #region constructores

        public HistorialAlumnosViewModel()
        {
            this.apiService = new ApiService();
            this.LoadHistorialAlumnos();
        }

        #endregion
        #region metodos
        private async void LoadHistorialAlumnos()
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

            int rut = (int)Application.Current.Properties["RutUsuario"];
            var response = await this.apiService.GetList<HistorialAlumno>(url, "/api", "/HistorialAlumnoes?rutUsuario=" + rut);
            if (!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            this.historialAlumnoList = (List<HistorialAlumno>)response.Result;
            this.HistorialAlumnos = new ObservableCollection<HistorialAlumno>(this.historialAlumnoList);
            this.IsRefreshing = false;
        }
        #endregion

        #region commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadHistorialAlumnos);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.HistorialAlumnos = new ObservableCollection<HistorialAlumno>(this.historialAlumnoList);
            }
            else
            {
                this.HistorialAlumnos = new ObservableCollection<HistorialAlumno>(this.historialAlumnoList.Where(x => x.Nombre.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        #endregion

    }
}
