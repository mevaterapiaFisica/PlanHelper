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

namespace PlanHelper
{
    public partial class AgregarQA : Form
    {
        public AgregarQA()
        {
            InitializeComponent();
        }

        private void AgregarQA_Load(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void llenarDGV()
        {
            DGV_QAAgregar.Rows.Clear();
            List<PlanPaciente> pacientesQAPE = PlanPaciente.ExtraerDeArchivo(Equipo.pathArchivos + "pacientesQAPE.txt",1);
            foreach (PlanPaciente paciente in pacientesQAPE)
            {
                if (!paciente.RequierePlanQA)
                {
                    string equipo = "";
                    if (paciente.EquipoID == "D-2300CD")
                    {
                        equipo = "Equipo 4";
                    }
                    else if (paciente.EquipoID == "Equipo1")
                    {
                        equipo = "Equipo 1";
                    }
                    else if (paciente.EquipoID == "2100CMLC")
                    {
                        equipo = "Equipo 3";
                    }
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGV_QAAgregar);
                    row.Cells[1].Value = paciente.PacienteID;
                    row.Cells[2].Value = paciente.PacienteNombre;
                    row.Cells[3].Value = paciente.PlanID;
                    row.Cells[4].Value = equipo;
                    DGV_QAAgregar.Rows.Add(row);
                }
            }
            DGV_QAAgregar.Sort(DGV_QAAgregar.Columns[2], ListSortDirection.Ascending);
            DGV_QAAgregar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void BT_AgregarQACancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_AgregarQAAceptar_Click(object sender, EventArgs e)
        {
            List<PlanPaciente> pacientesQAPE = PlanPaciente.ExtraerDeArchivo(Equipo.pathArchivos + "pacientesQAPE.txt",1);
            foreach (DataGridViewRow row in DGV_QAAgregar.Rows)
            {
                if ((bool)row.Cells[0].FormattedValue)
                {
                    PlanPaciente plan = PlanDeRow(row, pacientesQAPE);
                    plan.RequierePlanQA = true;
                    plan.NotaQA = "Agregado manualmente";
                }
            }
            string fechaQAPE = ConsultasDB.LeerDateTimeQAPE();
            File.WriteAllLines(Equipo.pathArchivos + "pacientesQAPE.txt", pacientesQAPE.Select(p => p.ToString()).ToArray());
            ConsultasDB.agregarDateTime(Equipo.pathArchivos + "pacientesQAPE.txt", fechaQAPE);
            Close();
        }

        private PlanPaciente PlanDeRow(DataGridViewRow row, List<PlanPaciente> lista)
        {
            return lista.First(p => p.PacienteID == (string)row.Cells[1].Value && p.PlanID == (string)row.Cells[3].Value);
        }
    }
}
