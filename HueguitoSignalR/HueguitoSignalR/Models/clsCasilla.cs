using HueguitoSignalR.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueguitoSignalR.Models
{
    public class clsCasilla: clsVMBase
    {
        #region atributos 
        string imagenMostrada;//ruta src
        bool meToca;

        #endregion

        #region constructor
        public clsCasilla()
        {
            imagenMostrada = "casilla_roja.png";

        }

        public clsCasilla(bool meToca)
        {
            this.MeToca = meToca;//uso la propiedad para evitar otra linea de codigo con notify
             
        }
        #endregion
        #region propiedades
        public string ImagenMostrada { get { return imagenMostrada; } }

        //servidor pulsa una casilla al hacerlo entra en este setter y cambia bool
        public bool MeToca { 
            get { return meToca; }
            set { meToca = value;
                imagenMostrada = "casilla_verde.png";
                NotifyPropertyChanged("ImagenMostrada");

            }

        }
        #endregion

    }
}
