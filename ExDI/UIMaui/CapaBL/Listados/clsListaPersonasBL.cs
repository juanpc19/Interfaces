using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMaui.CapaDAL.Listados;

namespace UIMaui.CapaBL.Listados
{
    public class clsListaPersonasBL
    {
        /// <summary>
        /// funcion que devolvera un listado de personas extraido de una API aplicandole reglas de negocio pertinentes
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersona>> ListadoPersonasBL()
        {

            clsListaPersonasDAL oDal = new clsListaPersonasDAL();

            List<clsPersona> listado = await oDal.ListadoPersonasDAL();

            return listado;
        }
    }
}
