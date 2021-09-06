namespace LMSApp.ViewModels
{
    public class MainViewModel
    {
        public ActividadVigentesViewModel ActividadVigentes { get; set; }

        public MainViewModel()
        {
            this.ActividadVigentes = new ActividadVigentesViewModel();
        }
    }
}
