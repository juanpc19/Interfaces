using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BibliotecaDeClases
{
	public class clsPersona 
	{
	#region atributos

	    private string nombre;
        private string apellidos;
        private string fechaNac;
        private string foto;
        private string direccion;
        private int telefono;
        #endregion

        #region constructores
        public clsPersona()
        {     
            nombre = "Javier";
            apellidos = "Pérez Caballero";   
        }

        public clsPersona(string nombre, string apellidos, string fechaNac, string foto, string direccion, int telefono)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.foto = foto;
            this.direccion = direccion;
            this.telefono = telefono;
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

        public string FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }


        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }


        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
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