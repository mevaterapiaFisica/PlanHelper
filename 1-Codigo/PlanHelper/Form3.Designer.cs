namespace PlanHelper
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Consulta = new System.Windows.Forms.TabPage();
            this.TB_NumFracciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_ParaQueEquipo = new System.Windows.Forms.TextBox();
            this.CHB_EsP1 = new System.Windows.Forms.CheckBox();
            this.BT_ConsultaBuscarEquipo = new System.Windows.Forms.Button();
            this.CHB_Electrones = new System.Windows.Forms.CheckBox();
            this.DTP_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.CHB_TieneFechaDeInicio = new System.Windows.Forms.CheckBox();
            this.CHB_EsVMAT = new System.Windows.Forms.CheckBox();
            this.CHB_10MV = new System.Windows.Forms.CheckBox();
            this.tab_EstadoEquipos = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_GraficarTurnosLibres = new System.Windows.Forms.Button();
            this.BT_EstadoEquiposActualizar = new System.Windows.Forms.Button();
            this.L_EstadoEquipoUltimaBusqueda = new System.Windows.Forms.Label();
            this.DGV_EstadoEquipos = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_QA = new System.Windows.Forms.TabPage();
            this.BT_QA_ExportarLista = new System.Windows.Forms.Button();
            this.LB_QA = new System.Windows.Forms.ListBox();
            this.BT_QA_SacarDeLista = new System.Windows.Forms.Button();
            this.BT_QAActualizarBusquedas = new System.Windows.Forms.Button();
            this.L_QA_UltimaBusquedaPlacasPendientes = new System.Windows.Forms.Label();
            this.DGV_QA_PlacasPendientes = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_Parametros = new System.Windows.Forms.TabPage();
            this.BT_Minar = new System.Windows.Forms.Button();
            this.BT_ParametrosRecalcular = new System.Windows.Forms.Button();
            this.L_ParametrosUltimoCalculo = new System.Windows.Forms.Label();
            this.tab_ExacTrac = new System.Windows.Forms.TabPage();
            this.BT_EliminarExacTrac = new System.Windows.Forms.Button();
            this.LB_ExacTrac = new System.Windows.Forms.ListBox();
            this.BT_BuscarExacTrac = new System.Windows.Forms.Button();
            this.DGV_ExacTrac = new System.Windows.Forms.DataGridView();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HayCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HayEstructuras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_Buscador = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_BuscadorEstructuras = new System.Windows.Forms.TextBox();
            this.BT_BuscadorExportarPDF = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CHB_BuscarEstaEnTratamiento = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_BuscadorEstadoAprobacion = new System.Windows.Forms.ComboBox();
            this.L_BuscadorResultados = new System.Windows.Forms.Label();
            this.DGV_Buscador = new System.Windows.Forms.DataGridView();
            this.BuscadorHC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuscadorApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuscadorNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuscadorCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuscadorPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_BuscadorExportar = new System.Windows.Forms.Button();
            this.BT_BuscadorBuscar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CB_BuscadorModalidad = new System.Windows.Forms.ComboBox();
            this.CB_BuscadorEquipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CHB_BuscadorHasta = new System.Windows.Forms.CheckBox();
            this.CHB_BuscadorDesde = new System.Windows.Forms.CheckBox();
            this.DTP_BuscadorHasta = new System.Windows.Forms.DateTimePicker();
            this.DTP_BuscadorDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.L_BuscadorNumFx = new System.Windows.Forms.Label();
            this.TB_BuscadorNumFx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_BuscadorDosisDia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_BuscadorPlan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_BuscadorCurso = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_BuscadorApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_BuscadorHC = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BT_EliminarDeLaLista = new System.Windows.Forms.Button();
            this.L_QAPEActualizacion = new System.Windows.Forms.Label();
            this.BT_QAAgregar = new System.Windows.Forms.Button();
            this.BT_QAGuardarCambios = new System.Windows.Forms.Button();
            this.BT_ActualizarQAPE = new System.Windows.Forms.Button();
            this.DGV_QAPE = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipoQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QA_OK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NotaQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BT_TBIGuardarCambios = new System.Windows.Forms.Button();
            this.BT_TBIActualizarBusqueda = new System.Windows.Forms.Button();
            this.BT_PacTBIEliminarPaciente = new System.Windows.Forms.Button();
            this.BT_TBIEditaPaciente = new System.Windows.Forms.Button();
            this.BT_NuevoTBI = new System.Windows.Forms.Button();
            this.DGV_PacientesTBI = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LlevaPbs = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Treatment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PbsListos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DicomEnEq = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BT_PedidoActualizarEstado = new System.Windows.Forms.Button();
            this.BT_EliminarPedido = new System.Windows.Forms.Button();
            this.BT_CompletarPedido = new System.Windows.Forms.Button();
            this.BT_EditarPedido = new System.Windows.Forms.Button();
            this.BT_NuevoPedido = new System.Windows.Forms.Button();
            this.DGV_Pedidos = new System.Windows.Forms.DataGridView();
            this.ColPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTecnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFechaLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSolicita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFisResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BT_ActualizarInicios = new System.Windows.Forms.Button();
            this.RTB_Inicios = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tab_Consulta.SuspendLayout();
            this.tab_EstadoEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EstadoEquipos)).BeginInit();
            this.tab_QA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QA_PlacasPendientes)).BeginInit();
            this.tab_Parametros.SuspendLayout();
            this.tab_ExacTrac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ExacTrac)).BeginInit();
            this.tab_Buscador.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Buscador)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QAPE)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PacientesTBI)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Pedidos)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Consulta);
            this.tabControl1.Controls.Add(this.tab_EstadoEquipos);
            this.tabControl1.Controls.Add(this.tab_Buscador);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tab_QA);
            this.tabControl1.Controls.Add(this.tab_ExacTrac);
            this.tabControl1.Controls.Add(this.tab_Parametros);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(869, 418);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab_Consulta
            // 
            this.tab_Consulta.Controls.Add(this.TB_NumFracciones);
            this.tab_Consulta.Controls.Add(this.label2);
            this.tab_Consulta.Controls.Add(this.TB_ParaQueEquipo);
            this.tab_Consulta.Controls.Add(this.CHB_EsP1);
            this.tab_Consulta.Controls.Add(this.BT_ConsultaBuscarEquipo);
            this.tab_Consulta.Controls.Add(this.CHB_Electrones);
            this.tab_Consulta.Controls.Add(this.DTP_FechaInicio);
            this.tab_Consulta.Controls.Add(this.CHB_TieneFechaDeInicio);
            this.tab_Consulta.Controls.Add(this.CHB_EsVMAT);
            this.tab_Consulta.Controls.Add(this.CHB_10MV);
            this.tab_Consulta.Location = new System.Drawing.Point(4, 22);
            this.tab_Consulta.Name = "tab_Consulta";
            this.tab_Consulta.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Consulta.Size = new System.Drawing.Size(861, 392);
            this.tab_Consulta.TabIndex = 0;
            this.tab_Consulta.Text = "Consulta";
            this.tab_Consulta.UseVisualStyleBackColor = true;
            // 
            // TB_NumFracciones
            // 
            this.TB_NumFracciones.Location = new System.Drawing.Point(134, 130);
            this.TB_NumFracciones.Name = "TB_NumFracciones";
            this.TB_NumFracciones.Size = new System.Drawing.Size(100, 20);
            this.TB_NumFracciones.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de fracciones:";
            // 
            // TB_ParaQueEquipo
            // 
            this.TB_ParaQueEquipo.Location = new System.Drawing.Point(258, 182);
            this.TB_ParaQueEquipo.Multiline = true;
            this.TB_ParaQueEquipo.Name = "TB_ParaQueEquipo";
            this.TB_ParaQueEquipo.Size = new System.Drawing.Size(203, 71);
            this.TB_ParaQueEquipo.TabIndex = 7;
            // 
            // CHB_EsP1
            // 
            this.CHB_EsP1.AutoSize = true;
            this.CHB_EsP1.Location = new System.Drawing.Point(22, 12);
            this.CHB_EsP1.Name = "CHB_EsP1";
            this.CHB_EsP1.Size = new System.Drawing.Size(54, 17);
            this.CHB_EsP1.TabIndex = 6;
            this.CHB_EsP1.Text = "Es P1";
            this.CHB_EsP1.UseVisualStyleBackColor = true;
            // 
            // BT_ConsultaBuscarEquipo
            // 
            this.BT_ConsultaBuscarEquipo.Location = new System.Drawing.Point(258, 118);
            this.BT_ConsultaBuscarEquipo.Name = "BT_ConsultaBuscarEquipo";
            this.BT_ConsultaBuscarEquipo.Size = new System.Drawing.Size(121, 32);
            this.BT_ConsultaBuscarEquipo.TabIndex = 5;
            this.BT_ConsultaBuscarEquipo.Text = "¿Para qué equipo?";
            this.BT_ConsultaBuscarEquipo.UseVisualStyleBackColor = true;
            this.BT_ConsultaBuscarEquipo.Click += new System.EventHandler(this.BT_ConsultaBuscarEquipo_Click);
            // 
            // CHB_Electrones
            // 
            this.CHB_Electrones.AutoSize = true;
            this.CHB_Electrones.Location = new System.Drawing.Point(22, 58);
            this.CHB_Electrones.Name = "CHB_Electrones";
            this.CHB_Electrones.Size = new System.Drawing.Size(120, 17);
            this.CHB_Electrones.TabIndex = 4;
            this.CHB_Electrones.Text = "Necesito electrones";
            this.CHB_Electrones.UseVisualStyleBackColor = true;
            // 
            // DTP_FechaInicio
            // 
            this.DTP_FechaInicio.Enabled = false;
            this.DTP_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_FechaInicio.Location = new System.Drawing.Point(153, 104);
            this.DTP_FechaInicio.Name = "DTP_FechaInicio";
            this.DTP_FechaInicio.Size = new System.Drawing.Size(81, 20);
            this.DTP_FechaInicio.TabIndex = 3;
            // 
            // CHB_TieneFechaDeInicio
            // 
            this.CHB_TieneFechaDeInicio.AutoSize = true;
            this.CHB_TieneFechaDeInicio.Location = new System.Drawing.Point(22, 104);
            this.CHB_TieneFechaDeInicio.Name = "CHB_TieneFechaDeInicio";
            this.CHB_TieneFechaDeInicio.Size = new System.Drawing.Size(125, 17);
            this.CHB_TieneFechaDeInicio.TabIndex = 2;
            this.CHB_TieneFechaDeInicio.Text = "Tiene fecha de inicio";
            this.CHB_TieneFechaDeInicio.UseVisualStyleBackColor = true;
            this.CHB_TieneFechaDeInicio.CheckedChanged += new System.EventHandler(this.CHB_TieneFechaDeInicio_CheckedChanged);
            // 
            // CHB_EsVMAT
            // 
            this.CHB_EsVMAT.AutoSize = true;
            this.CHB_EsVMAT.Location = new System.Drawing.Point(22, 81);
            this.CHB_EsVMAT.Name = "CHB_EsVMAT";
            this.CHB_EsVMAT.Size = new System.Drawing.Size(71, 17);
            this.CHB_EsVMAT.TabIndex = 1;
            this.CHB_EsVMAT.Text = "Es VMAT";
            this.CHB_EsVMAT.UseVisualStyleBackColor = true;
            // 
            // CHB_10MV
            // 
            this.CHB_10MV.AutoSize = true;
            this.CHB_10MV.Location = new System.Drawing.Point(22, 35);
            this.CHB_10MV.Name = "CHB_10MV";
            this.CHB_10MV.Size = new System.Drawing.Size(99, 17);
            this.CHB_10MV.TabIndex = 0;
            this.CHB_10MV.Text = "Necesito 10MV";
            this.CHB_10MV.UseVisualStyleBackColor = true;
            // 
            // tab_EstadoEquipos
            // 
            this.tab_EstadoEquipos.Controls.Add(this.label1);
            this.tab_EstadoEquipos.Controls.Add(this.BT_GraficarTurnosLibres);
            this.tab_EstadoEquipos.Controls.Add(this.BT_EstadoEquiposActualizar);
            this.tab_EstadoEquipos.Controls.Add(this.L_EstadoEquipoUltimaBusqueda);
            this.tab_EstadoEquipos.Controls.Add(this.DGV_EstadoEquipos);
            this.tab_EstadoEquipos.Location = new System.Drawing.Point(4, 22);
            this.tab_EstadoEquipos.Name = "tab_EstadoEquipos";
            this.tab_EstadoEquipos.Padding = new System.Windows.Forms.Padding(3);
            this.tab_EstadoEquipos.Size = new System.Drawing.Size(861, 392);
            this.tab_EstadoEquipos.TabIndex = 1;
            this.tab_EstadoEquipos.Text = "EstadoEquipos";
            this.tab_EstadoEquipos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "(Haciendo click sobre el número se puede acceder a la lista de pacientes)";
            // 
            // BT_GraficarTurnosLibres
            // 
            this.BT_GraficarTurnosLibres.Location = new System.Drawing.Point(526, 210);
            this.BT_GraficarTurnosLibres.Name = "BT_GraficarTurnosLibres";
            this.BT_GraficarTurnosLibres.Size = new System.Drawing.Size(117, 23);
            this.BT_GraficarTurnosLibres.TabIndex = 3;
            this.BT_GraficarTurnosLibres.Text = "Graficar turnos libres";
            this.BT_GraficarTurnosLibres.UseVisualStyleBackColor = true;
            this.BT_GraficarTurnosLibres.Click += new System.EventHandler(this.BT_GraficarTurnosLibres_Click);
            // 
            // BT_EstadoEquiposActualizar
            // 
            this.BT_EstadoEquiposActualizar.Location = new System.Drawing.Point(340, 210);
            this.BT_EstadoEquiposActualizar.Name = "BT_EstadoEquiposActualizar";
            this.BT_EstadoEquiposActualizar.Size = new System.Drawing.Size(75, 23);
            this.BT_EstadoEquiposActualizar.TabIndex = 2;
            this.BT_EstadoEquiposActualizar.Text = "Actualizar";
            this.BT_EstadoEquiposActualizar.UseVisualStyleBackColor = true;
            this.BT_EstadoEquiposActualizar.Click += new System.EventHandler(this.BT_EstadoEquiposActualizar_Click);
            // 
            // L_EstadoEquipoUltimaBusqueda
            // 
            this.L_EstadoEquipoUltimaBusqueda.AutoSize = true;
            this.L_EstadoEquipoUltimaBusqueda.Location = new System.Drawing.Point(18, 220);
            this.L_EstadoEquipoUltimaBusqueda.Name = "L_EstadoEquipoUltimaBusqueda";
            this.L_EstadoEquipoUltimaBusqueda.Size = new System.Drawing.Size(92, 13);
            this.L_EstadoEquipoUltimaBusqueda.TabIndex = 1;
            this.L_EstadoEquipoUltimaBusqueda.Text = "Última búsqueda: ";
            // 
            // DGV_EstadoEquipos
            // 
            this.DGV_EstadoEquipos.AllowUserToAddRows = false;
            this.DGV_EstadoEquipos.AllowUserToDeleteRows = false;
            this.DGV_EstadoEquipos.AllowUserToResizeColumns = false;
            this.DGV_EstadoEquipos.AllowUserToResizeRows = false;
            this.DGV_EstadoEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_EstadoEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.DGV_EstadoEquipos.Location = new System.Drawing.Point(21, 19);
            this.DGV_EstadoEquipos.Name = "DGV_EstadoEquipos";
            this.DGV_EstadoEquipos.ReadOnly = true;
            this.DGV_EstadoEquipos.Size = new System.Drawing.Size(394, 150);
            this.DGV_EstadoEquipos.TabIndex = 0;
            this.DGV_EstadoEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_EstadoEquipos_CellContentClick);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Equipo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 70;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Planificando";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Con Ap Médica";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Con Ap Física";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 70;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "En Equipo";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 70;
            // 
            // tab_QA
            // 
            this.tab_QA.Controls.Add(this.BT_QA_ExportarLista);
            this.tab_QA.Controls.Add(this.LB_QA);
            this.tab_QA.Controls.Add(this.BT_QA_SacarDeLista);
            this.tab_QA.Controls.Add(this.BT_QAActualizarBusquedas);
            this.tab_QA.Controls.Add(this.L_QA_UltimaBusquedaPlacasPendientes);
            this.tab_QA.Controls.Add(this.DGV_QA_PlacasPendientes);
            this.tab_QA.Location = new System.Drawing.Point(4, 22);
            this.tab_QA.Name = "tab_QA";
            this.tab_QA.Padding = new System.Windows.Forms.Padding(3);
            this.tab_QA.Size = new System.Drawing.Size(861, 392);
            this.tab_QA.TabIndex = 2;
            this.tab_QA.Text = "QA";
            this.tab_QA.UseVisualStyleBackColor = true;
            // 
            // BT_QA_ExportarLista
            // 
            this.BT_QA_ExportarLista.Location = new System.Drawing.Point(184, 193);
            this.BT_QA_ExportarLista.Name = "BT_QA_ExportarLista";
            this.BT_QA_ExportarLista.Size = new System.Drawing.Size(120, 24);
            this.BT_QA_ExportarLista.TabIndex = 7;
            this.BT_QA_ExportarLista.Text = "Exportar lista";
            this.BT_QA_ExportarLista.UseVisualStyleBackColor = true;
            this.BT_QA_ExportarLista.Click += new System.EventHandler(this.BT_QA_ExportarLista_Click);
            // 
            // LB_QA
            // 
            this.LB_QA.FormattingEnabled = true;
            this.LB_QA.Location = new System.Drawing.Point(7, 12);
            this.LB_QA.Name = "LB_QA";
            this.LB_QA.Size = new System.Drawing.Size(171, 173);
            this.LB_QA.TabIndex = 6;
            this.LB_QA.SelectedIndexChanged += new System.EventHandler(this.LB_QA_SelectedIndexChanged);
            // 
            // BT_QA_SacarDeLista
            // 
            this.BT_QA_SacarDeLista.Location = new System.Drawing.Point(562, 192);
            this.BT_QA_SacarDeLista.Name = "BT_QA_SacarDeLista";
            this.BT_QA_SacarDeLista.Size = new System.Drawing.Size(120, 25);
            this.BT_QA_SacarDeLista.TabIndex = 5;
            this.BT_QA_SacarDeLista.Text = "Sacar de la lista";
            this.BT_QA_SacarDeLista.UseVisualStyleBackColor = true;
            this.BT_QA_SacarDeLista.Click += new System.EventHandler(this.BT_QA_SacarDeLista_Click);
            // 
            // BT_QAActualizarBusquedas
            // 
            this.BT_QAActualizarBusquedas.Location = new System.Drawing.Point(562, 232);
            this.BT_QAActualizarBusquedas.Name = "BT_QAActualizarBusquedas";
            this.BT_QAActualizarBusquedas.Size = new System.Drawing.Size(120, 24);
            this.BT_QAActualizarBusquedas.TabIndex = 4;
            this.BT_QAActualizarBusquedas.Text = "Actualizar Búsquedas";
            this.BT_QAActualizarBusquedas.UseVisualStyleBackColor = true;
            this.BT_QAActualizarBusquedas.Click += new System.EventHandler(this.BT_ActualizarBusquedas_Click);
            // 
            // L_QA_UltimaBusquedaPlacasPendientes
            // 
            this.L_QA_UltimaBusquedaPlacasPendientes.AutoSize = true;
            this.L_QA_UltimaBusquedaPlacasPendientes.Location = new System.Drawing.Point(181, 238);
            this.L_QA_UltimaBusquedaPlacasPendientes.Name = "L_QA_UltimaBusquedaPlacasPendientes";
            this.L_QA_UltimaBusquedaPlacasPendientes.Size = new System.Drawing.Size(92, 13);
            this.L_QA_UltimaBusquedaPlacasPendientes.TabIndex = 2;
            this.L_QA_UltimaBusquedaPlacasPendientes.Text = "Última búsqueda: ";
            // 
            // DGV_QA_PlacasPendientes
            // 
            this.DGV_QA_PlacasPendientes.AllowUserToAddRows = false;
            this.DGV_QA_PlacasPendientes.AllowUserToDeleteRows = false;
            this.DGV_QA_PlacasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_QA_PlacasPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.DGV_QA_PlacasPendientes.Location = new System.Drawing.Point(184, 12);
            this.DGV_QA_PlacasPendientes.Name = "DGV_QA_PlacasPendientes";
            this.DGV_QA_PlacasPendientes.RowHeadersVisible = false;
            this.DGV_QA_PlacasPendientes.Size = new System.Drawing.Size(560, 173);
            this.DGV_QA_PlacasPendientes.TabIndex = 1;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Width = 20;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "HC";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Equipo";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Plan";
            this.Column4.Name = "Column4";
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Última fx";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Última placa";
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // tab_Parametros
            // 
            this.tab_Parametros.Controls.Add(this.BT_Minar);
            this.tab_Parametros.Controls.Add(this.BT_ParametrosRecalcular);
            this.tab_Parametros.Controls.Add(this.L_ParametrosUltimoCalculo);
            this.tab_Parametros.Location = new System.Drawing.Point(4, 22);
            this.tab_Parametros.Name = "tab_Parametros";
            this.tab_Parametros.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Parametros.Size = new System.Drawing.Size(861, 392);
            this.tab_Parametros.TabIndex = 3;
            this.tab_Parametros.Text = "Parámetros";
            this.tab_Parametros.UseVisualStyleBackColor = true;
            // 
            // BT_Minar
            // 
            this.BT_Minar.Enabled = false;
            this.BT_Minar.Location = new System.Drawing.Point(558, 209);
            this.BT_Minar.Name = "BT_Minar";
            this.BT_Minar.Size = new System.Drawing.Size(75, 23);
            this.BT_Minar.TabIndex = 8;
            this.BT_Minar.Text = "Minar";
            this.BT_Minar.UseVisualStyleBackColor = true;
            this.BT_Minar.Click += new System.EventHandler(this.BT_Minar_Click);
            // 
            // BT_ParametrosRecalcular
            // 
            this.BT_ParametrosRecalcular.Location = new System.Drawing.Point(277, 214);
            this.BT_ParametrosRecalcular.Name = "BT_ParametrosRecalcular";
            this.BT_ParametrosRecalcular.Size = new System.Drawing.Size(75, 23);
            this.BT_ParametrosRecalcular.TabIndex = 7;
            this.BT_ParametrosRecalcular.Text = "Recalcular";
            this.BT_ParametrosRecalcular.UseVisualStyleBackColor = true;
            this.BT_ParametrosRecalcular.Visible = false;
            this.BT_ParametrosRecalcular.Click += new System.EventHandler(this.BT_ParametrosRecalcular_Click);
            // 
            // L_ParametrosUltimoCalculo
            // 
            this.L_ParametrosUltimoCalculo.AutoSize = true;
            this.L_ParametrosUltimoCalculo.Location = new System.Drawing.Point(24, 214);
            this.L_ParametrosUltimoCalculo.Name = "L_ParametrosUltimoCalculo";
            this.L_ParametrosUltimoCalculo.Size = new System.Drawing.Size(74, 13);
            this.L_ParametrosUltimoCalculo.TabIndex = 6;
            this.L_ParametrosUltimoCalculo.Text = "Último Cálculo";
            // 
            // tab_ExacTrac
            // 
            this.tab_ExacTrac.Controls.Add(this.BT_EliminarExacTrac);
            this.tab_ExacTrac.Controls.Add(this.LB_ExacTrac);
            this.tab_ExacTrac.Controls.Add(this.BT_BuscarExacTrac);
            this.tab_ExacTrac.Controls.Add(this.DGV_ExacTrac);
            this.tab_ExacTrac.Location = new System.Drawing.Point(4, 22);
            this.tab_ExacTrac.Name = "tab_ExacTrac";
            this.tab_ExacTrac.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ExacTrac.Size = new System.Drawing.Size(861, 392);
            this.tab_ExacTrac.TabIndex = 4;
            this.tab_ExacTrac.Text = "ExacTrac";
            this.tab_ExacTrac.UseVisualStyleBackColor = true;
            // 
            // BT_EliminarExacTrac
            // 
            this.BT_EliminarExacTrac.Enabled = false;
            this.BT_EliminarExacTrac.Location = new System.Drawing.Point(51, 219);
            this.BT_EliminarExacTrac.Name = "BT_EliminarExacTrac";
            this.BT_EliminarExacTrac.Size = new System.Drawing.Size(75, 23);
            this.BT_EliminarExacTrac.TabIndex = 3;
            this.BT_EliminarExacTrac.Text = "Eliminar";
            this.BT_EliminarExacTrac.UseVisualStyleBackColor = true;
            // 
            // LB_ExacTrac
            // 
            this.LB_ExacTrac.FormattingEnabled = true;
            this.LB_ExacTrac.Location = new System.Drawing.Point(6, 18);
            this.LB_ExacTrac.Name = "LB_ExacTrac";
            this.LB_ExacTrac.Size = new System.Drawing.Size(120, 95);
            this.LB_ExacTrac.TabIndex = 2;
            this.LB_ExacTrac.SelectedIndexChanged += new System.EventHandler(this.LB_ExacTrac_SelectedIndexChanged);
            // 
            // BT_BuscarExacTrac
            // 
            this.BT_BuscarExacTrac.Location = new System.Drawing.Point(51, 154);
            this.BT_BuscarExacTrac.Name = "BT_BuscarExacTrac";
            this.BT_BuscarExacTrac.Size = new System.Drawing.Size(75, 23);
            this.BT_BuscarExacTrac.TabIndex = 1;
            this.BT_BuscarExacTrac.Text = "Buscar";
            this.BT_BuscarExacTrac.UseVisualStyleBackColor = true;
            this.BT_BuscarExacTrac.Click += new System.EventHandler(this.BT_BuscarExacTrac_Click);
            // 
            // DGV_ExacTrac
            // 
            this.DGV_ExacTrac.AllowUserToAddRows = false;
            this.DGV_ExacTrac.AllowUserToDeleteRows = false;
            this.DGV_ExacTrac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ExacTrac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccion,
            this.HC,
            this.Nombre,
            this.Plan,
            this.HayCT,
            this.HayEstructuras});
            this.DGV_ExacTrac.Location = new System.Drawing.Point(148, 18);
            this.DGV_ExacTrac.Name = "DGV_ExacTrac";
            this.DGV_ExacTrac.RowHeadersVisible = false;
            this.DGV_ExacTrac.Size = new System.Drawing.Size(499, 224);
            this.DGV_ExacTrac.TabIndex = 0;
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Width = 30;
            // 
            // HC
            // 
            this.HC.HeaderText = "HC";
            this.HC.Name = "HC";
            this.HC.Width = 70;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 150;
            // 
            // Plan
            // 
            this.Plan.HeaderText = "Plan";
            this.Plan.Name = "Plan";
            this.Plan.Width = 80;
            // 
            // HayCT
            // 
            this.HayCT.HeaderText = "Hay CT";
            this.HayCT.Name = "HayCT";
            this.HayCT.Width = 70;
            // 
            // HayEstructuras
            // 
            this.HayEstructuras.HeaderText = "Hay estructuras";
            this.HayEstructuras.Name = "HayEstructuras";
            this.HayEstructuras.Width = 70;
            // 
            // tab_Buscador
            // 
            this.tab_Buscador.Controls.Add(this.groupBox6);
            this.tab_Buscador.Controls.Add(this.BT_BuscadorExportarPDF);
            this.tab_Buscador.Controls.Add(this.groupBox5);
            this.tab_Buscador.Controls.Add(this.L_BuscadorResultados);
            this.tab_Buscador.Controls.Add(this.DGV_Buscador);
            this.tab_Buscador.Controls.Add(this.BT_BuscadorExportar);
            this.tab_Buscador.Controls.Add(this.BT_BuscadorBuscar);
            this.tab_Buscador.Controls.Add(this.groupBox4);
            this.tab_Buscador.Controls.Add(this.groupBox3);
            this.tab_Buscador.Controls.Add(this.groupBox2);
            this.tab_Buscador.Controls.Add(this.groupBox1);
            this.tab_Buscador.Location = new System.Drawing.Point(4, 22);
            this.tab_Buscador.Name = "tab_Buscador";
            this.tab_Buscador.Size = new System.Drawing.Size(861, 392);
            this.tab_Buscador.TabIndex = 5;
            this.tab_Buscador.Text = "Buscador de planes";
            this.tab_Buscador.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.TB_BuscadorEstructuras);
            this.groupBox6.Location = new System.Drawing.Point(296, 90);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(321, 49);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Estructuras";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Contiene";
            // 
            // TB_BuscadorEstructuras
            // 
            this.TB_BuscadorEstructuras.Location = new System.Drawing.Point(68, 19);
            this.TB_BuscadorEstructuras.Name = "TB_BuscadorEstructuras";
            this.TB_BuscadorEstructuras.Size = new System.Drawing.Size(66, 20);
            this.TB_BuscadorEstructuras.TabIndex = 12;
            // 
            // BT_BuscadorExportarPDF
            // 
            this.BT_BuscadorExportarPDF.Location = new System.Drawing.Point(12, 266);
            this.BT_BuscadorExportarPDF.Name = "BT_BuscadorExportarPDF";
            this.BT_BuscadorExportarPDF.Size = new System.Drawing.Size(117, 23);
            this.BT_BuscadorExportarPDF.TabIndex = 9;
            this.BT_BuscadorExportarPDF.Text = "Exportar como pdf";
            this.BT_BuscadorExportarPDF.UseVisualStyleBackColor = true;
            this.BT_BuscadorExportarPDF.Click += new System.EventHandler(this.BT_BuscadorExportarPDF_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CHB_BuscarEstaEnTratamiento);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.CB_BuscadorEstadoAprobacion);
            this.groupBox5.Location = new System.Drawing.Point(623, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(159, 72);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // CHB_BuscarEstaEnTratamiento
            // 
            this.CHB_BuscarEstaEnTratamiento.AutoSize = true;
            this.CHB_BuscarEstaEnTratamiento.Location = new System.Drawing.Point(9, 44);
            this.CHB_BuscarEstaEnTratamiento.Name = "CHB_BuscarEstaEnTratamiento";
            this.CHB_BuscarEstaEnTratamiento.Size = new System.Drawing.Size(117, 17);
            this.CHB_BuscarEstaEnTratamiento.TabIndex = 6;
            this.CHB_BuscarEstaEnTratamiento.Text = "Está en tratamiento";
            this.CHB_BuscarEstaEnTratamiento.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Aprobación";
            // 
            // CB_BuscadorEstadoAprobacion
            // 
            this.CB_BuscadorEstadoAprobacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BuscadorEstadoAprobacion.FormattingEnabled = true;
            this.CB_BuscadorEstadoAprobacion.Items.AddRange(new object[] {
            "",
            "Unapproved",
            "PlanApproval",
            "TreatApproval"});
            this.CB_BuscadorEstadoAprobacion.Location = new System.Drawing.Point(77, 17);
            this.CB_BuscadorEstadoAprobacion.Name = "CB_BuscadorEstadoAprobacion";
            this.CB_BuscadorEstadoAprobacion.Size = new System.Drawing.Size(76, 21);
            this.CB_BuscadorEstadoAprobacion.TabIndex = 3;
            // 
            // L_BuscadorResultados
            // 
            this.L_BuscadorResultados.AutoSize = true;
            this.L_BuscadorResultados.Location = new System.Drawing.Point(171, 147);
            this.L_BuscadorResultados.Name = "L_BuscadorResultados";
            this.L_BuscadorResultados.Size = new System.Drawing.Size(60, 13);
            this.L_BuscadorResultados.TabIndex = 8;
            this.L_BuscadorResultados.Text = "Resultados";
            this.L_BuscadorResultados.Visible = false;
            // 
            // DGV_Buscador
            // 
            this.DGV_Buscador.AllowUserToAddRows = false;
            this.DGV_Buscador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Buscador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuscadorHC,
            this.BuscadorApellido,
            this.BuscadorNombre,
            this.BuscadorCurso,
            this.BuscadorPlan});
            this.DGV_Buscador.Location = new System.Drawing.Point(173, 166);
            this.DGV_Buscador.Name = "DGV_Buscador";
            this.DGV_Buscador.RowHeadersVisible = false;
            this.DGV_Buscador.Size = new System.Drawing.Size(524, 155);
            this.DGV_Buscador.TabIndex = 7;
            // 
            // BuscadorHC
            // 
            this.BuscadorHC.HeaderText = "HC";
            this.BuscadorHC.Name = "BuscadorHC";
            // 
            // BuscadorApellido
            // 
            this.BuscadorApellido.HeaderText = "Apellido";
            this.BuscadorApellido.Name = "BuscadorApellido";
            // 
            // BuscadorNombre
            // 
            this.BuscadorNombre.HeaderText = "Nombre";
            this.BuscadorNombre.Name = "BuscadorNombre";
            // 
            // BuscadorCurso
            // 
            this.BuscadorCurso.HeaderText = "Curso";
            this.BuscadorCurso.Name = "BuscadorCurso";
            // 
            // BuscadorPlan
            // 
            this.BuscadorPlan.HeaderText = "Plan";
            this.BuscadorPlan.Name = "BuscadorPlan";
            // 
            // BT_BuscadorExportar
            // 
            this.BT_BuscadorExportar.Location = new System.Drawing.Point(12, 237);
            this.BT_BuscadorExportar.Name = "BT_BuscadorExportar";
            this.BT_BuscadorExportar.Size = new System.Drawing.Size(117, 23);
            this.BT_BuscadorExportar.TabIndex = 6;
            this.BT_BuscadorExportar.Text = "Exportar como txt";
            this.BT_BuscadorExportar.UseVisualStyleBackColor = true;
            this.BT_BuscadorExportar.Click += new System.EventHandler(this.BT_BuscadorExportar_Click);
            // 
            // BT_BuscadorBuscar
            // 
            this.BT_BuscadorBuscar.Location = new System.Drawing.Point(12, 166);
            this.BT_BuscadorBuscar.Name = "BT_BuscadorBuscar";
            this.BT_BuscadorBuscar.Size = new System.Drawing.Size(117, 23);
            this.BT_BuscadorBuscar.TabIndex = 5;
            this.BT_BuscadorBuscar.Text = "Buscar";
            this.BT_BuscadorBuscar.UseVisualStyleBackColor = true;
            this.BT_BuscadorBuscar.Click += new System.EventHandler(this.BT_BuscadorBuscar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CB_BuscadorModalidad);
            this.groupBox4.Controls.Add(this.CB_BuscadorEquipo);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(468, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(149, 72);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Campos";
            // 
            // CB_BuscadorModalidad
            // 
            this.CB_BuscadorModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BuscadorModalidad.FormattingEnabled = true;
            this.CB_BuscadorModalidad.Items.AddRange(new object[] {
            "",
            "10MV",
            "SRS",
            "Electrones",
            "VMAT",
            "3DC",
            "IMRT"});
            this.CB_BuscadorModalidad.Location = new System.Drawing.Point(66, 42);
            this.CB_BuscadorModalidad.Name = "CB_BuscadorModalidad";
            this.CB_BuscadorModalidad.Size = new System.Drawing.Size(69, 21);
            this.CB_BuscadorModalidad.TabIndex = 4;
            // 
            // CB_BuscadorEquipo
            // 
            this.CB_BuscadorEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BuscadorEquipo.FormattingEnabled = true;
            this.CB_BuscadorEquipo.Items.AddRange(new object[] {
            "",
            "Equipo 1",
            "Equipo 2",
            "Equipo 3",
            "Equipo 4",
            "Cetro",
            "Medrano"});
            this.CB_BuscadorEquipo.Location = new System.Drawing.Point(66, 16);
            this.CB_BuscadorEquipo.Name = "CB_BuscadorEquipo";
            this.CB_BuscadorEquipo.Size = new System.Drawing.Size(69, 21);
            this.CB_BuscadorEquipo.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Modalidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Equipo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CHB_BuscadorHasta);
            this.groupBox3.Controls.Add(this.CHB_BuscadorDesde);
            this.groupBox3.Controls.Add(this.DTP_BuscadorHasta);
            this.groupBox3.Controls.Add(this.DTP_BuscadorDesde);
            this.groupBox3.Location = new System.Drawing.Point(296, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 72);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fecha Creación";
            // 
            // CHB_BuscadorHasta
            // 
            this.CHB_BuscadorHasta.AutoSize = true;
            this.CHB_BuscadorHasta.Location = new System.Drawing.Point(7, 44);
            this.CHB_BuscadorHasta.Name = "CHB_BuscadorHasta";
            this.CHB_BuscadorHasta.Size = new System.Drawing.Size(54, 17);
            this.CHB_BuscadorHasta.TabIndex = 6;
            this.CHB_BuscadorHasta.Text = "Hasta";
            this.CHB_BuscadorHasta.UseVisualStyleBackColor = true;
            this.CHB_BuscadorHasta.CheckedChanged += new System.EventHandler(this.CHB_BuscadorHasta_CheckedChanged);
            // 
            // CHB_BuscadorDesde
            // 
            this.CHB_BuscadorDesde.AutoSize = true;
            this.CHB_BuscadorDesde.Location = new System.Drawing.Point(7, 18);
            this.CHB_BuscadorDesde.Name = "CHB_BuscadorDesde";
            this.CHB_BuscadorDesde.Size = new System.Drawing.Size(57, 17);
            this.CHB_BuscadorDesde.TabIndex = 5;
            this.CHB_BuscadorDesde.Text = "Desde";
            this.CHB_BuscadorDesde.UseVisualStyleBackColor = true;
            this.CHB_BuscadorDesde.CheckedChanged += new System.EventHandler(this.CHB_BuscadorDesde_CheckedChanged);
            // 
            // DTP_BuscadorHasta
            // 
            this.DTP_BuscadorHasta.Enabled = false;
            this.DTP_BuscadorHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_BuscadorHasta.Location = new System.Drawing.Point(68, 41);
            this.DTP_BuscadorHasta.Name = "DTP_BuscadorHasta";
            this.DTP_BuscadorHasta.Size = new System.Drawing.Size(88, 20);
            this.DTP_BuscadorHasta.TabIndex = 4;
            // 
            // DTP_BuscadorDesde
            // 
            this.DTP_BuscadorDesde.Enabled = false;
            this.DTP_BuscadorDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_BuscadorDesde.Location = new System.Drawing.Point(68, 16);
            this.DTP_BuscadorDesde.Name = "DTP_BuscadorDesde";
            this.DTP_BuscadorDesde.Size = new System.Drawing.Size(88, 20);
            this.DTP_BuscadorDesde.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.L_BuscadorNumFx);
            this.groupBox2.Controls.Add(this.TB_BuscadorNumFx);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TB_BuscadorDosisDia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TB_BuscadorPlan);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TB_BuscadorCurso);
            this.groupBox2.Location = new System.Drawing.Point(159, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 127);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plan";
            // 
            // L_BuscadorNumFx
            // 
            this.L_BuscadorNumFx.AutoSize = true;
            this.L_BuscadorNumFx.Location = new System.Drawing.Point(12, 95);
            this.L_BuscadorNumFx.Name = "L_BuscadorNumFx";
            this.L_BuscadorNumFx.Size = new System.Drawing.Size(30, 13);
            this.L_BuscadorNumFx.TabIndex = 6;
            this.L_BuscadorNumFx.Text = "Nº fx";
            // 
            // TB_BuscadorNumFx
            // 
            this.TB_BuscadorNumFx.Location = new System.Drawing.Point(56, 92);
            this.TB_BuscadorNumFx.Name = "TB_BuscadorNumFx";
            this.TB_BuscadorNumFx.Size = new System.Drawing.Size(66, 20);
            this.TB_BuscadorNumFx.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "D.Dia[Gy]";
            // 
            // TB_BuscadorDosisDia
            // 
            this.TB_BuscadorDosisDia.Location = new System.Drawing.Point(69, 66);
            this.TB_BuscadorDosisDia.Name = "TB_BuscadorDosisDia";
            this.TB_BuscadorDosisDia.Size = new System.Drawing.Size(53, 20);
            this.TB_BuscadorDosisDia.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Plan";
            // 
            // TB_BuscadorPlan
            // 
            this.TB_BuscadorPlan.Location = new System.Drawing.Point(56, 40);
            this.TB_BuscadorPlan.Name = "TB_BuscadorPlan";
            this.TB_BuscadorPlan.Size = new System.Drawing.Size(66, 20);
            this.TB_BuscadorPlan.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Curso";
            // 
            // TB_BuscadorCurso
            // 
            this.TB_BuscadorCurso.Location = new System.Drawing.Point(56, 16);
            this.TB_BuscadorCurso.Name = "TB_BuscadorCurso";
            this.TB_BuscadorCurso.Size = new System.Drawing.Size(66, 20);
            this.TB_BuscadorCurso.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_BuscadorApellido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_BuscadorHC);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paciente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Apellido";
            // 
            // TB_BuscadorApellido
            // 
            this.TB_BuscadorApellido.Location = new System.Drawing.Point(56, 42);
            this.TB_BuscadorApellido.Name = "TB_BuscadorApellido";
            this.TB_BuscadorApellido.Size = new System.Drawing.Size(80, 20);
            this.TB_BuscadorApellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "HC";
            // 
            // TB_BuscadorHC
            // 
            this.TB_BuscadorHC.Location = new System.Drawing.Point(56, 16);
            this.TB_BuscadorHC.Name = "TB_BuscadorHC";
            this.TB_BuscadorHC.Size = new System.Drawing.Size(80, 20);
            this.TB_BuscadorHC.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BT_EliminarDeLaLista);
            this.tabPage1.Controls.Add(this.L_QAPEActualizacion);
            this.tabPage1.Controls.Add(this.BT_QAAgregar);
            this.tabPage1.Controls.Add(this.BT_QAGuardarCambios);
            this.tabPage1.Controls.Add(this.BT_ActualizarQAPE);
            this.tabPage1.Controls.Add(this.DGV_QAPE);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(861, 392);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "QA Paciente Específico";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BT_EliminarDeLaLista
            // 
            this.BT_EliminarDeLaLista.Location = new System.Drawing.Point(425, 347);
            this.BT_EliminarDeLaLista.Name = "BT_EliminarDeLaLista";
            this.BT_EliminarDeLaLista.Size = new System.Drawing.Size(105, 23);
            this.BT_EliminarDeLaLista.TabIndex = 6;
            this.BT_EliminarDeLaLista.Text = "Eliminar de la lista";
            this.BT_EliminarDeLaLista.UseVisualStyleBackColor = true;
            this.BT_EliminarDeLaLista.Click += new System.EventHandler(this.BT_EliminarDeLaLista_Click);
            // 
            // L_QAPEActualizacion
            // 
            this.L_QAPEActualizacion.AutoSize = true;
            this.L_QAPEActualizacion.Location = new System.Drawing.Point(11, 357);
            this.L_QAPEActualizacion.Name = "L_QAPEActualizacion";
            this.L_QAPEActualizacion.Size = new System.Drawing.Size(108, 13);
            this.L_QAPEActualizacion.TabIndex = 5;
            this.L_QAPEActualizacion.Text = "Ultima Actualización: ";
            // 
            // BT_QAAgregar
            // 
            this.BT_QAAgregar.Location = new System.Drawing.Point(547, 348);
            this.BT_QAAgregar.Name = "BT_QAAgregar";
            this.BT_QAAgregar.Size = new System.Drawing.Size(75, 23);
            this.BT_QAAgregar.TabIndex = 4;
            this.BT_QAAgregar.Text = "Agregar";
            this.BT_QAAgregar.UseVisualStyleBackColor = true;
            this.BT_QAAgregar.Click += new System.EventHandler(this.BT_QAAgregar_Click);
            // 
            // BT_QAGuardarCambios
            // 
            this.BT_QAGuardarCambios.Location = new System.Drawing.Point(644, 348);
            this.BT_QAGuardarCambios.Name = "BT_QAGuardarCambios";
            this.BT_QAGuardarCambios.Size = new System.Drawing.Size(101, 23);
            this.BT_QAGuardarCambios.TabIndex = 3;
            this.BT_QAGuardarCambios.Text = "Guardar cambios";
            this.BT_QAGuardarCambios.UseVisualStyleBackColor = true;
            this.BT_QAGuardarCambios.Click += new System.EventHandler(this.BT_QAGuardarCambios_Click);
            // 
            // BT_ActualizarQAPE
            // 
            this.BT_ActualizarQAPE.Location = new System.Drawing.Point(766, 348);
            this.BT_ActualizarQAPE.Name = "BT_ActualizarQAPE";
            this.BT_ActualizarQAPE.Size = new System.Drawing.Size(75, 23);
            this.BT_ActualizarQAPE.TabIndex = 2;
            this.BT_ActualizarQAPE.Text = "Actualizar";
            this.BT_ActualizarQAPE.UseVisualStyleBackColor = true;
            this.BT_ActualizarQAPE.Click += new System.EventHandler(this.BT_ActualizarQAPE_Click);
            // 
            // DGV_QAPE
            // 
            this.DGV_QAPE.AllowUserToAddRows = false;
            this.DGV_QAPE.AllowUserToDeleteRows = false;
            this.DGV_QAPE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_QAPE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.EquipoQA,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.QA_OK,
            this.NotaQA});
            this.DGV_QAPE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.DGV_QAPE.Location = new System.Drawing.Point(11, 10);
            this.DGV_QAPE.Name = "DGV_QAPE";
            this.DGV_QAPE.RowHeadersVisible = false;
            this.DGV_QAPE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_QAPE.Size = new System.Drawing.Size(830, 332);
            this.DGV_QAPE.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "HC";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Paciente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Plan";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // EquipoQA
            // 
            this.EquipoQA.HeaderText = "Equipo";
            this.EquipoQA.Name = "EquipoQA";
            this.EquipoQA.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "QA creado";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "QA medido";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // QA_OK
            // 
            this.QA_OK.HeaderText = "QA OK";
            this.QA_OK.Name = "QA_OK";
            // 
            // NotaQA
            // 
            this.NotaQA.HeaderText = "Nota";
            this.NotaQA.MinimumWidth = 170;
            this.NotaQA.Name = "NotaQA";
            this.NotaQA.Width = 170;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BT_TBIGuardarCambios);
            this.tabPage2.Controls.Add(this.BT_TBIActualizarBusqueda);
            this.tabPage2.Controls.Add(this.BT_PacTBIEliminarPaciente);
            this.tabPage2.Controls.Add(this.BT_TBIEditaPaciente);
            this.tabPage2.Controls.Add(this.BT_NuevoTBI);
            this.tabPage2.Controls.Add(this.DGV_PacientesTBI);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(861, 392);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "TBI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BT_TBIGuardarCambios
            // 
            this.BT_TBIGuardarCambios.Location = new System.Drawing.Point(738, 355);
            this.BT_TBIGuardarCambios.Name = "BT_TBIGuardarCambios";
            this.BT_TBIGuardarCambios.Size = new System.Drawing.Size(98, 23);
            this.BT_TBIGuardarCambios.TabIndex = 7;
            this.BT_TBIGuardarCambios.Text = "Guardar cambios";
            this.BT_TBIGuardarCambios.UseVisualStyleBackColor = true;
            this.BT_TBIGuardarCambios.Click += new System.EventHandler(this.BT_TBIGuardarCambios_Click);
            // 
            // BT_TBIActualizarBusqueda
            // 
            this.BT_TBIActualizarBusqueda.Location = new System.Drawing.Point(611, 355);
            this.BT_TBIActualizarBusqueda.Name = "BT_TBIActualizarBusqueda";
            this.BT_TBIActualizarBusqueda.Size = new System.Drawing.Size(98, 23);
            this.BT_TBIActualizarBusqueda.TabIndex = 6;
            this.BT_TBIActualizarBusqueda.Text = "Actualizar";
            this.BT_TBIActualizarBusqueda.UseVisualStyleBackColor = true;
            this.BT_TBIActualizarBusqueda.Click += new System.EventHandler(this.BT_TBIActualizarBusqueda_Click);
            // 
            // BT_PacTBIEliminarPaciente
            // 
            this.BT_PacTBIEliminarPaciente.Location = new System.Drawing.Point(238, 355);
            this.BT_PacTBIEliminarPaciente.Name = "BT_PacTBIEliminarPaciente";
            this.BT_PacTBIEliminarPaciente.Size = new System.Drawing.Size(98, 23);
            this.BT_PacTBIEliminarPaciente.TabIndex = 5;
            this.BT_PacTBIEliminarPaciente.Text = "Eliminar paciente";
            this.BT_PacTBIEliminarPaciente.UseVisualStyleBackColor = true;
            this.BT_PacTBIEliminarPaciente.Click += new System.EventHandler(this.BT_PacTBIEliminarPaciente_Click);
            // 
            // BT_TBIEditaPaciente
            // 
            this.BT_TBIEditaPaciente.Location = new System.Drawing.Point(124, 355);
            this.BT_TBIEditaPaciente.Name = "BT_TBIEditaPaciente";
            this.BT_TBIEditaPaciente.Size = new System.Drawing.Size(98, 23);
            this.BT_TBIEditaPaciente.TabIndex = 4;
            this.BT_TBIEditaPaciente.Text = "Editar paciente";
            this.BT_TBIEditaPaciente.UseVisualStyleBackColor = true;
            this.BT_TBIEditaPaciente.Click += new System.EventHandler(this.BT_TBIEditaPaciente_Click);
            // 
            // BT_NuevoTBI
            // 
            this.BT_NuevoTBI.Location = new System.Drawing.Point(7, 355);
            this.BT_NuevoTBI.Name = "BT_NuevoTBI";
            this.BT_NuevoTBI.Size = new System.Drawing.Size(98, 23);
            this.BT_NuevoTBI.TabIndex = 3;
            this.BT_NuevoTBI.Text = "Nuevo paciente";
            this.BT_NuevoTBI.UseVisualStyleBackColor = true;
            this.BT_NuevoTBI.Click += new System.EventHandler(this.BT_NuevoTBI_Click);
            // 
            // DGV_PacientesTBI
            // 
            this.DGV_PacientesTBI.AllowUserToAddRows = false;
            this.DGV_PacientesTBI.AllowUserToDeleteRows = false;
            this.DGV_PacientesTBI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_PacientesTBI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.Inicio,
            this.Fx,
            this.LlevaPbs,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3,
            this.Treatment,
            this.PbsListos,
            this.DicomEnEq});
            this.DGV_PacientesTBI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.DGV_PacientesTBI.Location = new System.Drawing.Point(6, 6);
            this.DGV_PacientesTBI.Name = "DGV_PacientesTBI";
            this.DGV_PacientesTBI.RowHeadersVisible = false;
            this.DGV_PacientesTBI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_PacientesTBI.Size = new System.Drawing.Size(830, 332);
            this.DGV_PacientesTBI.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "HC";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Paciente";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 180;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Equipo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // Inicio
            // 
            this.Inicio.HeaderText = "Inicio";
            this.Inicio.Name = "Inicio";
            this.Inicio.Width = 60;
            // 
            // Fx
            // 
            this.Fx.HeaderText = "Fx";
            this.Fx.Name = "Fx";
            this.Fx.Width = 40;
            // 
            // LlevaPbs
            // 
            this.LlevaPbs.HeaderText = "Lleva Pbs";
            this.LlevaPbs.Name = "LlevaPbs";
            this.LlevaPbs.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LlevaPbs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LlevaPbs.Width = 50;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "TAC";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Planes";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 50;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Aprobación";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Width = 70;
            // 
            // Treatment
            // 
            this.Treatment.HeaderText = "Treatment";
            this.Treatment.Name = "Treatment";
            this.Treatment.ReadOnly = true;
            this.Treatment.Width = 70;
            // 
            // PbsListos
            // 
            this.PbsListos.HeaderText = "Pbs listos";
            this.PbsListos.Name = "PbsListos";
            this.PbsListos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PbsListos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PbsListos.Width = 50;
            // 
            // DicomEnEq
            // 
            this.DicomEnEq.HeaderText = "DicomEnEq";
            this.DicomEnEq.Name = "DicomEnEq";
            this.DicomEnEq.Width = 70;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BT_PedidoActualizarEstado);
            this.tabPage4.Controls.Add(this.BT_EliminarPedido);
            this.tabPage4.Controls.Add(this.BT_CompletarPedido);
            this.tabPage4.Controls.Add(this.BT_EditarPedido);
            this.tabPage4.Controls.Add(this.BT_NuevoPedido);
            this.tabPage4.Controls.Add(this.DGV_Pedidos);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(861, 392);
            this.tabPage4.TabIndex = 9;
            this.tabPage4.Text = "Pedidos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BT_PedidoActualizarEstado
            // 
            this.BT_PedidoActualizarEstado.Location = new System.Drawing.Point(628, 359);
            this.BT_PedidoActualizarEstado.Name = "BT_PedidoActualizarEstado";
            this.BT_PedidoActualizarEstado.Size = new System.Drawing.Size(98, 23);
            this.BT_PedidoActualizarEstado.TabIndex = 10;
            this.BT_PedidoActualizarEstado.Text = "Actualizar estado";
            this.BT_PedidoActualizarEstado.UseVisualStyleBackColor = true;
            this.BT_PedidoActualizarEstado.Click += new System.EventHandler(this.BT_PedidoActualizarEstado_Click);
            // 
            // BT_EliminarPedido
            // 
            this.BT_EliminarPedido.Location = new System.Drawing.Point(252, 359);
            this.BT_EliminarPedido.Name = "BT_EliminarPedido";
            this.BT_EliminarPedido.Size = new System.Drawing.Size(98, 23);
            this.BT_EliminarPedido.TabIndex = 9;
            this.BT_EliminarPedido.Text = "Eliminar";
            this.BT_EliminarPedido.UseVisualStyleBackColor = true;
            this.BT_EliminarPedido.Click += new System.EventHandler(this.BT_EliminarPedido_Click);
            // 
            // BT_CompletarPedido
            // 
            this.BT_CompletarPedido.Location = new System.Drawing.Point(747, 359);
            this.BT_CompletarPedido.Name = "BT_CompletarPedido";
            this.BT_CompletarPedido.Size = new System.Drawing.Size(98, 23);
            this.BT_CompletarPedido.TabIndex = 8;
            this.BT_CompletarPedido.Text = "Completar";
            this.BT_CompletarPedido.UseVisualStyleBackColor = true;
            this.BT_CompletarPedido.Click += new System.EventHandler(this.BT_CompletarPedido_Click);
            // 
            // BT_EditarPedido
            // 
            this.BT_EditarPedido.Location = new System.Drawing.Point(133, 359);
            this.BT_EditarPedido.Name = "BT_EditarPedido";
            this.BT_EditarPedido.Size = new System.Drawing.Size(98, 23);
            this.BT_EditarPedido.TabIndex = 7;
            this.BT_EditarPedido.Text = "Editar";
            this.BT_EditarPedido.UseVisualStyleBackColor = true;
            this.BT_EditarPedido.Click += new System.EventHandler(this.BT_EditarPedido_Click);
            // 
            // BT_NuevoPedido
            // 
            this.BT_NuevoPedido.Location = new System.Drawing.Point(16, 359);
            this.BT_NuevoPedido.Name = "BT_NuevoPedido";
            this.BT_NuevoPedido.Size = new System.Drawing.Size(98, 23);
            this.BT_NuevoPedido.TabIndex = 6;
            this.BT_NuevoPedido.Text = "Nuevo";
            this.BT_NuevoPedido.UseVisualStyleBackColor = true;
            this.BT_NuevoPedido.Click += new System.EventHandler(this.BT_NuevoPedido_Click);
            // 
            // DGV_Pedidos
            // 
            this.DGV_Pedidos.AllowUserToAddRows = false;
            this.DGV_Pedidos.AllowUserToDeleteRows = false;
            this.DGV_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Pedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPaciente,
            this.ColTecnica,
            this.ColTarea,
            this.ColEquipo,
            this.ColFechaLimite,
            this.ColMedico,
            this.ColMotivo,
            this.ColSolicita,
            this.ColFisResponsable,
            this.ColComentario});
            this.DGV_Pedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.DGV_Pedidos.Location = new System.Drawing.Point(15, 10);
            this.DGV_Pedidos.Name = "DGV_Pedidos";
            this.DGV_Pedidos.RowHeadersVisible = false;
            this.DGV_Pedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Pedidos.Size = new System.Drawing.Size(830, 332);
            this.DGV_Pedidos.TabIndex = 5;
            // 
            // ColPaciente
            // 
            this.ColPaciente.HeaderText = "Paciente";
            this.ColPaciente.Name = "ColPaciente";
            this.ColPaciente.ReadOnly = true;
            // 
            // ColTecnica
            // 
            this.ColTecnica.HeaderText = "Técnica";
            this.ColTecnica.Name = "ColTecnica";
            this.ColTecnica.ReadOnly = true;
            // 
            // ColTarea
            // 
            this.ColTarea.HeaderText = "Tarea";
            this.ColTarea.Name = "ColTarea";
            this.ColTarea.ReadOnly = true;
            // 
            // ColEquipo
            // 
            this.ColEquipo.HeaderText = "Equipo";
            this.ColEquipo.Name = "ColEquipo";
            this.ColEquipo.ReadOnly = true;
            // 
            // ColFechaLimite
            // 
            this.ColFechaLimite.HeaderText = "Fecha Limite";
            this.ColFechaLimite.Name = "ColFechaLimite";
            this.ColFechaLimite.ReadOnly = true;
            // 
            // ColMedico
            // 
            this.ColMedico.HeaderText = "Médico";
            this.ColMedico.Name = "ColMedico";
            this.ColMedico.ReadOnly = true;
            // 
            // ColMotivo
            // 
            this.ColMotivo.HeaderText = "Motivo";
            this.ColMotivo.Name = "ColMotivo";
            this.ColMotivo.ReadOnly = true;
            // 
            // ColSolicita
            // 
            this.ColSolicita.HeaderText = "Fis solicita";
            this.ColSolicita.Name = "ColSolicita";
            this.ColSolicita.ReadOnly = true;
            // 
            // ColFisResponsable
            // 
            this.ColFisResponsable.HeaderText = "Fis responsable";
            this.ColFisResponsable.Name = "ColFisResponsable";
            this.ColFisResponsable.ReadOnly = true;
            // 
            // ColComentario
            // 
            this.ColComentario.HeaderText = "Comentario";
            this.ColComentario.Name = "ColComentario";
            this.ColComentario.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BT_ActualizarInicios);
            this.tabPage3.Controls.Add(this.RTB_Inicios);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(861, 392);
            this.tabPage3.TabIndex = 8;
            this.tabPage3.Text = "Inicios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BT_ActualizarInicios
            // 
            this.BT_ActualizarInicios.Location = new System.Drawing.Point(437, 336);
            this.BT_ActualizarInicios.Name = "BT_ActualizarInicios";
            this.BT_ActualizarInicios.Size = new System.Drawing.Size(75, 23);
            this.BT_ActualizarInicios.TabIndex = 1;
            this.BT_ActualizarInicios.Text = "Actualizar";
            this.BT_ActualizarInicios.UseVisualStyleBackColor = true;
            this.BT_ActualizarInicios.Click += new System.EventHandler(this.BT_ActualizarInicios_Click);
            // 
            // RTB_Inicios
            // 
            this.RTB_Inicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Inicios.Location = new System.Drawing.Point(34, 23);
            this.RTB_Inicios.Name = "RTB_Inicios";
            this.RTB_Inicios.Size = new System.Drawing.Size(372, 304);
            this.RTB_Inicios.TabIndex = 0;
            this.RTB_Inicios.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 446);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plan Helper V2";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_Consulta.ResumeLayout(false);
            this.tab_Consulta.PerformLayout();
            this.tab_EstadoEquipos.ResumeLayout(false);
            this.tab_EstadoEquipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EstadoEquipos)).EndInit();
            this.tab_QA.ResumeLayout(false);
            this.tab_QA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QA_PlacasPendientes)).EndInit();
            this.tab_Parametros.ResumeLayout(false);
            this.tab_Parametros.PerformLayout();
            this.tab_ExacTrac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ExacTrac)).EndInit();
            this.tab_Buscador.ResumeLayout(false);
            this.tab_Buscador.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Buscador)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QAPE)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PacientesTBI)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Pedidos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Consulta;
        private System.Windows.Forms.TabPage tab_EstadoEquipos;
        private System.Windows.Forms.TabPage tab_QA;
        private System.Windows.Forms.TabPage tab_Parametros;
        private System.Windows.Forms.Button BT_ConsultaBuscarEquipo;
        private System.Windows.Forms.CheckBox CHB_Electrones;
        private System.Windows.Forms.DateTimePicker DTP_FechaInicio;
        private System.Windows.Forms.CheckBox CHB_TieneFechaDeInicio;
        private System.Windows.Forms.CheckBox CHB_EsVMAT;
        private System.Windows.Forms.CheckBox CHB_10MV;
        private System.Windows.Forms.DataGridView DGV_EstadoEquipos;
        private System.Windows.Forms.Button BT_EstadoEquiposActualizar;
        private System.Windows.Forms.Label L_EstadoEquipoUltimaBusqueda;
        private System.Windows.Forms.DataGridView DGV_QA_PlacasPendientes;
        private System.Windows.Forms.Button BT_ParametrosRecalcular;
        private System.Windows.Forms.Label L_ParametrosUltimoCalculo;
        private System.Windows.Forms.Label L_QA_UltimaBusquedaPlacasPendientes;
        private System.Windows.Forms.CheckBox CHB_EsP1;
        private System.Windows.Forms.TextBox TB_ParaQueEquipo;
        private System.Windows.Forms.Button BT_QAActualizarBusquedas;
        private System.Windows.Forms.Button BT_QA_SacarDeLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button BT_GraficarTurnosLibres;
        private System.Windows.Forms.Button BT_Minar;
        private System.Windows.Forms.ListBox LB_QA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_NumFracciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tab_ExacTrac;
        private System.Windows.Forms.ListBox LB_ExacTrac;
        private System.Windows.Forms.Button BT_BuscarExacTrac;
        private System.Windows.Forms.DataGridView DGV_ExacTrac;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn HC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HayCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HayEstructuras;
        private System.Windows.Forms.Button BT_EliminarExacTrac;
        private System.Windows.Forms.TabPage tab_Buscador;
        private System.Windows.Forms.DataGridView DGV_Buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuscadorHC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuscadorApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuscadorNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuscadorCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuscadorPlan;
        private System.Windows.Forms.Button BT_BuscadorExportar;
        private System.Windows.Forms.Button BT_BuscadorBuscar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CB_BuscadorModalidad;
        private System.Windows.Forms.ComboBox CB_BuscadorEquipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DTP_BuscadorHasta;
        private System.Windows.Forms.DateTimePicker DTP_BuscadorDesde;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_BuscadorPlan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_BuscadorCurso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_BuscadorApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_BuscadorHC;
        private System.Windows.Forms.Label L_BuscadorResultados;
        private System.Windows.Forms.CheckBox CHB_BuscadorHasta;
        private System.Windows.Forms.CheckBox CHB_BuscadorDesde;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox CB_BuscadorEstadoAprobacion;
        private System.Windows.Forms.Button BT_QA_ExportarLista;
        private System.Windows.Forms.Button BT_BuscadorExportarPDF;
        private System.Windows.Forms.CheckBox CHB_BuscarEstaEnTratamiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label L_BuscadorNumFx;
        private System.Windows.Forms.TextBox TB_BuscadorNumFx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_BuscadorDosisDia;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TB_BuscadorEstructuras;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BT_ActualizarQAPE;
        private System.Windows.Forms.DataGridView DGV_QAPE;
        private System.Windows.Forms.Button BT_QAAgregar;
        private System.Windows.Forms.Button BT_QAGuardarCambios;
        private System.Windows.Forms.Label L_QAPEActualizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipoQA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QA_OK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaQA;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BT_TBIGuardarCambios;
        private System.Windows.Forms.Button BT_TBIActualizarBusqueda;
        private System.Windows.Forms.Button BT_PacTBIEliminarPaciente;
        private System.Windows.Forms.Button BT_TBIEditaPaciente;
        private System.Windows.Forms.Button BT_NuevoTBI;
        private System.Windows.Forms.DataGridView DGV_PacientesTBI;
        private System.Windows.Forms.Button BT_ActualizarInicios;
        private System.Windows.Forms.RichTextBox RTB_Inicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fx;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LlevaPbs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Treatment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PbsListos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DicomEnEq;
        private System.Windows.Forms.Button BT_EliminarDeLaLista;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button BT_EditarPedido;
        private System.Windows.Forms.Button BT_NuevoPedido;
        private System.Windows.Forms.DataGridView DGV_Pedidos;
        private System.Windows.Forms.Button BT_CompletarPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTecnica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSolicita;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFisResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColComentario;
        private System.Windows.Forms.Button BT_EliminarPedido;
        private System.Windows.Forms.Button BT_PedidoActualizarEstado;
    }
}