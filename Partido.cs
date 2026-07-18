using System;

namespace GestorTorneosLocales
{
    // Controla los datos específicos de cada enfrentamiento y modifica los resultados globales.
    public class Partido
    {
        // Atributos
        private Equipo equipoLocal;
        private Equipo equipoVisitante;
        private int golesLocal;
        private int golesVisitante;
        private bool partidoFinalizado;

        // Propiedades
        public Equipo EquipoLocal
        {
            get { return equipoLocal; }
            set { equipoLocal = value; }
        }

        public Equipo EquipoVisitante
        {
            get { return equipoVisitante; }
            set { equipoVisitante = value; }
        }

        public int GolesLocal
        {
            get { return golesLocal; }
            set { golesLocal = value; }
        }

        public int GolesVisitante
        {
            get { return golesVisitante; }
            set { golesVisitante = value; }
        }

        public bool PartidoFinalizado
        {
            get { return partidoFinalizado; }
            set { partidoFinalizado = value; }
        }

        public Partido(Equipo equipoLocal, Equipo equipoVisitante)
        {
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            golesLocal = 0;
            golesVisitante = 0;
            partidoFinalizado = false;
        }

        // Método: registra el resultado del partido y actualiza las estadísticas de ambos equipos
        public void RegistrarResultado(int golesLocal, int golesVisitante)
        {
            if (golesLocal < 0 || golesVisitante < 0)
            {
                throw new ArgumentException("La cantidad de goles no puede ser negativa.");
            }

            this.golesLocal = golesLocal;
            this.golesVisitante = golesVisitante;
            partidoFinalizado = true;

            equipoLocal.PartidosJugados = equipoLocal.PartidosJugados + 1;
            equipoVisitante.PartidosJugados = equipoVisitante.PartidosJugados + 1;

            equipoLocal.GolesAFavor = equipoLocal.GolesAFavor + golesLocal;
            equipoLocal.GolesEnContra = equipoLocal.GolesEnContra + golesVisitante;
            equipoVisitante.GolesAFavor = equipoVisitante.GolesAFavor + golesVisitante;
            equipoVisitante.GolesEnContra = equipoVisitante.GolesEnContra + golesLocal;

            if (golesLocal > golesVisitante)
            {
                equipoLocal.PartidosGanados = equipoLocal.PartidosGanados + 1;
                equipoVisitante.PartidosPerdidos = equipoVisitante.PartidosPerdidos + 1;
            }
            else if (golesLocal < golesVisitante)
            {
                equipoVisitante.PartidosGanados = equipoVisitante.PartidosGanados + 1;
                equipoLocal.PartidosPerdidos = equipoLocal.PartidosPerdidos + 1;
            }
            else
            {
                equipoLocal.PartidosEmpatados = equipoLocal.PartidosEmpatados + 1;
                equipoVisitante.PartidosEmpatados = equipoVisitante.PartidosEmpatados + 1;
            }

            equipoLocal.CalcularPuntosTotales();
            equipoVisitante.CalcularPuntosTotales();
        }
    }
}
