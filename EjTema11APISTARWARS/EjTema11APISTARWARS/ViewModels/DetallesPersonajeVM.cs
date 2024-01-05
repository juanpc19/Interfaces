using CapaEntidades;
using EjTema11APIPersonas.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema11APISTARWARS.ViewModels
{
    public class DetallesPersonajeVM : clsVMBase 
    {
       
        #region atributos
        private clsPersonaje personaje;
        private string planeta;
        #endregion

        #region constructores
        public DetallesPersonajeVM()
        {
            this.personaje = new clsPersonaje();
            this.planeta = "a";
        }
        public DetallesPersonajeVM(clsPersonaje personaje, string planeta)
        {
            this.personaje = personaje;
            this.planeta = planeta;
        }
        #endregion

        #region propiedades
        public clsPersonaje Personaje
        {
            get
            {
                return personaje;
            }
            private set //privado porque no se va a modificar en este ejercicio y prefiero tenerlo ya escrito
            {
                personaje = value;
                NotifyPropertyChanged("Personaje");
            }
        }

        public string Planeta
        {
            get
            {
                return planeta;
            }
            private set //privado porque no se va a modificar en este ejercicio y prefiero tenerlo ya escrito
            {
                planeta = value;
                NotifyPropertyChanged("Planeta");
            }
        }
        #endregion

    


    }
}
