using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDeClases;

namespace Ej5tema9MVVM.Views.ViewModel
{
    internal class clsPersonaSeleccionadaVM
    {

        #region atributos
        private clsPersona persona;
        #endregion

        #region constructores
        public clsPersonaSeleccionadaVM()
        {

        }

        public clsPersonaSeleccionadaVM(clsPersona persona)
        {
            this.persona = persona;
        }
        #endregion

        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }

            set
            {
                persona = value;

                //intento setear valor de persona con binding a persona clicked en lista
                 //new clsPersonaSeleccionada() { BindingContext = Persona }; 
            }

        }
        #endregion

    }
}

