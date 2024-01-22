using Microsoft.AspNetCore.SignalR;
using Models;

namespace ServidorSignalIR.Hubs
{
    public class ChatHubSelector : Hub
    {
        //clase modificada del tuto que pasara el string de la sala al servidor (por lo que esto "es el servidor" o al menos su comportamiento),
        //usar esta parte EnviarMensajesAClientes se usa para enviar mensajes a todos los clientes 
        //usar esta parte GoToChat hacer que el cliente navege a la sala de chat (endpoint especificado en program y url VM)
        public async Task EnviarMensajesAClientes(string salaChat)
        {
            await Clients.All.SendAsync("GoToChat", salaChat);//esto es como mostrar mensajes, se llama al gotochat del servidor (esta linea)
            //desde el cliente cuando pulse el boton de ir a chat despues de introducir el string, usar el string para navegar a una u otra sala
            
        }
    }
}
