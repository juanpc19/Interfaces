using CapaDAL.Listado;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listado
{
    public static class clsListaDepBL
    {

        /// <summary>
        /// funcion que deolvera un listado de los departamentos de la BBDD aplicando las reglas de negocio pertinentes
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> listadoDepartamentosBL()
        {
            List<clsDepartamento> listado = clsListaDepDAL.listadoDepartamentosDAL();
            //NO EXISTEN REGLAS 
            return listado;
        }
    }
}
