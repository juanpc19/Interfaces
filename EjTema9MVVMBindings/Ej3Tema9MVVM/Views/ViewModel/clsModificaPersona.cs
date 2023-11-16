using BibliotecaDeClases;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Ej3Tema9MVVM.Views.ViewModel
{
	
	public class clsModificaPersona : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		private string nombre;

		private string apellidos;

		public clsModificaPersona(clsPersona persona)
		{
			nombre = persona.Nombre;
			apellidos = persona.Apellidos;
		}	
		//modifico nombres de propiedad de clsModificaPersona a NombreM para claridad
		public string NombreM
		{
			get { return nombre; }
			set { nombre = value; OnPropertyChanged(); }
		}

		public string ApellidosM
		{
			get { return apellidos; }
			set { apellidos = value; OnPropertyChanged(); }
		}

		public void OnPropertyChanged([CallerMemberName] string nombre = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		}
	}

}
