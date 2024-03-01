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
    public class JuegoVM: clsVMBase
    {
        #region atributos
        private readonly HubConnection conexion;
        private string labelJugador;//
        private string labelGanador;//coge valor de jugador si partidaFinalizada==true
        private int rondas;//20 cuando suben? cuando cliente pulsa 
        private int puntos;//los que acierten
        private bool partidaIniciada;// para iniciar juego se pone true si datos partida jugadores=2
        private bool partidaFinalizada;//si rondas==20
        //manda a servidor boton pulsado, tendra command parameters para ver cual se ha pulsado, ejecutable si juego empezado (can execute con partidaIniciada)
        private DelegateCommand botonPulsado;    
        //llama a servidor para recibir boton a pulsar iniciando juego, ejecuta si valor no null ni empty en entryjugador (can execute con partidaIniciada), pone partidaIniciada a true 
        //private DelegateCommand empezarJuego;
        private List<clsCasilla> listaCasillas;
        private clsCasilla casillaSeleccionada;
        private int ultimaCasillaActivada;
       
   
        #endregion

        //cuando se pulse empezar juego llamar a metodo servidor k ponga una aleatoria a verde
        #region constructores
        public JuegoVM(string nombreJugador)
        {
            conexion = new HubConnectionBuilder().WithUrl("http://localhost:5189/juegoHub").Build();
            labelJugador = nombreJugador;


            //empezarJuego = new DelegateCommand(EmpezarJuegoCommandExecute, EmpezarJuegoCommandCanExecute);
            botonPulsado = new DelegateCommand(BotonPulsadoCommandExecute, BotonPulsadoCommandCanExecute);
            IniciarConexion();
        }
        #endregion

        #region propiedades

        public string LabelJugador
        {
            get { return labelJugador; }
            set { labelJugador = value; NotifyPropertyChanged("LabelJugador"); }
        }

        public string LabelGanador
        {
            get { return labelGanador; }
            set { labelGanador = value; NotifyPropertyChanged("LabelGanador"); }
        }

        public int Rondas
        {
            get { return rondas; }
            set { rondas = value; NotifyPropertyChanged("Rondas"); }
        }

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; NotifyPropertyChanged("Puntos"); }
        }

        public bool PartidaFinalizada
        {
            get { return partidaFinalizada; }
            set { partidaFinalizada = value; NotifyPropertyChanged("PartidaFinalizada"); }
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

        //public DelegateCommand EmpezarJuego
        //{
        //    get { return empezarJuego; }
        //}

        public DelegateCommand BotonPulsado
        {
            get { return botonPulsado; }
        }

        public int UltimaCasillaActivada
        {
            get { return ultimaCasillaActivada; } 
        }
        #endregion


        #region comandos

        ///// <summary>
        ///// comprueba que entryJugador no es null y ejecuta su comando 
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //private bool EmpezarJuegoCommandCanExecute()
        //{
        //    bool ejecutable = false;
        //    if (!string.IsNullOrEmpty(entryJugador))
        //    {
        //        ejecutable = true;
        //    }
        //    return ejecutable;
        //}

        ///// <summary>
        ///// metodo que llamara a IniciarJuego de server para empezar a poner botones verdes
        ///// </summary>
        ///// <exception cref="NotImplementedException"></exception>
        //private void EmpezarJuegoCommandExecute()
        //{
        //    CargaCasillasInicial();
        //    labelJugador = entryJugador;
        //    //conexion.InvokeAsync("IniciarJuego"); 
        //    labelGanador = "ha ganado tal";
        //    rondas = 5;
        //    puntos = 10;
        //    NotifyPropertyChanged("LabelGanador");
        //    NotifyPropertyChanged("LabelJugador");
        //    NotifyPropertyChanged("Rondas");
        //    NotifyPropertyChanged("Puntos");
        //}

        private bool BotonPulsadoCommandCanExecute()
        {
            throw new NotImplementedException();
        }

        private void BotonPulsadoCommandExecute()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// metodo que crea la lista de casillas que por defecto tendran imagenMostrada = casillaRoja
        /// </summary>
        #region metodos
        private void CargaCasillasInicial()
        {
            listaCasillas = new List<clsCasilla>();
            for (int i = 0; i < 9; i++)
            {
                listaCasillas.Add(new clsCasilla());
            }
             
            NotifyPropertyChanged("ListaCasillas");
        }

        private void ActivaCasillaAleatoria(int index)
        {
            if (ultimaCasillaActivada == index)
            {
                if (index == 8)
                {
                    index = 0;
                }
                else if (index == 0)
                {
                    index=8;
                }
            }
            listaCasillas[ultimaCasillaActivada].MeToca = false;
            listaCasillas[index].MeToca = true;
            ultimaCasillaActivada = index;

            NotifyPropertyChanged("ListaCasillas");
        }




        /// <summary>
        /// metodo para iniciar la conexion con el servidor de forma asincrona
        /// </summary>
        private async void IniciarConexion()
        {
            await conexion.StartAsync();
        }
        #endregion

    }
}
