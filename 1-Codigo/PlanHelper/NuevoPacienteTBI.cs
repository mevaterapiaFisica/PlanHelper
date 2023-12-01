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
    public partial class NuevoPacienteTBI : Form
    {
		public PacienteTBI nuevoPaciente;

		public bool edita;
		public NuevoPacienteTBI(bool _edita, PacienteTBI pacienteEdita = null)
		{
			InitializeComponent();
			edita = _edita;
			TB_NuevoPacFxPorDia.Text = "1";
			if (edita)
			{
				nuevoPaciente = pacienteEdita;
				TB_NuevoPacHC.Text = pacienteEdita.ID;
				TB_NuevoPacApellido.Text = pacienteEdita.Apellido;
				TB_NuevoPacNombre.Text = pacienteEdita.Nombre;
				CB_NuevoPacEquipo.Text = pacienteEdita.Equipo.Nombre;
				DTP_NuevoPacInicio.Value = pacienteEdita.FechaInicio;
				TB_NuevoPacNumFx.Text = pacienteEdita.NumeroFracciones.ToString();
				TB_NuevoPacFxPorDia.Text = pacienteEdita.FraccionesPorDia.ToString();
			}
		}

		private void BT_Aceptar_Click(object sender, EventArgs e)
		{
			if (edita)
			{
				nuevoPaciente.ID = TB_NuevoPacHC.Text;
				nuevoPaciente.Apellido = TB_NuevoPacApellido.Text;
				nuevoPaciente.Nombre = TB_NuevoPacNombre.Text;
				nuevoPaciente.Equipo = Equipo.FromStringNombre(CB_NuevoPacEquipo.Text);
				nuevoPaciente.FechaInicio = DTP_NuevoPacInicio.Value;
				nuevoPaciente.NumeroFracciones = Convert.ToInt32(TB_NuevoPacNumFx.Text);
				nuevoPaciente.FraccionesPorDia = Convert.ToInt32(TB_NuevoPacFxPorDia.Text);
			}
			else
			{
				nuevoPaciente = new PacienteTBI(TB_NuevoPacHC.Text, TB_NuevoPacApellido.Text, TB_NuevoPacNombre.Text, CB_NuevoPacEquipo.Text, DTP_NuevoPacInicio.Value, Convert.ToInt32(TB_NuevoPacNumFx.Text), Convert.ToInt32(TB_NuevoPacFxPorDia.Text));
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void BT_Cancelar_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
    }
}
