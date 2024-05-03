using AriaQ;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace PlanHelper
{
    public class PlanPaciente
    {
        public string PacienteID { get; set; }
        public string PacienteNombre { get; set; }
        public string CursoID { get; set; }
        public string PlanID { get; set; }
        public long PlanSer { get; set; }
        public string Modalidad { get; set; }
        public string Status { get; set; }
        public DateTime FechaStatus { get; set; }
        public string EquipoID { get; set; }
        public int? NumeroFracciones { get; set; }
        public bool BeamRecordOverride { get; set; }
        public int AplicacionesRealizadas { get; set; }
        public bool RequierePlanQA { get; set; }
        public bool TienePlanQA { get; set; }
        public bool SeMidioPlanQA { get; set; }
        public bool PlanQAOK { get; set; }
        public string NotaQA { get; set; }
        public int? UltimaFx { get; set; } //Valor que no se lee ni escribe en txt, se genera 1 vez cuando se actualiza la agenda de ocupacion en DicomRT
        public DateTime UltimaFecha { get; set; } //Valor que no se lee ni escribe en txt, se genera 1 vez cuando se actualiza la agenda de ocupacion en DicomRT
        public string CarpetaBackupPlan { get; set; }
        public Tecnica Tecnica { get; set; }

        public PlanPaciente(PlanSetup planSetup)
        {
            if (planSetup != null)
            {
                PacienteID = planSetup.Course.Patient.PatientId;
                PacienteNombre = planSetup.Course.Patient.LastName + ", " + planSetup.Course.Patient.FirstName;
                CursoID = planSetup.Course.CourseId;
                PlanID = planSetup.PlanSetupId;
                PlanSer = planSetup.PlanSetupSer;
                Modalidad = ConsultasDB.Modalidad(planSetup);
                Status = planSetup.Status;
                FechaStatus = planSetup.StatusDate;
                EquipoID = planSetup.Radiations.First().RadiationDevice.Machine.MachineId;
                NumeroFracciones = planSetup.RTPlans.First().NoFractions;
                Tecnica = Tecnica.Otro;
            }
        }

        public PlanPaciente(string String)
        {
            string[] aux = String.Split(';');
            PacienteID = aux[0];
            PacienteNombre = aux[1];
            CursoID = aux[2];
            PlanID = aux[3];
            PlanSer = Convert.ToInt32(aux[4]);
            Modalidad = aux[5];
            Status = aux[6];
            DateTime fechaStatusAux = DateTime.MinValue;
            DateTime.TryParse(aux[7], out fechaStatusAux);
            FechaStatus = fechaStatusAux;
            EquipoID = aux[8];
            if (aux[9] != "null")
            {
                NumeroFracciones = Convert.ToInt32(aux[9]);
            }
            else
            {
                NumeroFracciones = null;
            }
            if (aux.Count() > 16) //QAPE
            {
                BeamRecordOverride = Convert.ToBoolean(aux[10]);
                AplicacionesRealizadas = Convert.ToInt32(aux[11]);
                RequierePlanQA = Convert.ToBoolean(aux[12]);
                TienePlanQA = Convert.ToBoolean(aux[13]);
                SeMidioPlanQA = Convert.ToBoolean(aux[14]);
                PlanQAOK = Convert.ToBoolean(aux[15]);
                NotaQA = aux[16];
            }
            if (aux.Any(a => a.Contains("Tecnica:")))
            {
                Tecnica = (Tecnica)Enum.Parse(typeof(Tecnica), aux[17].Replace("Tecnica:", ""));
            }
        }
        public PlanPaciente(string String, bool actualizacionFracciones)
        {
            string[] aux = String.Split(';');
            PacienteID = aux[0];
            PacienteNombre = aux[1];
            PlanID = aux[2];
            Tecnica = Tecnica.Otro;
            AplicacionesRealizadas = Convert.ToInt32(aux[3]);
            //NumeroFracciones = Convert.ToInt32(aux[4]);
        }

        public PlanPaciente(string _ID, string _pacNombre, string _planId, int? _NumeroFracciones, string _EquipoID) //Para pacientes en equipo DICOMRT
        {
            PacienteID = _ID;
            PacienteNombre = _pacNombre;
            CursoID = " ";
            PlanID = _planId;
            PlanSer = 0000;
            Modalidad = " ";
            Status = "EnEquipo";
            FechaStatus = DateTime.MinValue;
            EquipoID = _EquipoID;
            NumeroFracciones = _NumeroFracciones;
            Tecnica = Tecnica.Otro;
        }

        public void ObtenerUltimaFx(string carpetaPaciente)
        {
            this.UltimaFx = MetodosDicomRT.ultimaFraccion(carpetaPaciente);
        }

        public string Apellido()
        {
            return PacienteNombre.Split(',')[0].ToUpper();
        }

        public string Nombre()
        {
            return PacienteNombre.Split(',')[1].ToUpper();
        }
        public override string ToString()
        {
            string nfx;
            if (NumeroFracciones != null)
            {
                nfx = NumeroFracciones.ToString();
            }
            else
            {
                nfx = "null";
            }
            /*string apRealizadas;
            if (AplicacionesRealizadas!=null)
            {
                apRealizadas = AplicacionesRealizadas.ToString();
            }
            else
            {
                apRealizadas = "null";
            }*/
            if (NotaQA == null)
            {
                NotaQA = "";
            }
            return PacienteID + ";" + PacienteNombre + ";" + CursoID + ";" + PlanID + ";" + PlanSer.ToString() + ";" + Modalidad + ";" + Status + ";" + FechaStatus.ToString() + ";" + EquipoID + ";" + nfx +
                ";" + BeamRecordOverride.ToString() + ";" + AplicacionesRealizadas.ToString() + ";" + RequierePlanQA.ToString() + ";" + TienePlanQA.ToString() + ";" + SeMidioPlanQA.ToString() + ";" + PlanQAOK.ToString() + ";" + NotaQA.ToString() + ";Tecnica:" + Tecnica.ToString();
        }

        public string ToStringQAPE()
        {
            return PacienteID + ";" + PacienteNombre + ";" + PlanID + ";" + FechaStatus.ToString() + ";" + EquipoID + ";" + TienePlanQA.ToString() + ";" + SeMidioPlanQA.ToString() + ";" + PlanQAOK.ToString() + ";" + NotaQA.ToString();
        }

        public override bool Equals(object otroPlan)
        {
            if (otroPlan.GetType() == typeof(PlanPaciente))
            {
                if (PlanSer == ((PlanPaciente)otroPlan).PlanSer)
                {
                    return true;
                }
                else
                {
                    return this.PacienteID == ((PlanPaciente)otroPlan).PacienteID && this.PlanID == ((PlanPaciente)otroPlan).PlanID;
                }
            }
            return false;
        }

        public static List<PlanPaciente> ConvertirListas(List<PlanSetup> planes)
        {
            List<PlanPaciente> planPacientes = new List<PlanPaciente>();
            foreach (PlanSetup plan in planes)
            {
                planPacientes.Add(new PlanPaciente(plan));
            }
            return planPacientes;
        }

        public static List<PlanPaciente> ExtraerDeArchivo(string path, int saltear = 0)
        {
            string[] archivo;
            List<PlanPaciente> lista = new List<PlanPaciente>();
            try
            {
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                    archivo = File.ReadAllLines(path);

                    foreach (string linea in archivo.Skip(saltear))
                    {
                        lista.Add(new PlanPaciente(linea));
                    }
                }
            }
            catch (IOException)
            {
                System.Threading.Thread.Sleep(1000);
                ExtraerDeArchivo(path, saltear);

            }
            return lista;
        }

        public static List<PlanPaciente> ExtraerSimple(string path)
        {
            List<PlanPaciente> planPacienteList = new List<PlanPaciente>();
            try
            {
                using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    fileStream.Close();
                    foreach (string readAllLine in File.ReadAllLines(path))
                        planPacienteList.Add(new PlanPaciente(readAllLine));
                }
            }
            catch (IOException ex)
            {
                Thread.Sleep(1000);
                PlanPaciente.ExtraerDeArchivo(path, 0);
            }
            return planPacienteList;
        }
        public static List<PlanPaciente> ExtraerDeArchivo(string path, int saltear = 0, bool esQAPE = false)
        {
            List<PlanPaciente> planPacienteList1 = (List<PlanPaciente>)null;
            if (esQAPE)
            {
                string path1 = Equipo.pathArchivos + "listaNegraQAPE.txt";
                if (File.Exists(path1))
                    planPacienteList1 = PlanPaciente.ExtraerSimple(path1);
            }
            List<PlanPaciente> planPacienteList2 = new List<PlanPaciente>();
            try
            {
                using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    fileStream.Close();
                    foreach (string String in ((IEnumerable<string>)File.ReadAllLines(path)).Skip<string>(saltear))
                        planPacienteList2.Add(new PlanPaciente(String));
                }
            }
            catch (IOException ex)
            {
                Thread.Sleep(1000);
                PlanPaciente.ExtraerDeArchivo(path, saltear);
            }
            if (planPacienteList1 != null && planPacienteList1.Count > 0)
            {
                foreach (PlanPaciente planPaciente in planPacienteList1)
                {
                    if (planPacienteList2.Contains(planPaciente))
                        planPacienteList2.Remove(planPaciente);
                }
            }
            return planPacienteList2;
        }

        public static List<PlanPaciente> ExtraerDeArchivo(string path, bool actualizacionFracciones)
        {
            string[] archivo = File.ReadAllLines(path);
            List<PlanPaciente> lista = new List<PlanPaciente>();
            foreach (string linea in archivo)
            {
                lista.Add(new PlanPaciente(linea, actualizacionFracciones));
            }
            return lista;
        }

        public static List<string> ConvertirListasToString(List<PlanSetup> planes, Aria aria)
        {
            List<string> planPacientes = new List<string>();
            foreach (PlanSetup plan in planes)
            {
                PlanPaciente planPaciente = new PlanPaciente(plan);
                if (planPaciente.PacienteID == null)
                {

                }
                planPaciente.DefinirTecnica(aria);
                planPacientes.Add(planPaciente.ToString());
            }
            return planPacientes;
        }

        public bool EstaraEnEquipo(Equipo equipo, double Dias)
        {
            if (Dias == 0)
            {
                return false;
            }
            int? diasHastaInicio = 0;
            if (equipo.Parametros.Any(p => p.StatusInicial == this.Status && p.Modalidad == this.Modalidad))
            {
                diasHastaInicio = equipo.Parametros.Where(p => p.StatusInicial == this.Status && p.Modalidad == this.Modalidad).First().Dias;
            }
            else
            {
                diasHastaInicio = Convert.ToInt32(equipo.Parametros.Select(p => p.Dias).Average());
            }

            if (diasHastaInicio != null && ConsultasDB.AddBusinessDays(this.FechaStatus, Convert.ToDouble(diasHastaInicio)) < ConsultasDB.AddBusinessDays(DateTime.Today, Dias) && ConsultasDB.AddBusinessDays(this.FechaStatus, Convert.ToDouble(diasHastaInicio + this.NumeroFracciones)) > ConsultasDB.AddBusinessDays(DateTime.Today, Dias))
            {
                return true;
            }
            return false;
        }

        public bool actualizarPlanPacienteQA(List<PlanPaciente> planesNuevos, Aria aria)
        {
            if (planesNuevos.Contains(this))
            {
                PlanPaciente planNuevo = planesNuevos.First(p => p.Equals(this));
                Status = planNuevo.Status;
                FechaStatus = planNuevo.FechaStatus;
                if (!RequierePlanQA) //por si es un unnaproved que se agrego manualmente
                {
                    RequierePlanQA = planNuevo.RequierePlanQA;
                }
                TienePlanQA = planNuevo.TienePlanQA;
                if (!SeMidioPlanQA) //por si se midio y tildo manualmente
                {
                    SeMidioPlanQA = planNuevo.SeMidioPlanQA;
                }
                return true;
            }
            else
            {

                PlanSetup planNuevo = aria.PlanSetups.FirstOrDefault(p => p.PlanSetupSer == this.PlanSer);
                if (planNuevo == null)
                {
                    return true;
                }
                else if (planNuevo.Status == "TreatApproval")
                {
                    return false;
                }
            }
            return true;
        }
        public static Tecnica DefinirTecnica(PlanSetup plan)
        {
            if (plan.Status == "TreatApproval")
            {
                if (plan.PlanSetupId.Contains("TBI"))
                {
                    return Tecnica.TBI;
                }
                if (plan.Radiations.First().RadiationDevice.Machine.MachineId == "D-2300CD")
                {
                    if (plan.Radiations.First().DoseMatrices.First().ResX == 1)
                    {
                        if (plan.RTPlans.First().NoFractions == 1 && plan.RTPlans.First().PrescribedDose > 9)
                        {
                            return Tecnica.SRS1fx;
                        }
                        else if (plan.Radiations.Any(r => r.RadiationId == "CBCT"))
                        {
                            return Tecnica.SBRT;
                        }
                        else if (plan.RTPlans.First().NoFractions == 3 || plan.RTPlans.First().NoFractions == 5)
                        {
                            return Tecnica.SRS3o5fx;
                        }
                    }
                }
                if (plan.Radiations.Any(r => r.RadiationId == "CBCT"))
                {
                    return Tecnica.IGRT;
                }
            }
            return Tecnica.Otro;
        }
        public void DefinirTecnica(Aria aria)
        {
            if (this.PacienteID == "")
            {
                return;
            }

            PlanSetup plan = new PlanSetup();
            if (this.PlanSer != 0000)
            {
                plan = aria.PlanSetups.FirstOrDefault(p => p.PlanSetupSer == this.PlanSer);
            }
            else if (this.PacienteID != null)
            {
                var cursosActivosNoQA = aria.Patients.FirstOrDefault(p => p.PatientId == this.PacienteID).Courses.Where(c => c.ClinicalStatus == "ACTIVE" && !c.CourseId.Contains("QA") && !c.CourseId.Contains("Fisica"));
                foreach (var curso in cursosActivosNoQA)
                {
                    plan = curso.PlanSetups.FirstOrDefault(p => p.PlanSetupId == this.PlanID && p.Status == "TreatApproval");
                    break;
                }
            }
            this.Tecnica = DefinirTecnica(plan);
        }
        public int TurnosPorPaciente()
        {
            return TurnosPorTecnica(this.Tecnica);
        }

        public static int TurnosPorTecnica(Tecnica tecnica)
        {
            if (tecnica == Tecnica.TBI)
            {
                return 4;
            }
            else if (tecnica == Tecnica.SRS1fx || tecnica == Tecnica.SBRT)
            {
                return 3;
            }
            else if (tecnica == Tecnica.IGRT)
            {
                return 1; //hay muchos con CBCT aunque no sean IGRT
            }
            return 1;
        }

        public static Tecnica TecnicaPorPacienteString(string ID, Aria aria)
        {
            var cursosActivosNoQA = aria.Patients.FirstOrDefault(p => p.PatientId == ID).Courses.Where(c => c.ClinicalStatus == "ACTIVE" && !c.CourseId.Contains("QA") && !c.CourseId.Contains("Fisica"));
            foreach (var curso in cursosActivosNoQA)
            {
                return DefinirTecnica(curso.PlanSetups.FirstOrDefault(p => p.Status == "TreatApproval"));
            }
            return Tecnica.Otro;
        }
        public static PlanPaciente PlanPacienteDeString(string ID, Aria aria)
        {
            var cursosActivosNoQA = aria.Patients.FirstOrDefault(p => p.PatientId == ID).Courses.Where(c => c.ClinicalStatus == "ACTIVE" && !c.CourseId.Contains("QA") && !c.CourseId.Contains("Fisica"));
            foreach (var curso in cursosActivosNoQA)
            {
                PlanPaciente plan = new PlanPaciente(curso.PlanSetups.FirstOrDefault(p => p.Status == "TreatApproval"));
                if (plan.PacienteID == null)
                {

                }
                plan.DefinirTecnica(aria);
                return plan;
            }
            return null;
        }

        public static int TurnosPorPacienteString(string ID, Aria aria)
        {
            var cursosActivosNoQA = aria.Patients.FirstOrDefault(p => p.PatientId == ID).Courses.Where(c => c.ClinicalStatus == "Active" && !c.CourseId.Contains("QA") && !c.CourseId.Contains("Fisica"));
            foreach (var curso in cursosActivosNoQA)
            {
                Tecnica tecnica = DefinirTecnica(curso.PlanSetups.FirstOrDefault(p => p.Status == "TreatApproval"));
                return TurnosPorTecnica(tecnica);
            }
            return 1;
        }

    }
    public enum Tecnica
    {
        TBI,
        SRS1fx,
        SRS3o5fx,
        SBRT,
        IGRT,
        Otro
    }

}
