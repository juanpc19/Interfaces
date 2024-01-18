using Microsoft.AspNetCore.SignalR;
using Models;

namespace ServidorSignalIR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario oMensajePersona)
        {
            await Clients.All.SendAsync("ReceiveMessage", oMensajePersona);
        }
    }
}
