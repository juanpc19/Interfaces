using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMaui.CapaDAL.Conexion;

namespace UIMaui.CapaDAL.Listados
{
    /// <summary>
    /// funcion que devolvera un listado de departamentos extraido de una API
    /// </summary>
    /// <returns></returns>
    public class clsListaDepartamentosDAL
    {
        public async Task<List<Entidades.clsDepartamento>> ListadoDepsDAL()
        {
            List<clsDepartamento> listado = new List<clsDepartamento>();

            clsMyUrlDAL miUrl = new clsMyUrlDAL();
            Uri miUriDeps = new Uri($"{miUrl.Url}Departamentos");
            HttpClient miCliente = new HttpClient();
            HttpResponseMessage miCodigoRespuesta;
            string jsonRecibido;

            try
            {
                miCodigoRespuesta = await miCliente.GetAsync(miUriDeps);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    jsonRecibido = await miCliente.GetStringAsync(miUriDeps);
                    miCliente.Dispose();
                    listado = JsonConvert.DeserializeObject<List<clsDepartamento>>(jsonRecibido);
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
