using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL.Conexion;
using CapaEntidades;

namespace CapaDAL.Listado
{
    public static class clsListaPersonasDAL
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas extraido de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoPersonasDAL()
        {
            List<clsPersona> listado = new List<clsPersona>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona;
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM personas";

            
                connection.Close();
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)reader["ID"];
                        oPersona.Nombre = (string)reader["Nombre"];
                        oPersona.Apellidos = (string)reader["Apellidos"];
                        oPersona.Telefono = (string)reader["Telefono"];
                        oPersona.Direccion = (string)reader["Direccion"];
                        oPersona.Foto = (string)reader["Foto"];
                        oPersona.FechaNac = (DateTime)reader["FechaNacimiento"];
                        oPersona.IdDepartamento = (int)reader["IDDepartamento"];
                        listado.Add(oPersona);
                    }
                }
                reader.Close();
                connection.Close();

            return listado;
        }

      
    }
}
