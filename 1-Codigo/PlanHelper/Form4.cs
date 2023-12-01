using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AriaQ;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using Eclipse = VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace PlanHelper
{
    public partial class Form4 : Form
    {
        Aria aria = new Aria();
        Eclipse.Application app = Eclipse.Application.CreateApplication("paberbuj", "123qwe");
        List<Equipo> Equipos = new List<Equipo>();
        public Form4()
        {
           

                /* foreach (PlanSetup p in mamas)
                {
                    output.Add(p.Course.Patient.PatientId + ";" + p.Course.Patient.LastName + ", " + p.Course.Patient.FirstName + ";" + p.PlanSetupId + ";" + p.StatusDate.ToShortDateString() + ";" + p.RTPlans.FirstOrDefault().NoFractions.ToString());
                }
                */
                //File.WriteAllLines(@"c:\output.txt", output.ToArray());
                //MessageBox.Show("Se grabaron " + (output.Count() - 1).ToString() + " registros");                
                InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Dia = monthCalendar1.SelectionRange.Start;
            Tiempo_Tratamiento(Dia);
        }

        private void Tiempo_Tratamiento(DateTime Dia)
        {
            
            List<string> output = new List<string>();
            List<string> outputINOUT = new List<string>();

            Machine MEquipo = aria.Machines.Where(m => m.MachineId == "D-2300CD").First();
            var Attendees = MEquipo.Resource.Attendees.Select(aa => aa.ActivityInstanceSer).ToList();
            //var aux = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == DateTime.Today && s.ObjectStatus.Equals("Active")).ToList();
            var SchAct = aria.ScheduledActivities.Where(s => DbFunctions.TruncateTime(s.ScheduledStartTime) == Dia && s.ObjectStatus.Equals("Active")).ToList();
            List<string> pacientes = SchAct.Where(s => Attendees.Contains(s.ActivityInstanceSer) && s.Patient != null).Select(s => s.Patient.PatientId).ToList();
            pacientes.RemoveAll(p => p.Contains("1-0000"));
            foreach (string pat in pacientes)
            {
                Patient currpat =aria.Patients.Where(p => p.PatientId == pat).First();
                string Nombre = (currpat.LastName + ", " + currpat.FirstName);
                List<TreatmentRecord> Tr = currpat.TreatmentRecords.ToList();
                List<ScheduledActivity> SA = currpat.ScheduledActivities.ToList();
                foreach (TreatmentRecord Record in Tr)
                {
                    int Fraction=Record.RadiationHstries.First().FractionNumber;
                    string StartTime=Record.RadiationHstries.First().TreatmentStartTime.ToString();
                    string EndTime = Record.RadiationHstries.First().TreatmentEndTime.ToString();
                    output.Add(pat + ";" + Nombre + ";" +Fraction+";"+ StartTime + ";" + EndTime);
                }
                foreach (ScheduledActivity Act in SA)
                {
                    if (Act.ScheduledActivityCode == "Completed")
                    {
                        string InTime = Act.ActualStartDate.ToString();
                        string OutTime = Act.ActualEndDate.ToString();
                        outputINOUT.Add(pat + ";" + Nombre +  ";" + InTime + ";" + OutTime);
                    }
                }
            }
            
            //return pacientes;

            /*

            string[] posiblesEst = { "wb_eval", "cw_eval" };
            var query = aria.PlanSetups.Where(p => p.StructureSet != null && p.StructureSet.Structures.Count > 0 && p.Radiations.Count > 0).AsQueryable();
            var queryMama = query.Where(p => p.RTPlans.FirstOrDefault().NoFractions == 15 && p.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains("wb_eval"))).ToList();
            List<long> planSerials = new List<long>();
            List<long> pacientesSerial = new List<long>();
            List<string> output = new List<string>();
            output.Add("ID;Apellido;Plan;Dia Aprobacion;Año");
            var queryNormof = query.Where(p => p.RTPlans.FirstOrDefault().NoFractions == 25).ToList();
            foreach (string est in posiblesEst)
            {
                queryMama.AddRange(queryNormof.Where(p => p.StructureSet.Structures.Any(s => s.StructureId.ToLower().Contains(est))).ToList());
            }
            queryMama = queryMama.Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == "Equipo1" || p.Radiations.First().RadiationDevice.Machine.MachineId == "D-2300CD").ToList();
            queryMama = queryMama.Where(p => ConsultasDB.estaEnTratamiento(p, Equipos)).ToList();
            foreach (PlanSetup p in queryMama)
            {
                if (!planSerials.Contains(p.PlanSetupSer) && !pacientesSerial.Contains(p.Course.PatientSer))
                {
                    planSerials.Add(p.PlanSetupSer);
                    pacientesSerial.Add(p.Course.PatientSer);
                    output.Add(p.Course.Patient.PatientId + ";" + p.Course.Patient.LastName + ", " + p.Course.Patient.FirstName + ";" + p.PlanSetupId + ";" + p.StatusDate.ToShortDateString() + ";" + p.RTPlans.FirstOrDefault().NoFractions.ToString());
                }
            }*/
            File.WriteAllLines(@"c:\output.txt", output.ToArray());
            File.WriteAllLines(@"c:\outputINOUT.txt", outputINOUT.ToArray());
            MessageBox.Show("Se grabaron " + (output.Count() - 1).ToString() + " registros");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            HC_Tratamiento(textHC.Text);
        }

        

    private void HC_Tratamiento(string HC)
    {

        List<string> output = new List<string>();
        List<string> outputINOUT = new List<string>();
            
            Patient currpat = aria.Patients.Where(p => p.PatientId == HC).First();
            string Nombre = (currpat.LastName + ", " + currpat.FirstName);
            List<TreatmentRecord> Tr = currpat.TreatmentRecords.ToList();
            List<ScheduledActivity> SA = currpat.ScheduledActivities.ToList();
            foreach (TreatmentRecord Record in Tr)
            {
                int Fraction = Record.RadiationHstries.First().FractionNumber;
                string StartTime = Record.RadiationHstries.First().TreatmentStartTime.ToString();
                string EndTime = Record.RadiationHstries.First().TreatmentEndTime.ToString();
                output.Add(HC + ";" + Nombre + ";" + Fraction + ";" + StartTime + ";" + EndTime);
            }
            foreach (ScheduledActivity Act in SA)
            {
                if (Act.ScheduledActivityCode == "Completed")
                {
                    string InTime = Act.ActualStartDate.ToString();
                    string OutTime = Act.ActualEndDate.ToString();
                    outputINOUT.Add(HC + ";" + Nombre + ";" + InTime + ";" + OutTime);
                }
            }
        
        File.WriteAllLines(@"c:\outputHC.txt", output.ToArray());
        File.WriteAllLines(@"c:\outputINOUT_HC.txt", outputINOUT.ToArray());
        MessageBox.Show("Se grabaron " + (output.Count() - 1).ToString() + " registros");
    }
}
}
