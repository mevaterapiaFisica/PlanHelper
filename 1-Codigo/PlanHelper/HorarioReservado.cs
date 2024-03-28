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
            return turnoSitra.HoraInicio.TimeOfDay >= HoraDesde.TimeOfDay && turnoSitra.HoraInicio.TimeOfDay <= HoraHasta.TimeOfDay;
        }

        public double DuracionHoras()
        {
            return (HoraHasta.TimeOfDay - HoraDesde.TimeOfDay).Minutes / 60;
        }
    }
}
