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
    public class EditPersonaVM: clsVMBase
    {
        #region atributos
        private clsPersona persona;
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommandAsync editCommand;//comando asincrono con clase modificada de delegate command
        #endregion

        #region constructores
        public EditPersonaVM(clsPersona persona) {
            RecogerListadoDepsBL();
            this.persona = persona;
            editCommand = new DelegateCommandAsync(EditCommandExecute,EditCommandCanExecute);
        }
        #endregion

        #region propiedades     
        public clsPersona Persona { get { return persona; } set { persona = value; } }
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get { return listaDepartamentos; } private set { listaDepartamentos = value; NotifyPropertyChanged("ListaDepartamentos"); } }
        public clsDepartamento DepartamentoSeleccionado { get { return departamentoSeleccionado; } set { departamentoSeleccionado = value; editCommand.RaiseCanExecuteChanged(); }  }
        public DelegateCommandAsync EditCommand
        {
            get { return editCommand; }
        }
        #endregion

        #region comandos
        /// <summary>
        /// funcion que comprueba si se puede ejecutar el comando de editar
        /// </summary>
        /// <returns></returns>
        private bool EditCommandCanExecute()
        {
            bool ejecutable=false;
            if (departamentoSeleccionado != null)
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
        private async Task EditCommandExecute()
        {
            persona.IdDepartamento = departamentoSeleccionado.Id;//machaco idDep de persona con id de departamentoSeleccionado
            clsManejadoraPersonaBL oBl = new clsManejadoraPersonaBL();

            await oBl.EditarPersonaBL(persona); //llamo al metodo editar de la bl y le paso la persona editada no veo uso para el codigo devuelto      
            await Shell.Current.Navigation.PushAsync(new ListadoPersonas());//navego de vuelta al listado de personas
        }
        #endregion

        #region metodos
        /// <summary>
        /// funcion que recoge el listado de departamentos de la api, sera usado en constructor
        /// </summary>
        /// <returns></returns>
        private async Task RecogerListadoDepsBL()
        {
            try
            {               
                clsListaDepsBL oBl = new clsListaDepsBL();
                List<clsDepartamento> listaAuxiliar = await oBl.ListadoDepsBL();
                ListaDepartamentos = new ObservableCollection<clsDepartamento>(listaAuxiliar);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion RecogerListadoDepsBL(): {ex.Message}");
            }
        }
        #endregion
    }
}
