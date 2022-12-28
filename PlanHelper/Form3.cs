using System;
using System.Threading;
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
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace PlanHelper
{
    public partial class Form3 : Form
    {
        public List<Equipo> Equipos;
        private List<PacienteTBI> pacientesTBI;
        public string QAVisible = "";
        public string QATitulo = "";
        public Form3()
        {
            InitializeComponent();
            Stopwatch sw = new Stopwatch();
            //ConsultasDB.buscaPbElectrones();
            Equipos = PlanHelper.Equipo.InicializarEquipos();
            GenerarGUI_Parametros();
            habilitacionBotones();
            iniciarLB_ExacTrac();
            DTP_FechaInicio.Format = DateTimePickerFormat.Custom;
            DTP_FechaInicio.CustomFormat = "dd/MM/yyyy";
            //Equipos.Where(e => e.ID == "2100CMLC").First().escribirSeguimiento();
        }

        #region Tab_Consulta

        private bool EsP1()
        {
            return CHB_EsP1.Checked;
        }

        private bool Necesita10MV()
        {
            return CHB_10MV.Checked;
        }

        private bool NecesitaElectrones()
        {
            return CHB_Electrones.Checked;
        }

        private bool EsVMAT()
        {
            return CHB_EsVMAT.Checked;
        }

        private bool TieneFechaDeInicio()
        {
            return CHB_TieneFechaDeInicio.Checked;
        }

        private int NumeroDeFracciones()
        {
            int numeroDeFracciones;
            if (int.TryParse(TB_NumFracciones.Text, out numeroDeFracciones))
            {
                return numeroDeFracciones;
            }
            else
            {
                return 0;
            }

        }

        public List<Equipo> EquiposUtiles()
        {
            List<Equipo> equiposUtiles = new List<Equipo>();
            foreach (Equipo equipo in Equipos)
            {
                equiposUtiles.Add(equipo);
            }
            if (Necesita10MV())
            {
                equiposUtiles = equiposUtiles.Where(e => e.Tiene10MV).ToList();
            }
            if (NecesitaElectrones())
            {
                equiposUtiles = equiposUtiles.Where(e => e.TieneElectrones).ToList();
            }
            if (EsVMAT())
            {
                equiposUtiles = equiposUtiles.Where(e => e.HaceVMAT).ToList();
            }
            return equiposUtiles;
        }

        private DateTime? FechaDeInicio(Equipo equipo)
        {
            if (TieneFechaDeInicio())
            {
                return DTP_FechaInicio.Value;
            }
            else if (EsP1())
            {
                return ConsultasDB.AddBusinessDays(DateTime.Today, InicioP1());
            }
            else
            {
                return null;
            }
        }

        private int? TurnosLibres(Equipo equipo)
        {
            DateTime? fechaInicio = FechaDeInicio(equipo);
            int? ocupacion;
            if (fechaInicio != null)
            {
                ocupacion = equipo.BuscarOcupacion((DateTime)fechaInicio);
            }
            else
            {
                string modalidad = "3DC";
                if (EsVMAT())
                {
                    modalidad = "VMAT";
                }
                ocupacion = equipo.ocupacionMediaEnRango(equipo.encontrarParametro("Unapproved", modalidad, NumeroDeFracciones()));
            }
            if (ocupacion != null)
            {
                return equipo.TurnosPorDia - (int)ocupacion;
            }
            else
            {
                return null;
            }
        }
        private void BT_ConsultaBuscarEquipo_Click(object sender, EventArgs e)
        {
            TB_ParaQueEquipo.Text = "";
            List<Tuple<Equipo, int?>> Tuplas = new List<Tuple<Equipo, int?>>();
            if (NumeroDeFracciones() == 0)
            {
                MessageBox.Show("Ingresar número de fracciones");
            }
            else
            {
                foreach (Equipo equipo in EquiposUtiles())
                {
                    Tuplas.Add(new Tuple<Equipo, int?>(equipo, TurnosLibres(equipo)));
                }

                if (Tuplas.Any(t => t.Item2 != null))
                {
                    if (DateTime.Today.Month==12)
                    {
                        MessageBox.Show("Muchaaaaaaaaaaaaaaaaaaaaaaachos....\nPlanificar para el " + Tuplas.OrderByDescending(t => t.Item2).First().Item1.Nombre);
                    }
                    else
                    {
                        MessageBox.Show("Planificar para el " + Tuplas.OrderByDescending(t => t.Item2).First().Item1.Nombre);
                    }
                    
                    /*Equipo equipoElegido = Tuplas.OrderByDescending(t => t.Item2).First().Item1;
                    TB_ParaQueEquipo.Text += "Planificar para el " + equipoElegido.Nombre + Environment.NewLine;
                    TB_ParaQueEquipo.Text += "Se asume que el paciente iniciará el " + FechaDeInicio(equipoElegido).ToShortDateString() + Environment.NewLine + Environment.NewLine;*/
                    foreach (var tupla in Tuplas)
                    {
                        TB_ParaQueEquipo.Text += tupla.Item1.Nombre + ": " + TurnosLibres(tupla.Item1).ToString() + " turnos libres" + Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show("No hay información para ese día");
                }
            }
            TB_ParaQueEquipo.Update();
        }

        private int InicioP1()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday || DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                return 1;
            }
            else
            {
                return 6 - (int)DateTime.Today.DayOfWeek;
            }
        }

        private void CHB_TieneFechaDeInicio_CheckedChanged(object sender, EventArgs e)
        {
            DTP_FechaInicio.Enabled = CHB_TieneFechaDeInicio.Checked;
        }
        #endregion

        #region tab_EstadoEquipos

        private void llenarDGVEstadoEquipos()
        {
            DGV_EstadoEquipos.Rows.Clear();
            foreach (Equipo equipo in Equipos)
            {
                List<PlanPaciente> listaEquipo = equipo.LeerEnCurso();
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_EstadoEquipos);
                row.Cells[0].Value = equipo.Nombre;
                row.Cells[1].Value = listaEquipo.Where(p => p.Status == "Unapproved").Count();
                row.Cells[2].Value = listaEquipo.Where(p => p.Status == "PlanApproval").Count();
                row.Cells[3].Value = listaEquipo.Where(p => p.Status == "TreatApproval").Count();
                row.Cells[4].Value = equipo.BuscarOcupacion(DateTime.Today) + " (" + equipo.TurnosPorDia.ToString() + ")";
                DGV_EstadoEquipos.Rows.Add(row);

                L_EstadoEquipoUltimaBusqueda.Text = "Última búsqueda: " + File.GetLastWriteTime(Directory.GetFiles(Equipo.pathArchivos).Where(s => s.Contains("ocupacion")).First()).ToString();
            }
        }

        private void BT_EstadoEquiposActualizar_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion(false, true, true, false, Equipos);
            conexion.ShowDialog();
            llenarDGVEstadoEquipos();
            L_EstadoEquipoUltimaBusqueda.Text = "Última búsqueda: " + DateTime.Now.ToString();
        }

        private void DGV_EstadoEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Equipo equipoActual = Equipos[DGV_EstadoEquipos.CurrentCell.RowIndex];
            List<PlanPaciente> listaCompleta = equipoActual.LeerEnCurso();
            List<PlanPaciente> listaFiltrada = new List<PlanPaciente>();
            List<string> listaString = null;
            string status = "";
            if (DGV_EstadoEquipos.CurrentCell.ColumnIndex == 1)
            {
                status = "Unapproved";
            }
            else if (DGV_EstadoEquipos.CurrentCell.ColumnIndex == 2)
            {
                status = "PlanApproval";
            }
            else if (DGV_EstadoEquipos.CurrentCell.ColumnIndex == 3)
            {
                status = "TreatApproval";
            }
            else if (DGV_EstadoEquipos.CurrentCell.ColumnIndex == 4)
            {
                status = "EnEquipo";
                listaString = File.ReadAllLines(Equipo.pathArchivos + equipoActual.Nombre + "_ocupacionHoy.txt").ToList();
            }
            if (DGV_EstadoEquipos.CurrentCell.ColumnIndex != 0)
            {
                listaFiltrada = listaCompleta.Where(p => p.Status == status).ToList();
                ListaPacientes listaPacientes = new ListaPacientes(listaFiltrada, status, equipoActual, listaString);
                listaPacientes.ShowDialog();
            }

        }

        private void BT_GraficarTurnosLibres_Click(object sender, EventArgs e)
        {
            Grafico grafico = new Grafico(Equipos);
            grafico.ShowDialog();
        }
        #endregion

        #region tab_QA
        private void LlenarDGVQAPlacasPendientes()
        {
            string[] Planes = File.ReadAllLines(Equipo.pathArchivos + "QA_ImagenesAtrasadas.txt");
            DGV_QA_PlacasPendientes.Rows.Clear();
            DGV_QA_PlacasPendientes.Columns[5].HeaderText = "Ultima fx";
            DGV_QA_PlacasPendientes.Columns[6].Visible = true;
            DGV_QA_PlacasPendientes.Columns[6].HeaderText = "Ultima placa";
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarPendientePlacas.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarPendientePlacas.txt").ToList();
            }
            foreach (string plan in Planes)
            {
                if (Sacar.Count() == 0 || !Sacar.Contains(plan))
                {
                    string[] planSplit = plan.Split(';');
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGV_QA_PlacasPendientes);
                    row.Cells[1].Value = planSplit[0];
                    row.Cells[2].Value = planSplit[1];
                    row.Cells[3].Value = planSplit[2];
                    row.Cells[4].Value = planSplit[3];
                    row.Cells[5].Value = planSplit[4];
                    row.Cells[6].Value = planSplit[5];
                    DGV_QA_PlacasPendientes.Rows.Add(row);
                }
            }
            QAVisible = "PlacasPendientes";

            L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: " + File.GetLastWriteTime(Directory.GetFiles(Equipo.pathArchivos).Where(s => s.Contains("QA_ImagenesAtrasadas")).First()).ToString();
        }
        private int QAPlacasPendientes_Cantidad()
        {
            List<string> Planes = File.ReadAllLines(Equipo.pathArchivos + "QA_ImagenesAtrasadas.txt").ToList();
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarPendientePlacas.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarPendientePlacas.txt").ToList();
            }
            if (Sacar.Count > 0)
            {
                return Planes.Except(Sacar).Count();
            }
            else
            {
                return Planes.Count();
            }
        }

        private void llenarDGVQAVMATMenorA2min()
        {
            string[] Planes = File.ReadAllLines(Equipo.pathArchivos + "QA_VMATcorto.txt");
            DGV_QA_PlacasPendientes.Rows.Clear();
            DGV_QA_PlacasPendientes.Columns[5].HeaderText = "En equipo?";
            DGV_QA_PlacasPendientes.Columns[6].Visible = false;
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarVMATMenorA2.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarVMATMenorA2.txt").ToList();
            }
            foreach (string plan in Planes)
            {
                if (Sacar.Count() == 0 || !Sacar.Contains(plan))
                {
                    string[] planSplit = plan.Split(';');
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGV_QA_PlacasPendientes);
                    row.Cells[1].Value = planSplit[0];
                    row.Cells[2].Value = planSplit[1];
                    row.Cells[3].Value = planSplit[2];
                    row.Cells[4].Value = planSplit[3];
                    row.Cells[5].Value = planSplit[4];
                    DGV_QA_PlacasPendientes.Rows.Add(row);
                }
            }
            QAVisible = "VMATmenorA2";
            L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: " + File.GetLastWriteTime(Directory.GetFiles(Equipo.pathArchivos).Where(s => s.Contains("QA_VMATcorto")).First()).ToString();
        }

        private int QAVMATmenor2_Cantidad()
        {
            List<string> Planes = File.ReadAllLines(Equipo.pathArchivos + "QA_VMATcorto.txt").ToList();
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarVMATMenorA2.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarVMATMenorA2.txt").ToList();
            }
            if (Sacar.Count > 0)
            {
                return Planes.Except(Sacar).Count();
            }
            else
            {
                return Planes.Count();
            }
        }

        private void llenarDGVQAEstancadosEq3()
        {
            List<string> Planes = File.ReadAllLines(Equipo.pathArchivos + "Equipo 3_estancados.txt").ToList();
            Planes.AddRange(File.ReadAllLines(Equipo.pathArchivos + "Equipo 2_estancados.txt").ToList());
            DGV_QA_PlacasPendientes.Rows.Clear();
            DGV_QA_PlacasPendientes.Columns[5].HeaderText = "Ultima fx";
            DGV_QA_PlacasPendientes.Columns[6].Visible = true;
            DGV_QA_PlacasPendientes.Columns[6].HeaderText = "Ov Mach";
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarEq3_estancados.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarEq3_estancados.txt").ToList();
            }
            foreach (string plan in Planes)
            {
                if (Sacar.Count() == 0 || !Sacar.Contains(plan))
                {
                    string[] planSplit = plan.Split(';');
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGV_QA_PlacasPendientes);
                    row.Cells[1].Value = planSplit[0];
                    row.Cells[2].Value = planSplit[1];
                    row.Cells[3].Value = planSplit[2];
                    row.Cells[4].Value = planSplit[3];
                    row.Cells[5].Value = planSplit[4];
                    row.Cells[6].Value = planSplit[5];
                    DGV_QA_PlacasPendientes.Rows.Add(row);
                }
            }
            QAVisible = "Equipo3_Estancados";
            L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: " + File.GetLastWriteTime(Directory.GetFiles(Equipo.pathArchivos).Where(s => s.Contains("Equipo 3_estancados")).First()).ToString();
        }

        private int QAEstancadosEq3Cantidad()
        {
            List<string> Planes = File.ReadAllLines(Equipo.pathArchivos + "Equipo 3_estancados.txt").ToList();
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarEq3_estancados.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarEq3_estancados.txt").ToList();
            }
            if (Sacar.Count > 0)
            {
                return Planes.Except(Sacar).Count();
            }
            else
            {
                return Planes.Count();
            }
        }

        private void llenarDGVQAEstancadosEnCurso()
        {
            string[] Planes = File.ReadAllLines(Equipo.pathArchivos + "QA_pacientesEstancadosEnCurso.txt");
            DGV_QA_PlacasPendientes.Rows.Clear();
            DGV_QA_PlacasPendientes.Columns[5].HeaderText = "Status";
            DGV_QA_PlacasPendientes.Columns[6].HeaderText = "Fecha status";
            DGV_QA_PlacasPendientes.Columns[6].Visible = true;
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarEnCursoEstancados.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarEnCursoEstancados.txt").ToList();
            }
            foreach (string plan in Planes)
            {
                if (Sacar.Count() == 0 || !Sacar.Contains(plan))
                {
                    string[] planSplit = plan.Split(';');
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGV_QA_PlacasPendientes);
                    row.Cells[1].Value = planSplit[0];
                    row.Cells[2].Value = planSplit[1];
                    row.Cells[3].Value = planSplit[2];
                    row.Cells[4].Value = planSplit[3];
                    row.Cells[5].Value = planSplit[4];
                    row.Cells[6].Value = planSplit[5];
                    DGV_QA_PlacasPendientes.Rows.Add(row);
                }
            }
            QAVisible = "EnCursoEstancados";
            L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: " + File.GetLastWriteTime(Directory.GetFiles(Equipo.pathArchivos).Where(s => s.Contains("QA_pacientesEstancadosEnCurso.txt")).First()).ToString();
        }

        private int QAEstancadosEnCursoCantidad()
        {
            List<string> Planes = File.ReadAllLines(Equipo.pathArchivos + "QA_pacientesEstancadosEnCurso.txt").ToList();
            List<string> Sacar = new List<string>();
            if (File.Exists(Equipo.pathArchivos + "SacarEnCursoEstancados.txt"))
            {
                Sacar = File.ReadAllLines(Equipo.pathArchivos + "SacarEnCursoEstancados.txt").ToList();
            }
            if (Sacar.Count > 0)
            {
                return Planes.Except(Sacar).Count();
            }
            else
            {
                return Planes.Count();
            }
        }

        private void BT_ActualizarBusquedas_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion(false, false, false, true, Equipos);
            conexion.ShowDialog();
            L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: " + DateTime.Now.ToString();
            DGV_QA_PlacasPendientes.Rows.Clear();
            QAVisible = "";
            llenarLB_QA();
            LB_QA.SelectedIndex = -1;
        }

        private void BT_QA_SacarDeLista_Click(object sender, EventArgs e)
        {
            List<string> Sacar = new List<string>();
            if (QAVisible == "PlacasPendientes")
            {
                foreach (DataGridViewRow row in DGV_QA_PlacasPendientes.Rows)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                    {
                        Sacar.Add(row.Cells[1].Value + ";" + row.Cells[2].Value + ";" + row.Cells[3].Value + ";" + row.Cells[4].Value + ";" + row.Cells[5].Value + ";" + row.Cells[6].Value);
                    }
                }
                File.AppendAllLines(Equipo.pathArchivos + "SacarPendientePlacas.txt", Sacar.ToArray());
                LlenarDGVQAPlacasPendientes();
            }
            else if (QAVisible == "VMATmenorA2")
            {
                foreach (DataGridViewRow row in DGV_QA_PlacasPendientes.Rows)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                    {
                        Sacar.Add(row.Cells[1].Value + ";" + row.Cells[2].Value + ";" + row.Cells[3].Value + ";" + row.Cells[4].Value + ";" + row.Cells[5].Value);
                    }
                }
                File.AppendAllLines(Equipo.pathArchivos + "SacarVMATMenorA2.txt", Sacar.ToArray());
                llenarDGVQAVMATMenorA2min();
            }
            else if (QAVisible == "Equipo3_Estancados")
            {
                foreach (DataGridViewRow row in DGV_QA_PlacasPendientes.Rows)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                    {
                        Sacar.Add(row.Cells[1].Value + ";" + row.Cells[2].Value + ";" + row.Cells[3].Value + ";" + row.Cells[4].Value + ";" + row.Cells[5].Value + ";" + row.Cells[6].Value);
                    }
                }
                File.AppendAllLines(Equipo.pathArchivos + "SacarEq3_estancados.txt", Sacar.ToArray());
                llenarDGVQAEstancadosEq3();
            }
            else if (QAVisible == "EnCursoEstancados")
            {
                foreach (DataGridViewRow row in DGV_QA_PlacasPendientes.Rows)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                    {
                        Sacar.Add(row.Cells[1].Value + ";" + row.Cells[2].Value + ";" + row.Cells[3].Value + ";" + row.Cells[4].Value + ";" + row.Cells[5].Value + ";" + row.Cells[6].Value);
                    }
                }
                File.AppendAllLines(Equipo.pathArchivos + "SacarEnCursoEstancados.txt", Sacar.ToArray());
                llenarDGVQAEstancadosEq3();

            }
            llenarLB_QA();
        }

        private void llenarLB_QA()
        {
            LB_QA.Items.Clear();
            LB_QA.Items.Add("Placas pendientes (" + QAPlacasPendientes_Cantidad().ToString() + ")");
            LB_QA.Items.Add("VMAT <2min (" + QAVMATmenor2_Cantidad().ToString() + ")");
            LB_QA.Items.Add("Estancados en eq3 (" + QAEstancadosEq3Cantidad().ToString() + ")");
            LB_QA.Items.Add("Estancados en planificación (" + QAEstancadosEnCursoCantidad().ToString() + ")");

        }

        private void LB_QA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_QA.SelectedIndex == 0)
            {
                LlenarDGVQAPlacasPendientes();
                QATitulo = "Placas pendientes";
            }
            else if (LB_QA.SelectedIndex == 1)
            {
                llenarDGVQAVMATMenorA2min();
                QATitulo = "Planes con VMAT <2min";
            }
            else if (LB_QA.SelectedIndex == 2)
            {
                llenarDGVQAEstancadosEq3();
                QATitulo = "Pacientes estancados en equipo 3";
            }
            else if (LB_QA.SelectedIndex == 3)
            {
                llenarDGVQAEstancadosEnCurso();
                QATitulo = "Pacientes estancados en planificación";
            }
        }



        private void BT_QA_ExportarLista_Click(object sender, EventArgs e)
        {
            if (DGV_QA_PlacasPendientes.Rows.Count > 0)
            {
                /*List<string> listaAExportar = new List<string>();
                string header = "|";
                foreach (DataGridViewColumn columna in DGV_QA_PlacasPendientes.Columns)
                {
                    if (columna.Index>0)
                    {
                        header += columna.HeaderText + "\t\t|";
                    }
                }
                listaAExportar.Add(header);
                foreach (DataGridViewRow fila in DGV_QA_PlacasPendientes.Rows)
                {
                    string stringFila = "|";
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        if (celda.ColumnIndex>0)
                        {
                            stringFila += celda.Value + "\t\t|";
                        }
                    }
                    listaAExportar.Add(stringFila);
                }
                string path = Path.Combine(@"\\ARIAMEVADB-SVR\va_data$\PlanHelper\QA_Export\", QAVisible + "_" + DateTime.Now.ToString("dd/MM/yyyy") + ".txt");
                File.WriteAllLines(path, listaAExportar.ToArray());
                MessageBox.Show("Se generó el archivo de texto: " + Path.GetFileName(path));*/
                var doc = new Document();
                Estilos.definirEstilos(doc);
                Section seccion = new Section();
                Estilos.formatearSeccion(seccion);
                MigraDoc.DocumentObjectModel.Tables.Table tabla = new MigraDoc.DocumentObjectModel.Tables.Table();
                tabla.Format.Alignment = ParagraphAlignment.Center;
                foreach (DataGridViewColumn columna in DGV_QA_PlacasPendientes.Columns)
                {
                    if (columna.Index > 0 && columna.Visible)
                    {
                        tabla.AddColumn(columna.Width * 1.1);
                    }
                }
                var filaHeadertabla = tabla.AddRow();
                foreach (DataGridViewRow filaDGV in DGV_QA_PlacasPendientes.Rows)
                {
                    var tableFila = tabla.AddRow();
                    for (int i = 1; i < DGV_QA_PlacasPendientes.Columns.Count; i++)
                    {
                        if (DGV_QA_PlacasPendientes.Columns[i].Visible)
                        {
                            string valor = "";
                            if (filaDGV.Cells[i].Value != null)
                            {
                                valor = filaDGV.Cells[i].Value.ToString();
                            }
                            tableFila.Cells[i - 1].AddParagraph(valor);
                        }

                    }
                }
                for (int i = 1; i < DGV_QA_PlacasPendientes.Columns.Count; i++)
                {
                    if (DGV_QA_PlacasPendientes.Columns[i].Visible)
                    {

                        tabla.Rows[0].Cells[i - 1].AddParagraph(DGV_QA_PlacasPendientes.Columns[i].HeaderText);
                    }
                }
                Estilos.formatearTabla(tabla);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                seccion.AddParagraph(QATitulo, "Titulo");
                seccion.AddParagraph("Fecha: " + DateTime.Today.ToShortDateString(), "Texto Negrita");
                seccion.Add(tabla);
                doc.Add(seccion);
                string path = Path.Combine(@"\\ARIAMEVADB-SVR\va_data$\PlanHelper\QA_Export\", QAVisible + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf");
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
                pdfRenderer.Document = doc;
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(path);
                MessageBox.Show("Se ha guardado el reporte con el nombre: " + Path.GetFileName(path));
            }

        }




        #endregion

        #region tab_Parametros

        private void GenerarGUI_Parametros()
        {
            int dist = 160;
            for (int i = 0; i < Equipos.Count; i++)
            {
                Label label = new Label();
                label.Text = Equipos.ElementAt(i).Nombre;
                label.Location = new Point(15 + dist * i, 15);
                tab_Parametros.Controls.Add(label);
                ListBox listBox = new ListBox();
                listBox.Location = new Point(15 + dist * i, 45);
                listBox.Width = 150;
                listBox.Name = "LB_" + Equipos.ElementAt(i).Nombre;
                tab_Parametros.Controls.Add(listBox);
            }
            CargarLBParametros();
        }

        private void CargarLBParametrosEquipo(ListBox ListBox)
        {
            Equipo equipo = Equipos.Where(e => ListBox.Name.Contains(e.Nombre)).First();
            if (equipo.Parametros != null && equipo.Parametros.Count > 0)
            {
                foreach (Parametro parametro in equipo.Parametros)
                {
                    ListBox.Items.Add(parametro.StatusInicial + "-" + parametro.Modalidad + " " + parametro.Dias.ToString() + " días");
                }
            }
        }

        private void CargarLBParametros()
        {
            foreach (Control LB in tab_Parametros.Controls)
            {
                if (LB is ListBox)
                {
                    CargarLBParametrosEquipo((ListBox)LB);
                }
            }
            L_ParametrosUltimoCalculo.Text = "Último cálculo: " + Equipos.First().UltimoCalculo.ToString();
        }

        private void BT_ParametrosRecalcular_Click(object sender, EventArgs e)
        {
            foreach (Control LB in tab_Parametros.Controls)
            {
                if (LB is ListBox)
                {
                    ((ListBox)LB).Items.Clear();
                }
            }
            Conexion conexion = new Conexion(true, false, false, false, Equipos);
            conexion.ShowDialog();
            CargarLBParametros();
        }

        private void BT_Minar_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        #endregion

        #region tab_ExacTrac
        List<PacienteExacTrac> pacientesExacTracEq1 = new List<PacienteExacTrac>();
        List<PacienteExacTrac> pacientesExacTracEq4 = new List<PacienteExacTrac>();
        private void iniciarLB_ExacTrac()
        {
            LB_ExacTrac.Items.Add("Equipo 1");
            LB_ExacTrac.Items.Add("Equipo 4");
            LB_ExacTrac.Enabled = false;
        }

        private void buscarPacientesExacTrac()
        {
            //pacientesEq1 = PacienteExacTrac.BuscarPacientes(PacienteExacTrac.pathEquipo1);
            pacientesExacTracEq4 = PacienteExacTrac.BuscarPacientes(PacienteExacTrac.pathEquipo4);
        }
        private void llenarDGVPacientesExactrac(List<PacienteExacTrac> pacientes)
        {
            DGV_ExacTrac.Rows.Clear();
            foreach (PacienteExacTrac paciente in pacientes)
            {
                foreach (string plan in paciente.Planes)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(DGV_ExacTrac);
                    fila.Cells[1].Value = paciente.ID;
                    fila.Cells[2].Value = paciente.Nombre;
                    fila.Cells[3].Value = plan;
                    if (paciente.hayCT)
                    {
                        fila.Cells[4].Value = "Sí";
                    }
                    else
                    {
                        fila.Cells[4].Value = "No";
                    }
                    if (paciente.HayStructureSet)
                    {
                        fila.Cells[5].Value = "Sí";
                    }
                    else
                    {
                        fila.Cells[5].Value = "No";
                    }
                    DGV_ExacTrac.Rows.Add(fila);
                }
            }
        }

        private void LB_ExacTrac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_ExacTrac.GetItemText(LB_ExacTrac.SelectedItem) == "Equipo 1")
            {
                llenarDGVPacientesExactrac(pacientesExacTracEq1);
            }
            else
            {
                llenarDGVPacientesExactrac(pacientesExacTracEq4);
            }
        }

        private void BT_BuscarExacTrac_Click(object sender, EventArgs e)
        {
            buscarPacientesExacTrac();
            LB_ExacTrac.Enabled = true;
        }

        #endregion

        #region tabBuscar
        private void BT_BuscadorBuscar_Click(object sender, EventArgs e)
        {
            L_BuscadorResultados.Visible = false;
            DGV_Buscador.Rows.Clear();
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            if (CHB_BuscadorDesde.Checked)
            {
                fechaDesde = DTP_BuscadorDesde.Value;
            }
            if (CHB_BuscadorHasta.Checked)
            {
                fechaHasta = DTP_BuscadorHasta.Value;
            }
            string equipoEtiqueta = "";
            if (CB_BuscadorEquipo.Text == "Equipo 1")
            {
                equipoEtiqueta = "Equipo1";
            }
            else if (CB_BuscadorEquipo.Text == "Equipo 3")
            {
                equipoEtiqueta = "2100CMLC";
            }
            else if (CB_BuscadorEquipo.Text == "Equipo 4")
            {
                equipoEtiqueta = "D-2300CD";
            }
            else if (CB_BuscadorEquipo.Text == "Cetro")
            {
                equipoEtiqueta = "PBA_6EX_730";
            }
            int aux;
            int? numFx;
            if (int.TryParse(TB_BuscadorNumFx.Text, out aux))
            {
                numFx = aux;
            }
            else
            {
                numFx = null;
            }
            double aux2;
            double? dosisDia;
            if (double.TryParse(TB_BuscadorDosisDia.Text, out aux2))
            {
                dosisDia = aux2;
            }
            else
            {
                dosisDia = null;
            }

            List<AriaQ.PlanSetup> planes = ConsultasDB.BusquedaGeneral(TB_BuscadorApellido.Text, TB_BuscadorHC.Text, TB_BuscadorCurso.Text, TB_BuscadorPlan.Text, equipoEtiqueta, fechaDesde, fechaHasta, CB_BuscadorModalidad.Text, CB_BuscadorEstadoAprobacion.Text, CHB_BuscarEstaEnTratamiento.Checked, numFx, dosisDia, TB_BuscadorEstructuras.Text);

            foreach (AriaQ.PlanSetup plan in planes)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_Buscador);
                row.Cells[0].Value = plan.Course.Patient.PatientId;
                row.Cells[1].Value = plan.Course.Patient.LastName;
                row.Cells[2].Value = plan.Course.Patient.FirstName;
                row.Cells[3].Value = plan.Course.CourseId;
                row.Cells[4].Value = plan.PlanSetupId;
                DGV_Buscador.Rows.Add(row);
            }
            L_BuscadorResultados.Text = "Se encontraron " + planes.Count().ToString() + " resultados";
            L_BuscadorResultados.Visible = true;

        }

        private void CHB_BuscadorDesde_CheckedChanged(object sender, EventArgs e)
        {
            DTP_BuscadorDesde.Enabled = CHB_BuscadorDesde.Checked;
        }

        private void CHB_BuscadorHasta_CheckedChanged(object sender, EventArgs e)
        {
            DTP_BuscadorHasta.Enabled = CHB_BuscadorHasta.Checked;
        }

        private void BT_BuscadorExportar_Click(object sender, EventArgs e)
        {
            string nombreAutomatico = "Busqueda_" + DateTime.Now.ToString("dd/MM/yyyy_HH_mm_ss");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.AddExtension = true;
            //saveFileDialog.CheckFileExists = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text (*.txt)|*.txt";
            saveFileDialog.FileName = nombreAutomatico;
            saveFileDialog.InitialDirectory = @"\\ARIAMEVADB-SVR\va_data$\PlanHelper\Busquedas";

            if (DGV_Buscador.Rows.Count > 0)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    List<string> output = new List<string>();
                    output.Add("HC;Apellido;Nombre;Curso;Plan");
                    foreach (DataGridViewRow fila in DGV_Buscador.Rows)
                    {
                        output.Add(fila.Cells[0].Value + ";" + fila.Cells[1].Value + ";" + fila.Cells[2].Value + ";" + fila.Cells[3].Value + ";" + fila.Cells[4].Value);
                    }
                    File.WriteAllLines(saveFileDialog.FileName, output.ToArray());
                    File.WriteAllLines(saveFileDialog.FileName, output.ToArray());

                }
                //string path = Path.Combine(@"\\ARIAMEVADB-SVR\va_data$\PlanHelper\Busquedas", "Busqueda_" + DateTime.Now.ToString("dd/MM/yyyy_HH_mm_ss") + ".txt");
                //File.WriteAllLines(path,output.ToArray());
                //MessageBox.Show("Se guardaron los registros en: " + Path.GetFileName(path));
            }
        }

        private void BT_BuscadorExportarPDF_Click(object sender, EventArgs e)
        {
            var doc = new Document();
            Estilos.definirEstilos(doc);
            Section seccion = new Section();
            Estilos.formatearSeccion(seccion);
            MigraDoc.DocumentObjectModel.Tables.Table tabla = new MigraDoc.DocumentObjectModel.Tables.Table();
            tabla.Format.Alignment = ParagraphAlignment.Center;
            foreach (DataGridViewColumn columna in DGV_Buscador.Columns)
            {
                tabla.AddColumn(columna.Width * 1.1);

            }
            var filaHeadertabla = tabla.AddRow();
            foreach (DataGridViewRow filaDGV in DGV_Buscador.Rows)
            {
                var tableFila = tabla.AddRow();
                for (int i = 0; i < DGV_Buscador.Columns.Count; i++)
                {
                    if (DGV_Buscador.Columns[i].Visible)
                    {
                        string valor = "";
                        if (filaDGV.Cells[i].Value != null)
                        {
                            valor = filaDGV.Cells[i].Value.ToString();
                        }
                        tableFila.Cells[i].AddParagraph(valor);
                    }

                }
            }
            for (int i = 0; i < DGV_Buscador.Columns.Count; i++)
            {
                if (DGV_Buscador.Columns[i].Visible)
                {

                    tabla.Rows[0].Cells[i].AddParagraph(DGV_Buscador.Columns[i].HeaderText);
                }
            }
            string descripcion = "";
            if (!string.IsNullOrEmpty(TB_BuscadorHC.Text))
            {
                descripcion += "HC: " + TB_BuscadorHC.Text + " - ";
            }
            if (!string.IsNullOrEmpty(TB_BuscadorApellido.Text))
            {
                descripcion += "Apellido: " + TB_BuscadorApellido.Text + " - ";
            }
            if (!string.IsNullOrEmpty(TB_BuscadorCurso.Text))
            {
                descripcion += "Curso: " + TB_BuscadorCurso.Text + " - ";
            }
            if (!string.IsNullOrEmpty(TB_BuscadorPlan.Text))
            {
                descripcion += "Plan: " + TB_BuscadorPlan.Text + " - ";
            }
            if (!string.IsNullOrEmpty(TB_BuscadorNumFx.Text))
            {
                descripcion += "Nº Fx: " + TB_BuscadorNumFx.Text + " - ";
            }
            if (!string.IsNullOrEmpty(TB_BuscadorDosisDia.Text))
            {
                descripcion += "Dosis día: " + TB_BuscadorDosisDia.Text + " - ";
            }
            if (!string.IsNullOrEmpty(TB_BuscadorEstructuras.Text))
            {
                descripcion += "Contiene la estructura: " + TB_BuscadorEstructuras.Text + " - ";
            }
            if (CHB_BuscadorDesde.Checked)
            {
                descripcion += "Desde: " + DTP_BuscadorDesde.Value.ToShortDateString() + " - ";
            }
            if (CHB_BuscadorHasta.Checked)
            {
                descripcion += "Desde: " + DTP_BuscadorHasta.Value.ToShortDateString() + " - ";
            }
            if (!string.IsNullOrEmpty(CB_BuscadorEquipo.Text))
            {
                descripcion += CB_BuscadorEquipo.Text + " - ";
            }
            if (!string.IsNullOrEmpty(CB_BuscadorModalidad.Text))
            {
                descripcion += "Modalidad: " + CB_BuscadorModalidad.Text + " - ";
            }
            if (!string.IsNullOrEmpty(CB_BuscadorEstadoAprobacion.Text))
            {
                descripcion += "Estado: " + CB_BuscadorEstadoAprobacion.Text + " - ";
            }
            if (CHB_BuscarEstaEnTratamiento.Checked)
            {
                descripcion += "Está en tratamiento";
            }
            Estilos.formatearTabla(tabla);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            seccion.AddParagraph("Búsqueda", "Titulo");
            seccion.AddParagraph(descripcion, "Texto Negrita");
            seccion.AddParagraph("Fecha: " + DateTime.Today.ToShortDateString(), "Texto Negrita");
            seccion.Add(tabla);
            doc.Add(seccion);
            string path = Path.Combine(@"\\ARIAMEVADB-SVR\va_data$\PlanHelper\Busquedas\", "Busqueda_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".pdf");
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = doc;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(path);
            MessageBox.Show("Se ha guardado el reporte con el nombre: " + Path.GetFileName(path));
        }

        #endregion

        #region tabQAPE

        private void BT_ActualizarQAPE_Click(object sender, EventArgs e)
        {
            if(true)//Environment.MachineName == "ARIA-FISICA3")// && Environment.UserName == "Varian")
            {
                Conexion conexion = new Conexion(false, false, false, false, Equipos, true);
                conexion.ShowDialog();
                llenarDGVEstadoEquipos();
            }
            LlenarDGVQAPE();
        }

        private void LlenarDGVQAPE()
        {
            if (File.Exists(Equipo.pathArchivos + "pacientesQAPE.txt"))
            {
                DGV_QAPE.Rows.Clear();
                List<PlanPaciente> pacientesQAPE = PlanPaciente.ExtraerDeArchivo(Equipo.pathArchivos + "pacientesQAPE.txt",1);
                foreach (PlanPaciente paciente in pacientesQAPE)
                {
                    if (paciente.RequierePlanQA)
                    {
                        string equipo = "";
                        if (paciente.EquipoID== "D-2300CD")
                        {
                            equipo = "Equipo 4";
                        }
                        else if (paciente.EquipoID=="Equipo1")
                        {
                            equipo = "Equipo 1";
                        }
                        else if (paciente.EquipoID=="2100CMLC")
                        {
                            equipo = "Equipo 3";
                        }
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(DGV_QAPE);
                        row.Cells[0].Value = paciente.PacienteID;
                        row.Cells[1].Value = paciente.PacienteNombre;
                        row.Cells[2].Value = paciente.PlanID;
                        row.Cells[3].Value = equipo;
                        row.Cells[4].Value = paciente.TienePlanQA;
                        row.Cells[5].Value = paciente.SeMidioPlanQA;
                        row.Cells[6].Value = paciente.PlanQAOK;
                        row.Cells[7].Value = paciente.NotaQA;
                        DGV_QAPE.Rows.Add(row);
                    }
                }
                DGV_QAPE.Columns[0].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
                DGV_QAPE.Columns[1].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
                DGV_QAPE.Columns[2].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
                DGV_QAPE.Columns[3].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
                DGV_QAPE.Columns[4].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
                DGV_QAPE.Sort(DGV_QAPE.Columns[1], ListSortDirection.Ascending);
                DGV_QAPE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                DGV_QAPE.Columns[7].Width = 150;
            }
            L_QAPEActualizacion.Text = "Ultima actualización: " + ConsultasDB.LeerDateTimeQAPE();

        }

        private PlanPaciente PlanDeRow(DataGridViewRow row, List<PlanPaciente> lista)
        {
            return lista.First(p => p.PacienteID == (string)row.Cells[0].Value && p.PlanID == (string)row.Cells[2].Value);
        }

        private void BT_QAGuardarCambios_Click(object sender, EventArgs e)
        {
            if (File.Exists(Equipo.pathArchivos + "pacientesQAPE.txt"))
            {
                List<PlanPaciente> pacientesQAPE = PlanPaciente.ExtraerDeArchivo(Equipo.pathArchivos + "pacientesQAPE.txt",1);
                foreach (DataGridViewRow row in DGV_QAPE.Rows)
                {
                    PlanPaciente plan = PlanDeRow(row, pacientesQAPE);
                    plan.SeMidioPlanQA = (bool)row.Cells[5].Value;
                    plan.PlanQAOK = (bool)row.Cells[6].Value;
                    plan.NotaQA = (string)row.Cells[7].Value;
                }
                string fechaQAPE = ConsultasDB.LeerDateTimeQAPE();
                List<PlanPaciente> pacientesRequiereQA = pacientesQAPE.Where(p => p.RequierePlanQA).ToList();
                MetodosAuxiliares.EscribirSiEstaDisponible(Equipo.pathArchivos + "pacientesQAPE.txt", pacientesQAPE.Select(p => p.ToString()).ToArray());
                MetodosAuxiliares.EscribirSiEstaDisponible(Equipo.pathArchivos + "pacientesRequiereQAPE.txt", pacientesRequiereQA.Select(p => p.ToStringQAPE()).ToArray());
                ConsultasDB.agregarDateTime(Equipo.pathArchivos + "pacientesQAPE.txt", fechaQAPE);
                ConsultasDB.agregarHeader(Equipo.pathArchivos + "pacientesRequiereQAPE.txt");
                LlenarDGVQAPE();
            }

        }

        private void BT_QAAgregar_Click(object sender, EventArgs e)
        {
            AgregarQA agregarQA = new AgregarQA();
            agregarQA.ShowDialog();
            LlenarDGVQAPE();
        }



        #endregion
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {

            }
            else if (tabControl1.SelectedIndex == 1)
            {
                llenarDGVEstadoEquipos();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                llenarLB_QA();
                L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: " + File.GetLastWriteTime(Directory.GetFiles(Equipo.pathArchivos).Where(s => s.Contains("QA_VMATcorto")).First()).ToString();
            }
            else if (tabControl1.SelectedIndex == 3)
            {

            }
            else if (tabControl1.SelectedIndex == 4)
            {

            }
            else if (tabControl1.SelectedIndex == 5 && !(Environment.UserName == "Varian"))
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("No se puede buscar en la base de datos desde esta pc y usuario");
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                LlenarDGVQAPE();
            }
			else if (this.tabControl1.SelectedIndex == 7)
        {
          this.LlenarDGVTBI();
        }
        else
        {
          if (this.tabControl1.SelectedIndex != 8)
            return;
          this.LlenarInicios();
        }
        }



        private void habilitacionBotones()
        {
            if (Environment.UserName == "Varian")
            {
                BT_QAActualizarBusquedas.Enabled = true;
                BT_EstadoEquiposActualizar.Enabled = true;
                BT_ParametrosRecalcular.Enabled = true;
                BT_Minar.Enabled = true;
            }
            else
            {
                BT_QAActualizarBusquedas.Enabled = false;
                BT_EstadoEquiposActualizar.Enabled = false;
                BT_ParametrosRecalcular.Enabled = false;
                BT_Minar.Enabled = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void BT_NuevoTBI_Click(object sender, EventArgs e)
        {
            NuevoPacienteTBI nuevoPacienteTBI = new NuevoPacienteTBI(_edita: false);
            nuevoPacienteTBI.ShowDialog();
            if (nuevoPacienteTBI.DialogResult == DialogResult.OK)
            {
                pacientesTBI.Add(nuevoPacienteTBI.nuevoPaciente);
                PacienteTBI.EscribirArchivo(pacientesTBI);
                LlenarDGVTBI();
            }
        }

        private void BT_TBIEditaPaciente_Click(object sender, EventArgs e)
        {
            if (pacienteTBISeleccionado() != null)
            {
                NuevoPacienteTBI nuevoPacienteTBI = new NuevoPacienteTBI(_edita: true, pacienteTBISeleccionado());
                nuevoPacienteTBI.ShowDialog();
                if (nuevoPacienteTBI.DialogResult == DialogResult.OK)
                {
                    pacientesTBI.Remove(pacienteTBISeleccionado());
                    pacientesTBI.Add(nuevoPacienteTBI.nuevoPaciente);
                    PacienteTBI.EscribirArchivo(pacientesTBI);
                    LlenarDGVTBI();
                }
            }
        }

        private void BT_PacTBIEliminarPaciente_Click(object sender, EventArgs e)
        {
            pacientesTBI = PacienteTBI.LeerArchivo();
            pacientesTBI.Remove(pacienteTBISeleccionado());
            PacienteTBI.EscribirArchivo(pacientesTBI);
            LlenarDGVTBI();

        }

        private void BT_TBIActualizarBusqueda_Click(object sender, EventArgs e)
        {
            if (Environment.UserName == "Varian")
            {
                Conexion conexion = new Conexion(false, false, false, false, Equipos, false, true);
                conexion.ShowDialog();
            }
            LlenarDGVTBI();
        }

        private void BT_TBIGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in DGV_PacientesTBI.Rows)
            {
                PacienteTBI pacienteTBI = pacientesTBI.First((PacienteTBI p) => p.ID == fila.Cells[0].Value.ToString());
                pacienteTBI.LlevaPb = Convert.ToBoolean(fila.Cells[5].Value);
                pacienteTBI.PbHechos = Convert.ToBoolean(fila.Cells[10].Value);
                pacienteTBI.ArchivosEnEquipo = Convert.ToBoolean(fila.Cells[11].Value);
            }
            PacienteTBI.EscribirArchivo(pacientesTBI);
            LlenarDGVTBI();

        }

        private void LlenarDGVTBI()
        {
            pacientesTBI = PacienteTBI.LeerArchivo();
            DGV_PacientesTBI.Rows.Clear();
            if (pacientesTBI.Count <= 0)
            {
                return;
            }
            foreach (PacienteTBI pac in pacientesTBI)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(DGV_PacientesTBI);
                fila.Cells[0].Value = pac.ID;
                fila.Cells[1].Value = pac.Apellido + ", " + pac.Nombre;
                fila.Cells[2].Value = pac.Equipo.Nombre;
                if (fila.Cells[2].Value.ToString() == "Discrepancia")
                {
                    fila.Cells[2].Style.BackColor = System.Drawing.Color.LightSalmon;
                }
                fila.Cells[3].Value = pac.FechaInicio.ToString("dd-MM-yyyy");
                fila.Cells[4].Value = pac.NumeroFracciones.ToString();
                if (fila.Cells[4].Value.ToString() == "1000")
                {
                    fila.Cells[4].Style.BackColor = System.Drawing.Color.LightSalmon;
                }
                fila.Cells[5].Value = pac.LlevaPb;
                fila.Cells[6].Value = pac.CTIngresada;
                fila.Cells[7].Value = pac.PlanesCreados;
                fila.Cells[8].Value = pac.PlanesAprobados;
                fila.Cells[9].Value = pac.TratamientoAprobado;
                fila.Cells[10].Value = pac.PbHechos;
                fila.Cells[11].Value = pac.ArchivosEnEquipo;
                DGV_PacientesTBI.Rows.Add(fila);
            }
            DGV_PacientesTBI.Columns[0].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[1].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[2].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[3].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[4].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[5].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[6].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[7].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[8].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.Columns[9].DefaultCellStyle.BackColor = DGV_QAPE.ColumnHeadersDefaultCellStyle.BackColor;
            DGV_PacientesTBI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGV_PacientesTBI.Update();
            DGV_PacientesTBI.ClearSelection();
        }
        private PacienteTBI pacienteTBISeleccionado()
        {
            if (DGV_PacientesTBI.SelectedRows.Count == 1)
            {
                return pacientesTBI.First((PacienteTBI p) => p.ID == DGV_PacientesTBI.SelectedRows[0].Cells[0].Value.ToString());
            }
            return null;
        }

        private void LlenarInicios()
        {
            RTB_Inicios.Clear();
            string[] inicios = File.ReadAllLines(Equipo.pathArchivos + "\\placas.txt");
            RTB_Inicios.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 11f, FontStyle.Regular);
            RTB_Inicios.AppendText(inicios[0] + Environment.NewLine);
            for (int i = 1; i < inicios.Length; i++)
            {
                if (inicios[i].Contains("Equipo"))
                {
                    RTB_Inicios.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                    RTB_Inicios.AppendText(Environment.NewLine + Environment.NewLine + inicios[i]);
                }
                else
                {
                    RTB_Inicios.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
                    RTB_Inicios.AppendText(Environment.NewLine + inicios[i]);
                }
            }
        }

        private void BT_ActualizarInicios_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion(_ActualizaParametros: false, _ActualizaEnCurso: false, _ActualizaOcupacion: false, _ActualizaQA: false, Equipos, _actualizaQAPE: false, _actualizaPacTBI: false, _buscaIniciosSitramed: true);
            conexion.ShowDialog();
            LlenarInicios();
        }
    }

}
