using CapaDAL.Manejadoras;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Manejadoras
{
    public class clsManejadoraDepBL
    {
        /// <summary>
        /// funcion que pasara a la capa DAL el departamento a crear tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> CrearDepBL(clsDepartamento departamento)
        {
            clsManejadoraDepDAL oDal = new clsManejadoraDepDAL();
            HttpStatusCode miCodigoRespuesta = await oDal.CrearDepDAL(departamento);

            return miCodigoRespuesta;
        }

        /// <summary>
        /// funcion que pasara a la capa DAL el departamento a editar tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EditarDepBL(clsDepartamento departamento)
        {
            clsManejadoraDepDAL oDal = new clsManejadoraDepDAL();
            HttpStatusCode miCodigoRespuesta = await oDal.EditarDepDAL(departamento);

            return miCodigoRespuesta;
        }

        /// <summary>
        /// funcion que pasara a la capa DAL el departamento a editar tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> BorrarDepBL(clsDepartamento departamento)
        {
            clsManejadoraDepDAL oDal = new clsManejadoraDepDAL();
            HttpStatusCode miCodigoRespuesta = await oDal.BorrarDepDAL(departamento);

            return miCodigoRespuesta;
        }

        public async Task<clsDepartamento> ObtenerDepartamentoPorIdPersonaBL(clsPersona personaRecibida)
        {
           clsDepartamento departamentoEncontrado = new clsDepartamento();

            clsManejadoraDepDAL oDAL = new clsManejadoraDepDAL();

            departamentoEncontrado = await oDAL.ObtenerDepartamentoPorIdPersonaDAL(personaRecibida);

           return departamentoEncontrado;
        }

    }
}
