using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMaui.CapaDAL.Listados;

namespace UIMaui.CapaBL.Listados
{
    public class clsListaDepartamentosBL
    {
        /// <summary>
        /// funcion que devolvera un listado de departamentos extraido de una API aplicandole reglas de negocio pertinentes
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsDepartamento>> ListadoDepsBL()
        {
            clsListaDepartamentosDAL oDal = new clsListaDepartamentosDAL();

            List<clsDepartamento> listado = await oDal.ListadoDepsDAL();

            return listado;
        }
    }
}
