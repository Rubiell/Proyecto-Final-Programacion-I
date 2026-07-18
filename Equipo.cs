namespace GestorTorneosLocales
{
    // Almacena la información de los clubes participantes y centraliza sus estadísticas de juego.
    public class Equipo
    {
        // Atributos
        private string nombreEquipo;
        private string nombreCapitan;
        private int partidosJugados;
        private int partidosGanados;
        private int partidosEmpatados;
        private int partidosPerdidos;
        private int golesAFavor;
        private int golesEnContra;
        private int puntosTotales;

        // Propiedades
        public string NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }

        public string NombreCapitan
        {
            get { return nombreCapitan; }
            set { nombreCapitan = value; }
        }

        public int PartidosJugados
        {
            get { return partidosJugados; }
            set { partidosJugados = value; }
        }

        public int PartidosGanados
        {
            get { return partidosGanados; }
            set { partidosGanados = value; }
        }

        public int PartidosEmpatados
        {
            get { return partidosEmpatados; }
            set { partidosEmpatados = value; }
        }

        public int PartidosPerdidos
        {
            get { return partidosPerdidos; }
            set { partidosPerdidos = value; }
        }

        public int GolesAFavor
        {
            get { return golesAFavor; }
            set { golesAFavor = value; }
        }

        public int GolesEnContra
        {
            get { return golesEnContra; }
            set { golesEnContra = value; }
        }

        public int PuntosTotales
        {
            get { return puntosTotales; }
            set { puntosTotales = value; }
        }

        public Equipo(string nombreEquipo, string nombreCapitan)
        {
            this.nombreEquipo = nombreEquipo;
            this.nombreCapitan = nombreCapitan;
            partidosJugados = 0;
            partidosGanados = 0;
            partidosEmpatados = 0;
            partidosPerdidos = 0;
            golesAFavor = 0;
            golesEnContra = 0;
            puntosTotales = 0;
        }

        // Método: calcula los puntos totales del equipo (3 por victoria, 1 por empate)
        public void CalcularPuntosTotales()
        {
            puntosTotales = (partidosGanados * 3) + (partidosEmpatados * 1);
        }
    }
}
