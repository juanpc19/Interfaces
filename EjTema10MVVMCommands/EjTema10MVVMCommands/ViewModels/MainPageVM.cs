
using EjTema10MVVMCommands.Models.DAL;
using EjTema10MVVMCommands.Models.Entidades;
using EjTema10MVVMCommands.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema10MVVMCommands.ViewModels
{
    internal class MainPageVM : clsVMBase
    {
        #region atributos
        private DelegateCommand buscarCommand;
        private DelegateCommand eliminarCommand;
        private List<clsPersona2> listaPersonas;
        private clsPersona2 personaSeleccionada;
        private string textoBusqueda;
        #endregion


        #region Constructores
        public MainPageVM()
        {
            listaPersonas = clsListaPersonasFalsa.getListaFalsa();
            buscarCommand = new DelegateCommand(buscarCommandExecute, buscarCommandCanExecute);
            eliminarCommand = new DelegateCommand(eliminarCommandExecute, eliminarCommandCanExecute);


        }

        
        #endregion

        #region propiedades
        public DelegateCommand BuscarCommand 
        { get { return buscarCommand; } }

        public DelegateCommand DelegateCommand 
        { get { return eliminarCommand; } }

        public List <clsPersona2> ListaPersonas
        { get { return listaPersonas; } }

        public clsPersona2 PersonaSeleccionada
        {  get { return personaSeleccionada; } }

        public string TextoBusqueda
        { get { return textoBusqueda; } }


        #endregion

        #region comandos
        private bool eliminarCommandCanExecute()
        {
            bool habilitadoEliminar = false;

            if (personaSeleccionada != null)
            {
                habilitadoEliminar = true;
            }
            return habilitadoEliminar;
        }

        private void eliminarCommandExecute()
        {
            listaPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListaPersonas");
        }

        private bool buscarCommandCanExecute()
        {
            bool HabilitadoBuscar = false;
            if(!string.IsNullOrEmpty(textoBusqueda))
            {
                HabilitadoBuscar = true;

            }
            return HabilitadoBuscar;
        }
        private void buscarCommandExecute()
        {
            listaPersonas.FirstOrDefault();
        }

      

        #endregion

        #region Metodos y funciones

        #endregion
    }
}
