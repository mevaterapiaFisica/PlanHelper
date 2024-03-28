using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public class OcupacionEquipo
    {
        public string Equipo { get; set; }
        public DateTime Fecha { get; set; }
        public List<TurnoSitra> Turnos { get; set; }

        public OcupacionEquipo(string _equipo, DateTime _fecha, List<TurnoSitra> _turnos)
        {
            Equipo = _equipo;
            Fecha = _fecha;
            Turnos = _turnos;
        }
        public double HorasOcupadasTotales()
        {
            if (Turnos != null && Turnos.Count > 0)
            {
                return Turnos.Select(t => t.Duracion()).Sum() / 60;
            }
            return 0;
        }

        public double HorasOcupadas(Equipo equipo)
        {
            if (Turnos != null && Turnos.Count > 0)
            {
                double Minutos= 0;
                foreach (var turno in Turnos)
                {
                    if (!equipo.EstaEnHorarioReservado(turno))
                    {
                        Minutos += turno.Duracion();
                    }
                }
                return Minutos / 60;
            }
            return 0;
        }

        

        
    }
}
