using System.Data.SqlClient;
using static System.Net.WebRequestMethods;
 
namespace CapaDAL.Conexion
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
            this.url = "https://swapi.dev/";
        }
        //Con parámetros por si quisiera cambiar la url
        public clsMyUrlDAL(string url)
        {
            this.url = url;
        }
        #endregion

        #region Propiedades
        public string Url { 
            get { return url; } 
        }
        #endregion

    }

}
