using CapaDAL.Listado;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
    public static class clsManejadoraPersonaBL
    {

        /// <summary>
        /// Funcion que devuelve una persona segun su Id usando DAL aplicando las reglas de negocio oportunas
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersonaByIdBL(int id)
        {
            clsPersona oPersona = clsManejadoraPersonaDAL.getPersonaByIdDAL(id);

            return oPersona;
        }

        /// <summary>
        /// FUNCION QUE DEVUELVE EL NUMERO DE FILAS AFECTADAS  AL BORRAR LA PERSONA QUE RECIBE APLICANDO LAS REGLAS DE NEGOCIO
        /// Post: mi salida sera 0 cuando no haya errores, 1 si se ha borrado, -1 si hay error en borrado en bl
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <returns>devuelve el numero de personas afectadas</returns>
        public static int deletePersonaBL(int id)
        {
            int numeroFilasAfectadas = 0;

            DateTime fechaActual = DateTime.Now;

            if (fechaActual.DayOfWeek == DayOfWeek.Monday)
            {
                numeroFilasAfectadas = -1;
            }
            else
            {
                numeroFilasAfectadas = clsManejadoraPersonaDAL.deletePersonaDAL(id);
            }
            return numeroFilasAfectadas;

        }

        /// <summary>
        /// Funcion que aplicara reglas de negocio pertinentes antes de darle a la capa DAL una persona que añadir a la BBDD
        /// </summary>
        /// <param name="persona"></param>
        public static void createPersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL.createPersonaDAL(persona);
        }

        /// <summary>
        /// Funcion que aplicara reglas de negocio pertinentes antes de darle a la capa DAL una persona que editar en la BBDD
        /// </summary>
        /// <param name="persona"></param>
        public static void editPersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL.editPersonaDAL(persona);

        }
    }
}
