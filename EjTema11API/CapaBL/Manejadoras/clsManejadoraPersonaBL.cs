using CapaDAL.Conexion;
using CapaDAL.Manejadoras;
using CapaEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Manejadoras
{
    public class clsManejadoraPersonaBL
    {
        /// <summary>
        /// funcion que pasara a la capa DAL la persona a crear tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> CrearPersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL oDal = new clsManejadoraPersonaDAL();
            HttpStatusCode miCodigoRespuesta = await oDal.CrearPersonaDAL(persona);

            return miCodigoRespuesta;
        }

        /// <summary>
        /// funcion que pasara a la capa DAL la persona a editar tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EditarPersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL oDal = new clsManejadoraPersonaDAL();
            HttpStatusCode miCodigoRespuesta = await oDal.EditarPersonaDAL(persona);

            return miCodigoRespuesta;
        }


        /// <summary>
        /// funcion que pasara a la capa DAL la persona a editar tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> BorrarPersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL oDal = new clsManejadoraPersonaDAL();
            HttpStatusCode miCodigoRespuesta = await oDal.BorrarPersonaDAL(persona);

            return miCodigoRespuesta;
        }

    }
}
