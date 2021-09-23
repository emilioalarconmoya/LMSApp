namespace LMSApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using LMSApp.Common;
    using LMSApp.View;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class UnidadActividadesItemViewModel : UnidadesActividad
    {
        public ICommand SelectUnidadCommand
        {
            get
            {
                return new RelayCommand(SelectUnidad);
            }
        }

        private async void SelectUnidad()
        {
            Application.Current.Properties["CodUnidad"] = this.CodUnidad;
            if (this.CodTipoUnidad == 1)
            {
                MainViewModel.GetInstance().ContendorUams = new ContendorUamsViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ContenedorUam()));
            }
            else if(this.CodTipoUnidad == 2)
            {
                //MainViewModel.GetInstance().Evaluaciones = new EvaluacionViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new Evaluacion()));
            }
            else if (this.CodTipoUnidad == 3)
            {
                MainViewModel.GetInstance().Encuestas = new EncuestaViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new Encuesta()));
            }

        }
    }
}
