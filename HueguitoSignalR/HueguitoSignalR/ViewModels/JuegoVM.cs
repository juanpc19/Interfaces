using HueguitoSignalR.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Lights;

namespace HueguitoSignalR.ViewModels
{
    //se ilumina de verde un boton a pulsar el cliente que lo pulsa primero anota punto y pide a servidor nuevo boton a pulsar
    //habra 9 botones, 20 puntos, 
    public class JuegoVM: clsVMBase
    {
        #region atributos
        private string entryJugador;//
        private string labelJugador;//
        private string labelGanador;//coge valor de jugador si partidaFinalizada==true
        private int rondas;//20 cuando suben? cuando cliente pulsa 
        private int puntos;//los que acierten
        private bool partidaIniciada;// por defecto false
        private bool partidaFinalizada;//si rondas==20
        //manda a servidor boton pulsado, tendra command parameters para ver cual se ha pulsado, ejecutable si juego empezado (can execute con partidaIniciada)
        private DelegateCommand botonPulsado;    
        //llama a servidor para recibir boton a pulsar iniciando juego, ejecuta si valor no null ni empty en entryjugador (can execute con partidaIniciada), pone partidaIniciada a true 
        private DelegateCommand empezarJuego;
        private Color colorBoton;
        //añadir 8 propiedades una para cada color de cada boton
        #endregion

        #region constructores
        public JuegoVM()
        {
            colorBoton = Colors.Green;
            NotifyPropertyChanged("ColorBoton");

            //el boton sera puesto a mano en el collection view como item 
            //el color y el texto vienen del clsBoton que es parte de LIST<clsBoton>que se pasa como itemsurce al collection view
            //recorre el el list de botones para propiedades pero el boton se crea a mano
        }
        #endregion

        #region propiedades
         
       public Color ColorBoton { get { return colorBoton; } }
        #endregion
    }
}
