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
        /// funcion que devolvera un listado de personas extraido de una API aplicandole reglas de negocio pertinentes
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersona>> ListadoPersonasBL()
        {

            clsListaPersonasDAL oDal = new clsListaPersonasDAL();

            List<clsPersona> listado = await oDal.ListadoPersonasDAL();

            //si es viernes o sabado aplico regla de negocio de solo mostrar mayores de edad en listado
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday) {

                List<clsPersona> listadoAuxiliar = new List<clsPersona>();//creo listado donde guardo mayores de 18

                int edad; 

                //recorro lista
                foreach (clsPersona persona in listado)
                {
                    edad = DateTime.Today.Year - persona.FechaNac.Year;

                    if (edad >= 18)
                    {
                        listadoAuxiliar.Add(persona);//añado a lista axiliar mayores de 18
                    }
                }

                listado = listadoAuxiliar;//machaco el listado con el listado de solo los mayores de edad             
            }

            //si no es viernes o sabado devuelvo listado normal sin machacarlo con el auxiliar ni recorrer el codigo de arriba
            return listado;
        }

     
    }
}

