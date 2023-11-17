using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ej1Tema7.Models.Entidades
{
	public class clsPersona : INotifyPropertyChanged
	{
	#region atributos

	    private string nombre;
        private string apellidos;
        //el evento es obligatorio se lanza en cambio
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region constructores
		public clsPersona()
        {     
            nombre = "Juan";
            apellidos = "Pérez Caballero";   
        }

        public clsPersona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

       
		#endregion

		#region propiedades

			public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(); }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

     
        public string NombreCompleto
        {
            get { return nombre + " " + apellidos; }
        }
		#endregion

		#region metodos
        //metodo
		public void OnPropertyChanged([CallerMemberName] string nombre = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		}

		#endregion
	}
}