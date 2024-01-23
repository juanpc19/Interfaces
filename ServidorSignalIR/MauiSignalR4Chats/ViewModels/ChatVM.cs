
using MauiSignalR4Chats.ViewModels.Utilidades;
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSignalR4Chats.ViewModels
{
    public class ChatVM: clsVMBase
    {
        #region atributos
        private readonly HubConnection conexion;
        private string sala;
        private string usuario;//nombre y mensaje para can execute de enviar mensaje dar sus valores a omensajeusuario antes de enviar
        private string mensaje;
        private clsMensajeUsuario oMensajeUsuario; //coge valores de usuario y mensaje y lo meto en la lista
        private ObservableCollection<clsMensajeUsuario> listaMensajes; //lista de mensajes
        private DelegateCommand enviarMensajeCommand; //command para enviar mensaje
        private DelegateCommand irCommand; //command para enviar mensaje

        #endregion

        //
        #region constructores
        public ChatVM()
        {
            conexion = new HubConnectionBuilder().WithUrl("https://chathubjuan.azurewebsites.net/chatHub").Build();
            usuario = string.Empty;
            mensaje = string.Empty;
            sala = string.Empty;
            oMensajeUsuario = new clsMensajeUsuario();
            listaMensajes = new ObservableCollection<clsMensajeUsuario>();
            enviarMensajeCommand = new DelegateCommand(EnviarMensajeCommandExecute, EnviarMensajeCommandCanExecute);
            irCommand = new DelegateCommand(IrCommandExecute, IrCommandCanExecute);

            //aqui establezco handler de evento del cliente que se da al recibir un clsMensajeUsuario en la conexion.On<clsMensajeUsuario>,
            //este evento se llama MuestraMensaje y proviene del servidor, al darse llama al metodo MostrarMensaje del cliente
            //que se encarga de añadir el mensaje a la lista y mostrarla en el cliente
            conexion.On<clsMensajeUsuario>("MuestraMensaje", MostrarMensaje);
            IniciarConexion();
        }
        #endregion

        #region propiedades

        public string Sala
        {
            get { return sala; } 
            set { sala = value; irCommand.RaiseCanExecuteChanged(); }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; enviarMensajeCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged("Usuario"); }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; enviarMensajeCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged("Mensaje"); }
        }

       
        public ObservableCollection<clsMensajeUsuario> ListaMensajes
        {
            get { return listaMensajes; }
        }

        public DelegateCommand EnviarMensajeCommand
        {
            get { return enviarMensajeCommand; }
        }

        public DelegateCommand IrCommand
        {
            get { return irCommand; }
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

        /// <summary>
        /// metodo  que se ejecuta al dar al boton de enviar mensaje, llama a metodo del server EnviarMensajesAClientes, 
        /// para que envie el mensaje que se le pasa como argumento a todos los clientes (se le pasa el del cliente que lo llama)
        /// </summary>
        private async void EnviarMensajeCommandExecute()
        {
            oMensajeUsuario.NombreUsuario = Usuario;
            oMensajeUsuario.MensajeUsuario = Mensaje;
            await conexion.InvokeCoreAsync("EnviarMensajesAClientes", args: new[] { oMensajeUsuario });
            Usuario = string.Empty;
            Mensaje = string.Empty;

        }

        private bool IrCommandCanExecute()
        {
            bool puedeEnviar = false;

            if (!string.IsNullOrEmpty(Sala))
            {
                puedeEnviar = true;
            }

            return puedeEnviar;
        }

        private async void IrCommandExecute()
        {
            if (conexion.State == HubConnectionState.Connected)
            {
                await conexion.InvokeCoreAsync("GoToSala", args: new[] { sala });
            }
          
        }

        #endregion

        #region metodos
        /// <summary>
        /// metodo asociado a la llamada del servidor para mostrar mensaje por pantalla
        /// sera llamado por el evento MuestraMensaje del cliente al recibir un clsMensajeUsuario de servidor
        /// </summary>
        /// <param name="usuario"></param>
        private void MostrarMensaje(clsMensajeUsuario mensajeUsuario)
        {
            Device.BeginInvokeOnMainThread(() => //para que se ejecute en el hilo principal y no explote
            {
                listaMensajes.Add(mensajeUsuario);
            } );
      
        }

        //        this.Dispatcher.Dispatch(() => {
        //    this.listadoMensajes.Add(message);
        //});

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
