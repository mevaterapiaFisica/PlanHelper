using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public class HorarioReservado
    {
        public DateTime HoraDesde { get; set; }
        public DateTime HoraHasta { get; set; }
        public string Razon { get; set; } 

        public HorarioReservado(string _desde, string _hasta, string _razon)
        {
            HoraDesde = DateTime.ParseExact(_desde,"HH:mm",null);
            HoraHasta = DateTime.ParseExact(_hasta, "HH:mm", null);
            Razon = _razon;
        }

        public bool LoContiene(TurnoSitra turnoSitra)
        {
            var var1 = turnoSitra.HoraInicio.TimeOfDay >= HoraDesde.TimeOfDay;
            var var2 = turnoSitra.HoraFin.TimeOfDay <= HoraHasta.TimeOfDay;
            if (var1 && var2)
            {

            }
            return turnoSitra.HoraInicio.TimeOfDay >= HoraDesde.TimeOfDay && turnoSitra.HoraFin.TimeOfDay <= HoraHasta.TimeOfDay;
        }

        public double DuracionMinutos()
        {
            //HoraHasta.Subtract(HoraDesde).TotalMinutes;
            return (HoraHasta.TimeOfDay - HoraDesde.TimeOfDay).TotalMinutes;
        }
    }
}
