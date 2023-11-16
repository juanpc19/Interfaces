using BibliotecaDeClases;
using Ej3Tema9MVVM.Views.ViewModel;

namespace Ej3Tema9MVVM
{
	public partial class MainPage : ContentPage
	{
		

		public MainPage()
		{
			InitializeComponent();
			//hago que el binding context provenga de clsModificaPersona que recibe una clsPersona
			//que tendra valores por defecto en el constructor con mi nombre y apellidos,
			//el INotifyPropertyChanged sera implementado en clsModificaPersona
			BindingContext = new clsModificaPersona(new clsPersona {});
		}

		
	}
}