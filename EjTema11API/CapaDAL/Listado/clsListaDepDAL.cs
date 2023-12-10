using CapaDAL.Conexion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Listado
{
    public static class clsListaDepDAL
    {
        /// <summary>
        /// funcion que deolvera un listado de los departamentos de la BBDD  
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> listadoDepartamentosDAL()
        {

            List<clsDepartamento> listado = new List<clsDepartamento>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsDepartamento oDepartamento;
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM departamentos";

            connection.Close();
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    oDepartamento= new clsDepartamento();
                    oDepartamento.Id = (int)reader["ID"];
                    oDepartamento.NombreDep = (string)reader["Nombre"];
                    listado.Add(oDepartamento);
                }
            }

            reader.Close();
            connection.Close();
           

            return listado;
        }
    }
}
