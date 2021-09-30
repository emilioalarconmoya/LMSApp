using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LMSApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContenedorUam : ContentPage
	{
		public ContenedorUam ()
		{
			InitializeComponent ();
			
		}
		protected override bool OnBackButtonPressed()
		{
			DisplayAlert("alerta", "funciona", "aceptar");
			return true;
		}
	}
}