using AriaQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FechaStatus = Convert.ToDateTime(aux[7]);
            EquipoID = aux[8];
            if (aux[9] != "null")
            {
                NumeroFracciones = Convert.ToInt32(aux[9]);
            }
            else
            {
                NumeroFracciones = null;
            }
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
            if (NumeroFracciones!=null)
            {
                nfx = NumeroFracciones.ToString();
            }
            else
            {
                nfx = "null";
            }
            return PacienteID + ";" + PacienteNombre + ";" + CursoID + ";" + PlanID + ";" + PlanSer.ToString() + ";" + Modalidad + ";" + Status + ";" + FechaStatus.ToString() + ";" + EquipoID + ";" + nfx;
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
            if (Dias==0)
            {
                return false;
            }
            int? diasHastaInicio = equipo.Parametros.Where(p => p.StatusInicial == this.Status && p.Modalidad == this.Modalidad).First().Dias;
            if (diasHastaInicio!=null && ConsultasDB.AddBusinessDays(this.FechaStatus,Convert.ToDouble(diasHastaInicio))<ConsultasDB.AddBusinessDays(DateTime.Today,Dias) && ConsultasDB.AddBusinessDays(this.FechaStatus,Convert.ToDouble(diasHastaInicio + this.NumeroFracciones)) > ConsultasDB.AddBusinessDays(DateTime.Today,Dias))
            {
                return true;
            }
            return false;
        }
    }
}
