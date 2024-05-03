using System.IO;
using AriaQ;
using System.Data.Entity;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Eclipse = VMS.TPS.Common.Model.API;


namespace PlanHelper
{
    public static class ConsultasDB
    {
        #region Consultas Listas de Planes
        public static List<PlanSetup> planesCreadosEntreFechas(Aria aria, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            if (fechaFinal == null)
            {
                return FiltrarPorEquiposMeva(aria.PlanSetups.Where(p => p.CreationDate > fechaInicial).ToList());
            }
            else
            {
                return FiltrarPorEquiposMeva(aria.PlanSetups.Where(p => p.CreationDate > fechaInicial && p.CreationDate < fechaFinal).ToList());
            }
        }

        public static List<PlanSetup> PlanesConAprobacionFisicaOMedica(string equipo, Aria aria, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            List<PlanSetup> planesEntreFechas = planesCreadosEntreFechas(aria, fechaInicial, fechaFinal);
            return planesEntreFechas.Where(p => (p.Status == "TreatApproval" || p.Status == "PlanApproval") && p.Radiations.First().RadiationDevice.Machine.MachineId == equipo && !p.PlanSetupId.Contains("TBI")).ToList();
        }


        public static List<PlanSetup> PlanesEnPlanificacion(Aria aria)
        {
            DateTime Hace14dias = DateTime.Today.AddDays(-14);
            List<PlanSetup> Planes14dias = planesCreadosEntreFechas(aria, Hace14dias).Where(p => CursoEstosMeses(p) == true).ToList(); //planes de hace 14 días
            List<PlanSetup> Planes14diasUnapproved = Planes14dias.Where(p => p.Status == "Unapproved" && !HayPlanesAprobadosEnCurso(p) && !p.Course.CourseId.Contains("QA") && !p.Course.CourseId.Contains("Fis") && !p.PlanSetupId.Contains("TBI") && p.Radiations.First().ExternalFieldCommon.ExternalField.DoseRate != 1000).ToList(); //planes desaprobados y que no tienen ningún aprobado en el curso
            //var pac = FiltrarUnoPorPaciente(Planes14diasUnapproved).Select(p => p.Course.Patient.PatientId).ToList();
            return FiltrarUnoPorPaciente(Planes14diasUnapproved);
        }

        public static List<PlanSetup> PlanesConAprobacionMedica(Aria aria)
        {
            DateTime Hace14dias = DateTime.Today.AddDays(-14);
            List<PlanSetup> Planes21dias = planesCreadosEntreFechas(aria, Hace14dias).Where(p => CursoEstosMeses(p) == true).ToList(); //planes de hace 14 días
            List<PlanSetup> Planes21diasPlanApproval = Planes21dias.Where(p => p.Status == "PlanApproval" && !p.Course.CourseId.Contains("QA") && !p.Course.CourseId.Contains("Fis") && !p.PlanSetupId.Contains("TBI") && p.Radiations.First().ExternalFieldCommon.ExternalField.DoseRate != 1000).ToList(); //planes desaprobados y que no tienen ningún aprobado en el curso
            //var pac = FiltrarUnoPorPaciente(Planes21diasPlanApproval).Select(p => p.Course.Patient.PatientId).ToList();
            return FiltrarUnoPorPaciente(Planes21diasPlanApproval);
        }

        public static List<PlanSetup> PlanesConAprobacionFisica(Aria aria, List<Equipo> equipos)
        {
            DateTime Hace14dias = DateTime.Today.AddDays(-14);
            List<PlanSetup> Planes28dias = planesCreadosEntreFechas(aria, Hace14dias).Where(p => CursoEstosMeses(p) == true).ToList(); //planes de hace 14 días
            List<PlanSetup> Planes28diasTreatApproval = Planes28dias.Where(p => p.Status == "TreatApproval" && !p.Course.CourseId.Contains("QA") && !p.Course.CourseId.Contains("Fis") && fechaInicio(p, equipos) == null && !p.PlanSetupId.Contains("TBI") && p.Radiations.First().ExternalFieldCommon.ExternalField.DoseRate != 1000).ToList(); //planes desaprobados y que no tienen ningún aprobado en el curso
            //var pac = FiltrarUnoPorPaciente(Planes28diasTreatApproval).Select(p => p.Course.Patient.PatientId).ToList();
            return FiltrarUnoPorPaciente(Planes28diasTreatApproval);
        }

        public static List<PlanSetup> PlanesConAprobacionFisicaEnTto(Aria aria, List<Equipo> equipos, int diasAtras)
        {
            DateTime Hace14dias = DateTime.Today.AddDays(-1 * diasAtras);
            List<PlanSetup> Planes28dias = planesCreadosEntreFechas(aria, Hace14dias).ToList(); //planes de hace 14 días
            List<PlanSetup> Planes28diasTreatApproval = Planes28dias.Where(p => p.Status == "TreatApproval" && !p.Course.CourseId.Contains("QA") && !p.Course.CourseId.Contains("Fis") && fechaInicio(p, equipos) != null && !p.PlanSetupId.Contains("TBI") && p.Radiations.First().ExternalFieldCommon.ExternalField.DoseRate != 1000).ToList(); //planes desaprobados y que no tienen ningún aprobado en el curso
            //var pac = FiltrarUnoPorPaciente(Planes28diasTreatApproval).Select(p => p.Course.Patient.PatientId).ToList();
            return FiltrarUnoPorPaciente(Planes28diasTreatApproval);
        }


        public static List<PlanSetup> PacientesEncurso(Aria aria, List<Equipo> equipos)
        {
            List<PlanSetup> planesEncurso = PlanesEnPlanificacion(aria);
            planesEncurso.AddRange(PlanesConAprobacionMedica(aria));
            planesEncurso.AddRange(PlanesConAprobacionFisica(aria, equipos));
            EscribirPacientesEnCursoAtrasados(planesEncurso);
            return FiltrarUnoPorPaciente(planesEncurso);
        }
        #endregion

        public static void EscribirPacientesEnCursoAtrasados(List<PlanSetup> planesEnCurso)
        {
            List<string> PacientesAtrasados = new List<string>();
            foreach (PlanSetup plan in planesEnCurso)
            {
                if (planEstancado(plan))
                {
                    PacientesAtrasados.Add(plan.Course.Patient.PatientId + ";" + plan.Course.Patient.LastName + ";" + plan.Radiations.First().RadiationDevice.Machine.MachineId + ";" + plan.PlanSetupId + ";" + plan.Status + ";" + plan.StatusDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
            }
            File.WriteAllLines(Equipo.pathArchivos + "QA_pacientesEstancadosEnCurso.txt", PacientesAtrasados.ToArray());
        }

        public static bool planEstancado(PlanSetup plan)
        {
            Equipo equipo = Equipo.Seleccionar(Equipo.InicializarEquipos(), plan);
            Parametro parametro;
            double tolerancia = 1;
            parametro = equipo.encontrarParametro(plan.Status, Modalidad(plan));
            /*if (plan.RTPlans.First().NoFractions != null)
            {
                parametro = equipo.encontrarParametro(plan.Status, Modalidad(plan));//, (int)plan.RTPlans.First().NoFractions);
            }
            else
            {
                parametro = equipo.encontrarParametro(plan.Status, Modalidad(plan));
            }*/
            return GetBusinessDays(plan.StatusDate, DateTime.Today) > (parametro.Dias + (parametro.Margen * tolerancia));

        }
        #region Consultas Fechas y Fracciones
        public static DateTime? fechaAprobacionMedica(AriaQ.PlanSetup plan, Eclipse.Application app)
        {
            if (plan.Status == "PlanApproval")
            {
                return plan.StatusDate;
            }
            else if (plan.Status == "TreatApproval")
            {
                return ConsultasEclipse.FechaAprobacionMedica(plan.Course.Patient.PatientId, plan.Course.CourseId, plan.PlanSetupId, app);
            }
            else
            {
                return null;
            }
        }

        public static DateTime? fechaAprobacionFisica(AriaQ.PlanSetup plan)
        {
            if (plan.Status == "TreatApproval")
            {
                return plan.StatusDate;
            }
            else
            {
                return null;
            }
        }

        public static DateTime? fechaInicio(PlanSetup plan, List<Equipo> Equipos)
        {
            Equipo equipo = Equipo.Seleccionar(Equipos, plan);
            if (plan.Status != "TreatApproval")
            {
                return null;
            }
            else if (equipo.EsDicomRT)
            {
                return MetodosDicomRT.FechaInicio(equipo, plan.Course.Patient.PatientId);
            }
            else if (plan.RTPlans.First().TreatmentRecords.Count() > 0)
            {
                return plan.RTPlans.First().TreatmentRecords.OrderBy(t => t.TreatmentRecordDateTime).First().TreatmentRecordDateTime;
            }
            return null;
        }

        public static int? ultimaFraccion(PlanSetup plan, List<Equipo> equipos)
        {
            Equipo equipo = Equipo.Seleccionar(equipos, plan);
            if (equipo.EsDicomRT)
            {
                return MetodosDicomRT.ultimaFraccion(MetodosDicomRT.CarpetaPaciente(equipo, plan.Course.Patient.PatientId));
            }
            else if (plan.RTPlans.First().TreatmentRecords.Count() > 0)
            {
                return plan.RTPlans.First().TreatmentRecords.Last().RadiationHstries.First().FractionNumber;
            }
            else
            {
                return null;
            }
        }

        public static List<int> FraccionesConImagenes(PlanSetup plan)
        {

            if (plan.Radiations.First().RadiationDevice.Machine.MachineId == "Equipo1")
            {
                var imagenes = plan.RTPlans.First().TreatmentRecords.Where(t => t.RadiationHstries.First().TreatmentDeliveryType == "OPEN_PORTFILM" || t.RadiationHstries.First().TreatmentDeliveryType == "TRMT_PORTFILM");
                if (imagenes.Count() > 0)
                {
                    //return imagenes.OrderBy(i => i.HstryDateTime).Last().RadiationHstries.OrderBy(r => r.HstryDateTime).Last().FractionNumber;
                    return imagenes.Select(i => i.RadiationHstries.Last().FractionNumber).Distinct().ToList();
                }
                else
                {
                    return null;
                }
            }
            else if (plan.Radiations.First().RadiationDevice.Machine.MachineId == "D-2300CD")
            {
                var paciente = plan.Course.Patient.LastName;
                var imagenes = plan.RTPlans.First().SessionRTPlans.Where(s => s.Session.SessionProcedures.Count > 0 && s.Session.SessionProcedures.Any(ss => ss.SessionProcedureTemplateId == "kV" || ss.SessionProcedureTemplateId == "CBCT"));
                if (imagenes.Count() > 0)
                {
                    var lista = imagenes.Select(i => i.Session.SessionNum).OrderBy(i => i).Distinct().ToList();
                    //return imagenes.OrderBy(i => i.HstryDateTime).ToList().Last().Session.SessionNum;
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static int? ultimaFraccionConImagen(PlanSetup plan)
        {
            if (plan.Radiations.First().RadiationDevice.Machine.MachineId == "Equipo1")
            {
                var imagenes = plan.RTPlans.First().TreatmentRecords.Where(t => t.RadiationHstries.First().TreatmentDeliveryType == "OPEN_PORTFILM" || t.RadiationHstries.First().TreatmentDeliveryType == "TRMT_PORTFILM");
                if (imagenes.Count() > 0)
                {
                    return imagenes.OrderBy(i => i.HstryDateTime).Last().RadiationHstries.OrderBy(r => r.HstryDateTime).Last().FractionNumber;
                }
                else
                {
                    return null;
                }
            }
            else if (plan.Radiations.First().RadiationDevice.Machine.MachineId == "D-2300CD")
            {
                var imagenes = plan.RTPlans.First().SessionRTPlans.Where(s => s.Session.SessionProcedures.Count > 0 && s.Session.SessionProcedures.Any(ss => ss.SessionProcedureTemplateId == "kV" || ss.SessionProcedureTemplateId == "CBCT"));
                if (imagenes.Count() > 0)
                {
                    return imagenes.OrderBy(i => i.HstryDateTime).ToList().Last().Session.SessionNum;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Consulta días entre

        public static bool estaraEnEquipo(Eclipse.Application app, PlanSetup plan, DateTime dia, List<Equipo> Equipos) //REVISAR BIEN POR DIAS da
        {
            if (estaEnTratamiento(plan, Equipos))
            {
                return AddBusinessDays(DateTime.Today, Convert.ToDouble(plan.RTPlans.First().NoFractions - ultimaFraccion(plan, Equipos))) > dia;

            }
            else
            {
                Equipo equipo = Equipos.Where(e => e.ID == plan.Radiations.First().RadiationDevice.Machine.MachineId).First();
                Parametro parametro = equipo.Parametros.Where(p => p.Modalidad == Modalidad(plan) && p.StatusInicial == plan.Status).First();
                DateTime DiaInicio;
                DateTime DiaFin;
                if (parametro.StatusInicial == "Unapproved")
                {
                    DiaInicio = AddBusinessDays(plan.CreationDate, Convert.ToDouble(parametro.Dias));
                    DiaFin = AddBusinessDays(plan.CreationDate, Convert.ToDouble(parametro.Dias + plan.RTPlans.First().NoFractions));
                }
                else if (parametro.StatusInicial == "PlanApproval")
                {
                    DiaInicio = AddBusinessDays((DateTime)fechaAprobacionMedica(plan, app), Convert.ToDouble(parametro.Dias));
                    DiaFin = AddBusinessDays((DateTime)fechaAprobacionMedica(plan, app), (Convert.ToDouble(parametro.Dias + plan.RTPlans.First().NoFractions)));
                }
                else
                {
                    DiaInicio = AddBusinessDays(plan.StatusDate, Convert.ToDouble(parametro.Dias));
                    DiaFin = AddBusinessDays(plan.StatusDate, Convert.ToDouble(parametro.Dias + plan.RTPlans.First().NoFractions));
                }
                return (DiaInicio <= dia && DiaFin > dia);
            }
        }


        public static int? diasTreatApprovalInicioPorPlan(PlanSetup plan, List<Equipo> Equipos)
        {
            DateTime? fechaInicioT = fechaInicio(plan, Equipos);
            if (plan.Status == "TreatApproval")
            {
                DateTime? fechaTreatApproval = plan.StatusDate;
                {
                    if (fechaTreatApproval != null && fechaInicioT != null && fechaInicioT > fechaTreatApproval)
                    {
                        return Convert.ToInt32(GetBusinessDays((DateTime)fechaTreatApproval, (DateTime)fechaInicioT));
                    }
                    else
                    {
                        return null;
                    }
                }
                //return ((DateTime)fechaInicioT - (DateTime)fechaTreatApproval).Days;
            }
            else
            {
                return null;
            }
        }

        public static int? diasPlanApprovalInicioPorPlan(PlanSetup plan, Eclipse.Application app, List<Equipo> Equipos)
        {
            DateTime? fechaAprobacion = fechaAprobacionMedica(plan, app);
            DateTime? fechaInicioT = fechaInicio(plan, Equipos);
            if (fechaAprobacion != null && fechaInicioT != null && fechaInicioT > fechaAprobacion)
            {
                return Convert.ToInt32(GetBusinessDays((DateTime)fechaAprobacion, (DateTime)fechaInicioT));
                //return ((DateTime)fechaInicioT - (DateTime)fechaAprobacion).Days;
            }
            else
            {
                return null;
            }
        }

        public static int? diasCreacionInicioPorPlan(AriaQ.PlanSetup plan, List<Equipo> Equipos)
        {
            DateTime? fechaCreacion = plan.CreationDate;
            DateTime? fechaInicioT = fechaInicio(plan, Equipos);
            if (fechaCreacion != null && fechaInicioT != null && fechaInicioT > fechaCreacion)
            {
                return Convert.ToInt32(GetBusinessDays((DateTime)fechaCreacion, (DateTime)fechaInicioT));
                //return ((DateTime)fechaInicioT - (DateTime)fechaCreacion).Days;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region auxiliares
        public static string Modalidad(AriaQ.PlanSetup plan)
        {
            if (plan.Radiations.First().ExternalFieldCommon.Technique==null)
            {
                return "Indefinido";
            }
            if (plan.Radiations.First().ExternalFieldCommon.Technique.TechniqueId == "ARC" && plan.Radiations.First().ExternalFieldCommon.MLCPlans.Count>0 && plan.Radiations.First().ExternalFieldCommon.MLCPlans.First().MLCPlanType == "DynMLCPlan")
            {
                /*if (plan.Radiations.First().RadiationDevice.Machine.MachineId == "2100CMLC")
                {
                    return "3DC"; //Es un arco conformado. Tengo que ver como distinguirlo. Con el DoseRate probar
                }*/
                return "VMAT";
            }
            else if (plan.Radiations.First().ExternalFieldCommon.Technique.TechniqueId == "ARC")
            {
                return "VMAT";
            }
            else if (plan.Radiations.First().ExternalFieldCommon.Technique.TechniqueId == "STATIC")
            {
                if (plan.Radiations.First().ExternalFieldCommon.ControlPoints.Count > 30) //Esto es IMRT pero lo cuento como VMAT porque no hay estadistica de IMRT
                {
                    return "VMAT";
                    //return "IMRT";
                }
                else
                {
                    return "3DC";
                }
            }
            else
            {
                return "Indefinido";
            }
        }

        public static bool HayPlanesAprobadosEnCurso(PlanSetup plan)
        {
            return plan.Course.PlanSetups.Any(p => p.Status == "TreatApproval" || p.Status == "PlanApproval");
        }

        public static bool estaEnTratamiento(PlanSetup plan, List<Equipo> Equipos)
        {
            if (ultimaFraccion(plan, Equipos) != null)
            {
                return ultimaFraccion(plan, Equipos) < plan.RTPlans.First().NoFractions;
            }
            else
            {
                return false;
            }
        }

        public static bool CursoEstosMeses(PlanSetup plan)
        {
            string EsteMes = DateTime.Today.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).Substring(0, 3);
            string MesPasado = DateTime.Today.AddMonths(-1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).Substring(0, 3);
            string MesProximo = DateTime.Today.AddMonths(1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).Substring(0, 3);

            return (plan.Course.CourseId.ToLower().Contains(EsteMes) || plan.Course.CourseId.ToLower().Contains(MesPasado) || plan.Course.CourseId.ToLower().Contains(MesProximo)) && !plan.Course.CourseId.Contains("QA");
        }

        public static List<PlanSetup> FiltrarUnoPorPaciente(List<PlanSetup> listaCompleta)
        {
            List<PlanSetup> filtrada = new List<PlanSetup>();
            foreach (PlanSetup plan in listaCompleta)
            {
                if (!filtrada.Any(p => p.Course.PatientSer == plan.Course.PatientSer))
                {
                    filtrada.Add(plan);
                }
            }
            return filtrada;
        }

        public static List<PlanSetup> FiltrarPorEquiposMeva(List<PlanSetup> listaCompleta)
        {
            string[] equiposID = Equipo.Equipos().Select(e => e.ID).ToArray();
            return listaCompleta.Where(p => p.Radiations.Count > 0 && equiposID.Contains(p.Radiations.First().RadiationDevice.Machine.MachineId)).ToList();
        }

        public static List<DateTime> Feriados()
        {
            List<DateTime> feriados = new List<DateTime>();
            var lineas = File.ReadAllLines(Equipo.pathArchivos + "Feriados.txt");
            foreach (string linea in lineas)
            {
                try
                {
                    feriados.Add(DateTime.Parse(linea, new CultureInfo("es-ES", false)));
                }
                catch (Exception)
                {


                }
            }
            return feriados;
        }
        public static double GetBusinessDays(DateTime startD, DateTime endD) //Obtenidos de https://alecpojidaev.wordpress.com/2009/10/29/work-days-calculation-with-c/
        {
            if (startD.Equals(endD))
            {
                return 0;
            }
            else
            {
                double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

                if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
                if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;
                if ((endD - startD).Days > 0)
                {
                    List<DateTime> dias = Enumerable.Range(0, (endD - startD).Days + 1).Select(day => startD.AddDays(day)).ToList();
                    foreach (DateTime dia in dias)
                    {
                        if (Feriados().Contains(dia))
                        {
                            calcBusinessDays--;
                        }
                    }
                }


                return calcBusinessDays;
            }

        }

        public static DateTime AddBusinessDays(DateTime startD, double businessDays) //Obtenidos de https://alecpojidaev.wordpress.com/2009/10/29/work-days-calculation-with-c/
        {
            if (businessDays == 0)
            {
                return startD;
            }
            else
            {
                int DoW = (int)startD.DayOfWeek;

                double temp = businessDays + DoW + 1;

                if (DoW != 0)
                {
                    temp--;
                }
                DateTime endD = startD.AddDays(Math.Floor(temp / 5) * 2 - DoW + temp - 2 * Convert.ToInt32(temp % 5 == 0));
                List<DateTime> dias = Enumerable.Range(0, (endD - startD).Days).Select(day => startD.AddDays(day + 1)).ToList();
                int agregardias = 0;
                foreach (DateTime dia in dias)
                {
                    if (Feriados().Contains(dia))
                    {
                        agregardias++;
                    }
                }

                return AddBusinessDays(endD, agregardias);
            }
        }

        public static DateTime AddBusinessDaysSinFeriados(DateTime startD, double businessDays) //Obtenidos de https://alecpojidaev.wordpress.com/2009/10/29/work-days-calculation-with-c/
        {
            if (businessDays == 0)
            {
                return startD;
            }
            else
            {
                int DoW = (int)startD.DayOfWeek;

                double temp = businessDays + DoW + 1;

                if (DoW != 0)
                {
                    temp--;
                }
                return startD.AddDays(Math.Floor(temp / 5) * 2 - DoW + temp - 2 * Convert.ToInt32(temp % 5 == 0));
            }
        }
        #endregion

        #region Consultas combinadas
        public static bool pendienteImagen(PlanSetup plan, List<Equipo> Equipos)
        {
            string _modalidad = Modalidad(plan);
            bool esMama = false;
            /*if (plan.Course.Patient.LastName.ToUpper()=="RONDAN")
            {
                List<string> estructuras = plan.StructureSet.Structures.Select(s => s.StructureId).ToList();
            }
            if(plan.Intent != "VERIFICATION" && plan.StructureSet!=null)
            {
                esMama = plan.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains("ptv_wb")) || plan.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains("ptv_cw"));
            }*/
            if (estaEnTratamiento(plan, Equipos) && ((_modalidad == "VMAT" || _modalidad == "IMRT") || esMama))
            {
                int? uF = ultimaFraccion(plan, Equipos);
                int? uFI = ultimaFraccionConImagen(plan);
                //pacientesPlacas.Add(plan.Course.Patient.LastName + ", " + plan.Course.Patient.FirstName + ";" + _modalidad + ";" + esMama.ToString() + ";" + uF.ToString() + ";" + uFI.ToString());
                if (uF != null && uFI != null)
                {
                    return (uF - uFI > 5);
                }
            }
            return false;
        }

        public static bool pendienteImagen(PlanSetup plan, List<Equipo> Equipos, List<string> pacientesPlacas, bool esMinado)
        {

            string _modalidad = Modalidad(plan);
            bool esMama = false;
            /*if (plan.Course.Patient.LastName.ToUpper() == "RONDAN")
            {
                List<string> estructuras = plan.StructureSet.Structures.Select(s => s.StructureId).ToList();
            }*/
            if (plan.Intent != "VERIFICATION" && plan.StructureSet != null)
            {
                esMama = plan.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains("ptv_wb")) || plan.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains("ptv_cw"));
            }
            if (estaEnTratamiento(plan, Equipos) && ((_modalidad == "VMAT" || _modalidad == "IMRT") || esMama))
            {
                int? uF = ultimaFraccion(plan, Equipos);
                List<int> FraccImag = FraccionesConImagenes(plan);
                string FraccImagS = "";
                if (FraccImag != null)
                {
                    for (int i = 0; i < FraccImag.Count; i++)
                    {
                        FraccImagS += ";" + FraccImag[i].ToString();
                    }
                }
                pacientesPlacas.Add(Equipo.Seleccionar(Equipos, plan).ID + ";" + plan.Course.Patient.LastName + ", " + plan.Course.Patient.FirstName + ";" + _modalidad + ";" + esMama.ToString() + ";" + uF.ToString() + ";" + FraccImagS);
            }
            return false;
        }



        public static List<string> PacientesSiguenEnEquipoDia(Aria aria, Equipo equipo, double Dias)
        {
            if (equipo.EsDicomRT)
            {
                return MetodosDicomRT.PacientesSiguenEnEquipoDia(equipo, Dias, equipo.planPacientesActualizarFx());
            }
            else
            {
                DateTime dia = AddBusinessDays(DateTime.Today, Dias);
                Machine MEquipo = aria.Machines.Where(m => m.MachineId == equipo.ID).First();
                var Attendees = MEquipo.Resource.Attendees.Select(aa => aa.ActivityInstanceSer).ToList();
                //var aux = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == DateTime.Today && s.ObjectStatus.Equals("Active")).ToList();
                var SchAct = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == dia && s.ObjectStatus.Equals("Active")).ToList();
                List<string> pacientes = SchAct.Where(s => Attendees.Contains(s.ActivityInstanceSer) && s.Patient != null).Select(s => s.Patient.PatientId).ToList();
                //List<string> pacientes = SchAct.Where(s => Attendees.Contains(s.ActivityInstanceSer) && s.Patient != null).Select(s => s.Patient.LastName).ToList();
                pacientes.RemoveAll(p => p.Contains("E1-2022") || p.Contains("4-2022"));
                return pacientes;
            }
        }

        public static int? PromedioCreacionInicio(Aria aria, Equipo equipo, string modalidad, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            var planes = planesCreadosEntreFechas(aria, fechaInicial, fechaFinal).Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo.ID && Modalidad(p) == modalidad);
            List<int> dias = new List<int>();
            List<PlanSetup> planesFiltrados = planes.Where(p => !p.Course.CourseId.Contains("QA") && !p.Course.CourseId.Contains("Fisica") && !p.Course.PlanSetups.Any(pc => pc.PlanSetupId!=p.PlanSetupId && (pc.Status == "TreatApproval" || pc.Status == "PlanApproval"))).ToList();
            var pacientes = planesFiltrados.Select(p => p.Course.Patient.PatientId + "-" + p.Course.Patient.LastName).ToList();
            foreach (PlanSetup plan in planesFiltrados)
            {
                int? dia = diasCreacionInicioPorPlan(plan, equipo.ToList());
                if (dia != null && dia > 0 && dia < 20)
                {
                    dias.Add((int)dia);
                }
            }
            if (dias.Count > 0)
            {
                return Convert.ToInt32(Math.Round(dias.Average(), 0, MidpointRounding.AwayFromZero));
            }
            else
            {
                return null;
            }
        }

        public static int? PromedioPlanApprovalInicio(Aria aria, Eclipse.Application app, Equipo equipo, string modalidad, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            List<PlanSetup> planes = planesCreadosEntreFechas(aria, fechaInicial, fechaFinal).Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo.ID && Modalidad(p) == modalidad).ToList();
            List<int> dias = new List<int>();
            foreach (PlanSetup plan in planes)
            {
                int? dia = diasPlanApprovalInicioPorPlan(plan, app, equipo.ToList());
                if (dia != null && dia > 0 && dia < 20)
                {
                    dias.Add((int)dia);
                }
            }
            if (dias.Count > 0)
            {
                return Convert.ToInt32(Math.Round(dias.Average(), 0, MidpointRounding.AwayFromZero));
            }
            else
            {
                return null;
            }
        }

        public static int? PromedioTreatApprovalInicio(Aria aria, Equipo equipo, string modalidad, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            List<PlanSetup> planes = planesCreadosEntreFechas(aria, fechaInicial, fechaFinal).Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo.ID && Modalidad(p) == modalidad).ToList();
            List<int> dias = new List<int>();
            foreach (PlanSetup plan in planes)
            {
                int? dia = diasTreatApprovalInicioPorPlan(plan, equipo.ToList());
                if (dia != null && dia > 0 && dia < 20)
                {
                    dias.Add((int)dia);
                }
            }
            if (dias.Count > 0)
            {
                return Convert.ToInt32(Math.Round(dias.Average(), 0, MidpointRounding.AwayFromZero));
            }
            else
            {
                return null;
            }

        }

        public static int? PromedioStatusInicio(string status, Aria aria, Eclipse.Application app, Equipo equipo, string modalidad, DateTime fechaInicial, DateTime? fechaFinal = null)
        {
            if (status == "Unapproved")
            {
                return PromedioCreacionInicio(aria, equipo, modalidad, fechaInicial, fechaFinal);
            }
            else if (status == "PlanApproval")
            {
                return PromedioPlanApprovalInicio(aria, app, equipo, modalidad, fechaInicial, fechaFinal);
            }
            else if (status == "TreatApproval")
            {
                return PromedioTreatApprovalInicio(aria, equipo, modalidad, fechaInicial, fechaFinal);
            }
            else
            {
                return null;
            }
        }



        public static List<PlanSetup> pacientesImagenesAtrasadas(Aria aria, Equipo equipo, DateTime fechaInicial)
        {
            List<PlanSetup> planes = PlanesConAprobacionFisicaOMedica(equipo.ID, aria, fechaInicial);
            List<PlanSetup> pacientePendiente = new List<PlanSetup>();
            List<string> pacientesPlacas = new List<string>();
            foreach (PlanSetup plan in planes)
            {
                if (pendienteImagen(plan, equipo.ToList()))
                {
                    //var uf = ultimaFraccionConImagen(plan);
                    pacientePendiente.Add(plan);
                }
            }
            File.WriteAllLines(@"C:\pacientesPlacas.txt", pacientesPlacas.ToArray());
            return pacientePendiente;
        }

        public static List<PlanSetup> pacientesImagenesAtrasadas(Aria aria, Equipo equipo, DateTime fechaInicial, List<string> pacientesPlacas, bool EsMinado)
        {
            List<PlanSetup> planes = PlanesConAprobacionFisicaOMedica(equipo.ID, aria, fechaInicial);
            List<PlanSetup> pacientePendiente = new List<PlanSetup>();

            foreach (PlanSetup plan in planes)
            {
                pendienteImagen(plan, equipo.ToList(), pacientesPlacas, true);
            }
            return pacientePendiente;
        }


        public static void EscribirQAImagenesAtrasadas(Aria aria, List<Equipo> Equipos, DateTime fechaInicial)
        {
            List<PlanSetup> ImagenesAtrasadas = new List<PlanSetup>();
            foreach (Equipo equipo in Equipos)
            {
                if (!equipo.EsDicomRT)
                {
                    ImagenesAtrasadas.AddRange(pacientesImagenesAtrasadas(aria, equipo, fechaInicial));
                }
            }
            List<string> imagenesString = new List<string>();
            foreach (PlanSetup Plan in ImagenesAtrasadas)
            {
                imagenesString.Add(Plan.Course.Patient.PatientId + ";" + Plan.Course.Patient.LastName + ";" + Plan.Radiations.First().RadiationDevice.Machine.MachineId + ";" + Plan.PlanSetupId + ";" + ultimaFraccion(Plan, Equipos) + ";" + ultimaFraccionConImagen(Plan));
            }
            File.WriteAllLines(Equipo.pathArchivos + "QA_ImagenesAtrasadas.txt", imagenesString.ToArray());
        }

        public static void EscribirQAImagenesAtrasadas(Aria aria, List<Equipo> Equipos, DateTime fechaInicial, bool ParaMinar)
        {
            List<PlanSetup> ImagenesAtrasadas = new List<PlanSetup>();
            List<string> pacientesPlacas = new List<string>();
            foreach (Equipo equipo in Equipos)
            {
                if (!equipo.EsDicomRT)
                {
                    ImagenesAtrasadas.AddRange(pacientesImagenesAtrasadas(aria, equipo, fechaInicial, pacientesPlacas, true));
                }
            }
            File.WriteAllLines(@"C:\todasLasPlacas.txt", pacientesPlacas.ToArray());
            /*List<string> imagenesString = new List<string>();
            foreach (PlanSetup Plan in ImagenesAtrasadas)
            {
                imagenesString.Add(Plan.Course.Patient.PatientId + ";" + Plan.Course.Patient.LastName + ";" + Plan.Radiations.First().RadiationDevice.Machine.MachineId + ";" + Plan.PlanSetupId + ";" + ultimaFraccion(Plan, Equipos) + ";" + ultimaFraccionConImagen(Plan));
            }
            File.WriteAllLines(Equipo.pathArchivos + "QA_ImagenesAtrasadas.txt", imagenesString.ToArray());*/
        }

        public static List<PlanSetup> PacientesMamaEnTto(Aria aria, List<Equipo> Equipos)
        {
            string[] posiblesEst = { "wb", "vol", "lecho", "vmi", "vmd", "mama", "ascv", "axil", "scv", "supra", "mast" };
            var query = PlanesConAprobacionFisicaEnTto(aria, Equipos, 60).Where(p => ConsultasDB.estaEnTratamiento(p, Equipos));
            query = query.Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == "Equipo1" || p.Radiations.First().RadiationDevice.Machine.MachineId == "D-2300CD");
            query = query.Where(p => p.RTPlans.FirstOrDefault().NoFractions == 15 || p.RTPlans.FirstOrDefault().NoFractions == 25);
            List<PlanSetup> queryMama = new List<PlanSetup>();
            foreach (string est in posiblesEst)
            {
                queryMama.AddRange(query.Where(p => p.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains(est))).ToList());
            }
            return queryMama;
        }
        public static List<PlanSetup> planesVMATTiempoMenorA3(Aria aria, Equipo equipo, DateTime fechaInicial)
        {
            List<PlanSetup> planes = PlanesConAprobacionFisicaOMedica(equipo.ID, aria, fechaInicial);
            List<PlanSetup> planTiempoMal = new List<PlanSetup>();
            foreach (PlanSetup plan in planes)
            {
                if (!plan.Course.CourseId.Contains("QA") && Modalidad(plan) == "VMAT" && plan.Radiations.Any(r => r.ExternalFieldCommon.TreatmentTime != null && r.ExternalFieldCommon.TreatmentTime < 2))
                {
                    planTiempoMal.Add(plan);
                }
            }
            return planTiempoMal;
        }

        public static void EscribirQAVMATTiempomenorA3(Aria aria, List<Equipo> Equipos, DateTime fechaInicial)
        {
            List<PlanSetup> VMATcortos = new List<PlanSetup>();
            foreach (Equipo equipo in Equipos)
            {
                if (!equipo.EsDicomRT)
                {
                    VMATcortos.AddRange(planesVMATTiempoMenorA3(aria, equipo, fechaInicial));
                }
            }
            List<string> imagenesString = new List<string>();
            foreach (PlanSetup Plan in VMATcortos)
            {
                imagenesString.Add(Plan.Course.Patient.PatientId + ";" + Plan.Course.Patient.LastName + ";" + Plan.Radiations.First().RadiationDevice.Machine.MachineId + ";" + Plan.PlanSetupId + ";" + estaEnTratamiento(Plan, Equipos).ToString());
            }
            File.WriteAllLines(Equipo.pathArchivos + "QA_VMATcorto.txt", imagenesString.ToArray());
        }

        #endregion

        #region En desuso o en Form2
        public static List<int> numeroPacientesPorEquipo(List<Equipo> Equipos, DateTime dia, Aria aria, Eclipse.Application app)
        {
            List<PlanSetup> planes = PacientesEncurso(aria, Equipos);
            List<int> numeroPacientes = new List<int> { 0, 0, 0 };
            foreach (PlanSetup plan in planes)
            {
                if (estaraEnEquipo(app, plan, dia, Equipos))
                {
                    int indiceEquipo = Equipos.IndexOf(Equipos.Where(e => plan.Radiations.First().RadiationDevice.Machine.MachineId == e.ID).First());
                    int numero = numeroPacientes.ElementAt(indiceEquipo);
                    numero++;
                }
            }
            return numeroPacientes;
        }

        public static string DateTimeNullToString(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                return ((DateTime)dateTime).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                return "";
            }
        }

        public static List<string> PacientesEnEquipoHoy(Aria aria, Equipo equipo)
        {
            if (equipo.EsDicomRT)
            {
                return MetodosDicomRT.PacientesSiguenEnEquipoDia(equipo, 0, equipo.planPacientesActualizarFx());
            }
            else
            {
                Machine MEquipo = aria.Machines.Where(m => m.MachineId == equipo.ID).First();
                var Attendees = MEquipo.Resource.Attendees.Select(aa => aa.ActivityInstanceSer).ToList();
                //var aux = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == DateTime.Today && s.ObjectStatus.Equals("Active")).ToList();
                var SchAct = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == DateTime.Today && s.ObjectStatus.Equals("Active")).ToList();
                List<string> pacientes = SchAct.Where(s => Attendees.Contains(s.ActivityInstanceSer) && s.Patient != null).Select(s => s.Patient.PatientId).ToList();
                pacientes.RemoveAll(p => p.Contains("1-0000"));
                return pacientes;
            }
        }

        public static List<string> TBIsDia(Aria aria, Equipo equipo, double Dias)
        {
            DateTime dia = AddBusinessDays(DateTime.Today, Dias);
            Machine MEquipo = aria.Machines.Where(m => m.MachineId == equipo.ID).First();
            var Attendees = MEquipo.Resource.Attendees.Select(aa => aa.ActivityInstanceSer).ToList();
            //var aux = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == DateTime.Today && s.ObjectStatus.Equals("Active")).ToList();
            var SchAct = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == dia && s.ObjectStatus.Equals("Active")).ToList();
            List<string> pacientes = SchAct.Where(s => Attendees.Contains(s.ActivityInstanceSer) && s.Patient != null).Select(s => s.Patient.PatientId).ToList();
            //List<string> pacientes = SchAct.Where(s => Attendees.Contains(s.ActivityInstanceSer) && s.Patient != null).Select(s => s.Patient.LastName).ToList();
            pacientes.RemoveAll(p => p.Contains("1-0000"));
            return pacientes;
        }



        public static PlanSetup PlanDePacienteEnEquipo(Aria aria, List<Equipo> Equipos, string idPaciente)
        {
            if (aria.Patients.Any(p => p.PatientId == idPaciente))
            {
                Patient paciente = aria.Patients.Where(p => p.PatientId == idPaciente).First();
                foreach (Course curso in paciente.Courses)
                {
                    foreach (PlanSetup plan in curso.PlanSetups.Where(p => p.Status == "TreatApproval"))
                    {
                        if (estaEnTratamiento(plan, Equipos))
                        {
                            return plan;
                        }
                    }
                }
            }
            else
            {
                /* foreach (Equipo equipoDicomRT in Equipos.Where(e => e.EsDicomRT))
                 {
                     if (equipoDicomRT.LeerEnCurso().Any(p => p.PacienteID == idPaciente))
                     {
                         PlanPaciente planPaciente = equipoDicomRT.LeerEnCurso().Where(p => p.PacienteID == idPaciente).First();
                         PlanSetup planSetup = new PlanSetup();
                         planSetup.PlanSetupId = planPaciente.PlanID;
                     }
                 }*/
            }
            return null;
        }

        public static Tuple<int, double> diasPlanApproval(Aria aria, Eclipse.Application app, Equipo equipo, string Modalidad, DateTime fechaInicial, DateTime? fechaFinal = null)
        {

            List<PlanSetup> planes = PlanesConAprobacionFisicaOMedica(equipo.ID, aria, fechaInicial, fechaFinal);
            List<int> dias = new List<int>();
            foreach (PlanSetup plan in planes)
            {
                if (ConsultasDB.Modalidad(plan) == Modalidad)
                {
                    int? dia = diasPlanApprovalInicioPorPlan(plan, app, equipo.ToList());
                    if (dia != null && dia >= 0)
                    {
                        dias.Add((int)dia);
                    }
                }
            }
            if (dias.Count > 0)
            {
                return new Tuple<int, double>(dias.Count(), dias.Average());
            }
            else
            {
                return new Tuple<int, double>(0, 0);
            }
        }

        public static List<string> infoPacientesAprobados(Eclipse.Application app, Aria aria, DateTime fechaInicial, List<Equipo> equipos, DateTime? fechaFinal = null)
        {
            List<string> info = new List<string>();
            info.Add("ID;Plan;Equipo;Status;FechaCreacion;DiasCreacionInicio;DiasApMedInicio;DiasApFisicaInicio;Modalidad;Fx completadas; Fx totales");
            foreach (Equipo equipo in equipos)
            {
                List<PlanSetup> planesAprobados = PlanesConAprobacionFisicaOMedica(equipo.ID, aria, fechaInicial, fechaFinal);
                foreach (PlanSetup plan in planesAprobados)
                {
                    DateTime? FechaCreacion = plan.CreationDate;
                    DateTime? FechaPlanApproval = fechaAprobacionMedica(plan, app);
                    DateTime? FechaTreatApproval = fechaAprobacionFisica(plan);
                    DateTime? FechaInicio = fechaInicio(plan, equipos);
                    string infoPlan = plan.Course.Patient.PatientId + ";" + plan.PlanSetupId + ";" + plan.Radiations.First().RadiationDevice.Machine.MachineId + ";" + plan.Status + ";" + plan.CreationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" + IntNullToString(DiasEntre(plan.CreationDate, FechaInicio)) + ";" + IntNullToString(DiasEntre(FechaPlanApproval, FechaInicio)) + ";";
                    infoPlan += IntNullToString(DiasEntre(FechaTreatApproval, FechaInicio)) + ";" + Modalidad(plan) + ";" + plan.RTPlans.First().SessionRTPlans.Where(s => s.Status.Contains("COMP")).Count().ToString() + ";" + plan.RTPlans.First().NoFractions;
                    info.Add(infoPlan);
                }
            }
            return info;
        }
        public static int? DiasEntre(DateTime? inicio, DateTime? fin)
        {
            if (inicio != null && fin != null)
            {
                return Convert.ToInt32(GetBusinessDays((DateTime)inicio, (DateTime)fin));
            }
            else
            {
                return null;
            }
        }

        public static string IntNullToString(int? valor)
        {
            if (valor != null)
            {
                return valor.ToString();
            }
            else
            {
                return "";
            }
        }

        public static void buscaPbElectrones()
        {
            Aria aria = new Aria();
            PlanSetup plan = aria.PlanSetups.Where(p => p.Course.Patient.PatientId == "1-90293-0" && p.PlanSetupId == "Plan3").First();
            List<Block> bloques = new List<Block>();
            foreach (var campo in plan.Radiations)
            {
                List<int> valores = new List<int>();
                byte[] coordenadas = campo.ExternalFieldCommon.Blocks.First().Coordinates;
                for (int i = 0; i < campo.ExternalFieldCommon.Blocks.First().CoordinatesLen / 8; i++)
                {
                    //byte[] array = new byte[] { coordenadas[8 * i], coordenadas[8 * i + 1], coordenadas[8 * i + 2], coordenadas[8 * i + 3] };
                    //byte[] array2 = array.Reverse().ToArray();
                    int valor = BitConverter.ToInt32(coordenadas.Reverse().ToArray(), 8 * i);
                    valores.Add(valor);
                }
                //int[] bytesAsInts = campo.ExternalFieldCommon.Blocks.First().Coordinates.Select(x => (int)x).ToArray();
                //string[] strings = bytesAsInts.Select(x => x.ToString()).ToArray();
                string[] strings = valores.Select(x => x.ToString()).ToArray();
                File.WriteAllLines(@"C:\coordenadas" + campo.RadiationId + ".txt", strings);
            }

        }

        public static List<PlanPaciente> busquedaQAPE(Aria aria)
        {
            List<Equipo> Equipos = Equipo.InicializarEquipos();
            IQueryable<PlanSetup> query;
            DateTime unMes = DateTime.Today.AddDays(-30);
            List<PlanPaciente> planPacientesQAPE = new List<PlanPaciente>();
            query = aria.PlanSetups.Where(p => p.Course.Patient.PatientId != null && p.Course.Patient.LastName != null);
            query = query.Where(p => p.Intent != "VERIFICATION");
            query = query.Where(p => p.Radiations.Any(r => (r.ExternalFieldCommon.ControlPoints.Any(c => c.GantryRtn != null) && r.ExternalFieldCommon.MLCPlans.FirstOrDefault().IndexParameterType.ToLower().Contains("imrt")) || (r.ExternalFieldCommon.ControlPoints.Count > 30 && r.ExternalFieldCommon.ControlPoints.FirstOrDefault().GantryRtn == null)));
            //query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.ControlPoints.Count > 30 && r.ExternalFieldCommon.ControlPoints.FirstOrDefault().GantryRtn == null));
            query = query.Where(p => p.CreationDate >= unMes);
            query = query.Where(p => p.Radiations.FirstOrDefault().RadiationDevice.Machine.MachineId != "PBA_6EX_730");
            query = query.Where(p => p.Status == "PlanApproval" || p.Status == "Unapproved");
            var lista = query.ToList();
            foreach (var plan in query)
            {
                PlanPaciente planPaciente = new PlanPaciente(plan);
                if (planPaciente.Status == "PlanApproval")
                {
                    planPaciente.RequierePlanQA = true;
                }
                else
                {
                    planPaciente.RequierePlanQA = false;
                }

                var paciente = plan.Course.Patient;
                if (plan.RTPlans.First().PlanRelationships1.Count > 0)
                {
                    planPaciente.TienePlanQA = true;
                    long RTPPlanVerSer = plan.RTPlans.First().PlanRelationships1.FirstOrDefault().RTPlanSer;
                    var RTPlanVer = aria.RTPlans.FirstOrDefault(p => p.RTPlanSer == RTPPlanVerSer);
                    if (RTPlanVer.SessionRTPlans.Count > 0)
                    {

                        if (RTPlanVer.PlanSetup.Radiations.FirstOrDefault().SliceRTs.Any(s => s.AcqNote != null))
                        {
                            planPaciente.SeMidioPlanQA = true;
                        }
                        else
                        {
                            planPaciente.SeMidioPlanQA = false;
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    planPaciente.TienePlanQA = false;
                }
                planPacientesQAPE.Add(planPaciente);
            }
            return planPacientesQAPE;
        }

        public static void ActualizarQAPE(Aria aria)
        {
            //Aria aria = new Aria();
            List<PlanPaciente> planesEnArchivo = new List<PlanPaciente>();
            List<PlanPaciente> planesNuevos = busquedaQAPE(aria);
            List<PlanPaciente> planesRemover = new List<PlanPaciente>();
            if (File.Exists(Equipo.pathArchivos + "pacientesQAPE.txt") && new FileInfo(Equipo.pathArchivos + "pacientesQAPE.txt").Length > 0)
            {
                planesEnArchivo.AddRange(PlanPaciente.ExtraerDeArchivo(Equipo.pathArchivos + "pacientesQAPE.txt", 1));//.Where(p=>p.NotaQA!=""));
                foreach (PlanPaciente planEnArchivo in planesEnArchivo)
                {
                    if (!planEnArchivo.actualizarPlanPacienteQA(planesNuevos, aria))
                    {
                        planesRemover.Add(planEnArchivo);
                    }
                    if (planesNuevos.Contains(planEnArchivo))
                    {
                        planesNuevos.Remove(planEnArchivo);
                    }

                }
                foreach (PlanPaciente planRemover in planesRemover)
                {
                    planesEnArchivo.Remove(planRemover);
                }
            }
            planesEnArchivo.AddRange(planesNuevos);
            File.WriteAllLines(Equipo.pathArchivos + "pacientesQAPE.txt", planesEnArchivo.Select(p => p.ToString()).ToArray());
            agregarDateTime(Equipo.pathArchivos + "pacientesQAPE.txt");
            List<PlanPaciente> pacientesRequiereQA = planesEnArchivo.Where(p => p.RequierePlanQA).ToList();
            File.WriteAllLines(Equipo.pathArchivos + "pacientesRequiereQAPE.txt", pacientesRequiereQA.Select(p => p.ToStringQAPE()).ToArray());
            agregarHeader(Equipo.pathArchivos + "pacientesRequiereQAPE.txt");
        }

        public static void agregarDateTime(string path)
        {
            List<string> texto = File.ReadAllLines(path).ToList();
            texto.Insert(0, DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " " + DateTime.Now.ToShortTimeString());
            File.WriteAllLines(path, texto.ToArray());
        }
        public static void agregarDateTime(string path, string _dateTime)
        {
            List<string> texto = File.ReadAllLines(path).ToList();
            texto.Insert(0, _dateTime);
            File.WriteAllLines(path, texto.ToArray());
        }

        public static void agregarHeader(string path)
        {
            List<string> texto = File.ReadAllLines(path).ToList();
            string header = "ID;Nombre;Plan;Fecha;Equipo;Tiene Plan QA; Se Midio;Plan QA OK;Nota";
            texto.Insert(0, header);
            File.WriteAllLines(path, texto.ToArray());
        }
        public static string LeerDateTimeQAPE()
        {
            if (File.Exists(Equipo.pathArchivos + "pacientesQAPE.txt"))
            {
                return File.ReadAllLines(Equipo.pathArchivos + "pacientesQAPE.txt")[0];
            }
            return "";
        }




        public static List<PlanSetup> BusquedaGeneral(string apellidoContiene, string idContiene, string cursoContiene, string planContiene, string equipoEtiqueta, DateTime? fechaDesde, DateTime? fechaHasta, string modalidad, string estadoAprobacion, bool estaEnTratamiento, int? numeroFracciones, double? dosisDia, string estructura)
        {
            Aria aria = new Aria();
            int cuantos;
            List<Equipo> Equipos = Equipo.InicializarEquipos();
            IQueryable<PlanSetup> query;
            if (estaEnTratamiento)
            {
                List<string> pacientesEnEquipos = new List<string>();
                if (!string.IsNullOrEmpty(equipoEtiqueta))
                {
                    pacientesEnEquipos.AddRange(PacientesEnEquipoHoy(aria, Equipo.FromString(equipoEtiqueta)));
                }
                else
                {
                    foreach (Equipo equipo in Equipos)
                    {
                        pacientesEnEquipos.AddRange(PacientesEnEquipoHoy(aria, equipo));
                    }
                }
                List<PlanSetup> planesEnEquipo = new List<PlanSetup>();
                foreach (string pacienteEnEquipo in pacientesEnEquipos)
                {
                    PlanSetup plan = PlanDePacienteEnEquipo(aria, Equipos, pacienteEnEquipo);
                    if (plan != null && plan.Course.Patient.PatientId != null && plan.Course.Patient.LastName != null)
                    {
                        planesEnEquipo.Add(plan);
                    }

                }
                query = planesEnEquipo.AsQueryable();
                cuantos = query.Count();
                //query = query.Where(p => pacientesEnEquipos.Any(pE => pE == p.Course.Patient.PatientId) && p.PlanSetupSer==PlanDePacienteEnEquipo(aria, Equipos, p.Course.Patient).PlanSetupSer);
            }
            else
            {
                query = aria.PlanSetups.Where(p => p.Course.Patient.PatientId != null && p.Course.Patient.LastName != null);
                //var toconas = query.Where(p => p.PlanSetupId.ToLower().Contains("plan3_ci_arc") && p.Course.Patient.LastName.ToLower().Contains("palmieri")).ToList();
            }
            if (!string.IsNullOrEmpty(apellidoContiene))
            {
                query = query.Where(p => p.Course.Patient.LastName.ToLower().Contains(apellidoContiene.ToLower()));
                //  cuantos = query.Count();
            }
            if (!string.IsNullOrEmpty(idContiene))
            {
                query = query.Where(p => p.Course.Patient.PatientId.Contains(idContiene));
                // cuantos = query.Count();
            }
            if (!string.IsNullOrEmpty(cursoContiene))
            {
                query = query.Where(p => !p.Course.CourseId.ToLower().Contains(cursoContiene.ToLower()));
                //query = query.Where(p => p.Course.CourseId.ToLower().Contains(cursoContiene.ToLower()));
                // cuantos = query.Count();
            }
            if (!string.IsNullOrEmpty(planContiene))
            {
                query = query.Where(p => p.PlanSetupId.ToLower().Contains(planContiene.ToLower()));
                //  cuantos = query.Count();
            }
            if (!string.IsNullOrEmpty(equipoEtiqueta))
            {
                query = query.Where(p => p.Radiations.Any(r => r.RadiationDevice.Machine.MachineId == equipoEtiqueta));
                cuantos = query.Count();
            }
            if (fechaDesde != null)
            {
                query = query.Where(p => p.CreationDate >= fechaDesde);
                //  cuantos = query.Count();
            }
            if (fechaHasta != null)
            {
                query = query.Where(p => p.CreationDate <= fechaHasta);
                //    cuantos = query.Count();
            }
            if (!string.IsNullOrEmpty(modalidad))
            {
                if (modalidad == "10MV")
                {
                    query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.EnergyMode.Energy == 10000));
                }
                else if (modalidad == "SRS")
                {
                    query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.ExternalField.DoseRate == 1000));
                }
                else if (modalidad == "Electrones")
                {
                    query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.EnergyMode.RadiationType == "E"));
                    //query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.EnergyMode.Energy > 17000));

                }
                else if (modalidad == "VMAT")
                {
                    query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.ControlPoints.Any(c => c.GantryRtn != null) && r.ExternalFieldCommon.MLCPlans.FirstOrDefault().IndexParameterType.ToLower().Contains("imrt")));

                }
                else if (modalidad == "IMRT")
                {
                    query = query.Where(p => p.Radiations.Any(r => r.ExternalFieldCommon.ControlPoints.Count > 30 && r.ExternalFieldCommon.ControlPoints.FirstOrDefault().GantryRtn == null));
                }


            }
            if (!string.IsNullOrEmpty(estadoAprobacion))
            {
                query = query.Where(p => p.Status == estadoAprobacion);
            }
            if (numeroFracciones != null)
            {
                query = query.Where(p => p.RTPlans.FirstOrDefault().NoFractions != null && p.RTPlans.FirstOrDefault().NoFractions == numeroFracciones);
            }
            if (dosisDia != null)
            {
                double dosisDiaCorr = Math.Round((double)dosisDia, 2);
                query = query.Where(p => p.RTPlans.FirstOrDefault().PrescribedDose != null && Math.Round((double)p.RTPlans.FirstOrDefault().PrescribedDose, 2) == dosisDiaCorr);
            }
            if (!string.IsNullOrEmpty(estructura))
            {
                query = query.Where(p => p.StructureSet.Structures.Any(s => s.StructureId.Contains(estructura)));
            }
            try
            {
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<PlanSetup>();
            }
        }



        #endregion

        public static List<PacienteTBI> BuscarTodosLosPacientesTBIs(Aria aria)
        {
            List<PacienteTBI> pacientesTBI = new List<PacienteTBI>();
            DateTime dosMeses = DateTime.Today.AddDays(-60.0);
            List<AriaQ.PlanSetup> query = aria.PlanSetups.Where((AriaQ.PlanSetup p) => p.PlanSetupId.ToUpper().Contains("TBI") && p.Status != "Rejected").ToList();
            query = query.Where((AriaQ.PlanSetup p) => p.CreationDate >= dosMeses).ToList();
            query = (from p in query
                     group p by p.Course.Patient.PatientId into @group
                     select @group.First()).ToList();
            foreach (AriaQ.PlanSetup plansetup in query)
            {
                pacientesTBI.Add(new PacienteTBI(plansetup));
            }
            return pacientesTBI;
        }

        public static List<AriaQ.PlanSetup> BuscarTodosLosPacientesPSTBIs(Aria aria)
        {
            DateTime dosMeses = DateTime.Today.AddDays(-60.0);
            List<AriaQ.PlanSetup> query = aria.PlanSetups.Where((AriaQ.PlanSetup p) => p.PlanSetupId.ToUpper().Contains("TBI") && p.Status != "Rejected").ToList();
            query = query.Where((AriaQ.PlanSetup p) => p.CreationDate >= dosMeses).ToList();
            return (from p in query
                    group p by p.Course.Patient.PatientId into @group
                    select @group.First()).ToList();
        }

        public static List<AriaQ.PlanSetup> BuscarPacientesPSTBIs(Aria aria, List<PacienteTBI> pacientesLista)
        {
            List<string> IDsRed = pacientesLista.Select((PacienteTBI p) => p.ID.Remove(p.ID.Count() - 2)).ToList();
            List<AriaQ.Patient> query = aria.Patients.Where((AriaQ.Patient p) => IDsRed.Any((string i) => p.PatientId.Contains(i))).ToList();
            List<AriaQ.PlanSetup> planSetups = new List<AriaQ.PlanSetup>();
            foreach (AriaQ.Patient paciente in query)
            {
                foreach (AriaQ.Course curso in paciente.Courses)
                {
                    if (curso.PlanSetups.Any((AriaQ.PlanSetup p) => p.PlanSetupId.ToUpper().Contains("TBI") && !p.PlanSetupId.ToUpper().Contains("PROT") && p.Status != "Rejected"))
                    {
                        planSetups.Add(curso.PlanSetups.First((AriaQ.PlanSetup p) => p.PlanSetupId.ToUpper().Contains("TBI") && !p.PlanSetupId.ToUpper().Contains("PROT") && p.Status != "Rejected"));
                        break;
                    }
                }
            }
            return planSetups;
        }

        public static void ActualizarPacTBI(Aria aria)
        {
            List<PacienteTBI> pacientesEnArchivo = PacienteTBI.LeerArchivo();
            List<AriaQ.PlanSetup> pacientesEnAria = BuscarPacientesPSTBIs(aria, pacientesEnArchivo);
            foreach (AriaQ.PlanSetup pacienteEnAria in pacientesEnAria)
            {
                if (pacientesEnArchivo.Any((PacienteTBI p) => pacienteEnAria.Course.Patient.PatientId.Contains(p.ID.Remove(p.ID.Count() - 2))))
                {
                    pacientesEnArchivo.First((PacienteTBI p) => pacienteEnAria.Course.Patient.PatientId.Contains(p.ID.Remove(p.ID.Count() - 2))).Actualizar(pacienteEnAria);
                }
                else
                {
                    pacientesEnArchivo.Add(new PacienteTBI(pacienteEnAria));
                }
            }
            List<PacienteTBI> pacientesContinuan = PacienteTBI.eliminarFinalizados(pacientesEnArchivo);
            PacienteTBI.EscribirArchivo(pacientesContinuan);
        }


    }
}

