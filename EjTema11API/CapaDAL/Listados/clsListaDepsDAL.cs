using CapaDAL.Conexion;
using CapaEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Listados
{
    public class clsListaDepsDAL
    {
        public async Task<List<clsDepartamento>> ListadoDepsDAL()
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
