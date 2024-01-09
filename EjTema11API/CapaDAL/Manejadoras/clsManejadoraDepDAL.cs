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
    public class clsManejadoraDepDAL
    {
        /// <summary>
        /// funcion que usara la API para crear un departamento
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> CrearDepDAL(clsDepartamento departamento)
        {
            clsMyUrlDAL myUrl = new clsMyUrlDAL();//recojo valor de clsMyUrlDAL y se lo doy a myUrl
            Uri uriListaDeps = new Uri($"{myUrl.Url}Departamentos");//creo uri concatenando url (IMPORTANTE HACER GET PARA OBTENER VALOR EN STRING Y NO EN OBJETO y endpoint (departamentos))
            HttpClient miHttpClient = new HttpClient();//Creo cliente http que manejara mis peticiones
            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();//creo codigo http que guarde respuesta de servidor
            string datos = JsonConvert.SerializeObject(departamento);//creo variable que guardara datos de la persona objeto a crear
            HttpContent contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");//contenido http que guardara los datosen formato json para trabajr con la API 

            try
            {
                //guardo en miCodigoRespuesta el resultado de intentar añadir el departamento (contenido) en la ruta departamentos
                miCodigoRespuesta = await miHttpClient.PostAsync(uriListaDeps, contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion CrearDepDAL(): {ex.Message}");
            }

            return miCodigoRespuesta.StatusCode;
        }

        /// <summary>
        /// funcion que usara la API para editar un departamento
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EditarDepDAL(clsDepartamento departamento)
        {
            clsMyUrlDAL myUrl = new clsMyUrlDAL();
            Uri uriListaDeps = new Uri($"{myUrl.Url}Departamentos/{departamento.Id}");
            HttpClient miHttpClient = new HttpClient();
            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();
            string datos = JsonConvert.SerializeObject(departamento);
            HttpContent contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

            try
            {
                //guardo en miCodigoRespuesta el resultado de intentar editar el departamento (contenido) en la ruta departamentos/id departamento recibido
                miCodigoRespuesta = await miHttpClient.PutAsync(uriListaDeps, contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion EditarDepDAL(): {ex.Message}");
            }

            return miCodigoRespuesta.StatusCode;
        }

        /// <summary>
        /// funcion que usara la API para borrar un departamento
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> BorrarDepDAL(clsDepartamento departamento)
        {
            clsMyUrlDAL myUrl = new clsMyUrlDAL();
            Uri uriListaDeps = new Uri($"{myUrl.Url}Departamentos/{departamento.Id}");
            HttpClient miHttpClient = new HttpClient();
            HttpResponseMessage miCodigoRespuesta = new HttpResponseMessage();


            try
            {
                //guardo en miCodigoRespuesta el resultado de intentar borrar el departamento  en la ruta departamentos/id departamento recibido
                miCodigoRespuesta = await miHttpClient.DeleteAsync(uriListaDeps);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcion DeletePersonaDAL(): {ex.Message}");
            }

            return miCodigoRespuesta.StatusCode;
        }


    }
}
