using CapaDAL.Conexion;
using CapaEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
        public class clsManejadoraPersonaDAL
        {
            public async Task<HttpStatusCode> crearPersonaDAL(clsPersona persona)
            {
                clsMyUrlDAL myUrl = new clsMyUrlDAL();//recojo valor de clsMyUrlDAL y se lo doy a myUrl
                Uri uriListaPersonas = new Uri($"{myUrl.Url}Personas");//creo uri concatenando url (IMPORTANTE HACER GET PARA OBTENER VALOR EN STRING Y NO EN OBJETO y endpoint (Personas))
                HttpClient miHttpClient = new HttpClient();//Creo cliente http que manejara mis peticiones
                HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();//creo codigo http que guarde respuesta de servidor
                string datos = JsonConvert.SerializeObject(persona);//creo variable que guardara datos de la persona objeto a crear
                HttpContent contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");//contenido http que guardara los datosen formato json para trabajr con la API 

                try
                {
                    //guardo en miCodigoRespuesta el resultado de intentar añadir la persona (contenido) en la ruta Personas
                    miCodigoRespuesta = await miHttpClient.PostAsync(uriListaPersonas, contenido);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en funcion crearPersonaDAL(): {ex.Message}");
                }
                //devuelvo el estado del codigo (deberia ser 200 o 201)
                return miCodigoRespuesta.StatusCode;
            }

        }
}
