using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClaseHandler
    {

        //
        public static SqlConnection miConexion;

        public static SqlCommand miComando;

        public static SqlDataReader miLector;





        /// <summary>
        /// Método para eliminar un combate por su ID.
        /// </summary>
        /// <param name="id">ID del combate a eliminar.</param>
        /// <returns>Número de filas afectadas.</returns>
        public static int deleteCombateDAL(int idPer1, int idPer2)
        {
            int numeroFilasAfectadas = 0;

            miConexion = new SqlConnection();
            miComando = new SqlCommand();

            miComando.Parameters.Add("@idPer1", System.Data.SqlDbType.Int).Value = idPer1;
            miComando.Parameters.Add("@idPer2", System.Data.SqlDbType.Int).Value = idPer2;

            try
            {
                miConexion.ConnectionString = EnlaceBBDD.Conexion(); // Reemplaza con tu cadena de conexión real
                miConexion.Open();

                miComando.CommandText = "DELETE FROM Combates WHERE IdPersonaje1 = @idPer1 AND IdPersonaje2 = @idPer2";

                miComando.Connection = miConexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }

            return numeroFilasAfectadas;
        }






    }
}
