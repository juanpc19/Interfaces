using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarizer.Models
{
    internal class clsCita
    {

        #region atributos
        private string nombre;
        private string direccion;
        private int telefono;
        private string observaciones;
        #endregion

        #region constructores
        public clsCita() {
        
        }
        public clsCita(string nombre, string direccion, int telefono, string observaciones)
        {
            this.nombre = nombre;   
            this.direccion = direccion; 
            this.telefono = telefono;   
            this.observaciones = observaciones;
        }
        #endregion

        #region
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Direccion { 
            get { return direccion; } 
            set { direccion = value; } }


        public int Telefono { 
            get { return telefono; } 
            set { telefono = value; } }

        public string Observaciones { 
            get { return observaciones; } 
            set { observaciones = value; }
        }
        #endregion

        #region funciones
        //public string 

        #endregion
    }
}
