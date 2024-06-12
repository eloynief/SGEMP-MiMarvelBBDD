namespace Models
{
    public class clsPersonajePuntos
    {


        private String nombre;

        private int puntuacion;


        public String Nombre { get { return nombre; } set { nombre = value; } }
        public int Puntuacion { get { return puntuacion; } set { puntuacion = value; } }


        public clsPersonajePuntos() { }

        public clsPersonajePuntos(String nombre, int puntuacion)
        {
            this.nombre = nombre;
            this.puntuacion = puntuacion;
        }


    }
}