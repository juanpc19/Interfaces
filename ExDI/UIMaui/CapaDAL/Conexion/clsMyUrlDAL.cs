using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIMaui.CapaDAL.Conexion
{
    public class clsMyUrlDAL
    {
        #region atributos
        public string url;
        #endregion

        //Constructores
        #region constructores
        public clsMyUrlDAL()
        {
            this.url = "http://localhost:5264/api/";
        }
        //Con parámetros por si quisiera cambiar la url
        public clsMyUrlDAL(string url)
        {
            this.url = url;
        }
        #endregion

        #region Propiedades
        public string Url
        {
            get { return url; }
        }
        #endregion

    }
}
