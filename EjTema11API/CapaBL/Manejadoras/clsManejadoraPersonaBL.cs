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
        /// funcion que pasara a la capa DAL la persona a borrar tras aplicar reglas de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> BorrarPersonaBL(clsPersona persona)
        {
            HttpStatusCode miCodigoRespuesta;

            //si es viernes no hago operacion borrar con api y devuelvo forbidden en codigo respuesta,
            //ademas hago toast con mensaje de no eliminar los domingos en deletepersonavm
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                //devuelvo forbiden como status code para indicar que no se puede eliminar ese dia por restriccion en servidor
                
                miCodigoRespuesta = HttpStatusCode.Forbidden;
            } 
            //de lo contrario procedoa eliminar persona normalmente
            else
            {
                clsManejadoraPersonaDAL oDal = new clsManejadoraPersonaDAL();
                miCodigoRespuesta = await oDal.BorrarPersonaDAL(persona);
            }
           

            return miCodigoRespuesta;
        }

    }
}
