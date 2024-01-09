
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
    //mirar enlace https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
    public class ListadoPersonasVM : clsVMBase
    {

        #region atributos
        private bool visibilidadCarga;
        private ObservableCollection<clsPersona> listaPersonas;
        private clsPersona personaSeleccionada; 
        private string barraBusqueda; 
        private DelegateCommandAsync buscarCommand; 
        private DelegateCommandAsync eliminarCommand; 
        private DelegateCommandAsync editarCommand; 
        private DelegateCommandAsync crearCommand; 
        #endregion

        #region constructores
        public ListadoPersonasVM()
        {

            RecogerListadoPersonasBL();//da valor a lista a traves de set privado

            buscarCommand = new DelegateCommandAsync(BuscarCommandExecute, BuscarCommandCanExecute);
            eliminarCommand = new DelegateCommandAsync(EliminarCommandExecute, EliminarCommandCanExecute);
            editarCommand = new DelegateCommandAsync(EditarCommandExecute, EditarCommandCanExecute);
            crearCommand = new DelegateCommandAsync(CrearCommandExecute);
        }
        #endregion

        #region propiedades

        public bool VisibilidadCarga
        {
            get { return visibilidadCarga; }
            set { visibilidadCarga = value; NotifyPropertyChanged("VisibilidadCarga"); }
        }
        public ObservableCollection<clsPersona> ListaPersonas
        {
            get { return listaPersonas; }
            private set { listaPersonas = value; NotifyPropertyChanged("ListaPersonas"); }
        }

        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            //set para dar valor igual a persona en la que hago click
            set
            {
                personaSeleccionada = value;
                
                eliminarCommand.RaiseCanExecuteChanged();
                editarCommand.RaiseCanExecuteChanged();
                crearCommand.RaiseCanExecuteChanged();              
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
                NotifyPropertyChanged("BarraBusqueda");
                //si nuevo valor es null o vacio
                if (string.IsNullOrEmpty(barraBusqueda))
                {
                    //restablezco lista original
                    // restablecerListaBusqueda();
                }
                //aviso a buscarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en entry
                buscarCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        //metodos para los comandos
        #region comandos
        private bool EliminarCommandCanExecute()
        {
            bool ejecutar = false;
            if (personaSeleccionada != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        private async Task EliminarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new DeletePersona(personaSeleccionada));
        }

        private bool EditarCommandCanExecute()
        {
            bool ejecutar = false;
            if (personaSeleccionada != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        private async Task EditarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new EditPersona(personaSeleccionada));
        }

        private async Task CrearCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new AddPersona());
        }

        /// <summary>
        /// comprueba si puede ejecutar comando buscar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        private bool BuscarCommandCanExecute()
        {
            bool ejecutar = false;
            if (!string.IsNullOrEmpty(barraBusqueda))
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        private async Task BuscarCommandExecute()
        {

        }
        #endregion

        #region metodos
        private async Task RecogerListadoPersonasBL()
        {
            try
            {
                VisibilidadCarga = true;
                clsListaPersonasBL oBl = new clsListaPersonasBL();
                List<clsPersona> listaAuxiliar = await oBl.ListadoPersonasBL();
                ListaPersonas = new ObservableCollection<clsPersona>(listaAuxiliar);
                VisibilidadCarga = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion RecogerListadoPersonasBL(): {ex.Message}");
            }
        }
        #endregion

    }

}

