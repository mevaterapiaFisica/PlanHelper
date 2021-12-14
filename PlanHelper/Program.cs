using AriaQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace PlanHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args != null && args.Count() > 0 && args[0] == "true" && Environment.MachineName == "ARIA-FISICA3" && Environment.UserName == "Varian")
            {
                List<Equipo> Equipos = Equipo.InicializarEquipos();
                //Conexion conexion = new Conexion(DateTime.Today.DayOfWeek == DayOfWeek.Monday && DateTime.Now.Hour == 5, true, true, true, Equipos);
                Conexion conexion = new Conexion(false, true, true, true, Equipos);
                conexion.ShowDialog();
            }
            else if (args != null && args.Count() > 0 && args[0] == "QAPE" && Environment.MachineName == "ARIA-FISICA3" && Environment.UserName == "Varian")
            {
                List<Equipo> Equipos = Equipo.InicializarEquipos();
                Conexion conexion = new Conexion(false, false, false, false, Equipos, true);
                conexion.ShowDialog();
            }
            else
            {
                Application.Run(new Form3());
            }



        }
    }
}
