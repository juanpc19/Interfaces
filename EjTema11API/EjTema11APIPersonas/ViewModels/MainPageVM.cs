
using CapaBL.Listados;
using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema11API.ViewModels
{
    //mirar enlace https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
    internal class MainPageVM : clsVMBase
    {
        //mas adelante mirar si puedo meter varios commands en uno con el commandParameter
        #region atributos
        private bool visibilidadCarga;
        private ObservableCollection<clsPersona> listaPersonas;
        private clsPersona personaSeleccionada; //
        private string barraBusqueda; //adaptar lo de ej 1 tema 10 de busqueda aqui
        private DelegateCommand buscarCommand; //adaptar lo de ej 1 tema 10 de busqueda aqui
        private DelegateCommand eliminarCommand; //hara navegacion vista eliminar y mostrara persona con cierto id hara uso de metodo getById de api
        private DelegateCommand editarCommand; //hara navegacion vista editar y mostrara persona con cierto id hara uso de metodo getById de api
        private DelegateCommand crearCommand; //hara navegacion vista crear y mostrara modelo de persona a rellenar con entrys
        #endregion

        #region constructores
        public MainPageVM()
        {
            
            RecogerListadoBL();
            
            // buscarCommand = new DelegateCommand(buscarCommandExecute, buscarCommandCanExecute);
            eliminarCommand = new DelegateCommand(eliminarCommandExecute);
            editarCommand = new DelegateCommand(editarCommandExecute);
            crearCommand = new DelegateCommand(crearCommandExecute);
        }
        #endregion

        #region propiedades

        public bool VisibilidadCarga
        {
            get { return visibilidadCarga; } set { visibilidadCarga = value; NotifyPropertyChanged("VisibilidadCarga"); }
        }
        public ObservableCollection<clsPersona> ListaPersonas
        {
            get { return listaPersonas; } 
            set { listaPersonas = value; NotifyPropertyChanged("ListaPersonas"); } 
        }
        
        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            //set para dar valor igual a persona en la que hago click
            set
            {
                personaSeleccionada = value;
                //aviso a eliminarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en personaSeleccionada
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand BuscarCommand
        { get { return buscarCommand; } }

        public DelegateCommand EliminarCommand
        { get { return eliminarCommand; } }

        public DelegateCommand EditarCommand
        { get { return editarCommand; } }

        public DelegateCommand CrearCommand
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
                   // restablecerListaBusqueda();
                }
                //aviso a buscarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en entry
               // buscarCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        //metodos para los comandos
        #region comandos
        public async void eliminarCommandExecute()
        {
           
        }

        public async void editarCommandExecute()
        {

        }

        public async void crearCommandExecute()
        {

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

        /// <summary>
        /// ejecuta comando buscar si hay texto escrito en el entry textoBusqueda
        /// </summary>
        //public void buscarCommandExecute()
        //{
        //    //doy a textoABuscar valor igual a TextoBusqueda (entry.text) y lo paso a minusculas para busqueda mas precisa
        //    string textoABuscar = BarraBusqueda.ToLower();

        //    //recargo lista original sin romper bindeo llamando a recargarListaOriginal (sin instanciar)
        //    recargarListaOriginal();

        //    // creo una nueva lista temporal en la que recogere las personas filtradas
        //    //.where es un metodo extensible de LINQ (Language Integrated Query) que hace una busqueda en el objeto listaPersonas 
        //    List<clsPersona> listadoFiltrado = listaPersonas.Where(persona =>
        //            //donde personas tenga nombre o apellido que contenga textoABuscar (paso a minuscula nombre y apellido para busqueda mas precisa)
        //            persona.Nombre.ToLower().Contains(textoABuscar) ||
        //            persona.Apellidos.ToLower().Contains(textoABuscar)
        //        //una vez tengo la lista la paso de tipo IEnumerable<T> o de tipo IQueryable<T> que son las que devuelve la busqueda where
        //        // a List<T> que es del tipo que estoy usando, esto se hace con el siguiente .ToList();
        //        ).ToList();

        //    //borro los elementos de listaPersonas
        //    listaPersonas.Clear();

        //    //y añado los elementos de la lista listadoFiltrado
        //    foreach (var persona in listadoFiltrado)
        //    {
        //        listaPersonas.Add(persona);
        //    }

        //    //notifico cambios a listaPersonas para reflejarlos en interfaz
        //    NotifyPropertyChanged("ListaPersonas");
        //}
        #endregion


        #region metodos
        private async Task RecogerListadoBL()
        {
            try
            {
                VisibilidadCarga = true;
                clsListaPersonasBL oBl = new clsListaPersonasBL();
                List<clsPersona> listaAuxiliar = await oBl.listadoPersonasBL();
                ListaPersonas = new ObservableCollection<clsPersona>(listaAuxiliar);
                VisibilidadCarga = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion RecogerListado(): {ex.Message}");
            }
        }

        ///// <summary>
        ///// funcion que reiniciara la lista a su valor original, usar para evitar rotura de binding(se da cuando reintancias el objeto de un binding,
        ///// ya que este debe dejar de existir para crear otro rompiendo el bind y jodiendote el fin de semana)
        ///// </summary>
        //public void recargarListaOriginal()
        //{
        //    //borro los elementos de listaPersonas
        //    listaPersonas.Clear();

        //    //y añado los elementos de la lista devuelta por metodo getListaFalsa de la clase clsListaPersonasFalsa
        //    foreach (clsPersona persona in clsListaPersonasFalsa.getListaFalsa())
        //    {
        //        listaPersonas.Add(persona);
        //    }
        //}

      
        #endregion

    }

}

