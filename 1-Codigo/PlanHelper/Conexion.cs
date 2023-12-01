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
    public partial class Conexion : Form
    {
        Stopwatch sw = new Stopwatch();
        Aria aria;



        Eclipse.Application app;
        List<Equipo> Equipos;
        bool ActualizaParametros;
        bool ActualizaEnCurso;
        bool ActualizaOcupacion;
        bool ActualizaQA;
        bool ActualizaQAPE;
        bool ActualizaPacTBI;
        bool BuscaIniciosSitramed;

        public Conexion(bool _ActualizaParametros, bool _ActualizaEnCurso, bool _ActualizaOcupacion, bool _ActualizaQA, List<Equipo> _Equipos, bool _actualizaQAPE = false, bool _actualizaPacTBI = false, bool _buscaIniciosSitramed = false)
        {
            InitializeComponent();
            Equipos = _Equipos;
            ActualizaParametros = _ActualizaParametros;
            ActualizaEnCurso = _ActualizaEnCurso;
            ActualizaOcupacion = _ActualizaOcupacion;
            ActualizaQA = _ActualizaQA;
            ActualizaQAPE = _actualizaQAPE;
            ActualizaPacTBI = _actualizaPacTBI;
            BuscaIniciosSitramed = _buscaIniciosSitramed;
            if (DateTime.Now.Hour == 5)
            {
                SeguimientoEq3();
            }
            L_Texto.Text = "";
        }

        private void ActualizarParametros()
        {

            app = Eclipse.Application.CreateApplication("paberbuj", "123qwe");
            L_Texto.Text += "Actualizando parámetros de equipos...\n";
            L_Texto.Update();
            sw.Start();
            Equipo.CalcularParametrosEquipos(aria, app, Equipos);
            L_Texto.Text += "Parámetros actualizados" + " (demoró " + sw.Elapsed.ToString() + ")\n";
            L_Texto.Update();
            sw.Stop();
            sw.Reset();
            app.ClosePatient();
        }

        private void ActualizarEnCurso()
        {
            L_Texto.Text += "Buscando pacientes en curso...\n";
            L_Texto.Update();
            sw.Start();
            Equipo.EscribirEnCurso(aria, Equipos);
            L_Texto.Text += "Búsqueda finalizada. Archivos actualizados" + " (demoró " + sw.Elapsed.ToString() + ")\n";
            L_Texto.Update();
            sw.Stop();
            sw.Reset();
        }

        private void ActualizarOcupacion()
        {
            L_Texto.Text += "Calculando ocupación de equipos...\n";
            L_Texto.Update();
            sw.Start();
            Equipo.EscribirOcupacionEquipos(aria, Equipos);
            L_Texto.Text += "Búsqueda finalizada. Archivos actualizados" + " (demoró " + sw.Elapsed.ToString() + ")\n";
            L_Texto.Update();
            sw.Stop();
            sw.Reset();
        }

        private void ActualizarQA()
        {
            L_Texto.Text += "Buscando QA imágenes atrasadas...\n";
            L_Texto.Update();
            sw.Start();
            ConsultasDB.EscribirQAImagenesAtrasadas(aria, Equipos, DateTime.Today.AddYears(-1),true);
            ConsultasDB.EscribirQAImagenesAtrasadas(aria, Equipos, DateTime.Today.AddMonths(-2));
            L_Texto.Text += "Búsqueda finalizada. Archivo actualizado" + "(demoró " + sw.Elapsed.ToString() + ")\n";
            L_Texto.Text += "Buscando QA tiempo VMAT...\n";
            L_Texto.Update();
            sw.Stop();
            sw.Restart();
            ConsultasDB.EscribirQAVMATTiempomenorA3(aria, Equipos, DateTime.Today.AddMonths(-2));
            L_Texto.Text += "Búsqueda finalizada. Archivo actualizado" + " (demoró " + sw.Elapsed.ToString() + ")\n";
            L_Texto.Update();
            sw.Stop();
            sw.Reset();
        }

        private void SeguimientoEq3()
        {
            L_Texto.Text += "Escribiendo ocupación equipo 3\n";
            L_Texto.Update();
            Equipos.Where(e => e.ID == "2100CMLC").First().escribirSeguimiento();
            L_Texto.Text += "Listo\n";
            L_Texto.Update();
        }
        private void ActualizarQAPE()
        {
            L_Texto.Text += "Buscando QA Paciente Específico...\n";
            L_Texto.Update();
            sw.Start();
            ConsultasDB.ActualizarQAPE(aria);
            L_Texto.Text += "Búsqueda finalizada. Archivo actualizado" + "(demoró " + sw.Elapsed.ToString() + ")\n";
            sw.Reset();
        }

        private void ActualizarPacTBI()
        {
            L_Texto.Text += "Buscando pacientes TBI...\n";
            L_Texto.Update();
            sw.Start();
            ConsultasDB.ActualizarPacTBI(aria);
            Label l_Texto = L_Texto;
            l_Texto.Text = l_Texto.Text + "Búsqueda finalizada. Archivo actualizado(demoró " + sw.Elapsed.ToString() + ")\n";
            sw.Reset();
        }

        private void BuscarIniciosSitramed()
        {
            L_Texto.Text += "Buscando inicios en Sitramed...\n";
            L_Texto.Update();
            sw.Start();
            BusquedaSitramed.Correr();
            Label l_Texto = L_Texto;
            l_Texto.Text = l_Texto.Text + "Búsqueda finalizada. Archivo actualizado(demoró " + sw.Elapsed.ToString() + ")\n";
            sw.Reset();
        }

        private void Conexion_Shown(object sender, EventArgs e)
        {
            try
            {
                aria = new Aria();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a Aria");
                throw;
            }


            if (ActualizaParametros)
            {
                ActualizarParametros();
            }
            if (ActualizaEnCurso)
            {
                ActualizarEnCurso();
            }
            if (ActualizaOcupacion)
            {
                ActualizarOcupacion();
            }
            if (ActualizaQA)
            {
                ActualizarQA();
            }
            if (ActualizaQAPE)
            {
                ActualizarQAPE();
            }
            if (ActualizaPacTBI)
            {
                ActualizarPacTBI();
            }
            if (BuscaIniciosSitramed)
            {
                BuscarIniciosSitramed();
            }
            L_Texto.Text += "\n\nTareas finalizadas";
            L_Texto.Update();
            System.Threading.Thread.Sleep(500);
            this.Close();
        }
    }
}
