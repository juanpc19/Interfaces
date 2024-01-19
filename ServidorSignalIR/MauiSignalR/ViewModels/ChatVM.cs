using MauiSignalR.ViewModels.Utilidades;
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSignalR.ViewModels
{
    public class ChatVM: clsVMBase
    {
        #region atributos
        private readonly HubConnection conexion;
        private string usuario;//nombre y mensaje para can execute de enviar mensaje dar sus valores a omensajeusuario antes de enviar
        private string mensaje;
        private clsMensajeUsuario oMensajeUsuario; //coge valores de usuario y mensaje y lo meto en la lista
        private ObservableCollection<clsMensajeUsuario> listaMensajes; //lista de mensajes, uso string en lugar de objeto clsMensajeUsuario por problema d econversion en ejecucion de comando
        private DelegateCommand enviarMensajeCommand; //command para enviar mensaje
        #endregion

        //
        #region constructores
        public ChatVM()
        {
            //revisar conexion
            conexion= new HubConnectionBuilder().WithUrl("https://chathubjuan.azurewebsites.net/chatHub").Build();
            usuario = string.Empty;
            mensaje = string.Empty;
            oMensajeUsuario = new clsMensajeUsuario();
            listaMensajes = new ObservableCollection<clsMensajeUsuario>();
            enviarMensajeCommand = new DelegateCommand(EnviarMensajeCommandExecuted, EnviarMensajeCommandCanExecute);
            conexion.On<clsMensajeUsuario>("MuestraMensaje", MostrarMensaje);
            iniciarConexion();
        }
        #endregion

        #region propiedades
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; enviarMensajeCommand.RaiseCanExecuteChanged(); }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; enviarMensajeCommand.RaiseCanExecuteChanged(); }
        }

       
        public ObservableCollection<clsMensajeUsuario> ListaMensajes
        {
            get { return listaMensajes; }
        }

        public DelegateCommand EnviarMensajeCommand
        {
            get { return enviarMensajeCommand; }
        }
        #endregion

        #region commands
        private bool EnviarMensajeCommandCanExecute()
        {
            bool puedeEnviar = false;

            if (!string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Mensaje))
            {
                puedeEnviar = true;
            }

            return puedeEnviar;
        }

        private async void EnviarMensajeCommandExecuted()
        {
            oMensajeUsuario.NombreUsuario = Usuario;
            oMensajeUsuario.MensajeUsuario = Mensaje;
            await conexion.InvokeCoreAsync("EnviarMensajesAClientes", args: new[] { oMensajeUsuario });

            Usuario = String.Empty;
            Mensaje = String.Empty;
        }
        #endregion

        /// <summary>
        /// metodo asociado a la llamada del servidor para mostrar mensaje por pantalla
        /// </summary>
        /// <param name="usuario"></param>
        private void MostrarMensaje(clsMensajeUsuario usuario)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                listaMensajes.Add(usuario);
            } );
      
        }

        //        this.Dispatcher.Dispatch(() => {
        //    this.listadoMensajes.Add(message);
        //});
        private async void iniciarConexion()
        {
            await conexion.StartAsync();
        }
    }
}
