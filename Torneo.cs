using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorTorneosLocales
{
    // Representa la entidad principal encargada de coordinar la competencia entera.
    public class Torneo
    {
        // Constante
        public const int MAX_EQUIPOS = 16;

        // Atributos
        private string nombreTorneo;
        private DateTime fechaInicio;
        private List<Equipo> listaEquipos;
        private List<Partido> listaPartidos;

        // Propiedades
        public string NombreTorneo
        {
            get { return nombreTorneo; }
            set { nombreTorneo = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public List<Equipo> ListaEquipos
        {
            get { return listaEquipos; }
            set { listaEquipos = value; }
        }

        public List<Partido> ListaPartidos
        {
            get { return listaPartidos; }
            set { listaPartidos = value; }
        }

        public Torneo(string nombreTorneo)
        {
            this.nombreTorneo = nombreTorneo;
            fechaInicio = DateTime.Now;
            listaEquipos = new List<Equipo>();
            listaPartidos = new List<Partido>();
        }

        // Método: agrega un nuevo equipo al torneo, validando cupo, nombres y capitanes repetidos
        public void AgregarEquipo(Equipo equipo)
        {
            if (listaEquipos.Count >= MAX_EQUIPOS)
            {
                throw new InvalidOperationException("Se alcanzó el máximo de " + MAX_EQUIPOS + " equipos permitidos.");
            }

            for (int i = 0; i < listaEquipos.Count; i++)
            {
                if (listaEquipos[i].NombreEquipo.Trim().ToLower() == equipo.NombreEquipo.Trim().ToLower())
                {
                    throw new ArgumentException("Ya existe un equipo registrado con ese nombre.");
                }

                if (listaEquipos[i].NombreCapitan.Trim().ToLower() == equipo.NombreCapitan.Trim().ToLower())
                {
                    throw new ArgumentException("Ya existe un equipo registrado con ese capitán.");
                }
            }

            listaEquipos.Add(equipo);
        }

        // Método: genera el calendario de partidos (todos contra todos, una sola vuelta)
        public void GenerarCalendario()
        {
            if (listaEquipos.Count < 2)
            {
                throw new InvalidOperationException("Se necesitan al menos 2 equipos para generar el calendario.");
            }

            listaPartidos.Clear();

            for (int i = 0; i < listaEquipos.Count; i++)
            {
                for (int j = i + 1; j < listaEquipos.Count; j++)
                {
                    Partido partido = new Partido(listaEquipos[i], listaEquipos[j]);
                    listaPartidos.Add(partido);
                }
            }
        }

        // Método: reordena la lista de equipos según puntos totales y diferencia de goles
        public void ActualizarTablaPosiciones()
        {
            listaEquipos = listaEquipos
                .OrderByDescending(e => e.PuntosTotales)
                .ThenByDescending(e => e.GolesAFavor - e.GolesEnContra)
                .ThenByDescending(e => e.GolesAFavor)
                .ToList();
        }
    }
}
