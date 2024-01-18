using Microsoft.AspNetCore.SignalR;
using Models;

namespace MauiSignalR.ViewModels.Utilidades
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario oMensajePersona)
        {
            await Clients.All.SendAsync("ReceiveMessage", oMensajePersona);
        }
    }
}
