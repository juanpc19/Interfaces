using HueguitoSignalR.Models;
using HueguitoSignalR.ViewModels.Utilidades;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HueguitoSignalR.ViewModels
{
    //se ilumina de verde un boton a pulsar el cliente que lo pulsa primero anota punto y pide a servidor nuevo boton a pulsar
    //habra 9 botones, 20 puntos, 
    public class JuegoVM : clsVMBase
    {
        #region atributos
        private readonly HubConnection conexion;

        private string labelJugador;//contendra nombre de jugador proporcionado en pagina anterior
        private string labelGanador;//toma valor de "Has ganado" o "Has perdido" segun si el jugador es el ganador o no
        private int rondas;//guardara rondas, limite 11
        private int puntos;//guardara aciertos los que acierten

         
        private DelegateCommand botonPulsado; 
        private List<clsCasilla> listaCasillas;
        private clsCasilla casillaSeleccionada;
        private int ultimaCasillaActivada; //guarda el index de la ultima casilla activada en cliente para poder desactivarla cuando se active otra y no repetir casilla activada
        private bool rondaJugable;// permite o no pulsar boton bindeado a commad botonPulsado
        private Dictionary<string, int> listaJugadoresPuntos;//guarda puntos de jugadores y nombres de jugadores


        #endregion

        //cuando se pulse empezar juego llamar a metodo servidor k ponga una aleatoria a verde
        #region constructores
        public JuegoVM(string nombreJugador, HubConnection conexion)
        {
            this.conexion = conexion;//recibo conexion de pagina login
            labelJugador = nombreJugador;//recibo nombre de jugador de pagina login
            listaJugadoresPuntos = new Dictionary<string, int>();//creo diccionario para guardar puntos de jugadores

            botonPulsado = new DelegateCommand(BotonPulsadoCommandExecute, BotonPulsadoCommandCanExecute);
            conexion.On("CompruebaJugadores", CompruebaJugadores);
            conexion.On<int>("ActivaCasillaAleatoria", ActivaCasillaAleatoria);
            conexion.On<int>("RefrescaRondas", RefrescaRondas);
            conexion.On<Dictionary<string, int>>("AnotaPuntuacion", AnotaPuntuacion);
            conexion.On<Dictionary<string, int>>("MuestraGanador", MuestraGanador);
            CargaCasillasInicial(); //crea la lista de casillas que por defecto tendran imagenMostrada = casillaRoja
        }
        #endregion

        #region propiedades
        public string LabelJugador
        {
            get { return labelJugador; }
        }
        public string LabelGanador
        {
            get { return labelGanador; }
        }
        public int Rondas
        {
            get { return rondas; }
        }
        public int Puntos
        {
            get { return puntos; }
        }
        public clsCasilla CasillaSeleccionada
        {
            get { return casillaSeleccionada; }
            set { casillaSeleccionada = value; }
        }
        public List<clsCasilla> ListaCasillas
        {
            get { return listaCasillas; }
        }
        public DelegateCommand BotonPulsado
        {
            get { return botonPulsado; }
        }
        #endregion

        #region comandos
        /// <summary>
        /// devuelve true si ronda jugable es true y false si no, ronda jugable se pone a false cuando se pulsa un boton y a true cuando se activa una casilla aleatoria desde server
        /// </summary>
        /// <returns></returns>
        private bool BotonPulsadoCommandCanExecute()
        {
            return rondaJugable;
        }

        /// <summary>
        /// metodo que se activa al pulsar un boton, suma o resta puntos segun casilla pulsada sea verde o roja,
        /// modifica rondaJugable a false y notifica cambio de estado de command y procede a llamar a metodo de server ClientePulsaBoton
        /// </summary>
        private async void BotonPulsadoCommandExecute()
        {
            rondaJugable = false;//deshabilito command poniendo a false su ronda jugable del que depende su can execute
            botonPulsado.RaiseCanExecuteChanged();//notifico cambio de estado de command

            //sumo o resto puntos segun casilla pulsada sea verde o roja
            if (casillaSeleccionada.ImagenMostrada == "casilla_verde.png")
            {
                puntos = puntos + 1;
            }
            else
            {
                puntos = puntos - 1;
            }
            NotifyPropertyChanged("Puntos");

            await conexion.InvokeAsync("ClientePulsaBoton", rondas);

        }
        #endregion

        #region metodos server/client
        /// <summary>
        /// metodo que se activa a traves de JugadorPreparado en servidor, comprueba la cantidad de jugadores conectados a 
        /// la pantalla de juego al hacer k estos sumen +1 a jugadores y si esta es igual a 2 empieza el juego
        /// </summary>
        private async void CompruebaJugadores()
        {
            DatosPartida.jugadores = DatosPartida.jugadores + 1;//sumo uno por cada cliente conectado, como esta suma se da dentro de juego no cuenta cuando estan en login

            if (DatosPartida.jugadores == 2)
            {
                HubConnectionState estado = conexion.State;//para comprobar conexion
                await conexion.InvokeAsync("SiguienteRonda");//solicito a servidor  la siguiente ronda
            }
        }

        /// <summary>
        /// metodo que se activa a traves de EmpezarJuego en servidor, activa una casilla aleatoria, desactiva la activada previamente si la hubiese y pone rondaJugable a true
        /// </summary>
        /// <param name="index"></param>
        private void ActivaCasillaAleatoria(int index)
        {
            rondaJugable = true;//reactivo command poniendo a true ronda jugable del que depende su can execute
            botonPulsado.RaiseCanExecuteChanged();
            if (ultimaCasillaActivada == index)
            {
                if (index == 8)
                {
                    index = 0;
                }
                else if (index == 0)
                {
                    index = 8;
                }
            }
            listaCasillas[ultimaCasillaActivada].ImagenMostrada = "casilla_roja.png";
            listaCasillas[index].ImagenMostrada = "casilla_verde.png";
            ultimaCasillaActivada = index;
        }

        /// <summary>
        /// metodo que se activa a traves de ClientePulsaBoton en servidor(llamado desde el command en vm), refresca las rondas y si se llega a 11 finaliza partida
        /// </summary>
        /// <param name="rondas"></param>
        private async void RefrescaRondas(int rondas)
        {
            this.rondas = rondas+1;//aumento rondas
            NotifyPropertyChanged("Rondas");//notifico cambios en rondas

            //si se llaga a 11 rondas se finaliza partida y se comparte lista de jugadores y puntos desde cliente que pulsa boton por ultima vez
            if (this.rondas == 11)
            {
                rondaJugable = false;//deshabilito command poniendo a false su ronda jugable del que depende su can execute
                botonPulsado.RaiseCanExecuteChanged();
                listaJugadoresPuntos[conexion.ConnectionId] = puntos;//añado a diccionario de puntos el id de conexion y los puntos del jugador
                
                await conexion.InvokeAsync("FinalizarPartida", listaJugadoresPuntos);//llamo a metodo de servidor para que comparta lista de jugadores y puntos
            }
            else
            {
                await conexion.InvokeAsync("SiguienteRonda");
            }

        }

        /// <summary>
        /// metodo que se activa a traves de FinalizarPartida en servidor, recibe lista de jugadores de cliente que pulsa boton por ultima vez
        /// con los datos de este y los envia a todos los demas clientes para que añadan sus datos
        /// </summary>
        /// <param name="listaJugadoresPuntos"></param>
        private async void AnotaPuntuacion(Dictionary<string, int> listaJugadoresPuntos)
        {
            listaJugadoresPuntos[conexion.ConnectionId] = puntos;//añado a diccionario de puntos el id de conexion y los puntos del jugador

            if (listaJugadoresPuntos.Count == 2)
            {
                await conexion.InvokeAsync("ComparteListaFinal", listaJugadoresPuntos);
            }
        }
        /// <summary>
        /// metodo que se activa a traves de ComparteListaFinal en servidor, recibe lista de jugadores y puntos y muestra ganador
        /// </summary>
        /// <param name="listaJugadoresPuntos"></param>
        private void MuestraGanador(Dictionary<string, int> listaJugadoresPuntos)
        {
            int max = 0;
            string ganador = "";
            foreach (KeyValuePair<string, int> jugador in listaJugadoresPuntos)
            {
                if (jugador.Value > max)
                {
                    max = jugador.Value;
                    ganador = jugador.Key;
                }
            }
            if (ganador == conexion.ConnectionId)
            {
                labelGanador = "Has ganado " + labelJugador;
            }
            else
            {
                labelGanador = "Has perdido " + labelJugador;
            }
            NotifyPropertyChanged("LabelGanador");
        }
        #endregion


        #region metodos UI/VM
        /// <summary>
        /// crea la lista de casillas que por defecto tendran imagenMostrada = casillaRoja
        /// </summary> 
        private void CargaCasillasInicial()
        {
            listaCasillas = new List<clsCasilla>();
            for (int i = 0; i < 9; i++)
            {
                listaCasillas.Add(new clsCasilla());
            }
        }
        #endregion
    }
}
