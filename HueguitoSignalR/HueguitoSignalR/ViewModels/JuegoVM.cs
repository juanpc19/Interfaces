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
            conexion = new HubConnectionBuilder().WithUrl("http://localhost:5189/").Build();
            CargaCasillasInicial();


            empezarJuego = new DelegateCommand(EmpezarJuegoCommandExecute, EmpezarJuegoCommandCanExecute);
            botonPulsado = new DelegateCommand(BotonPulsadoCommandExecute, BotonPulsadoCommandCanExecute);
            IniciarConexion();
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


        #region comandos

        private bool EmpezarJuegoCommandCanExecute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// metodo que llamara a IniciarJuego de server
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void EmpezarJuegoCommandExecute()
        {

            throw new NotImplementedException();
        }

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
