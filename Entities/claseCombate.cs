using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    /// <summary>
    /// clase para el combate
    /// </summary>
    public class claseCombate
    {

        #region atributos

        private DateTime fecha;
        //atributo para el id de los personajes
        private int idPersonaje1;

        private int idPersonaje2;

        private int puntuacion1;

        private int puntuacion2;
        #endregion

        #region Properties

        public DateTime Fecha { get { return fecha; } set { fecha = value; } }

        public int IdPersonaje1 { get { return idPersonaje1; } set { idPersonaje1 = value; } }

        public int IdPersonaje2 { get { return idPersonaje2; } set { idPersonaje2 = value; } }

        public int Puntuacion1 { get { return puntuacion1; } set { puntuacion1 = value; } }

        public int Puntuacion2 { get { return puntuacion2; } set { puntuacion2 = value; } }


        #endregion

        #region constructors
        /// <summary>
        /// constructor sin params
        /// </summary>
        public claseCombate()
        {

        }

        /// <summary>
        /// constuctor con parametros
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="idPersonaje1"></param>
        /// <param name="idPersonaje2"></param>
        /// <param name="puntuacion1"></param
        /// <param name="puntuacion2"></param>
        public claseCombate(DateTime fecha, int idPersonaje1, int idPersonaje2, int puntuacion1, int puntuacion2)
        {
            this.fecha = fecha;
            this.idPersonaje1 = idPersonaje1;
            this.idPersonaje2 = idPersonaje2;
            this.puntuacion1 = puntuacion1;
            this.puntuacion1 = puntuacion2;
        }
        #endregion

    }
}
