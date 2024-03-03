using Microsoft.AspNetCore.SignalR;

namespace Servidor.Hubs
{
    public class JuegoHub : Hub
    {
        /// <summary>
        /// metodo que sera llamado desde cliente cuando el cliente este listo para jugar,
        /// desde aqui mando peticion de activar comprueba jugadores en el cliente que lo ha llamado para que haga check de la cantidad de jugadores,
        /// si esta es igual a 2 empieza el juego lo que llamara a metodo empezar partida del servidor
        /// </summary>
        /// <returns></returns>
        public async Task JugadorPreparado()
        {
            await Clients.All.SendAsync("CompruebaJugadores");//ordena a todos los clientes a que comprueben la cantidad de jugadores
        }

        /// <summary>
        /// cambiara casilla activada de forma aleatoria pasandole un int random a todos los clientes
        /// </summary>
        /// <returns></returns>
        public async Task SiguienteRonda()
        {
            // instancia de Random
            Random random = new Random();

            // genera numero random entre 0 y 8
            int index = random.Next(0, 9);

            // envia el numero random a todos los clientes para que activen la casilla con el metodo ActivaCasillaAleatoria
            await Clients.All.SendAsync("ActivaCasillaAleatoria", index);
        }

        /// <summary>
        /// recibe el numero de rondas que lleva el cliente que pulsa boton y lo envia a todos los demas clientes 
        /// </summary>
        /// <param name="rondas"></param>
        /// <returns></returns>
        public async Task ClientePulsaBoton(int rondas)
        {
            await Clients.All.SendAsync("RefrescaRondas", rondas);
        }
        /// <summary>
        /// //recibe lista de jugadores de cliente que pulsa boton por ultima vez con los datos de este y los envia a todos los demas clientes
        /// </summary>
        /// <param name="listaJugadoresPuntos"></param>
        /// <returns></returns>
        public async Task FinalizarPartida(Dictionary<string, int> listaJugadoresPuntos)
        {
            //los demas clientes reciben la lista de jugadores y puntos y ponen sus datos
            await Clients.Others.SendAsync("AnotaPuntuacion", listaJugadoresPuntos);
        }
        /// <summary>
        /// metodo que recibe la lista de jugadores y puntos final de cliente que pulsa suma 2 jugadores y la envia a todos los clientes para que muestren al ganador
        /// </summary>
        /// <param name="listaJugadoresPuntos"></param>
        /// <returns></returns>
        public async Task ComparteListaFinal(Dictionary<string, int> listaJugadoresPuntos)
        {
            await Clients.All.SendAsync("MuestraGanador", listaJugadoresPuntos);
        }
    }
}
