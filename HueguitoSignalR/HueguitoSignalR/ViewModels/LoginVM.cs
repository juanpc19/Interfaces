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
    public class LoginVM: clsVMBase
    {
        #region atributos
        private readonly HubConnection conexion;
        private string entryJugador;//
        //llama a servidor para recibir boton a pulsar iniciando juego, ejecuta si valor no null ni empty en entryjugador (can execute con partidaIniciada), pone partidaIniciada a true 
        private DelegateCommand empezarJuego;
        #endregion

        //cuando se pulse empezar juego llamar a metodo servidor k ponga una aleatoria a verde
        #region constructores
        public LoginVM()
        {
            conexion = new HubConnectionBuilder().WithUrl("http://localhost:5189/juegoHub").Build(); 
            empezarJuego = new DelegateCommand(EmpezarJuegoCommandExecute, EmpezarJuegoCommandCanExecute); 
            IniciarConexion();
        }
        #endregion

        #region propiedades
        public string EntryJugador
        {
            get { return entryJugador; }
            set { entryJugador = value; empezarJuego.RaiseCanExecuteChanged(); }
        }

        public DelegateCommand EmpezarJuego
        {
            get { return empezarJuego; }
        }

        #endregion


        #region comandos
        /// <summary>
        /// comprueba que entryJugador no es null y ejecuta su comando 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool EmpezarJuegoCommandCanExecute()
        {
            bool ejecutable = false;
            if (!string.IsNullOrEmpty(entryJugador))
            {
                ejecutable = true;
            }
            return ejecutable;
        }

        /// <summary>
        /// metodo que llamara a IniciarJuego de server para empezar a poner botones verdes
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async void EmpezarJuegoCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new MainPage(entryJugador));
        }
        #endregion

  
        #region metodos
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
