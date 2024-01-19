using Microsoft.AspNetCore.SignalR;
using Models;

namespace ServidorSignalIR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task EnviarMensajesAClientes(clsMensajeUsuario oMensajePersona)
        {
            await Clients.All.SendAsync("MuestraMensaje", oMensajePersona);
        }
    }
}
