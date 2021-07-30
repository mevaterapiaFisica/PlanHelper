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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PlanHelper
{
    public partial class Grafico : Form
    {
        public Grafico(List<Equipo> Equipos)
        {
            InitializeComponent();
            OcupacionEquipos(Equipos);
        }

        private void OcupacionEquipos(List<Equipo> Equipos)
        {
            PlotModel plotModel = new PlotModel();
            DateTimeAxis ejeX = new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd/MM",
                Title = "Fecha",
                MajorGridlineColor = OxyColors.LightGray,
                MajorGridlineStyle = LineStyle.Solid,
            };
            LinearAxis ejeY = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Turnos libres",
                MajorGridlineColor = OxyColors.LightGray,
                MajorGridlineStyle = LineStyle.Solid,
            };
            plotModel.Axes.Add(ejeX);
            plotModel.Axes.Add(ejeY);
            foreach (Equipo equipo in Equipos)
            {
                if (File.Exists(Equipo.pathArchivos + equipo.Nombre + "_agendaocupacion.txt"))
                {
                    string[] fid = File.ReadAllLines(Equipo.pathArchivos + equipo.Nombre + "_agendaocupacion.txt");
                    var serie = new LineSeries()
                    {
                        Title = equipo.Nombre,
                    };
                    foreach (string linea in fid)
                    {
                        DateTime fecha = Convert.ToDateTime(linea.Split(';')[0]);
                        double cantidad = Convert.ToInt32(linea.Split(';')[1]);
                        double turnosLibres = equipo.TurnosPorDia - cantidad;
                        //serie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(fecha), cantidad));
                        serie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(fecha), turnosLibres));
                        serie.MarkerSize = 5;
                        serie.MarkerType = MarkerType.Circle;
                        //serie.TrackerFormatString = "{0}\n{2:dd/MM}, {3}: {4} (" +equipo.TurnosPorDia.ToString() + ")"; 
                        serie.TrackerFormatString = "{0}\n{2:dd/MM}, Turnos Libres: {4:0}";
                    }
                    plotModel.Series.Add(serie);
                }
            }
            plotModel.LegendPosition = LegendPosition.BottomRight;
            plotView1.Model = plotModel;
            
        }
    }
}