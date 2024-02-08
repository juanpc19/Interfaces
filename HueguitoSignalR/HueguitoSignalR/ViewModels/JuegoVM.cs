using HueguitoSignalR.Models;
using HueguitoSignalR.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        private List<clsCasilla> listaCasillas;
        private clsCasilla casillaSeleccionada;
       
   
        #endregion

        //cuando se pulse empezar juego llamar a metodo servidor k ponga una aleatoria a verde
        #region constructores
        public JuegoVM()
        {
            
            listaCasillas = new List<clsCasilla>();
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla());
            listaCasillas.Add(new clsCasilla(true));
            //aqui llamar a metodo k ponga todo rojo
            NotifyPropertyChanged("ListaCasillas");
  
        }
        #endregion

        #region propiedades
        
        public clsCasilla CasillaSeleccionada
        {
            get { return casillaSeleccionada; } set {  casillaSeleccionada = value;}
        }

        public List<clsCasilla> ListaCasillas
        {
            get { return listaCasillas; }
        
        }
        #endregion
    }
}
