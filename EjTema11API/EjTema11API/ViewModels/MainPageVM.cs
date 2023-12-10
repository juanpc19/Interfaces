using CapaDAL.Listado;
using CapaEntidades;
using EjTema10MVVMCommands.ViewModels.Utilidades;
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
        #region atributos
        private ObservableCollection<clsPersona> listaPersonas;
        private clsPersona personaSeleccionada;
        #endregion

        #region constructores
        public MainPageVM()
        {
            RecogerListadoBL();
        }
        #endregion

        #region propiedades
        public ObservableCollection<clsPersona> ListaPersonas
        {
            get { return listaPersonas; } 
            set { listaPersonas = value; NotifyPropertyChanged("ListaPersonas"); } 
        }
        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
        }

        #endregion

        #region metodos
        private async void RecogerListadoBL()
        {
            try
            {
                clsListaPersonasBL oBl = new clsListaPersonasBL();
                List<clsPersona> listaAuxiliar = await oBl.listadoPersonasBL();
                ListaPersonas = new ObservableCollection<clsPersona>(listaAuxiliar);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion RecogerListado(): {ex.Message}");
            }       
        }
        #endregion

    }
}
