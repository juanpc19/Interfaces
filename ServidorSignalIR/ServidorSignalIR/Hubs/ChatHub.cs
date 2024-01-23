using Microsoft.AspNetCore.SignalR;
using Models;

namespace ServidorSignalIR.Hubs
{
    public class ChatHub : Hub
    {
        //clase modificada del tuto que pasara los clsMensajeUsuario a los clientes (por lo que esto "es el servidor" o al menos su comportamiento),
        //usar esta parte EnviarMensajesAClientes se usa para enviar mensajes a todos los clientes 
        //usar esta parte MuestraMensaje para mostrar el mensaje en el cliente
        public async Task EnviarMensajesAClientes(clsMensajeUsuario oMensajePersona)
        {
            await Clients.All.SendAsync("MuestraMensaje", oMensajePersona);
        }
            
        public async Task GoToSala(string sala)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, sala);
        }
    }
}
