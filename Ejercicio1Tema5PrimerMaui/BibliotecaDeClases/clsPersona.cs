namespace BibliotecaDeClases
{
    public class clsPersona
     {
        #region atributos
        private String nombre;
        private String apellidos;
        #endregion

        #region constructores
        public clsPersona() { 
            nombre = "";
            apellidos = "";
        }
        public clsPersona(String nombres, String apellidos)
        {
            this.nombre = nombres;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public String Nombre {
            get { return nombre; }
            set {  nombre = value; }
        }

        public String Direccion { get; }


        public String NombreCompleto
        {
            get { return nombre + " " + apellidos; }
        }
        #endregion

        #region funciones
        /// <summary>
        /// Es una función que devuelve el nombre completo
        /// Precondiciones: El nombre y el apellido deben de empezar por mayuscula
        /// Poscondiciones: Ninguna
        /// </summary>
        /// <returns>String con nombre y apellidos completo</returns>
        public String FuncionNombreCompleto()
        {
            return $"El nombre completo es {nombre} {apellidos}";
        }
        #endregion
    }
}