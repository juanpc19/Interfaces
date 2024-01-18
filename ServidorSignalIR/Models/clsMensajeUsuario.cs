using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class clsMensajeUsuario
    {
       
        private string nombreUsuario;
        
        private string mensajeUsuario;

        public clsMensajeUsuario()
        {
            nombreUsuario = string.Empty;
            mensajeUsuario = string.Empty;
        }

        public clsMensajeUsuario(string nombre, string mensaje)
        {
            this.nombreUsuario = nombre;
            this.mensajeUsuario = mensaje;
        }

        [JsonPropertyName("NombreUsuario")]
        public string NombreUsuario { get {  return this.nombreUsuario; } set {  this.nombreUsuario = value;} }

        [JsonPropertyName("MensajeUsuario")]
        public string MensajeUsuario { get { return this.mensajeUsuario;} set { this.mensajeUsuario = value;} }
    }
}
