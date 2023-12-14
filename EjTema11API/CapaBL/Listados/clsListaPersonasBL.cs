using CapaDAL.Listados;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listados
{
    public class clsListaPersonasBL
    {
        /// <summary>
        /// funcion que devolvera un listado de personas extraido de una API
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersona>> listadoPersonasBL()
        {

            clsListaPersonasDAL oDal = new clsListaPersonasDAL();

            List<clsPersona> listado = await oDal.listadoPersonasDAL();

            return listado;
        }

        public async Task<clsPersona> getPersonaId(int id)
        {
               clsPersona persona = new clsPersona();

            return persona;
        }
    }
}

