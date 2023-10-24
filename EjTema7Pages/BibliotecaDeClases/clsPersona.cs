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
            nombre = "";
            apellidos = "";
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

        public string Direccion { get; }


        public string NombreCompleto
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
        public string FuncionNombreCompleto()
        {
            return $"El nombre completo es {nombre} {apellidos}";
        }
        #endregion
    }
}