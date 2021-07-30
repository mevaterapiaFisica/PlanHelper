using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanHelper
{
    public partial class ListaPacientes : Form
    {
        public ListaPacientes(List<PlanPaciente> pacientes, string status, Equipo equipo, List<string> pacientesString = null)
        {
            InitializeComponent();
            this.Text = equipo.Nombre + " - " + status;
            if (pacientes.Count>0)
            {
                foreach (PlanPaciente paciente in pacientes)
                {
                    LB_Pacientes.Items.Add(paciente.PacienteID + " " + paciente.PacienteNombre + "-" + paciente.PlanID);
                }
            }
            else if (pacientesString!=null && pacientesString.Count>0)
            {
                LB_Pacientes.DataSource = pacientesString;
            }
            
        }
    }
}
