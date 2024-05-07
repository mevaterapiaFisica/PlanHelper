using System;
using System.IO;
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

        public OcupacionEquipo(string path)
        {
            string[] lineas = File.ReadAllLines(path);
            Equipo = lineas[0];
            Fecha = DateTime.ParseExact(lineas[1], "HH:mm", null, System.Globalization.DateTimeStyles.None);
            Turnos = new List<TurnoSitra>();
            for (int i=2;i<lineas.Count();i++)
            {
                Turnos.Add(TurnoSitra.FromString(lineas[3]);
            }
        }
        public double HorasOcupadasTotales()
        {
            if (Turnos != null && Turnos.Count > 0)
            {
                return Turnos.Select(t => t.Duracion()).Sum() / 60;
            }
            return 0;
        }

        public double TurnosOcupados(Equipo equipo)
        {
            if (Turnos != null && Turnos.Count > 0)
            {
                double Minutos = 0;
                foreach (var turno in Turnos)
                {
                    if (!equipo.EstaEnHorarioReservado(turno))
                    {
                        Minutos += turno.Duracion();
                    }
                }
                Minutos += equipo.MinutosHorarioReservado();

                double turnos = Minutos / 15;

                List<PlanPaciente> planPacientes = equipo.LeerEnCurso();
                foreach (PlanPaciente planPaciente in planPacientes)
                {
                    if (planPaciente.EstaraEnEquipo(equipo, (this.Fecha - DateTime.Today).TotalDays))
                    {
                        if (!(this.Turnos.Any(t => planPaciente.Apellido() == t.Apellido() && planPaciente.Nombre() == t.Nombre())))
                        {
                            turnos++; //FAlta revisar si esta en la lista
                        }
                    }
                }
                return turnos;  //Mido turnos de 15 minutos
            }
            return 0;
        }
        public void EscribirAArchivo(string path)
        {
            List<string> texto = new List<string>();
            texto.Add(Equipo);
            texto.Add(Fecha.ToString("HH:mm"));
            texto.AddRange(Turnos.Select(t => t.ToString()));
            File.WriteAllLines(path, texto.ToArray());
        }

        




    }
}
