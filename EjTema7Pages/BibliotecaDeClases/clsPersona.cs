namespace BibliotecaDeClases
{
    public class clsPersona
    {
        #region atributos
        private string nombres;
        private string apellidos;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombres = "";
            apellidos = "";
        }
        public clsPersona(string nombres, string apellidos)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public string Nombre
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string apellido
        {
            get { return apellidos; }
            set { apellido = value; }
        }

        public string Direccion { get; }


        public string NombreCompleto
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
        public string FuncionNombreCompleto()
        {
            return $"El nombre completo es {nombres} {apellidos}";
        }
        #endregion
    }
}