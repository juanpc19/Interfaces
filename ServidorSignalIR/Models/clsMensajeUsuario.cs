using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    //ANOTE AQUI TODO LO REFERNTE AL EJ
    //https://www.youtube.com/watch?v=pDr0Hx67guk
    //https://learn.microsoft.com/es-es/aspnet/core/tutorials/signalr?view=aspnetcore-7.0&tabs=visual-studio
    //ChatVM y MainPage (Maui), ChatHub (Servidor) y program para añadir hubs, chat.js en wwwroot para cliente js/html Index, clsMensajeUsuario (Models)
    //
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
