using CapaBL.Manejadoras;
using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
using EjTema11APIPersonas.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema11APIPersonas.ViewModels
{
    public class DeleteDepVM: clsVMBase
    {
        #region atributos
        private clsDepartamento departamento;
        private bool check;
        private DelegateCommand borrarCommand;
        private DelegateCommand volverCommand;
        #endregion

        #region constructores
        public DeleteDepVM(clsDepartamento departamento)
        {
            this.departamento = departamento;
            borrarCommand = new DelegateCommand(BorrarCommandExecute, BorrarCommandCanExecute);
            volverCommand = new DelegateCommand(VolverCommandExecute);
        }
        #endregion

        #region propiedades
        public clsDepartamento Departamento { get { return departamento; } set { departamento = value; } }
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
            if (Check)
            {
                ejecutable = true;
            }
            //si hay tiempo modificar can execute en base a model state valid de data notations O EN BASE A SI DEP SELECCIONADO NO ES NULL)
            return ejecutable;
        }

        /// <summary>
        /// funcion que ejecuta el comando de editar dando a propiedad nombre de departamento el valor de NombreDepartamento antes de mandarselo a la capa BL
        /// </summary>
        private async void BorrarCommandExecute()
        {
            clsManejadoraDepBL oManejadoraDepBL = new clsManejadoraDepBL();      

            await oManejadoraDepBL.BorrarDepBL(departamento);
            await Shell.Current.Navigation.PushAsync(new ListadoDeps());
        }

        /// <summary>
        /// funcion para el comando de volver navega a listado recargando la pagina
        /// </summary>
        private async void VolverCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new ListadoDeps());
        }
        #endregion
    }
}
