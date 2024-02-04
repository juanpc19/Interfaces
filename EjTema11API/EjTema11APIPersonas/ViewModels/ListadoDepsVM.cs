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
        private List<clsDepartamento> listaDepartamentosAuxiliar;//para usar en busqueda sin tener que llamar a la api varias veces,
                                                                 //no tiene propiedades publicas para que no se pueda modificar desde fuera porque solo lo usa el VM
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
                    //restablezco lista original mediante metodo recargarListaOriginal
                    recargarListaOriginal();
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
            if (depSeleccionado != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }
        private async Task EliminarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new DeleteDep(depSeleccionado));
        }

        private bool EditarCommandCanExecute()
        {
            bool ejecutar = false;
            if (depSeleccionado != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        private async Task EditarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new EditDep(depSeleccionado));
        }

        private async Task CrearCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new AddDep());
        }

        /// <summary>
        /// comprueba si puede ejecutar comando buscar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        private bool BuscarCommandCanExecute()
        {
            bool habilitadoBuscar = false;
            if (!string.IsNullOrEmpty(barraBusqueda))
            {
                habilitadoBuscar = true;
            }
            return habilitadoBuscar;
        }

        /// <summary>
        /// metodo que se ejecuta al pulsar el boton buscar, filtra departamentos con una busqueda en la lista de departamentos usando el valor de barraBusqueda
        /// </summary>
        private async Task BuscarCommandExecute()
        {
            //doy a textoABuscar valor igual a barraBusqueda (entry.text) y lo paso a minusculas para busqueda mas precisa
            string textoABuscar = barraBusqueda.ToLower();

            //nohay necesidad de hacer una llamada a la api para recargar la lista original antes de hacer busqueda sobre ella
            //ya que tengo la lista original en listaDepartamentosAuxiliar


            // creo una nueva lista temporal en la que recogere los departamentos filtrados
            //.where es un metodo extensible de LINQ (Language Integrated Query) que hace una busqueda en listaDepartamentosAuxiliar
            List<clsDepartamento> listadoFiltrado = listaDepartamentosAuxiliar.Where(departamento =>
                    //donde departamento tenga nombre  que contenga textoABuscar (paso a minuscula nombre  para busqueda mas precisa)
                    departamento.Nombre.ToLower().Contains(textoABuscar) 
                //una vez tengo la lista la paso de tipo IEnumerable<T> o de tipo IQueryable<T> que son las que devuelve la busqueda where
                // a List<T> que es del tipo que estoy usando, esto se hace con el siguiente .ToList();
                ).ToList();

            //borro los elementos de listaDepartamentos
            listaDepartamentos.Clear();

            //y añado los elementos de la lista listadoFiltrado
            foreach (clsDepartamento departamento in listadoFiltrado)
            {
                listaDepartamentos.Add(departamento);
            }

            //notifico cambios a listaDepartamentos para reflejarlos en interfaz
            NotifyPropertyChanged("ListaDepartamentos");
        }

        #endregion

        #region metodos
        /// <summary>
        /// medoto que recoge listado departamentos de api de forma asincrona, usado en constructor
        /// </summary>
        private async Task RecogerListadoDepsBL()
        {

                VisibilidadCarga = true;
                clsListaDepsBL oBl = new clsListaDepsBL();
                List<clsDepartamento> listaAuxiliar = await oBl.ListadoDepsBL(); 
                listaDepartamentosAuxiliar = listaAuxiliar;//añado esta linea para tener una lista auxiliar con la que trabajar en la busqueda
                ListaDepartamentos = new ObservableCollection<clsDepartamento>(listaAuxiliar);
                VisibilidadCarga = false;
            
        }

        /// <summary>
        /// funcion que reiniciara la lista a su valor original sin llamar a la api al tener la lista original en listaDepartamentosAuxiliar tras carga inicial de pagina
        /// </summary>
        public void recargarListaOriginal()
        {
            //borro los elementos de listaDepartamentos
            listaDepartamentos.Clear();

            //y añado los elementos de listaDepartamentosAuxiliar
            foreach (clsDepartamento departamento in listaDepartamentosAuxiliar)
            {
                listaDepartamentos.Add(departamento);
            }
        }
        #endregion
    }
}
