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
    public class AddDepVM: clsVMBase
    {
        #region atributos
        private string nombreDepartamento;
        private clsDepartamento departamento;
        private DelegateCommand crearCommand;
        private DelegateCommand volverCommand;
        #endregion

        #region constructores
        public AddDepVM()
        {
            this.departamento = new clsDepartamento();
            crearCommand = new DelegateCommand(CrearCommandExecute, CrearCommandCanExecute);
            volverCommand = new DelegateCommand(VolverCommandExecute);
        }
        #endregion

        #region propiedades
        public string NombreDepartamento { get { return nombreDepartamento; } set { nombreDepartamento = value; crearCommand.RaiseCanExecuteChanged(); } }
        public clsDepartamento Departamento { get { return departamento; } set { departamento = value;  } }
        public DelegateCommand CrearCommand
        {
            get { return crearCommand; }
        }
        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }
        #endregion

        #region comandos
        /// <summary>
        /// funcion que comprueba si se puede ejecutar el comando de crear
        /// </summary>
        /// <returns></returns>
        public bool CrearCommandCanExecute()
        {
            bool ejecutable = false;

            if (!string.IsNullOrEmpty(NombreDepartamento))
            {
                ejecutable = true;
            }

            return ejecutable;
        }

        /// <summary>
        /// funcion que ejecuta el comando de crear dando a propiedad nombre de departamento el valor de NombreDepartamento antes de mandarselo a la capa BL
        /// </summary>
        public async void CrearCommandExecute()
        {        
            clsManejadoraDepBL oManejadoraDepBL = new clsManejadoraDepBL();
            departamento.Nombre = NombreDepartamento;

            await oManejadoraDepBL.CrearDepBL(departamento);
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
