using Microsoft.AspNetCore.SignalR;

namespace Servidor.Hubs
{
    public class JuegoHub : Hub
    {
        /// <summary>
        /// metodo que sera llamado desde cliente cuando los clientes esten listos y llamara al metodo del cliente que cargue la casilla verde
        /// </summary>
        /// <returns></returns>
        public async Task IniciarJuego()
        {
            await Clients.
        }
    }
}
