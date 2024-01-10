using CapaDAL.Listados;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listados
{
    public class clsListaDepsBL
    {
        /// <summary>
        /// funcion que devolvera un listado de departamentos extraido de una API aplicandole reglas de negocio pertinentes
        /// </summary>
        /// <returns></returns>
        public async Task <List<clsDepartamento>> ListadoDepsBL()
        {
            clsListaDepsDAL oDal= new clsListaDepsDAL();

            List<clsDepartamento> listado = await oDal.ListadoDepsDAL();

            return listado;
        }

    }
}
