using AriaQ;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

        public PlanPaciente(PlanSetup planSetup)
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
            DateTime.TryParse(aux[7],out fechaStatusAux);
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
        }
        public PlanPaciente(string String, bool actualizacionFracciones)
        {
            string[] aux = String.Split(';');
            PacienteID = aux[0];
            PacienteNombre = aux[1];
            PlanID = aux[2];
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
            if (NotaQA==null)
            {
                NotaQA = "";
            }
            return PacienteID + ";" + PacienteNombre + ";" + CursoID + ";" + PlanID + ";" + PlanSer.ToString() + ";" + Modalidad + ";" + Status + ";" + FechaStatus.ToString() + ";" + EquipoID + ";" + nfx +
                ";" + BeamRecordOverride.ToString() + ";" + AplicacionesRealizadas.ToString() + ";" + RequierePlanQA.ToString() + ";" + TienePlanQA.ToString() + ";" + SeMidioPlanQA.ToString() + ";" + PlanQAOK.ToString() + ";" + NotaQA.ToString();
        }

        public string ToStringQAPE()
        {
            return PacienteID + ";" + PacienteNombre + ";" + PlanID + ";" + FechaStatus.ToString() + ";" + EquipoID + ";" + TienePlanQA.ToString() + ";" + SeMidioPlanQA.ToString() + ";" + PlanQAOK.ToString() + ";" + NotaQA.ToString();
        }

        public override bool Equals(object otroPlan)
        {
            if (otroPlan.GetType() == typeof(PlanPaciente))
            {
                return (PacienteID == ((PlanPaciente)otroPlan).PacienteID) && (CursoID == ((PlanPaciente)otroPlan).CursoID) && (PlanSer == ((PlanPaciente)otroPlan).PlanSer) && (EquipoID == ((PlanPaciente)otroPlan).EquipoID);
            }
            else
            {
                return false;
            }
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

        public static List<PlanPaciente> ExtraerDeArchivo(string path, int saltear=0)
        {
            string[] archivo = File.ReadAllLines(path);
            List<PlanPaciente> lista = new List<PlanPaciente>();
            foreach (string linea in archivo.Skip(saltear))
            {
                lista.Add(new PlanPaciente(linea));
            }
            return lista;
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

        public static List<string> ConvertirListasToString(List<PlanSetup> planes)
        {
            List<string> planPacientes = new List<string>();
            foreach (PlanSetup plan in planes)
            {
                planPacientes.Add(new PlanPaciente(plan).ToString());
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
                if (planNuevo==null)
                {
                    return true;
                }
                else if (planNuevo.Status=="TreatApproval")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
