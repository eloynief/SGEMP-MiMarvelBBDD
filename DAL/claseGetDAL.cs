using Entities;
using Microsoft.Data.SqlClient;
using Models;

namespace DAL
{
    public class claseGetDAL
    {
        //
        public static SqlConnection miConexion;

        public static SqlCommand miComando;

        public static SqlDataReader miLector;


        /// <summary>
        /// Metodo que saca la lista de personajes de la BBDD de azure
        /// </summary>
        /// <returns></returns>
        public static List<clasePersonaje> listaPersonajesAzure()
        {


            List<clasePersonaje> listado = new List<clasePersonaje>();

            //
            miConexion = new SqlConnection();

            miComando = new SqlCommand();


            clasePersonaje oPersonajes;

            try

            {

                miConexion.ConnectionString = EnlaceBBDD.Conexion();

                miConexion.Open();


                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM personajes";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();



                //Si hay lineas en el lector

                if (miLector.HasRows)

                {
                    //
                    while (miLector.Read())

                    {

                        int idPer = (int)miLector["IdPersonaje"];

                        string nomPer= (string)miLector["Nombre"];

                        string fotoPer = (string)miLector["Foto"];
                        //


                        //oPersonajes.IdPersonaje = (int)miLector["IdPersonaje"];

                        //oPersonajes.Nombre = (string)miLector["Nombre"];



                        //comprobamos si los valores introducidos no son null

                        //Si sospechamos que el campo de la fechaNac puede ser Null en la BBDD


                        if (miLector["Foto"] != System.DBNull.Value)
                        {
                            //oPersonajes.Foto = (string)miLector["Foto"];
                        }

                        oPersonajes = new clasePersonaje(idPer,nomPer, fotoPer);

                        listado.Add(oPersonajes);

                    }

                }

                miLector.Close();

                miConexion.Close();





            }

            catch (SqlException exSql)

            {

                throw exSql;

            }


            return listado;


        }



        /// <summary>
        /// Metodo que saca la lista de personajes de la BBDD de azure
        /// </summary>
        /// <returns></returns>
        public static List<claseCombate> listaCombatesAzure()
        {
            List<claseCombate> listadoCombates = new List<claseCombate>();

            //
            miConexion = new SqlConnection();

            miComando = new SqlCommand();

            claseCombate oCombates;

            try
            {

                miConexion.ConnectionString = EnlaceBBDD.Conexion();

                miConexion.Open();


                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM combates";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                //Si hay lineas en el lector

                if (miLector.HasRows)
                {

                    while (miLector.Read())
                    {
                        //
                        oCombates = new claseCombate();


                        //
                        oCombates.Fecha = (DateTime)miLector["Fecha"];


                        oCombates.IdPersonaje1 = (int)miLector["IdPersonaje1"];

                        oCombates.IdPersonaje2 = (int)miLector["IdPersonaje2"];


                        oCombates.Puntuacion1 = (int)miLector["PuntuacionPersonaje1"];

                        oCombates.Puntuacion2 = (int)miLector["PuntuacionPersonaje2"];



                    }


                }


            }
            catch (SqlException exSql)
            {

                throw exSql;

            }



            return listadoCombates;
        }

        /// <summary>
        /// funcion para obtener la 
        /// </summary>
        /// <returns></returns>
        public static List<clsPersonajePuntos> ObtenerTablaClasificaciones()
        {
            var personajes = listaPersonajesAzure();
            var combates = listaCombatesAzure();
            var clasificaciones = new List<clsPersonajePuntos>();

            foreach (var personaje in personajes)
            {
                var puntuacionTotal = combates
                    .Where(c => c.IdPersonaje1 == personaje.IdPersonaje || c.IdPersonaje2 == personaje.IdPersonaje)
                    .Sum(c => (c.IdPersonaje1 == personaje.IdPersonaje ? c.Puntuacion1 : 0) + (c.IdPersonaje2 == personaje.IdPersonaje ? c.Puntuacion2 : 0));

                clasificaciones.Add(new clsPersonajePuntos
                {
                    Nombre = personaje.Nombre,
                    Puntuacion = puntuacionTotal
                });
            }

            return clasificaciones.OrderByDescending(p => p.Puntuacion).ToList();
        }






    }
}
