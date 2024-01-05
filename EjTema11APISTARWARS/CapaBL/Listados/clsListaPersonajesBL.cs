using CapaDAL.Listados;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listados
{
    public class clsListaPersonajesBL
    {

        /// <summary>
        /// funcion que recibira listado de capa DAL y lo devolvera a la UI tras aplicar reglas de negocio pertienentes
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersonaje>> ListadoPersonajesBL()
        {
            clsListaPersonajesDAL oDal = new clsListaPersonajesDAL();
            List<clsPersonaje> listado = await oDal.ListadoPersonajesDAL();

            return listado;
        }

        /// <summary>
        /// funcion que recibira personaje de capa DAL y lo devolvera a la UI tras aplicar reglas de negocio pertienentes
        /// </summary>
        /// <returns></returns>
        public async Task<clsPersonaje> GetPersonajeByIdDAL(string nombre)
        {
            clsListaPersonajesDAL oDal = new clsListaPersonajesDAL();
            clsPersonaje personaje = await oDal.GetPersonajeByIdDAL(nombre);

            return personaje;
        }

        /// <summary>
        /// funcion que recibira nombrePlaneta de capa DAL y lo devolvera a la UI tras aplicar reglas de negocio pertienentes
        /// </summary>
        /// <param name="urlPlaneta"></param>
        /// <returns></returns>
        public async Task<string> ObtenerNombrePlanetaBL(string urlPlaneta)
        {
            clsListaPersonajesDAL oDal = new clsListaPersonajesDAL();
            string nombrePlaneta = await oDal.ObtenerNombrePlanetaDAL(urlPlaneta);

            return nombrePlaneta;
        }

    }
}
