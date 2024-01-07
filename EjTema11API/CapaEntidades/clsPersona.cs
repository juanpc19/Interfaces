using System.ComponentModel.DataAnnotations;
namespace CapaEntidades

{
	public class clsPersona 
	{
        #region atributos
        private int id;
	    private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNac;
        private int idDepartamento;
        #endregion

        #region constructores
        public clsPersona()
        {     
            id= 0;
            nombre = "";
            apellidos = "";
            telefono = "";
            direccion = "";
            foto = "";
            fechaNac = DateTime.Now;
            idDepartamento= 0;
            
        }

        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNac, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNac = fechaNac;
            this.idDepartamento = idDepartamento;   
        }

        #endregion

        #region propiedades
        //[HiddenInput(DisplayValue=false)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Required(ErrorMessage = "El campo apellidos es obligatorio.")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        [StringLength(200, ErrorMessage = "El campo direccion debe ser menor a 200 caracteres")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }


        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        [DataType(DataType.Date, ErrorMessage = "Fecha nacimiento debe tener formato de fecha.")]
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        [Required(ErrorMessage = "El campo idDepartamento es obligatorio.")]
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
		#endregion

		#region funciones
	 

		#endregion
	}
}