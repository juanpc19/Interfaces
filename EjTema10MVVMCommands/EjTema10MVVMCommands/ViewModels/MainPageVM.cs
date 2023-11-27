using EjTema10MVVMCommands.Models.DAL;
using EjTema10MVVMCommands.Models.Entidades;
using EjTema10MVVMCommands.ViewModels.Utilidades;


namespace EjTema10MVVMCommands.ViewModels
{
    internal class MainPageVM : clsVMBase
    {
        #region atributos
        private DelegateCommand buscarCommand;
        private DelegateCommand eliminarCommand;
        private List<clsPersona> listaPersonas;
        private clsPersona personaSeleccionada;
        private string textoBusqueda;
        #endregion


        #region Constructores
        public MainPageVM()
        {
            //doy a atributo listaPersonas valor igual a metodo getListaFalsa de clase clsListaPersonasFalsa
            listaPersonas = clsListaPersonasFalsa.getListaFalsa();
            //doy a atributo buscarCommand valor igual a un nuevo commando con metodo buscarCommandExecute y buscarCommandCanExecute
            //el segundo innecesario si queremos ejecutar accion en click sin comprobacion
            buscarCommand = new DelegateCommand(buscarCommandExecute, buscarCommandCanExecute);
            eliminarCommand = new DelegateCommand(eliminarCommandExecute, eliminarCommandCanExecute);
        }

       
        #endregion

        //propiedades de los atributos
        #region propiedades
        public DelegateCommand BuscarCommand 
        { get { return buscarCommand; } }

        public DelegateCommand EliminarCommand 
        { get { return eliminarCommand; } }

        public List <clsPersona> ListaPersonas
        { get { return listaPersonas; } }

        public clsPersona PersonaSeleccionada
        {  get { return personaSeleccionada; } 
            //set para dar valor igual a persona en la que hago click
            set {  personaSeleccionada = value;
                //notifico cambio a la interfaz
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        public string TextoBusqueda
        { get { return textoBusqueda; }
            //set para dar valor igual al escrito en entry
            set { textoBusqueda = value;
                //aviso a buscarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en entry
                buscarCommand.RaiseCanExecuteChanged();
                //notifico cambio a la interfaz
                NotifyPropertyChanged("TextoBusqueda");
            }
        }


        #endregion
        //metodos para los comandos
        #region comandos
        /// <summary>
        /// comprueba si puede ejecutar comando eliminar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        private bool eliminarCommandCanExecute()
        {
            bool habilitadoEliminar = false;

            if (personaSeleccionada != null)
            {
                habilitadoEliminar = true;
            }
            return habilitadoEliminar;
        }

        /// <summary>
        /// ejecuta comando eliminar borrando personaSeleccionada de listaPersonas notificando el cambio en propiedad de listaPersonas
        /// </summary>
        private void eliminarCommandExecute()
        {
            mensajeBorrado("Borrar persona:", "Esta a punto de borrar una persona del listado esta seguro del borrado?");
            listaPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListaPersonas");
        }

        /// <summary>
        /// comprueba si puede ejecutar comando buscar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        private bool buscarCommandCanExecute()
        {
            bool habilitadoBuscar = false;
            if(!string.IsNullOrEmpty(textoBusqueda))
            {
                habilitadoBuscar = true;

            }
            return habilitadoBuscar;
        }

        /// <summary>
        /// ejecuta comando buscar devolviendo personaSeleccionada de listaPersonas notificando el cambio en propiedad de listaPersonas
        /// </summary>
        private void buscarCommandExecute()
        {
            //cuando use set de entry hay cambio por lo k notifico al comandoBuscar k checkee si se puede ejecutar y luego notifico cambio a propiedad entry

            //doy a textoABuscar valor igual a TextoBusqueda (entry.text) y lo paso a minusculas para busqueda mas precisa
            string textoABuscar = TextoBusqueda.ToLower();

            // creo una nueva lista temporal en la que recogere las personas filtradas
            //.where es un metodo extensible de LINQ (Language Integrated Query) que hace una busqueda en el objeto listaPersonas 
            List<clsPersona> personasFiltradas = listaPersonas.Where(persona =>
                //donde personas tenga nombre o apellido que contenga textoABuscar (paso a minuscula nombre y apellido para busqueda mas precisa
                persona.Nombre.ToLower().Contains(textoABuscar) ||
                persona.Apellidos.ToLower().Contains(textoABuscar)
            //una vez tengo la lista la paso de tipo IEnumerable<T> o de tipo IQueryable<T> que son las que devuelve la busqueda where
            // a List<T> que es del tipo que estoy usando, esto se hace con el siguiente .ToList();
            ).ToList();

            //sobreescribir lista actual de momento lo ideal seria devolver una nueva?
            listaPersonas = personasFiltradas;
        }
        #endregion

        #region Metodos y funciones
        private async void mensajeBorrado(string titulo, string mensaje)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, mensaje, "OK");
        }
        #endregion
    }
}
