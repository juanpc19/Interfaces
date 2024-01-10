using CapaBL.Listados;
using CapaBL.Manejadoras;
using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
using EjTema11APIPersonas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema11APIPersonas.ViewModels
{
    public class DeletePersonaVM : clsVMBase
    {
        #region atributos
        private clsPersona persona;
        private string noBorrar;
        private bool check;
        private DelegateCommand borrarCommand;
        private DelegateCommand volverCommand;
        #endregion

        #region constructores
        public DeletePersonaVM(clsPersona persona)
        {
            UpdateMensaje();
            this.persona = persona;
            borrarCommand = new DelegateCommand(BorrarCommandExecute, BorrarCommandCanExecute);
            volverCommand = new DelegateCommand(VolverCommandExecute);
        }
        #endregion

        #region propiedades     
        public clsPersona Persona { get { return persona; } set { persona = value; } }
        public string NoBorrar { get { return noBorrar; } set { noBorrar = value; } }
        public bool Check { get { return check; } set { check = value; borrarCommand.RaiseCanExecuteChanged(); } }

        public DelegateCommand BorrarCommand
        {
            get { return borrarCommand; }
        }
        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }
        #endregion

        #region comandos
        /// <summary>
        /// funcion que comprueba si se puede ejecutar el comando de editar
        /// </summary>
        /// <returns></returns>
        private bool BorrarCommandCanExecute()
        {
            bool ejecutable = false;
            if (Check && DateTime.Now.DayOfWeek != DayOfWeek.Sunday) //si el check esta activado y no es domingo
            {
                ejecutable = true;
            }

            return ejecutable;
        }

        /// <summary>
        /// comando que enviara la persona editada a la api
        /// </summary>
        /// <returns></returns>
        private async void BorrarCommandExecute()
        {
            clsManejadoraPersonaBL oBl = new clsManejadoraPersonaBL();

            await oBl.BorrarPersonaBL(persona); //llamo al metodo editar de la bl y le paso la persona editada no veo uso para el codigo devuelto      
            await Shell.Current.Navigation.PushAsync(new ListadoPersonas());//navego de vuelta al listado de personas
        }

        /// <summary>
        /// funcion para el comando de volver navega a listado recargando la pagina
        /// </summary>
        private async void VolverCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new ListadoPersonas());
        }

        private void UpdateMensaje()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                NoBorrar = "No se pueden borrar personas los domingos";
            }
            else
            {
                NoBorrar = "";
            }
        }
        #endregion


    }
}
