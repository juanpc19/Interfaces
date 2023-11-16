using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BibliotecaDeClases
{
	public class clsPersona 
	{
	#region atributos

	    private string nombre;
        private string apellidos;
		

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
            set { nombre = value; }
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

		#region funciones
	 

		#endregion
	}
}