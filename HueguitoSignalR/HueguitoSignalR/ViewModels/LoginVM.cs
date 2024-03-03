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
        private string entryJugador; 
        private DelegateCommand empezarJuego;
        private bool haySitio;
        #endregion

        //cuando se pulse empezar juego llamar a metodo servidor k ponga una aleatoria a verde
        #region constructores
        public LoginVM()
        {
            conexion = new HubConnectionBuilder().WithUrl("https://servidorjuegosignal.azurewebsites.net/juegoHub").Build(); 
            empezarJuego = new DelegateCommand(EmpezarJuegoCommandExecute, EmpezarJuegoCommandCanExecute); 
            haySitio = true;
            NotifyPropertyChanged("HaySitio");
            IniciarConexion();
        }
        #endregion

        #region propiedades
        public string EntryJugador
        {
            get { return entryJugador; }
            set { entryJugador = value; empezarJuego.RaiseCanExecuteChanged(); }
        }

        public bool HaySitio
        {
            get { return haySitio; } 
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

            if (DatosPartida.jugadores<2)//si no hay 2 jugadores
            {
               
                await Shell.Current.Navigation.PushAsync(new MainPage(entryJugador, conexion));// y navego a pagina de juego
                await conexion.InvokeAsync("JugadorPreparado");
            } 
            else//hay 2 o mas jugadores por lo que el jugador no puede unirse la partida
            {
                haySitio = false;
                NotifyPropertyChanged("HaySitio");
            }
           
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
