using DAL;
using Entities;

namespace BL
{
    public class ClaseHandlerBL
    {





        /// <summary>
        /// 
        /// </summary>
        /// <param name="nuevoCombate"></param>
        public static void PuntuarCombate(claseCombate nuevoCombate)
        {
            var combates = claseGetDAL.listaCombatesAzure();
            var combateExistente = combates.FirstOrDefault(c =>
                c.Fecha.Date == nuevoCombate.Fecha.Date &&
                c.IdPersonaje1 == nuevoCombate.IdPersonaje1 &&
                c.IdPersonaje2 == nuevoCombate.IdPersonaje2);

            if (combateExistente == null)
            {
                //claseGetDAL.InsertarCombate(nuevoCombate);
            }
            else
            {
                nuevoCombate.Puntuacion1 += combateExistente.Puntuacion1;
                nuevoCombate.Puntuacion2 += combateExistente.Puntuacion2;
                //claseGetDAL.ActualizarCombate(nuevoCombate);
            }
        }


        /// <summary>
        /// Método para eliminar un combate por su ID.
        /// </summary>
        /// <param name="id">ID del combate a eliminar.</param>
        /// <returns>Número de filas afectadas.</returns>
        public static int EliminarCombate(int idPer1, int idPer2)
        {
            return ClaseHandler.deleteCombateDAL(idPer1, idPer2);
        }


    }
}
