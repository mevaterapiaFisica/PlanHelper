using AriaQ;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipse = VMS.TPS.Common.Model.API;

namespace PlanHelper
{
    public class Equipo
    {
        public static string pathArchivos = @"\\ARIAMEVADB-SVR\va_data$\PlanHelper\Archivos\";

        public string Nombre { get; set; }
        public string ID { get; set; }
        public bool EsDicomRT { get; set; }
        public string RutaDicomRT { get; set; }
        public int TurnosPorDia { get; set; }
        public bool HaceVMAT { get; set; }
        public bool Tiene10MV { get; set; }
        public bool TieneElectrones { get; set; }

        public List<Parametro> Parametros { get; set; }
        public DateTime? UltimoCalculo { get; set; }
        public Equipo(string _Nombre, string _ID, bool _EsDicomRT, string _RutaDicomRT, int _TurnosPorDia, bool _HaceVMAT, bool _Tiene10MV, bool _TieneElectrones)
        {
            Nombre = _Nombre;
            ID = _ID;
            EsDicomRT = _EsDicomRT;
            RutaDicomRT = _RutaDicomRT;
            TurnosPorDia = _TurnosPorDia;
            HaceVMAT = _HaceVMAT;
            Tiene10MV = _Tiene10MV;
            TieneElectrones = _TieneElectrones;
        }

        public static Equipo Seleccionar(List<Equipo> equipos, PlanSetup plan)
        {
            return equipos.Where(e => e.ID == plan.Radiations.First().RadiationDevice.Machine.MachineId).First();
        }

        public void EscribirEquipo()
        {
            List<string> texto = new List<string>();
            texto.Add(Nombre);
            texto.Add(ID);
            texto.Add(EsDicomRT.ToString());
            texto.Add(RutaDicomRT);
            texto.Add(TurnosPorDia.ToString());
            texto.Add(HaceVMAT.ToString());
            texto.Add(Tiene10MV.ToString());
            texto.Add(TieneElectrones.ToString());
            texto.Add(Parametros.Count.ToString());

            foreach (Parametro parametro in Parametros)
            {
                texto.Add(parametro.ToString());
            }

            if (UltimoCalculo != null)
            {
                texto.Add(((DateTime)UltimoCalculo).ToString());
            }
            else
            {
                texto.Add("null");
            }
            File.WriteAllLines(pathArchivos + Nombre + ".txt", texto.ToArray());
        }

        public void LeerEquipo()
        {
            string[] aux = File.ReadAllLines(pathArchivos + Nombre + ".txt");
            Nombre = aux[0];
            ID = aux[1];
            EsDicomRT = (aux[2].ToLower() == "true");
            RutaDicomRT = aux[3];
            TurnosPorDia = Convert.ToInt32(aux[4]);
            HaceVMAT = (aux[5].ToLower() == "true");
            Tiene10MV = (aux[6].ToLower() == "true");
            TieneElectrones = (aux[7].ToLower() == "true");
            int CantidadDeParametros = Convert.ToInt32(aux[8]);
            Parametros = new List<Parametro>();
            for (int i = 9; i < CantidadDeParametros + 9; i++)
            {
                Parametros.Add(Parametro.FromString(aux[i]));
            }
            if (aux[CantidadDeParametros + 9] != "null")
            {
                UltimoCalculo = Convert.ToDateTime(aux[CantidadDeParametros + 9]);
            }
            else
            {
                UltimoCalculo = null;
            }
        }

        public static List<Equipo> Equipos()
        {
            return new List<Equipo>()
            {
                new Equipo("Equipo 1", "Equipo1", false, "", 52, true, false, false),
                new Equipo("Equipo 2", "Equipo 2 6EX",true,@"\\FISICA0\equipo2\DICOM RT",52,false,false,false),
                new Equipo("Equipo 3", "2100CMLC", true, @"\\Fisica0\dicom rt", 48, false, true, true),
                new Equipo("Equipo 4", "D-2300CD", false, "", 40, true, true, true),
            };
        }

        public static List<Equipo> InicializarEquipos()
        {
            List<Equipo> equipos = Equipos();
            foreach (Equipo equipo in equipos)
            {
                if (File.Exists(pathArchivos + equipo.Nombre + ".txt"))
                {
                    equipo.LeerEquipo();
                }
            }
            return equipos;
        }

        public static void CalcularParametrosEquipos(Aria aria, Eclipse.Application app, List<Equipo> equipos)
        {
            foreach (Equipo equipo in equipos)
            {
                if (equipo.Parametros == null || equipo.Parametros.Count == 0)
                {
                    equipo.GenerarParametrosVacios();
                }
                equipo.CalcularParametros(aria, app);
            }
            GuardarEquipos(equipos);
        }

        public static void GuardarEquipos(List<Equipo> Equipos)
        {
            foreach (Equipo equipo in Equipos)
            {
                equipo.EscribirEquipo();
            }
        }

        public void GenerarParametrosVacios()
        {
            List<string> Statuses = new List<string> { "Unapproved", "PlanApproval", "TreatApproval" };
            List<string> Modalidades = new List<string> { "3DC" };
            if (!EsDicomRT)
            {
                Modalidades.Add("VMAT");
            }
            /*else Me parece que no hace falta por ahora
            {
                Modalidades.Add("IMRT");
            }*/
            Parametros = new List<Parametro>();
            foreach (string status in Statuses)
            {
                foreach (string modalidad in Modalidades)
                {
                    Parametros.Add(new Parametro(status, modalidad, null, 0, true, 0));
                }
            }
        }

        public void CalcularParametros(Aria aria, Eclipse.Application app)
        {
            for (int i = 0; i < Parametros.Count; i++)
            {
                Parametros.ElementAt(i).Dias = ConsultasDB.PromedioStatusInicio(Parametros.ElementAt(i).StatusInicial, aria, app, this, Parametros.ElementAt(i).Modalidad, DateTime.Today.AddMonths(-2));
            }
            UltimoCalculo = DateTime.Now;
        }

        public List<Equipo> ToList()
        {
            List<Equipo> Equipos = new List<Equipo>();
            Equipos.Add(this);
            return Equipos;
        }

        public static void EscribirEnCurso(Aria aria, List<Equipo> Equipos)
        {
            List<PlanSetup> pacientesEnCurso = ConsultasDB.PacientesEncurso(aria, Equipos);
            foreach (Equipo equipo in Equipos)
            {
                List<string> ocupacion = PlanPaciente.ConvertirListasToString(pacientesEnCurso.Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo.ID).ToList());
                File.WriteAllLines(pathArchivos + equipo.Nombre + "_encurso.txt", ocupacion.ToArray());
            }
        }

        public List<PlanPaciente> LeerEnCurso()
        {
            List<PlanPaciente> pacientesEnCurso = new List<PlanPaciente>();
            if (File.Exists(pathArchivos + Nombre + "_encurso.txt"))
            {
                string[] lineas = File.ReadAllLines(pathArchivos + Nombre + "_encurso.txt");
                foreach (string linea in lineas)
                {
                    pacientesEnCurso.Add(new PlanPaciente(linea));
                }
            }
            return pacientesEnCurso;
        }

        public int PacientesEnEquipoDia(Aria aria, double Dias)
        {
            List<PlanPaciente> planPacientes = LeerEnCurso();
            int PacientesEnEquipoDia = 0;
            foreach (PlanPaciente planPaciente in planPacientes)
            {
                if (planPaciente.EstaraEnEquipo(this, Dias))
                {
                    PacientesEnEquipoDia++;
                }
            }
            List<string> pacientesSiguen = ConsultasDB.PacientesSiguenEnEquipoDia(aria, this, Dias);
            if (Dias == 0)
            {
                File.WriteAllLines(pathArchivos + Nombre + "_ocupacionHoy.txt", pacientesSiguen.ToArray());
            }
            
            PacientesEnEquipoDia += pacientesSiguen.Count;
            if (ID=="2100CMLC")
            {
                int TBIs = ConsultasDB.TBIsDia(aria, this, Dias).Count;
                if (TBIs>0)
                {
                    int turnosExtras = (TBIs - 2) * 4;
                    PacientesEnEquipoDia += turnosExtras;
                }
            }
            return PacientesEnEquipoDia;
        }

        public void EscribirAgendaOcupacion(Aria aria)
        {
            int? maximoDias = this.Parametros.OrderBy(p => p.Dias).Last().Dias;
            int margen = this.Parametros.OrderBy(p => p.Dias).Last().Margen;
            if (maximoDias != null)
            {
                List<string> output = new List<string>();
                for (int i = 0; i < maximoDias + margen; i++)//busco un par de días de más por las dudas
                {
                    /*if (!ConsultasDB.Feriados().Contains(ConsultasDB.AddBusinessDaysSinFeriados(DateTime.Today, Convert.ToDouble(i))))
                    {
                        output.Add(ConsultasDB.AddBusinessDaysSinFeriados(DateTime.Today, Convert.ToDouble(i)).ToShortDateString() + ";" + PacientesEnEquipoDia(aria, Convert.ToDouble(i)).ToString());
                    }*/
                    output.Add(ConsultasDB.AddBusinessDays(DateTime.Today, Convert.ToDouble(i)).ToShortDateString() + ";" + PacientesEnEquipoDia(aria, Convert.ToDouble(i)).ToString());
                }
                File.WriteAllLines(pathArchivos + this.Nombre + "_agendaocupacion.txt", output.ToArray());
            }
        }

        public Parametro encontrarParametro(string status, string modalidad, int Fracciones)
        {
            List<Parametro> ParametrosPosibles = Parametros.Where(p => p.StatusInicial == status && p.Modalidad == modalidad).ToList();
            if (ParametrosPosibles.Any(p => p.ValeParaTodasLasFracciones))
            {
                return ParametrosPosibles.Where(p => p.ValeParaTodasLasFracciones).First();
            }
            else if (ParametrosPosibles.Any(p => p.Fracciones == Fracciones))
            {
                return ParametrosPosibles.Where(p => p.Fracciones == Fracciones).First();
            }
            else
            {
                if (ParametrosPosibles.OrderBy(p => Math.Abs(p.Fracciones - Fracciones)).Count()>0 )
                {
                    return ParametrosPosibles.OrderBy(p => Math.Abs(p.Fracciones - Fracciones)).First();
                }
                else
                {
                    return Parametros.First();
                }
                ; //Me quedo con el más cercano
            }
        }

        public Tuple<DateTime, int> minimaOcupacionEnRango(Parametro Parametro, DateTime? fecha = null)
        {
            if (Parametro.Dias != null)
            {
                List<Tuple<DateTime, int>> diasPosibles = new List<Tuple<DateTime, int>>();
                for (int i = -Parametro.Margen; i < Parametro.Margen + 1; i++)
                {
                    DateTime dia = ConsultasDB.AddBusinessDaysSinFeriados(DateTime.Today, i + (int)Parametro.Dias);
                    int? ocupacion = BuscarOcupacion(dia);
                    if (ocupacion != null)
                    {
                        diasPosibles.Add(new Tuple<DateTime, int>(dia, (int)ocupacion));
                    }
                }
                if (diasPosibles.Count > 0)
                {
                    return diasPosibles.OrderBy(d => d.Item2).First();
                }
            }
            return new Tuple<DateTime, int>(DateTime.Today, 1000);
        }

        public int ocupacionMediaEnRango(Parametro Parametro)
        {
            if (Parametro.Dias != null)
            {
                List<int> ocupaciones = new List<int>();
                for (int i = -Parametro.Margen; i < Parametro.Margen + 1; i++)
                {
                    DateTime dia = ConsultasDB.AddBusinessDaysSinFeriados(DateTime.Today, i+(int)Parametro.Dias);
                    if ((int)dia.DayOfWeek > 0 && (int)dia.DayOfWeek < 4)
                    {
                        int? ocupacion = BuscarOcupacion(dia);
                        if (ocupacion != null)
                        {
                            ocupaciones.Add((int)ocupacion);
                        }
                    }

                }
                if (ocupaciones.Count > 0)
                {
                    return Convert.ToInt32(ocupaciones.Average());
                }
            }
            return 1000;
        }

        public int? BuscarOcupacion(DateTime fecha)
        {
            if (File.Exists(pathArchivos + this.Nombre + "_agendaocupacion.txt"))
            {
                string[] fid = File.ReadAllLines(pathArchivos + this.Nombre + "_agendaocupacion.txt");
                try
                {
                    string linea = fid.Where(l => l.Contains(fecha.ToString("dd-MMM-yy"))).First();
                    return Convert.ToInt32(linea.Split(';')[1]);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static void EscribirOcupacionEquipos(Aria aria, List<Equipo> Equipos)
        {
            foreach (Equipo equipo in Equipos)
            {
                equipo.EscribirAgendaOcupacion(aria);
            }
        }

        public void escribirSeguimiento()
        {
            string texto = Environment.NewLine + DateTime.Today.ToShortDateString() + ";" + BuscarOcupacion(DateTime.Today).ToString() + ";" + BuscarOcupacion(DateTime.Today.AddDays(1)).ToString();
            File.AppendAllText(pathArchivos + Nombre + "_seguimiento.txt", texto);
        }

        public static Equipo FromString(string stringEquipo)
        {
            List<Equipo> equipos = InicializarEquipos();
            return equipos.Where(e => e.ID == stringEquipo).FirstOrDefault();
        }
    }



    /*public class Parametro
    {
        public string StatusInicial { get; set; }
        public string Modalidad { get; set; }
        public int? Dias { get; set; }

        public Parametro(string _status, string _modalidad, int? _dias)
        {
            StatusInicial = _status;
            Modalidad = _modalidad;
            Dias = _dias;
        }
        public override string ToString()
        {
            if (Dias != null)
            {
                return StatusInicial + ";" + Modalidad.ToString() + ";" + Dias.ToString();
            }
            else
            {
                return StatusInicial + ";" + Modalidad.ToString() + ";" + "null";
            }
        }

        public static Parametro FromString(string parametroString)
        {
            string[] aux = parametroString.Split(';');
            if (aux[2] != "null")
            {
                return new Parametro(aux[0], aux[1], Convert.ToInt32(aux[2]));
            }
            else
            {
                return new Parametro(aux[0], aux[1], null);
            }

        }
    }*/
}
