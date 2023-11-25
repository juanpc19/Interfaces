using Ej5tema9MVVM.Models.DAL;
using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Ej5tema9MVVM.Views.ViewModel
{
    internal class clsListaPersonasVM //usa interfaz notify property changed ?
    {
        #region atributos
        private ObservableCollection<clsPersona> listaFalsa;
        private clsPersona persona;
        //private readonly INavigation eventoNavegacion;
        #endregion

        #region constructores
        //constructor sin parametros con valor predeterminado para listFalsa extraido de capa datos
        public clsListaPersonasVM() {
            listaFalsa = clsListaPersonasFalsa.getListaFalsa();
        }

        //con o sin lista ?
        public clsListaPersonasVM(clsPersona persona)
        {
            this.persona = persona;
            listaFalsa = clsListaPersonasFalsa.getListaFalsa();
        }

        ////constructor con parametros que recibira un evento de navegacion desde view clsPersonaSeleccionada y 
        ////con valor predeterminado para listFalsa extraido de capa datos
        //public clsListaPersonasVM(INavigation navegation)
        //{
        //    this.eventoNavegacion = navegation;
        //    listaFalsa = clsListaPersonasFalsa.getListaFalsa();
        //}
        #endregion

        #region propiedades
        //ya tengo lista con el constructor no hace falta set
        public ObservableCollection<clsPersona> ListaFalsa
        {
            get { return listaFalsa; }

        }
        #endregion


        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }

            set
            {
                persona = value;

                //intento setear valor de persona con binding a persona clicked en lista?
               // new clsPersonaSeleccionada() { BindingContext = Persona };
            }

        }
        #endregion

        #region funciones
        //private async void DetallesPersona(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item is clsPersona persona)
        //    {
        //        await eventoNavegacion.PushAsync(new clsPersonaSeleccionadaVM(persona));
        //    }
        //}

        #endregion


    }
}
