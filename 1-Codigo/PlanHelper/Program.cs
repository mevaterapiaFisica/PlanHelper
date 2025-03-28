﻿using AriaQ;
using System.IO;
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
            //BusquedaSitramed.PruebaChrome();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args != null && args.Count() > 0 && args[0] == "true" && Environment.UserName.ToLower() == "varian")
            {
                List<Equipo> Equipos = Equipo.InicializarEquipos();
                //Conexion conexion = new Conexion(DateTime.Today.DayOfWeek == DayOfWeek.Monday && DateTime.Now.Hour == 5, true, true, true, Equipos);
                Conexion conexion = new Conexion(false, true, true, true, Equipos,true,true,false);
                //conexion.WindowState = FormWindowState.Minimized;
                conexion.ShowDialog();
            }
            else if (args != null && args.Count() > 0 && args[0] == "QAPE" && Environment.UserName.ToLower() == "varian")
            {
                List<Equipo> Equipos = Equipo.InicializarEquipos();
                Conexion conexion = new Conexion(false, false, false, false, Equipos, true);
                conexion.WindowState = FormWindowState.Minimized;
                conexion.ShowDialog();
            }
            else
            {
                

                //BusquedaSitramed.PruebaChrome();
                List<Equipo> equipos = Equipo.InicializarEquipos();
                BusquedaSitramed.BuscarOcupacionEquipos(equipos);
                //BusquedaSitramed.TestOcupacionEquipos(equipos);
                //Equipo.EscribirOcupacionEquipos2(equipos);*/
                //Conexion conexion = new Conexion(true,false,false,false,equipos);
                //conexion.ShowDialog();
                Application.Run(new Form3());
                //Application.Run(new NuevoPedido(false));
            }



        }
    }
}
