using CapaDAL.Listado;
using CapaDAL.Conexion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
    public static class clsManejadoraPersonaDAL
    {
        /// <summary>
        /// Funcion que devuelve una persona segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersonaByIdDAL(int id)
        {
            List<clsPersona> listaPersonas = clsListaPersonasDAL.listadoPersonasDAL();
            return listaPersonas.Find(x => x.Id == id);
        }

        /// <summary>
        /// funcion que borra una persona de la base de datos a partir de param entrada id y devuelve filas afectadas por borrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int deletePersonaDAL(int id)

        {
            int numeroFilasAfectadas = 0;

            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();
             
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.CommandText = "DELETE FROM Personas WHERE ID=@id";
            command.Connection = connection;

            
            numeroFilasAfectadas = command.ExecuteNonQuery();
            

            return numeroFilasAfectadas;

        }

        /// <summary>
        /// funcion que crea una persona a partir de la recibida de capa BL<UI, y la inserta en la BBDD
        /// </summary>
        /// <param name="persona"></param>
        public static void createPersonaDAL(clsPersona persona)
        {
            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@Nombre", persona.Nombre);
            command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
            command.Parameters.AddWithValue("@Telefono", persona.Telefono);
            command.Parameters.AddWithValue("@Direccion", persona.Direccion);
            command.Parameters.AddWithValue("@Foto", persona.Foto);
            command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNac);
            command.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
            command.CommandText = "INSERT INTO Personas (Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IDDepartamento) " +
                "VALUES(@Nombre,@Apellidos,@Telefono,@Direccion,@Foto,@FechaNacimiento,@IDDepartamento) ";
            command.Connection = connection;

            command.ExecuteNonQuery();            

        }

        /// <summary>
        /// edita una persona de la base de datos recibida por paramteros
        /// </summary>
        /// <param name="persona"></param>
        public static void editPersonaDAL(clsPersona persona)
        {
            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@ID", persona.Id);
            command.Parameters.AddWithValue("@Nombre", persona.Nombre);
            command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
            command.Parameters.AddWithValue("@Telefono", persona.Telefono);
            command.Parameters.AddWithValue("@Direccion", persona.Direccion);
            command.Parameters.AddWithValue("@Foto", persona.Foto);
            command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNac);
            command.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);

            command.CommandText = "UPDATE Personas SET Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, " +
                      "Direccion = @Direccion, Foto = @Foto, FechaNacimiento = @FechaNacimiento, " +
                      "IDDepartamento = @IDDepartamento WHERE ID = @ID";

            command.Connection = connection;

            command.ExecuteNonQuery();

            
        }

            /// <summary>
            /// funcion que devuelve id de la ultima persona de la lista extrida de la base de datos se usara solo en en create de DAL, BL no necesita copia
            /// </summary>
            /// <returns></returns>
            private static int getNewId()
        {
            List<clsPersona> listaPersonas = clsListaPersonasDAL.listadoPersonasDAL();
            int id = listaPersonas.Last().Id;

            return id;
        }
    }
}
