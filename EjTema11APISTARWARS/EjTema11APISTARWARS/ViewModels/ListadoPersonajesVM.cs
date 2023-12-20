using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
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
        // listapersonajes, personaje (para personaje seleccionado), entry para buscar pj, command buscar, command detalles, 
        #region atributos
        private ObservableCollection<clsPersonaje> listadoPersonajes;
        private clsPersonaje personajeSeleccionado;
        private string entryBuscar;
        private DelegateCommand buscarCommand;
        private DelegateCommand detallesCommand;
        #endregion

        #region constructores
      
        public ListadoPersonajesVM()
        {
            this.listadoPersonajes = new ObservableCollection<clsPersonaje>();
            this.personajeSeleccionado = new clsPersonaje();
            this.entryBuscar = "";
            //this.buscarCommand = new DelegateCommand(BuscarCommandExecuted, BuscarCommandCanExecute);
            //this.detallesCommand = new DelegateCommand(DetallesCommandExecuted, DetallesCommandCanExecute);
        }

        #endregion

        #region propiedades
        public ObservableCollection<clsPersonaje> ListadoPersonajes
        {
            get
            {
                return listadoPersonajes;
            }
            private set //necesario para busqueda?
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
            set //necesario para seleccionar personaje?
            {
                personajeSeleccionado = value;
                NotifyPropertyChanged("PersonajeSeleccionado");
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
                buscarCommand.RaiseCanExecuteChanged();
            }
        }   

        public DelegateCommand BuscarCommand
        {
            get
            {
                return buscarCommand;
            }
        }

        public DelegateCommand DetallesCommand
        {
            get
            {
                return detallesCommand;
            }
        }

        #endregion

        #region commands

        #endregion
    }

}
