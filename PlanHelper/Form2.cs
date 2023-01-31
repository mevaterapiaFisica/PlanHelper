using AriaQ;
using System;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eclipse = VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace PlanHelper
{
    public partial class Form2 : Form
    {
        Aria aria = new Aria();
        Eclipse.Application app = Eclipse.Application.CreateApplication("paberbuj", "123qwe");
        List<Equipo> Equipos = new List<Equipo>();
        public Form2(List<Equipo> _equipos)
        {
            Equipos = _equipos;
            var mamas = ConsultasDB.PacientesMamaEnTto(aria, Equipos);
            List<string> output = new List<string>();
            output.Add("ID;Apellido;Plan;Dia Aprobacion;Año");
            foreach (PlanSetup p in mamas)
            {
                output.Add(p.Course.Patient.PatientId + ";" + p.Course.Patient.LastName + ", " + p.Course.Patient.FirstName + ";" + p.PlanSetupId + ";" + p.StatusDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" + p.RTPlans.FirstOrDefault().NoFractions.ToString());
            }

            File.WriteAllLines(@"c:\output.txt", output.ToArray());
            MessageBox.Show("Se grabaron " + (output.Count() - 1).ToString() + " registros");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            InitializeComponent();

        }

        /*    public static void MinarTiempoDesdeApproval(Aria aria, Eclipse.Application app)
            {
                List<string> Equipos = new List<string>() { "Equipo1", "2100CMLC", "D-2300CD" };
                List<string> Modalidades = new List<string>() { "3DC", "IMRT", "VMAT" };
                List<string> output = new List<string>();
                output.Add("Desde;Hasta;Equipo;Modalidad;cantidad;dias");
                for (int i=0;i<6;i++)
                {
                    DateTime desde = DateTime.Today.AddMonths(i+2);
                    DateTime hasta = DateTime.Today.AddMonths(i);
                    foreach (string Equipo in Equipos)
                    {
                        foreach(string Modalidad in Modalidades)
                        {
                            Tuple<int, double> casos = ConsultasDB.diasPlanApproval(aria, app, Equipo, Modalidad, desde, hasta);
                            output.Add(desde.ToShortDateString() + ";" + hasta.ToShortDateString() + ";" + Equipo + ";" + Modalidad + ";" + casos.Item1.ToString() + ";" + casos.Item2.ToString());
                        }
                    }
                }
                File.WriteAllLines(@"output.txt", output.ToArray());
            }*/

        /*public static void MinarPendientePlacas(Aria aria)
        {
            List<string> Equipos = new List<string>() { "Equipo1", "D-2300CD" };
            List<string> output = new List<string>();
            output.Add("ID;Curso;Plan;Ultima Fx; Ultima Fx con Imagen");
            foreach (string equipo in Equipos)
            {
                output.AddRange(ConsultasDB.pacientesImagenesAtrasadas(aria, equipo, DateTime.Today.AddMonths(2)));
            }
            File.WriteAllLines(@"outputPendientePlacas.txt", output.ToArray());
        }*/

        public static void contarPacientesEnCadaEtapa(Aria aria, DataGridView dataGridView1)
        {
            /*var pacientesEnEquipo1 = ConsultasDB.PacientesEnEquipoHoy(aria,"Equipo1");
            var pacientesEnEquipo4 = ConsultasDB.PacientesEnEquipoHoy(aria, "D-2300CD");
            var planesEnPlanificacion = ConsultasDB.PlanesEnPlanificacion(aria);
            var planesConAporbacionMedica = ConsultasDB.PlanesConAprobacionMedica(aria);
            var planesConAporbacionFisica = ConsultasDB.PlanesConAprobacionFisica(aria);
            List<string> Equipos = new List<string>() { "Equipo1", "2100CMLC", "D-2300CD" };
            foreach (string equipo in Equipos)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                //dataGridView1.Rows.Add(row);
                row.Cells[0].Value = equipo;
                row.Cells[1].Value = planesEnPlanificacion.Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo).Count();
                row.Cells[2].Value = planesConAporbacionMedica.Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo).Count();
                row.Cells[3].Value = planesConAporbacionFisica.Where(p => p.Radiations.First().RadiationDevice.Machine.MachineId == equipo).Count();
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.Rows[0].Cells[4].Value = pacientesEnEquipo1.Count;
            dataGridView1.Rows[2].Cells[4].Value = pacientesEnEquipo4.Count;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //treatApprovalContraInicio();
            minarTratamientosMama();


        }

        private void minarPacientesAprobados()
        {
            //List<string> output = ConsultasDB.infoPacientesAprobados(app, aria, DateTime.Today.AddMonths(-5), Equipos);
            //File.WriteAllLines(@"c:\output.txt", output.ToArray());
        }

        private void minarTratamientosMama()
        {
            //string[] posiblesEst = {"wb", "vol", "lecho", "vmi", "vmd", "mama", "axil", "mast" };
            string[] posiblesEst = { "wb_eval", "cw_eval" };
            //string[] posiblesEst = { "wb", "vol", "lecho", "vmi", "vmd", "mama", "ascv", "axil", "scv", "supra", "mast" };
            //var query = aria.PlanSetups.Where(p => p.Status == "TreatApproval").Where(p => p.StatusDate.Year > 2018 && p.StructureSet!=null && p.StructureSet.Structures.Count>0).AsQueryable();
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
                    output.Add(p.Course.Patient.PatientId + ";" + p.Course.Patient.LastName + ", " + p.Course.Patient.FirstName + ";" + p.PlanSetupId + ";" + p.StatusDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" + p.RTPlans.FirstOrDefault().NoFractions.ToString());
                }
            }
            File.WriteAllLines(@"c:\output.txt", output.ToArray());
            MessageBox.Show("Se grabaron " + (output.Count() - 1).ToString() + " registros");
        }
        private void cuentaExploracionPlanes()
        {
            var reportes = Directory.GetFiles(@"\\ARIAMEVADB-SVR\va_data$\Reportes");
            List<string> planesPacientes = new List<string>();
            foreach (string reporte in reportes)
            {
                if ((Path.GetFileName(reporte)).Contains('_'))
                {
                    string[] split = (Path.GetFileName(reporte)).Split('_');
                    string id = split[0];
                    string plan = split[2];
                    Patient paciente = aria.Patients.Where(p => p.PatientId == id).First();
                    foreach (Course curso in paciente.Courses)
                    {
                        if (curso.PlanSetups.Any(p => p.PlanSetupId == plan))
                        //if (curso.PlanSetups.Any(p => p.PlanSetupId == plan) && curso.PlanSetups.Where(p => p.PlanSetupId == plan).First().Status == "TreatApproval")
                        //if (curso.PlanSetups.Any(p => p.PlanSetupId == plan) && curso.PlanSetups.Where(p => p.PlanSetupId == plan).First().Status == "PlanApproval")
                        {
                            if (!planesPacientes.Contains(id + ";" + plan))
                            {
                                planesPacientes.Add(id + ";" + plan);
                            }
                        }
                    }
                }
            }
        }

        private void treatApprovalContraInicio()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<string> equiposID = Equipos.Select(e => e.ID).ToList();
            List<string> output = new List<string>();
            var query = aria.PlanSetups.Where(p => p.Status == "TreatApproval" && p.Radiations.Count > 0);
            foreach (PlanSetup plan in query)
            {
                if (plan.Radiations.Count > 0 && equiposID.Contains(plan.Radiations.First().RadiationDevice.Machine.MachineId))
                {
                    DateTime? fechaInicio = ConsultasDB.fechaInicio(plan, Equipos);
                    if (fechaInicio != null && (plan.StatusDate - (DateTime)fechaInicio).Days >= 1)
                    {
                        output.Add(plan.Course.Patient.PatientId + ";" + plan.Course.Patient.LastName + ";" + plan.Course.Patient.FirstName + ";" + plan.PlanSetupId + ";" + plan.StatusDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" + ((DateTime)fechaInicio).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                }

            }
            File.WriteAllLines(@"c:\treatvsInicio.txt", output.ToList());
            MessageBox.Show("Fueron " + output.Count.ToString() + " pacientes\nDemoró " + sw.Elapsed.ToString());
        }

        private void pacientesVMAT()
        {
            List<string> pacientesEq1 = ConsultasDB.PacientesEnEquipoHoy(aria, Equipos.Where(f => f.ID == "Equipo1").First());
            List<string> pacientesEq4 = ConsultasDB.PacientesEnEquipoHoy(aria, Equipos.Where(f => f.ID == "D-2300CD").First());
            List<string> planesEq1 = new List<string>();
            foreach (string id in pacientesEq1)
            {

                Patient paciente = aria.Patients.Where(p => p.PatientId == id).First();
                PlanSetup plan = new PlanSetup();
                foreach (Course curso in paciente.Courses)
                {
                    if (curso.PlanSetups.Any(p => p.Status == "TreatApproval"))
                    {
                        plan = curso.PlanSetups.Where(p => p.Status == "TreatApproval").First();
                    }
                }
                string VMAT = "No";
                if (plan.Radiations.Count > 0 && plan.Radiations.First().ExternalFieldCommon.ControlPoints.Count > 30)
                {
                    VMAT = "Si";
                }
                planesEq1.Add(paciente.PatientId + ";" + paciente.LastName + ";" + paciente.FirstName + ";" + plan.PlanSetupId + ";" + VMAT);
            }
            File.WriteAllLines(@"c:\eq1.txt", planesEq1);
            List<string> planesEq4 = new List<string>();
            foreach (string id in pacientesEq4)
            {

                Patient paciente = aria.Patients.Where(p => p.PatientId == id).First();
                PlanSetup plan = new PlanSetup();
                foreach (Course curso in paciente.Courses)
                {
                    if (curso.PlanSetups.Any(p => p.Status == "TreatApproval"))
                    {
                        plan = curso.PlanSetups.Where(p => p.Status == "TreatApproval").First();
                    }
                }
                string VMAT = "No";
                if (plan.Radiations.Count > 0 && plan.Radiations.First().ExternalFieldCommon.ControlPoints.Count > 30)
                {
                    VMAT = "Si";
                }
                planesEq4.Add(paciente.PatientId + ";" + paciente.LastName + ";" + paciente.FirstName + ";" + plan.PlanSetupId + ";" + VMAT);

            }
            File.WriteAllLines(@"c:\eq4.txt", planesEq4);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

/*infoExportar.AddRange(infoPacientesAprobados(app, "Equipo1", aria, haceDosMeses));
infoExportar.AddRange(infoPacientesAprobados(app, "2100CMLC", aria, haceDosMeses));
infoExportar.AddRange(infoPacientesAprobados(app, "D-2300CD", aria, haceDosMeses));*/










