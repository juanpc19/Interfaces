using CapaBL.Listados;
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
    public class ListadoDepsVM : clsVMBase
    {
        #region atributos
        private bool visibilidadCarga;
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsDepartamento depSeleccionado; 
        private string barraBusqueda;  
        private DelegateCommandAsync buscarCommand; 
        private DelegateCommandAsync eliminarCommand;  
        private DelegateCommandAsync editarCommand;  
        private DelegateCommandAsync crearCommand;  
        #endregion

        #region constructores
        public ListadoDepsVM()
        {

            RecogerListadoDepsBL();//da valor a lista a traves de set privado

            // buscarCommand = new DelegateCommand(buscarCommandExecute, buscarCommandCanExecute);
            eliminarCommand = new DelegateCommandAsync(eliminarCommandExecute);
            editarCommand = new DelegateCommandAsync(editarCommandExecute);
            crearCommand = new DelegateCommandAsync(crearCommandExecute);
        }
        #endregion

        #region propiedades
        public bool VisibilidadCarga
        {
            get { return visibilidadCarga; }
            set { visibilidadCarga = value; NotifyPropertyChanged("VisibilidadCarga"); }
        }
        public ObservableCollection<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            private set { listaDepartamentos = value; NotifyPropertyChanged("ListaDepartamentos"); }
        }

        public clsDepartamento DepSeleccionado
        {
            get { return depSeleccionado; }
            //set para dar valor igual a persona en la que hago click
            set
            {
                depSeleccionado = value;
                //aviso a eliminarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en personaSeleccionada
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommandAsync BuscarCommand
        { get { return buscarCommand; } }

        public DelegateCommandAsync EliminarCommand
        { get { return eliminarCommand; } }

        public DelegateCommandAsync EditarCommand
        { get { return editarCommand; } }

        public DelegateCommandAsync CrearCommand
        { get { return crearCommand; } }

        public string BarraBusqueda
        {
            get { return barraBusqueda; }
            //set para dar valor igual al escrito en entry
            set
            {
                barraBusqueda = value;
                //si nuevo valor es null o vacio
                if (string.IsNullOrEmpty(barraBusqueda))
                {
                    //restablezco lista original
                    //restablecerListaBusqueda();
                }
                //aviso a buscarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en entry
                // buscarCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        //metodos para los comandos
        #region comandos
        public bool EliminarCommandCanExecute()
        {
            bool ejecutar = false;
            if (depSeleccionado != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }
        public async Task eliminarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new DeleteDep(depSeleccionado));
        }

        public bool EditarCommandCanExecute()
        {
            bool ejecutar = false;
            if (depSeleccionado != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        public async Task editarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new EditDep(depSeleccionado));
        }

        public async Task crearCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new AddDep());
        }

        /// <summary>
        /// comprueba si puede ejecutar comando buscar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        public bool buscarCommandCanExecute()
        {
            bool habilitadoBuscar = false;
            if (!string.IsNullOrEmpty(barraBusqueda))
            {
                habilitadoBuscar = true;
            }
            return habilitadoBuscar;
        }

        public async Task BuscarCommandExecute()
        {

        }

        #endregion

        #region metodos
        private async Task RecogerListadoDepsBL()
        {
            try
            {
                VisibilidadCarga = true;
                clsListaDepsBL oBl = new clsListaDepsBL();
                List<clsDepartamento> listaAuxiliar = await oBl.ListadoDepsBL(); 
                ListaDepartamentos = new ObservableCollection<clsDepartamento>(listaAuxiliar);
                VisibilidadCarga = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion RecogerListadoDepsBL(): {ex.Message}");
            }
        }
        #endregion
    }
}
