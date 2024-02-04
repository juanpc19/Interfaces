
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
    //mirar enlace https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
    public class ListadoPersonasVM : clsVMBase
    {

        #region atributos
        private bool visibilidadCarga;
        private ObservableCollection<clsPersona> listaPersonas;
        private List<clsPersona> listaPersonasAuxiliar;//para usar en busqueda sin tener que llamar a la api varias veces,
                                                        //no tiene propiedades publicas para que no se pueda modificar desde fuera porque solo lo usa el VM
        private clsPersona personaSeleccionada;
        private string barraBusqueda;
        private DelegateCommand buscarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand crearCommand;
        private clsDepartamento departamentoPersonaSeleccionada;//para mostrar en edit persona
        #endregion

        #region constructores
        public ListadoPersonasVM()
        {

            RecogerListadoPersonasBL();//da valor a lista a traves de set privado

            buscarCommand = new DelegateCommand(BuscarCommandExecute, BuscarCommandCanExecute);
            eliminarCommand = new DelegateCommand(EliminarCommandExecute, EliminarCommandCanExecute);
            editarCommand = new DelegateCommand(EditarCommandExecute, EditarCommandCanExecute);
            crearCommand = new DelegateCommand(CrearCommandExecute);
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

        public clsDepartamento DepartamentoPersonaSeleccionada
        {
            get { return departamentoPersonaSeleccionada; }

            set
            {
                departamentoPersonaSeleccionada = value;
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
            if (personaSeleccionada != null)
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        private async void EliminarCommandExecute()
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

        /// <summary>
        /// ejecuta el comando editar, abre la pagina de editar persona pasandole la persona seleccionada 
        /// y el departamento de la persona seleccionada (esto ultimo modificacion subida nota, 
        /// tambien cambio lo que recibe la pagina y lo que le pasa a su VM)
        /// </summary>
        private async void EditarCommandExecute()
        {

            clsManejadoraDepBL oBl = new clsManejadoraDepBL();
            //hago busqueda de departamento por id de persona seleccionada mediante metodo de la bl
            DepartamentoPersonaSeleccionada = await oBl.ObtenerDepartamentoPorIdPersonaBL(personaSeleccionada);

            await Shell.Current.Navigation.PushAsync(new EditPersona(personaSeleccionada, departamentoPersonaSeleccionada));

        }

        private async void CrearCommandExecute()
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
            if (!string.IsNullOrEmpty(barraBusqueda))//si barraBusqueda no es null o vacio se puede ejecutar el command
            {
                ejecutar = true;
            }
            return ejecutar;
        }

        /// <summary>
        /// metodo que se ejecuta al pulsar el boton buscar, filtra personas con una busqueda en la lista de personas usando el valor de barraBusqueda
        /// </summary>
        private async void BuscarCommandExecute()
        {
            //doy a textoABuscar valor igual a barraBusqueda (entry.text) y lo paso a minusculas para busqueda mas precisa
            string textoABuscar = barraBusqueda.ToLower();

            //nohay necesidad de hacer una llamada a la api para recargar la lista original antes de hacer busqueda sobre ella
            //ya que tengo la lista original en listaPersonasAuxiliar


            // creo una nueva lista temporal en la que recogere las personas filtradas
            //.where es un metodo extensible de LINQ (Language Integrated Query) que hace una busqueda en listaPersonasAuxiliar
            List<clsPersona> listadoFiltrado = listaPersonasAuxiliar.Where(persona =>
                    //donde personas tenga nombre o apellido que contenga textoABuscar (paso a minuscula nombre y apellido para busqueda mas precisa)
                    persona.Nombre.ToLower().Contains(textoABuscar) ||
                    persona.Apellidos.ToLower().Contains(textoABuscar)
                //una vez tengo la lista la paso de tipo IEnumerable<T> o de tipo IQueryable<T> que son las que devuelve la busqueda where
                // a List<T> que es del tipo que estoy usando, esto se hace con el siguiente .ToList();
                ).ToList();

            //borro los elementos de listaPersonas
            listaPersonas.Clear();

            //y añado los elementos de la lista listadoFiltrado
            foreach (clsPersona persona in listadoFiltrado)
            {
                listaPersonas.Add(persona);
            }

            //notifico cambios a listaPersonas para reflejarlos en interfaz
            NotifyPropertyChanged("ListaPersonas");
        }
        #endregion

        #region metodos
        /// <summary>
        /// medoto que recoge listado personas de api de forma asincrona, usado en constructor
        /// </summary>
        private async void RecogerListadoPersonasBL()
        {
            VisibilidadCarga = true;
            clsListaPersonasBL oBl = new clsListaPersonasBL();
            List<clsPersona> listaAuxiliar = await oBl.ListadoPersonasBL();
            listaPersonasAuxiliar = listaAuxiliar;//añado esta linea para tener una lista auxiliar con la que trabajar en la busqueda
            ListaPersonas = new ObservableCollection<clsPersona>(listaAuxiliar);
            VisibilidadCarga = false;
        }



        /// <summary>
        /// funcion que reiniciara la lista a su valor original sin llamar a la api al tener la lista original en listaPersonasAuxiliar tras carga inicial de pagina
        /// </summary>
        public void recargarListaOriginal()
        {           
            //borro los elementos de listaPersonas
            listaPersonas.Clear();

            //y añado los elementos de listaPersonasAuxiliar
            foreach (clsPersona persona in listaPersonasAuxiliar)
            {
                listaPersonas.Add(persona);
            }
        }
        #endregion

    }

}

