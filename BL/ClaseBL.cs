using DAL;
using Entities;
using Models;

namespace BL
{
    public class ClaseBL
    {


        /// <summary>
        /// devuelve la lista de la DAL para pasarla al controller
        /// </summary>
        /// <returns></returns>
        public static List<clasePersonaje> listaPersonajesAzureBL()
        {


            return claseGetDAL.listaPersonajesAzure();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<clsPersonajePuntos> ObtenerTablaClasificacionesBL()
        {
            return claseGetDAL.ObtenerTablaClasificaciones();
        }



    }
}