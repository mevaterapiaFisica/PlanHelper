using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public class TurnoSitra
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Paciente { get; set; }
        public string Tipo { get; set; }

        public int Duracion()
        {
            return Convert.ToInt32((HoraFin.TimeOfDay - HoraInicio.TimeOfDay).TotalMinutes);
        }

        public TurnoSitra(string texto)
        {
            string[] aux = texto.Split(';');
            if (aux.Count()>5)
            {
                
                HoraInicio = DateTime.ParseExact(aux[1], "HH:mm", null);
                Paciente = aux[2];
                if (aux.Count() < 7 || aux[7] == "")
                {
                    Tipo = aux[4];
                }
                else
                {
                    Tipo = aux[7];
                }
                if (aux.Count()>10)
                {
                    HoraFin = DateTime.ParseExact(aux[11], "HH:mm", null);
                }
                else
                {
                    DateTime dateTimeOut;
                    if (!DateTime.TryParseExact(aux[aux.Count() - 1], "HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTimeOut))
                    {
                        if(!DateTime.TryParseExact(aux[aux.Count() - 2], "HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTimeOut))
                        {
                            dateTimeOut = HoraInicio;
                        }
                    }
                    HoraFin = dateTimeOut;
                }
                
            }
            else
            {
                Paciente = null;
            }
            
        }

        public override string ToString()
        {
            return Paciente + "-" + Tipo + "-" + HoraInicio.ToString() + "-" + Duracion() + "minutos";
        }
        public string Apellido()
        {
            return Paciente.Split(',')[0].ToUpper();
        }

        public string Nombre()
        {
            return Paciente.Split(',')[1].ToUpper();
        }

    }
}
