using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanHelper
{
    public partial class NuevoPedido : Form
    {
        bool _edita;
        bool _actualizaEstado;
        public Pedido _pedido;
        public NuevoPedido(bool edita, bool actualizaEstado, Pedido pedidoEdita = null)
        {
            InitializeComponent();
            CargarComboBox();

            _pedido = new Pedido();
            _edita = edita;
            _actualizaEstado = actualizaEstado;
            if (edita || actualizaEstado)
            {
                _pedido = pedidoEdita;
                TB_Paciente.Text = _pedido.Paciente;
                CB_Tecnica.Text = _pedido.Tecnica;
                CB_Tarea.Text = _pedido.Tarea;
                CB_Equipo.Text = _pedido.Equipo;
                DTP_FechaLimite.Value = _pedido.FechaLimite;
                CB_Medico.Text = _pedido.MedicoResponsable;
                CB_Motivo.Text = _pedido.Motivo;
                CB_FisicoSolicita.Text = _pedido.Solicita;
                CB_FisicoResponsable.Text = _pedido.Responsable;
                TB_Comentario.Text = _pedido.Comentario;
                _pedido.TareaInicial = _pedido.Tarea;
            }
            if (actualizaEstado)
            {
                TB_Paciente.Enabled = false;
                CB_Tecnica.Enabled = false;
                //CB_Tarea.Text = _pedido.Tarea;
                CB_Equipo.Enabled = false;
                //DTP_FechaLimite.Value = _pedido.FechaLimite;
                CB_Medico.Enabled = false;
                CB_Motivo.Enabled= false;
                CB_FisicoSolicita.Enabled = false;
                CB_FisicoResponsable.Text = "";
                //TB_Comentario.Text = _pedido.Comentario;
            }
            
        }

        public void CargarComboBox()
        {
            if (File.Exists(Pedido.pathOpciones))
            {
                List<string> archivo = File.ReadAllLines(Pedido.pathOpciones).ToList();
                //int comienzoTecnica = archivo.IndexOf("**Tecnica");
                int comienzoTarea = archivo.IndexOf("**Tarea");
                int comienzoEquipo = archivo.IndexOf("**Equipo");
                int comienzoMedico = archivo.IndexOf("**Medico");
                int comienzoMotivo = archivo.IndexOf("**Motivo");
                int comienzoFisico = archivo.IndexOf("**Fisico");
                for (int i = 0; i < archivo.Count; i++)
                {
                    if (!archivo[i].Contains("**"))
                    {
                        if (i < comienzoTarea)
                        {
                            CB_Tecnica.Items.Add(archivo[i]);
                        }
                        else if (i < comienzoEquipo)
                        {
                            CB_Tarea.Items.Add(archivo[i]);
                        }
                        else if (i < comienzoMedico)
                        {
                            CB_Equipo.Items.Add(archivo[i]);
                        }
                        else if (i < comienzoMotivo)
                        {
                            CB_Medico.Items.Add(archivo[i]);
                        }
                        else if (i < comienzoFisico)
                        {
                            CB_Motivo.Items.Add(archivo[i]);
                        }
                        else
                        {
                            CB_FisicoSolicita.Items.Add(archivo[i]);
                            CB_FisicoResponsable.Items.Add(archivo[i]);
                        }
                    }
                }

            }

        }

        private void BT_Aceptar_Click(object sender, EventArgs e)
        {
            if (!_edita && !_actualizaEstado)
            {
                _pedido.fechaCarga = DateTime.Now;
            }
            _pedido.Paciente = TB_Paciente.Text;
            _pedido.Tecnica = CB_Tecnica.Text;
            _pedido.Tarea = CB_Tarea.Text;
            _pedido.Equipo = CB_Equipo.Text;
            _pedido.FechaLimite = DTP_FechaLimite.Value;
            _pedido.MedicoResponsable = CB_Medico.Text;
            _pedido.Motivo = CB_Motivo.Text;
            _pedido.Solicita = CB_FisicoSolicita.Text;
            _pedido.Responsable = CB_FisicoResponsable.Text;
            _pedido.Comentario = TB_Comentario.Text;
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
