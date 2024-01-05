using CapaBL.Listados;
using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
using EjTema11APISTARWARS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema11APISTARWARS.ViewModels
{
    public class ListadoPersonajesVM : clsVMBase
    {
        
        #region atributos
        private ObservableCollection<clsPersonaje> listadoPersonajes;
        private clsPersonaje personajeSeleccionado;
        private string entryBuscar;//no usado
        private DelegateCommand buscarCommand;//no usado
        private DelegateCommandAsync detallesCommand;
        #endregion

        #region constructores
      
        public ListadoPersonajesVM()
        {
            RecogerListado();//da valor a lista a traves de set privado
            buscarCommand = new DelegateCommand(BuscarCommandExecute, BuscarCommandCanExecute);//no usado
            detallesCommand = new DelegateCommandAsync(DetallesCommandExecute, DetallesCommandCanExecute);
        }

        #endregion

        #region propiedades
        public ObservableCollection<clsPersonaje> ListadoPersonajes
        {
            get
            {
                return listadoPersonajes;
            }
            private set //necesario para busqueda y para recoger listado de bl asincrono
            {
                listadoPersonajes = value;
                NotifyPropertyChanged("ListadoPersonajes");
            }
        }

        public clsPersonaje PersonajeSeleccionado
        {
            get
            {
                return personajeSeleccionado;
            }
            set //necesario para seleccionar personaje
            {
                personajeSeleccionado = value;
                //no necesita notificar cambios?
                detallesCommand.RaiseCanExecuteChanged();
            }
        }

        public string EntryBuscar
        {
            get
            {
                return entryBuscar;
            }
            set
            {
                entryBuscar = value;
                NotifyPropertyChanged("EntryBuscar");
               // buscarCommand.RaiseCanExecuteChanged();
            }
        }   

        public DelegateCommand BuscarCommand
        {
            get
            {
                return buscarCommand;
            }
        }

        public DelegateCommandAsync DetallesCommand
        {
            get
            {
                return detallesCommand;
            }
        }
        #endregion

        #region commands
        public bool BuscarCommandCanExecute()
        {
            bool ejecutable = false;

            return ejecutable;
        }
        public async void BuscarCommandExecute()
        {
            
        }

        public bool DetallesCommandCanExecute()
        {
            bool ejecutable = false;
            if (personajeSeleccionado != null)
            {
                ejecutable = true;
            }

            return ejecutable;
        }


        /// <summary>
        /// metodo que ejecutara el command detalles de forma asincrona navegando 
        /// a la pagina de detalles pasandole el personaje seleccionado y el nombre del planeta
        /// </summary>
        /// <returns></returns>
        public async Task DetallesCommandExecute()
        {
            string urlPlaneta=personajeSeleccionado.Homeworld;//extraigo url de planeta de personaje seleccionado
           
            clsListaPersonajesBL oBL = new clsListaPersonajesBL();
            string nombrePlaneta= await oBL.ObtenerNombrePlanetaBL(urlPlaneta);//hago busqueda de esta url en api para obtener nombre de planeta

            //navego a pagina de detalles pasandole personaje seleccionado y nombre de planeta
            await Shell.Current.Navigation.PushAsync(new DetallesPersonaje(personajeSeleccionado, nombrePlaneta));
        }
        #endregion

        #region metodos
        private async Task RecogerListado()
        {
            clsListaPersonajesBL oBL = new clsListaPersonajesBL();
            List<clsPersonaje> listaAuxiliar = await oBL.ListadoPersonajesBL();
            ListadoPersonajes = new ObservableCollection<clsPersonaje>(listaAuxiliar);
        }   
        #endregion
    }

}
