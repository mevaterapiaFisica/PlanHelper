using AriaQ;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;



namespace PlanHelper
{



    public partial class Form1 : Form
    {


        String Route = @"\\10.0.0.57\centro de datos2018\Eclipse Planning Monitor\PtsInPlanning.phs";
        public Form1()
        {
            InitializeComponent();

            DateTime today = DateTime.Today;
            DateTime StartDate = today.AddDays(30);


            // ****************************************************************
            // Aca leo los pacientes en planificacion. 

            //List<String> HC = new List<String>();
            //List<DateTime> PotDate = new List<DateTime>();
            //List<String> Equipo = new List<String>();
            //List<int> fr = new List<int>();

            List<EnPlanning> EnPlan = new List<EnPlanning>();

            var readText = new List<string>(File.ReadAllLines(Route));

            foreach (string s in readText)
            {
                int dte = s.IndexOf(" dte ");
                int eq = s.IndexOf(" eq ");
                int frx = s.IndexOf(" fr ");

                String HC = (s.Substring(0, dte));
                String Dte = s.Substring(dte + 4, 22);
                DateTime PotDate = (Convert.ToDateTime(Dte).Date);
                String Equipo = (s.Substring(eq + 3, 9));

                int fr = (Convert.ToInt32(s.Substring(frx + 3)));
                EnPlan.Add(new EnPlanning(HC, PotDate, Equipo, fr));
            }

            // ******************************************************************

            using (var aria = new Aria())
            {
                
                Machine M1 = aria.Machines.Where(m => m.MachineId == "Equipo1").First();
                Machine M4 = aria.Machines.Where(m => m.MachineId == "D-2300CD").First();
                List<Attendee> AtendidosEq1 = M1.Resource.Attendees.ToList();
                List<Attendee> AtendidosEq4 = M4.Resource.Attendees.ToList();
                List<ScheduledActivity> SchAct = aria.ScheduledActivities.Where(s => (s.ScheduledStartTime <= (StartDate.Date)) & (s.ScheduledStartTime >= (today.Date))& s.ObjectStatus.Equals("Active")).ToList();

                var ConTurno = (from h in EnPlan
                                join s in SchAct on h.HC equals s.Patient.PatientId
                                where h.HC.Equals(s.Patient.PatientId)
                                select new
                                {
                                    s.Patient.PatientId,
                                }).Distinct().ToList();

                // ****************************************************************
                // Aca borro los pacientes que ya tienen turno asignado en equipo.
                foreach (var r in ConTurno)
                {
                    String rr = r.PatientId.ToString();

                    int index = EnPlan.FindIndex(s => s.HC.Equals(rr));
                    EnPlan.RemoveAt(index);
                    readText.RemoveAt(index);
                }

                File.WriteAllLines(Route, readText.ToArray());
                // ****************************************************************

                var Dias = (StartDate.Date - today.Date);

                double Intervalo = Dias.TotalDays;

                DateTime Dia_x = today.AddDays(-1);
                List<String> LabelDate = new List<string>();
                List<int> PtesEq1 = new List<int>();
                List<int> PtesEq4 = new List<int>();
                List<int> PtesEq1Plan = new List<int>();
                List<int> PtesEq3Plan = new List<int>();
                List<int> PtesEq4Plan = new List<int>();



                for (int i = 1; i <= Intervalo; i++)
                {
                    Dia_x = Dia_x.AddDays(1);

                    int Equipo1 = 0;
                    int Equipo4 = 0;

                    int EnPlan3 = 0;


                    var L_Eq1 = (from sc in SchAct
                                 join ae1 in AtendidosEq1 on sc.ActivityInstanceSer equals ae1.ActivityInstanceSer
                                 where Convert.ToDateTime(sc.ScheduledStartTime).Date.Equals(Dia_x.Date) && sc.ObjectStatus.Equals("Active")
                                 select new
                                 {
                                     sc.Patient.LastName,
                                     sc.Patient.PatientId,
                                 }).ToList();

                    var L_Eq4 = (from sc in SchAct
                                 join ae1 in AtendidosEq4 on sc.ActivityInstanceSer equals ae1.ActivityInstanceSer
                                 where Convert.ToDateTime(sc.ScheduledStartTime).Date.Equals(Dia_x.Date) && sc.ObjectStatus.Equals("Active")
                                 select new
                                 {
                                     sc.Patient.LastName,
                                     sc.Patient.PatientId,
                                 }).ToList();


                    var P_Eq1 = (from sc in EnPlan
                                 where sc.PotDate.Date.Equals(Dia_x.Date) && sc.Equipo.Equals(" Equipo 1")
                                 select new
                                 {
                                     sc.HC,

                                 }).ToList();

                    var P_Eq4 = (from sc in EnPlan
                                 where sc.PotDate.Date.Equals(Dia_x.Date) && sc.Equipo.Equals(" Equipo 4")
                                 select new
                                 {
                                     sc.HC,

                                 }).ToList();

                    Equipo1 = L_Eq1.Count();
                    Equipo4 = L_Eq4.Count();

                    PtesEq1.Add(Equipo1);
                    PtesEq4.Add(Equipo4);
                    PtesEq1Plan.Add(P_Eq1.Count());
                    PtesEq3Plan.Add(EnPlan3);
                    PtesEq4Plan.Add(P_Eq4.Count());
                    LabelDate.Add(Dia_x.ToLongDateString());
                }

                PlotPatientsSc(LabelDate, PtesEq1, PtesEq4, PtesEq1Plan, PtesEq3Plan, PtesEq4Plan);
            }


            // string[] lines = System.IO.File.ReadAllLines(Route);
        }
        private void PlotPatientsSc(List<String> Dias, List<int> Eq1, List<int> Eq4, List<int> PlanEq1, List<int> PlanEq3, List<int> PlanEq4)
        {
            int Intervalo = Eq1.Count();

            chartGraphic.ChartAreas[0].AxisY.Minimum = 0;
            chartGraphic.ChartAreas[0].AxisY.Maximum = 100;
            chartGraphic.ChartAreas[0].AxisX.Minimum = 0;
            chartGraphic.ChartAreas[0].AxisX.Maximum = Intervalo + 1;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = Intervalo + 1;

            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 100;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = Intervalo + 1;

            //System.Windows.Forms.DataVisualization.Charting.Series s0 = chartGraphic.Series.Add("Total");
            System.Windows.Forms.DataVisualization.Charting.Series s1 = chartGraphic.Series.Add("Equipo 1 - Tto");
            System.Windows.Forms.DataVisualization.Charting.Series s3 = chart1.Series.Add("Equipo 3 - Tto");
            System.Windows.Forms.DataVisualization.Charting.Series s4 = chart2.Series.Add("Equipo 4 - Tto");

            System.Windows.Forms.DataVisualization.Charting.Series sp1 = chartGraphic.Series.Add("Equipo 1 - Planning");
            System.Windows.Forms.DataVisualization.Charting.Series sp3 = chart1.Series.Add("Equipo 3 - Planning");
            System.Windows.Forms.DataVisualization.Charting.Series sp4 = chart2.Series.Add("Equipo 4 - Planning");

            s1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            s1.IsValueShownAsLabel = true;
            s3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            s3.IsValueShownAsLabel = true;
            s4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            s4.IsValueShownAsLabel = true;

            sp1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            sp1.IsValueShownAsLabel = true;
            sp3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            sp3.IsValueShownAsLabel = true;
            sp4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            sp4.IsValueShownAsLabel = true;


            for (int i = 1; i <= Intervalo; i++)
            {
                s1.Points.AddXY(i, Eq1.ElementAt(i - 1));
                //s3.Points.AddXY(i, Eq3.ElementAt(i - 1));
                s4.Points.AddXY(i, Eq4.ElementAt(i - 1));

                sp1.Points.AddXY(i, PlanEq1.ElementAt(i - 1));
                sp3.Points.AddXY(i, PlanEq3.ElementAt(i - 1));
                sp4.Points.AddXY(i, PlanEq4.ElementAt(i - 1));


                chartGraphic.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 1, Dias.ElementAt(i - 1));
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 1, Dias.ElementAt(i - 1));
                chart2.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 1, Dias.ElementAt(i - 1));
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            using (var aria = new Aria())
            {
                Patient SelPat = aria.Patients.Where(p => p.LastName == listBox1.SelectedItem.ToString()).First();
                listBox2.Items.Clear();
                foreach (Course c in SelPat.Courses)
                {
                    listBox2.Items.Add(c.CourseId.ToString());
                    //listBox2.DisplayMember = "CourseId";
                }               
               
            } 
           */
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
                using (var aria = new Aria())
                {
                    listBox3.Items.Clear();
                    var Paciente = aria.Patients.Where(p => p.LastName == listBox1.SelectedItem.ToString()).First();
                    Course Csel = Paciente.Courses.Where(c => c.CourseId == listBox2.SelectedItem.ToString()).First();
                    foreach (PlanSetup p in Csel.PlanSetups)
                    {
                        listBox3.Items.Add(p.PlanSetupId.ToString());
                    }
                }
                */
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String Equipo = cB_Equipo.SelectedItem.ToString();
            DateTime today = DateTime.Today;
            DateTime Dia_x = StartDatePicker.Value;
            Int32 fracc = Convert.ToInt32(textBoxFr.Text);

            for (int d = 1; d <= fracc; d++)
            {
                Dia_x = Dia_x.AddDays(1);
                if (Dia_x.DayOfWeek.ToString() == "Saturday")
                {
                    Dia_x = Dia_x.AddDays(2);
                }
                else if (Dia_x.DayOfWeek.ToString() == "Sunday")
                {
                    Dia_x = Dia_x.AddDays(1);
                }
                String Line = tB_HC.Text + " dte " + Dia_x.Date.ToString() + " eq " + Equipo + " fr " + d.ToString();
                File.AppendAllText(Route, Line + Environment.NewLine);
            }
        }

        private void chartGraphic_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime Dia_x;
            switch (comboBox2.SelectedIndex)
            {
                case 0: // P1 - 2 Dias
                    Dia_x = today.AddDays(2);
                    if (Dia_x.DayOfWeek.ToString() == "Saturday")
                    {
                        Dia_x = Dia_x.AddDays(2);
                    }
                    else if (Dia_x.DayOfWeek.ToString() == "Sunday")
                    {
                        Dia_x = Dia_x.AddDays(1);
                    }
                    StartDatePicker.Value = Dia_x;
                    break;

                case 1: // P2 - 7 Dias
                    Dia_x = today.AddDays(7);
                    switch (Dia_x.DayOfWeek.ToString())
                    {
                        case "Thursday":
                            Dia_x = Dia_x.AddDays(4);
                            break;
                        case "Friday":
                            Dia_x = Dia_x.AddDays(3);
                            break;
                        case "Saturday":
                            Dia_x = Dia_x.AddDays(2);
                            break;
                        case "Sunday":
                            Dia_x = Dia_x.AddDays(1);
                            break;
                    }
                    StartDatePicker.Value = Dia_x;
                    break;

                case 2: // P3 - 14 Dias
                    Dia_x = today.AddDays(14);
                    switch (Dia_x.DayOfWeek.ToString())
                    {
                        case "Thursday":
                            Dia_x = Dia_x.AddDays(4);
                            break;
                        case "Friday":
                            Dia_x = Dia_x.AddDays(3);
                            break;
                        case "Saturday":
                            Dia_x = Dia_x.AddDays(2);
                            break;
                        case "Sunday":
                            Dia_x = Dia_x.AddDays(1);
                            break;
                    }
                    StartDatePicker.Value = Dia_x;
                    break;

                case 3: // IMRT - 14 Dias
                    Dia_x = today.AddDays(14);
                    switch (Dia_x.DayOfWeek.ToString())
                    {
                        case "Thursday":
                            Dia_x = Dia_x.AddDays(4);
                            break;
                        case "Friday":
                            Dia_x = Dia_x.AddDays(3);
                            break;
                        case "Saturday":
                            Dia_x = Dia_x.AddDays(2);
                            break;
                        case "Sunday":
                            Dia_x = Dia_x.AddDays(1);
                            break;
                    }
                    StartDatePicker.Value = Dia_x;
                    break;

                case 4: // SRS / SBRT

                    break;

                case 5: // Inicio Definido

                    break;
            }

        }
    }

    public class EnPlanning
    {
        public EnPlanning(string aHC, DateTime aPotDate, String aEquipo, int afr)
        {
            HC = aHC;
            PotDate = aPotDate;
            Equipo = aEquipo;
            Fr = afr;
        }

        public string HC { get; set; }
        public string Equipo { get; set; }
        public DateTime PotDate { get; set; }
        public int Fr { get; set; }
    }

}