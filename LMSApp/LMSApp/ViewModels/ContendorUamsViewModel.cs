using GalaSoft.MvvmLight.Command;
using LMSApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LMSApp.ViewModels
{
    public class ContendorUamsViewModel : BaseViewModel
    {
        #region Atributos
        private ApiService apiService;
        private bool isRefreshing;
        private string rutaUam;
        private int codEmpresa = (int)Application.Current.Properties["CodEmpresa"];
        private int codUnidad = (int)Application.Current.Properties["CodUnidad"];
        private string archivo = (string)Application.Current.Properties["Archivo"];
        #endregion

        #region propiedades
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }

        public string RutaUam
        {
            get { return this.rutaUam; }
            set { this.SetValue(ref this.rutaUam, value); }

        }
        #endregion

        #region constructores

        public ContendorUamsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadUnidades();
        }

        #endregion
        #region metodos
        private  void LoadUnidades()
        {
            this.IsRefreshing = true;
            this.RutaUam = "https://g5lmsme.academiag5.cl/contenidos/Emp" + codEmpresa + "/uams/" + codUnidad + "/" + archivo;
        }

        
        #endregion

        #region commands
        //public ICommand RefreshCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(LoadUnidades);
        //    }
        //}
        #endregion
    }
}
