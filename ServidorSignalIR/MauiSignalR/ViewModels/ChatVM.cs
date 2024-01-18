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
        private ObservableCollection<string> listaMensajes; //lista de mensajes, uso string en lugar de objeto clsMensajeUsuario por problema d econversion en ejecucion de comando
        private DelegateCommand enviarMensajeCommand; //command para enviar mensaje
        #endregion

        //
        #region constructores
        public ChatVM()
        {
            //revisar conexion
            conexion= new HubConnectionBuilder().WithUrl("https://localhost:44389/chatHub").Build();
            usuario = string.Empty;
            mensaje = string.Empty;
            oMensajeUsuario = new clsMensajeUsuario();
            listaMensajes = new ObservableCollection<string>();
            enviarMensajeCommand = new DelegateCommand(EnviarMensajeCommandExecuted, EnviarMensajeCommandCanExecute);
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

        public clsMensajeUsuario OMensajeUsuario
        {
            get { return oMensajeUsuario; }
            set { oMensajeUsuario = value; }
        }

        public ObservableCollection<string> ListaMensajes
        {
            get { return listaMensajes; }
            set { listaMensajes = value; NotifyPropertyChanged("ListaMensajes"); }
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

        private void EnviarMensajeCommandExecuted()
        {
            conexion.On<clsMensajeUsuario>("ReceiveMessage", (oMensajeUsuario) =>
            {
                listaMensajes.Add($"{Environment.NewLine} {oMensajeUsuario.NombreUsuario} {oMensajeUsuario.MensajeUsuario}");
                NotifyPropertyChanged("ListaMensajes");
            });
            
        }
        #endregion




    }
}
