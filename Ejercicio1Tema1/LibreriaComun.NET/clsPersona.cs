namespace LibreriaComun.NET
{
    public class clsPersona
    {
        #region atributos
        private String nombres;
        private String apellidos;
        #endregion

        #region constructores
        public clsPersona() { 
            nombres = "";
            apellidos = "";
        }
        public clsPersona(String nombres, String apellidos)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public String Nombre {
            get { return nombres; }
            set {  nombres = value; }
        }

        public String Direccion { get; }


        public String NombreCompleto
        {
            get { return nombres + " " + apellidos; }
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
            return $"El nombre completo es {nombres} {apellidos}";
        }
        #endregion
    }
}