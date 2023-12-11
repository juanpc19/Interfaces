using EjTema10MVVMCommands.Models.DAL;
using EjTema10MVVMCommands.Models.Entidades;
using EjTema10MVVMCommands.ViewModels.Utilidades;
using System.Collections.ObjectModel;
using Application = Microsoft.Maui.Controls.Application;

namespace EjTema10MVVMCommands.ViewModels
{
    internal class MainPageVM : clsVMBase
    {
        #region atributos
        private DelegateCommand buscarCommand;
        private DelegateCommand eliminarCommand;
        private ObservableCollection<clsPersona> listaPersonas;
        private clsPersona personaSeleccionada;
        private string textoBusqueda;
        #endregion


        #region Constructores
        public MainPageVM()
        {
            //doy a atributo listaPersonas valor igual a metodo getListaFalsa de clase clsListaPersonasFalsa
            listaPersonas = new ObservableCollection<clsPersona>(clsListaPersonasFalsa.getListaFalsa());         
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

        public ObservableCollection <clsPersona> ListaPersonas
        { get { return listaPersonas; } }

        public clsPersona PersonaSeleccionada
        {  get { return personaSeleccionada; } 
            //set para dar valor igual a persona en la que hago click
            set {  personaSeleccionada = value;
                //aviso a eliminarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en personaSeleccionada
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public string TextoBusqueda
        { get { return textoBusqueda; }
            //set para dar valor igual al escrito en entry
            set { textoBusqueda = value;
               
                //si nuevo valor es null o vacio
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    //restablezco lista original
                     recargarListaOriginal();
                }
                //aviso a buscarCommand que haga check de si puede ejecutarse o no debido a nuevo valor en entry
                buscarCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion
        //metodos para los comandos
        #region comandos
        /// <summary>
        /// comprueba si puede ejecutar comando eliminar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        public bool eliminarCommandCanExecute()
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
        /// 
        public async void eliminarCommandExecute()
        {
            bool confirmacionUsuario = await mensajeBorrado("Borrar persona:", "Esta a punto de borrar una persona del listado esta seguro del borrado?");

            if (confirmacionUsuario)
            {
                listaPersonas.Remove(personaSeleccionada);
                NotifyPropertyChanged("ListaPersonas");
            }
        }
        /// <summary>
        /// comprueba si puede ejecutar comando buscar 
        /// </summary>
        /// <returns>devuelve bool</returns>
        public bool buscarCommandCanExecute()
        {
            bool habilitadoBuscar = false;
            if(!string.IsNullOrEmpty(textoBusqueda))
            {
                habilitadoBuscar = true;
            }
            return habilitadoBuscar;
        }

        /// <summary>
        /// ejecuta comando buscar si hay texto escrito en el entry textoBusqueda
        /// </summary>
        public void buscarCommandExecute()
        {
            //doy a textoABuscar valor igual a TextoBusqueda (entry.text) y lo paso a minusculas para busqueda mas precisa
            string textoABuscar = TextoBusqueda.ToLower();

            //recargo lista original sin romper bindeo llamando a recargarListaOriginal (sin instanciar)
            recargarListaOriginal();

            // creo una nueva lista temporal en la que recogere las personas filtradas
            //.where es un metodo extensible de LINQ (Language Integrated Query) que hace una busqueda en el objeto listaPersonas 
            List<clsPersona> listadoFiltrado = listaPersonas.Where(persona =>
                    //donde personas tenga nombre o apellido que contenga textoABuscar (paso a minuscula nombre y apellido para busqueda mas precisa)
                    persona.Nombre.ToLower().Contains(textoABuscar) ||
                    persona.Apellidos.ToLower().Contains(textoABuscar)
                //una vez tengo la lista la paso de tipo IEnumerable<T> o de tipo IQueryable<T> que son las que devuelve la busqueda where
                // a List<T> que es del tipo que estoy usando, esto se hace con el siguiente .ToList();
                ).ToList();

                //borro los elementos de listaPersonas
                listaPersonas.Clear();

                //y añado los elementos de la lista listadoFiltrado
                foreach (var persona in listadoFiltrado)
                {
                    listaPersonas.Add(persona);
                }

            //notifico cambios a listaPersonas para reflejarlos en interfaz
            NotifyPropertyChanged("ListaPersonas");
        }
        #endregion

        /// <summary>
        /// funcion que muestra alerta de borrado preguntando por borrado y recoge respuesta de usuario para devolverla en un return
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        #region Metodos y funciones
        public async Task<bool> mensajeBorrado(string titulo, string mensaje)
        {
            bool respuesta=false;
            //devuelve true /si o false/no y guarda en respuesta 
            respuesta=await Application.Current.MainPage.DisplayAlert(titulo, mensaje, "SI", "NO");

            return respuesta;
             
        }

        /// <summary>
        /// funcion que reiniciara la lista a su valor original, usar para evitar rotura de binding(se da cuando reintancias el objeto de un binding,
        /// ya que este debe dejar de existir para crear otro rompiendo el bind y jodiendote el fin de semana)
        /// </summary>
        public void recargarListaOriginal()
        {  
             //borro los elementos de listaPersonas
            listaPersonas.Clear();

             //y añado los elementos de la lista devuelta por metodo getListaFalsa de la clase clsListaPersonasFalsa
             foreach (clsPersona persona in clsListaPersonasFalsa.getListaFalsa())
             {
                    listaPersonas.Add(persona);
             }
        }
        #endregion
    }

   
}
