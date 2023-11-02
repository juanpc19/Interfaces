namespace LibreriaDeClases
{
    //en este ej va aqui o en entidades
    public class Persona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        #endregion

        #region constructores
        public Persona()
        {
            nombre = "";
            apellidos = "";
        }
        public Persona(string nombre, string apellidos)
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