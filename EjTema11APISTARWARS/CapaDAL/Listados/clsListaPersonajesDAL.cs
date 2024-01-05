using CapaDAL.Conexion;
using CapaEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDAL.Listados
{
    public class clsListaPersonajesDAL
    {
        /// <summary>
        /// funcion asincrona que recibira listado de la API y lo deserializara en una lista de personajes
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersonaje>> ListadoPersonajesDAL()
        {
            List<clsPersonaje> miLista = new List<clsPersonaje>();//guarda lista de personajes

            clsMyUrlDAL miUrl = new clsMyUrlDAL();//contiene url
            Uri miUriListaPersonajes = new Uri($"{miUrl.Url}/api/people/");//contiene url y le doy end point api/people/
            HttpClient miCliente = new HttpClient();//cliente http a usar

            HttpResponseMessage miCodigoRespuesta;//guarda codigo respuesta
            string miJsonRecibido; //guarda json recibido

            try
            {
                miCodigoRespuesta = await miCliente.GetAsync(miUriListaPersonajes);//obtengo codigo respuesta mediante get para codigo
                if (miCodigoRespuesta.IsSuccessStatusCode)//si el codigo es correcto
                {
                    miJsonRecibido = await miCliente.GetStringAsync(miUriListaPersonajes);//obtengo json recibido mediante get en formato string
                    miCliente.Dispose();//me deshago del cliente para ahorra recursos

                    // encuentro el index del primer caracter de la subcadena que quiero extraer con index of y
                    // le sumo la longitud de la subcadena porque tampoco la quiero extraer
                    int copiaDesde = miJsonRecibido.IndexOf("\"results\":") + "\"results\":".Length;

                    // extraigo la subcadena a partir del index encontrado
                    string cadenaExtraida = miJsonRecibido.Substring(copiaDesde);
                 //   cadenaExtraida =
                 //   "[{\"name\":\"Luke Skywalker\",\"height\":\"172\",\"mass\":\"77\",\"hair_color\":\"blond\",\"skin_color\":\"fair\",\"eye_color\":\"blue\",\"birth_year\":\"19BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[\"https://swapi.dev/api/vehicles/14/\",\"https://swapi.dev/api/vehicles/30/\"],\"starships\":[\"https://swapi.dev/api/starships/12/\",\"https://swapi.dev/api/starships/22/\"],\"created\":\"2014-12-09T13:50:51.644000Z\",\"edited\":\"2014-12-20T21:17:56.891000Z\",\"url\":\"https://swapi.dev/api/people/1/\"},{\"name\":\"C-3PO\",\"height\":\"167\",\"mass\":\"75\",\"hair_color\":\"n/a\",\"skin_color\":\"gold\",\"eye_color\":\"yellow\",\"birth_year\":\"112BBY\",\"gender\":\"n/a\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/4/\",\"https://swapi.dev/api/films/5/\",\"https://swapi.dev/api/films/6/\"],\"species\":[\"https://swapi.dev/api/species/2/\"],\"vehicles\":[],\"starships\":[],\"created\":\"2014-12-10T15:10:51.357000Z\",\"edited\":\"2014-12-20T21:17:50.309000Z\",\"url\":\"https://swapi.dev/api/people/2/\"},{\"name\":\"R2-D2\",\"height\":\"96\",\"mass\":\"32\",\"hair_color\":\"n/a\",\"skin_color\":\"white, blue\",\"eye_color\":\"red\",\"birth_year\":\"33BBY\",\"gender\":\"n/a\",\"homeworld\":\"https://swapi.dev/api/planets/8/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/4/\",\"https://swapi.dev/api/films/5/\",\"https://swapi.dev/api/films/6/\"],\"species\":[\"https://swapi.dev/api/species/2/\"],\"vehicles\":[],\"starships\":[],\"created\":\"2014-12-10T15:11:50.376000Z\",\"edited\":\"2014-12-20T21:17:50.311000Z\",\"url\":\"https://swapi.dev/api/people/3/\"},{\"name\":\"Darth Vader\",\"height\":\"202\",\"mass\":\"136\",\"hair_color\":\"none\",\"skin_color\":\"white\",\"eye_color\":\"yellow\",\"birth_year\":\"41.9BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[],\"starships\":[\"https://swapi.dev/api/starships/13/\"],\"created\":\"2014-12-10T15:18:20.704000Z\",\"edited\":\"2014-12-20T21:17:50.313000Z\",\"url\":\"https://swapi.dev/api/people/4/\"},{\"name\":\"Leia Organa\",\"height\":\"150\",\"mass\":\"49\",\"hair_color\":\"brown\",\"skin_color\":\"light\",\"eye_color\":\"brown\",\"birth_year\":\"19BBY\",\"gender\":\"female\",\"homeworld\":\"https://swapi.dev/api/planets/2/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[\"https://swapi.dev/api/vehicles/30/\"],\"starships\":[],\"created\":\"2014-12-10T15:20:09.791000Z\",\"edited\":\"2014-12-20T21:17:50.315000Z\",\"url\":\"https://swapi.dev/api/people/5/\"},{\"name\":\"Owen Lars\",\"height\":\"178\",\"mass\":\"120\",\"hair_color\":\"brown, grey\",\"skin_color\":\"light\",\"eye_color\":\"blue\",\"birth_year\":\"52BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/5/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[],\"starships\":[],\"created\":\"2014-12-10T15:52:14.024000Z\",\"edited\":\"2014-12-20T21:17:50.317000Z\",\"url\":\"https://swapi.dev/api/people/6/\"},{\"name\":\"Beru Whitesun lars\",\"height\":\"165\",\"mass\":\"75\",\"hair_color\":\"brown\",\"skin_color\":\"light\",\"eye_color\":\"blue\",\"birth_year\":\"47BBY\",\"gender\":\"female\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/5/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[],\"starships\":[],\"created\":\"2014-12-10T15:53:41.121000Z\",\"edited\":\"2014-12-20T21:17:50.319000Z\",\"url\":\"https://swapi.dev/api/people/7/\"},{\"name\":\"R5-D4\",\"height\":\"97\",\"mass\":\"32\",\"hair_color\":\"n/a\",\"skin_color\":\"white, red\",\"eye_color\":\"red\",\"birth_year\":\"unknown\",\"gender\":\"n/a\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\"],\"species\":[\"https://swapi.dev/api/species/2/\"],\"vehicles\":[],\"starships\":[],\"created\":\"2014-12-10T15:57:50.959000Z\",\"edited\":\"2014-12-20T21:17:50.321000Z\",\"url\":\"https://swapi.dev/api/people/8/\"},{\"name\":\"Biggs Darklighter\",\"height\":\"183\",\"mass\":\"84\",\"hair_color\":\"black\",\"skin_color\":\"light\",\"eye_color\":\"brown\",\"birth_year\":\"24BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\"],\"species\":[],\"vehicles\":[],\"starships\":[\"https://swapi.dev/api/starships/12/\"],\"created\":\"2014-12-10T15:59:50.509000Z\",\"edited\":\"2014-12-20T21:17:50.323000Z\",\"url\":\"https://swapi.dev/api/people/9/\"},{\"name\":\"Obi-Wan Kenobi\",\"height\":\"182\",\"mass\":\"77\",\"hair_color\":\"auburn, white\",\"skin_color\":\"fair\",\"eye_color\":\"blue-gray\",\"birth_year\":\"57BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/20/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/4/\",\"https://swapi.dev/api/films/5/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[\"https://swapi.dev/api/vehicles/38/\"],\"starships\":[\"https://swapi.dev/api/starships/48/\",\"https://swapi.dev/api/starships/59/\",\"https://swapi.dev/api/starships/64/\",\"https://swapi.dev/api/starships/65/\",\"https://swapi.dev/api/starships/74/\"],\"created\":\"2014-12-10T16:16:29.192000Z\",\"edited\":\"2014-12-20T21:17:50.325000Z\",\"url\":\"https://swapi.dev/api/people/10/\"}]";

                    cadenaExtraida = cadenaExtraida.Remove(cadenaExtraida.Length - 1);

                    //aqui cambio json recibidio por cadena estraida por parte que no requiero previa a results
                    miLista = JsonConvert.DeserializeObject<List<clsPersonaje>>(cadenaExtraida);//deserializo el json recibido en una lista de personajes a partir de string extraida
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en funcion ListadoPersonajesDAL(): {e.Message}");
            }

            return miLista;
        }

        /// <summary>
        /// funcion asincrona que recibira un nombre de personaje como identificador y devolvera el personaje con ese nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public async Task<clsPersonaje> GetPersonajeByIdDAL(string nombre)
        {
            clsPersonaje miPersonaje = new clsPersonaje();

            clsMyUrlDAL miUrl = new clsMyUrlDAL();
            Uri miUriPersonaje = new Uri($"{miUrl.Url}/api/people/{nombre}");
            HttpClient miCliente = new HttpClient();

            HttpResponseMessage miCodigoRespuesta;
            string miJsonRecibido;

            try
            {
                miCodigoRespuesta = await miCliente.GetAsync(miUriPersonaje);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    miJsonRecibido = await miCliente.GetStringAsync(miUriPersonaje);
                    miCliente.Dispose();
                    miPersonaje = JsonConvert.DeserializeObject<clsPersonaje>(miJsonRecibido);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en funcion GetPersonajeByIdDAL(): {e.Message}");
            }

            return miPersonaje;
        }

        /// <summary>
        /// funcion asincrona que recibira una url como y devolvera el nombre del planeta de esa url
        /// </summary>
        /// <param name="urlPlaneta"></param>
        /// <returns></returns>
        public async Task<string> ObtenerNombrePlanetaDAL(string urlPlaneta)
        {

            string nombrePlaneta = "";

            Uri miUriPlanetaPersonaje = new Uri(urlPlaneta);
            HttpClient miCliente = new HttpClient();

            HttpResponseMessage miCodigoRespuesta;
            string miJsonRecibido;

            try
            {
                miCodigoRespuesta = await miCliente.GetAsync(miUriPlanetaPersonaje);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    miJsonRecibido = await miCliente.GetStringAsync(miUriPlanetaPersonaje);
                    miCliente.Dispose();

                    // convierte la string del jsonRecibido en un documento json para mas facil manipulacion del mismo
                    JsonDocument documentoJson = JsonDocument.Parse(miJsonRecibido);

                    // obtiene el elemento raiz del documento json (todo el jsonRecibido pero con una especie de index para navegar sus claves/valores) 
                    JsonElement elementoRaiz = documentoJson.RootElement;

                    // accedo al vaoor de la clave "name" del elemento raiz
                    nombrePlaneta = elementoRaiz.GetProperty("name").GetString();

                    // me deshago del recursos del documento json
                    documentoJson.Dispose();
                }
            } catch (Exception e)
            {
                Console.WriteLine($"Error en funcion ObtenerNombrePlanetaDAL(): {e.Message}");
            }   

            return nombrePlaneta;
        }

    }
}
