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
        /// <summary>
        /// funcion que usara la API para crear una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
            public async Task<HttpStatusCode> CrearPersonaDAL(clsPersona persona)
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
                    Console.WriteLine($"Error en funcion CrearPersonaDAL(): {ex.Message}");
                }
                
                return miCodigoRespuesta.StatusCode;
            }

        /// <summary>
        /// funcion que usara la API para editar una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EditarPersonaDAL(clsPersona persona)
        {
            clsMyUrlDAL myUrl = new clsMyUrlDAL(); 
            Uri uriListaPersonas = new Uri($"{myUrl.Url}Personas/{persona.Id}"); 
            HttpClient miHttpClient = new HttpClient(); 
            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage(); 
            string datos = JsonConvert.SerializeObject(persona); 
            HttpContent contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json"); 

            try
            {
                //guardo en miCodigoRespuesta el resultado de intentar editar la persona (contenido) en la ruta Personas/id persona recibida
                miCodigoRespuesta = await miHttpClient.PutAsync(uriListaPersonas, contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion EditarPersonaDAL(): {ex.Message}");
            }
            
            return miCodigoRespuesta.StatusCode;
        }

        /// <summary>
        /// funcion que usara la API para borrar una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> BorrarPersonaDAL(clsPersona persona)
        {
            clsMyUrlDAL myUrl = new clsMyUrlDAL();
            Uri uriListaPersonas = new Uri($"{myUrl.Url}Personas/{persona.Id}");
            HttpClient miHttpClient = new HttpClient();
            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();
            

            try
            {
                //guardo en miCodigoRespuesta el resultado de intentar borrar la persona  en la ruta Personas/id persona recibida
                miCodigoRespuesta = await miHttpClient.DeleteAsync(uriListaPersonas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion EditarPersonaDAL(): {ex.Message}");
            }
            
            return miCodigoRespuesta.StatusCode;
        }
    }
}
