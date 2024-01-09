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
    public class EditDepVM: clsVMBase
    {
        #region atributos
        private string nombreDepartamento;
        private clsDepartamento departamento;
        private DelegateCommand editarCommand;
        private DelegateCommand volverCommand;
        #endregion

        #region constructores
        public EditDepVM(clsDepartamento departamento)
        {
            this.departamento = departamento;
            editarCommand = new DelegateCommand(EditarCommandExecute, EditarCommandCanExecute);
            volverCommand = new DelegateCommand(VolverCommandExecute);
        }
        #endregion

        #region propiedades
        public string NombreDepartamento { get { return nombreDepartamento; } set { nombreDepartamento = value; editarCommand.RaiseCanExecuteChanged(); } }
        public clsDepartamento Departamento { get { return departamento; } set { departamento = value; } }
        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
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
        private bool EditarCommandCanExecute()
        {
            bool ejecutable = false;

            if (!string.IsNullOrEmpty(NombreDepartamento))
            {
                ejecutable = true;
            }

            return ejecutable;
        }

        /// <summary>
        /// funcion que ejecuta el comando de editar dando a propiedad nombre de departamento el valor de NombreDepartamento antes de mandarselo a la capa BL
        /// </summary>
        private async void EditarCommandExecute()
        {
            clsManejadoraDepBL oManejadoraDepBL = new clsManejadoraDepBL();
            departamento.Nombre = NombreDepartamento;

            await oManejadoraDepBL.EditarDepBL(departamento);
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
