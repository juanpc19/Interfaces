using CapaDAL.Conexion;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDAL.Listados
{
    public class clsListaPersonasDAL
    {
            /// <summary>
            /// funcion que devolvera un listado de personas extraido de una API
            /// </summary>
            /// <returns></returns>
            public async Task<List<clsPersona>> ListadoPersonasDAL()
            {
                List<clsPersona> listado = new List<clsPersona>();//lista para guardar personas

                clsMyUrlDAL myUrl = new clsMyUrlDAL();//recojo valor de clsMyUrlDAL y se lo doy a myUrl
                Uri uriListaPersonas = new Uri($"{myUrl.Url}Personas");//creo uri concatenando url (IMPORTANTE HACER GET PARA OBTENER VALOR EN STRING Y NO EN OBJETO y endpoint (Personas)
                HttpClient miHttpClient = new HttpClient();//Creo cliente http que manejara mis peticiones
                HttpResponseMessage miCodigoRespuesta;//creo codigo http que guarde respuesta de servidor
                string jsonRecibido;//creo variable que guarda json recibido con todas las personas

                //abro try porque intento conectar a recurso externo
                try
                {
                    //guardo en codigo respuesta el codigo devuelto por mi cliente al intentar conectar con el get de uriListaPersonas
                    miCodigoRespuesta = await miHttpClient.GetAsync(uriListaPersonas);

                    //si el codigo es correcto 
                    if (miCodigoRespuesta.IsSuccessStatusCode)
                    {
                        //guardo en string el string recibido al atacar el end point uriListaPersonas
                        jsonRecibido = await miHttpClient.GetStringAsync(uriListaPersonas);
                        //me deshago de mi cliente porque ya no lo necesito(como cerrar conexion)
                        miHttpClient.Dispose();
                        //guardo en listado el resultado de aplicar deserializacion al string jsonRecibido
                        //pasando el json con las personas en formato diccionario a un List<clsPersona>
                        listado = JsonConvert.DeserializeObject<List<clsPersona>>(jsonRecibido);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en funcion listadoPersonasDAL(): {ex.Message}");
                }

                return listado;
            }

        }
}
