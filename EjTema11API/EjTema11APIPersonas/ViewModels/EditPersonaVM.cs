using CapaBL.Listados;
using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
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
        //persona y dep seleccionado set publico si puede ser hacer privado o eliminar
        public clsPersona Persona { get { return persona; } set { persona = value; } }
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get { return listaDepartamentos; } private set { listaDepartamentos = value; NotifyPropertyChanged("ListaDepartamentos"); } }
        public clsDepartamento DepartamentoSeleccionado { get { return departamentoSeleccionado; } set { departamentoSeleccionado = value; editCommand.RaiseCanExecuteChanged(); }  }
        public DelegateCommandAsync EditCommand
        {
            get { return editCommand; }
        }
        #endregion

        #region comandos
        public bool EditCommandCanExecute()
        {
            bool ejecutable=false;
            if (departamentoSeleccionado != null)
            {
                ejecutable = true;
            }
            //si hay tiempo modificar can execute en base a model state valid de data notations O EN BASE A SI DEP SELECCIONADO NO ES NULL)
            return ejecutable;
        }

        public async Task EditCommandExecute()
        {
            await Shell.Current.Navigation.PopAsync();
            // idDep de persona = id de depseleccionado 
            // enviar persona a api
        }
        #endregion

        #region metodos
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
