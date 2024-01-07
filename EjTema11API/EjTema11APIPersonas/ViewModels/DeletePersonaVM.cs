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
    public class DeletePersonaVM: clsVMBase
    {
        #region atributos
        private clsPersona persona;
        private bool check;
        private DelegateCommandAsync borrarCommand;//comando asincrono con clase modificada de delegate command
        #endregion

        #region constructores
        public DeletePersonaVM(clsPersona persona)
        {
            
            this.persona = persona;
            borrarCommand = new DelegateCommandAsync(BorrarCommandExecute, BorrarCommandCanExecute);
        }
        #endregion

        #region propiedades     
        public clsPersona Persona { get { return persona; } set { persona = value; } }

        public bool Check { get { return check; } set { check = value; borrarCommand.RaiseCanExecuteChanged(); } } 

        public DelegateCommandAsync BorrarCommand
        {
            get { return borrarCommand; }
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
            if (Check)
            {
                ejecutable = true;
            }
            //si hay tiempo modificar can execute en base a model state valid de data notations O EN BASE A SI DEP SELECCIONADO NO ES NULL)
            return ejecutable;
        }

        /// <summary>
        /// comando que enviara la persona editada a la api
        /// </summary>
        /// <returns></returns>
        private async Task BorrarCommandExecute()
        {
            clsManejadoraPersonaBL oBl = new clsManejadoraPersonaBL();

            await oBl.BorrarPersonaBL(persona); //llamo al metodo editar de la bl y le paso la persona editada no veo uso para el codigo devuelto      
            await Shell.Current.Navigation.PushAsync(new ListadoPersonas());//navego de vuelta al listado de personas
        }
        #endregion

        #region metodos
        /// <summary>
        /// funcion que recoge el listado de departamentos de la api, sera usado en constructor
        /// </summary>
        /// <returns></returns>
     
        #endregion
    }
}
