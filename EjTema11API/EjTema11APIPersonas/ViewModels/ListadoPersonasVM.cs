
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
        private string barraBusqueda; //adaptar lo de ej 1 tema 10 de busqueda aqui
        private DelegateCommandAsync buscarCommand; //adaptar lo de ej 1 tema 10 de busqueda aqui
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
        public bool EliminarCommandCanExecute()
        {
            bool ejecutar = false;
            if (personaSeleccionada != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        public async Task EliminarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new DeletePersona(personaSeleccionada));
        }

        public bool EditarCommandCanExecute()
        {
            bool ejecutar = false;
            if (personaSeleccionada != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        public async Task EditarCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new EditPersona(personaSeleccionada));
        }

        public async Task CrearCommandExecute()
        {
            await Shell.Current.Navigation.PushAsync(new AddPersona());
        }

        /// <summary>
        /// comprueba si puede ejecutar comando buscar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        public bool BuscarCommandCanExecute()
        {
            bool ejecutar = false;
            if (!string.IsNullOrEmpty(barraBusqueda))
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        public async Task BuscarCommandExecute()
        {

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

