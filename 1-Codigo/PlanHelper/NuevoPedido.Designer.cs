
namespace PlanHelper
{
    partial class NuevoPedido
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
            this.DTP_FechaLimite = new System.Windows.Forms.DateTimePicker();
            this.CB_Tarea = new System.Windows.Forms.ComboBox();
            this.TB_Paciente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Aceptar = new System.Windows.Forms.Button();
            this.BT_Cancelar = new System.Windows.Forms.Button();
            this.CB_Tecnica = new System.Windows.Forms.ComboBox();
            this.CB_Equipo = new System.Windows.Forms.ComboBox();
            this.CB_Medico = new System.Windows.Forms.ComboBox();
            this.CB_FisicoResponsable = new System.Windows.Forms.ComboBox();
            this.CB_FisicoSolicita = new System.Windows.Forms.ComboBox();
            this.TB_Comentario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_Motivo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DTP_FechaLimite
            // 
            this.DTP_FechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_FechaLimite.Location = new System.Drawing.Point(112, 119);
            this.DTP_FechaLimite.Name = "DTP_FechaLimite";
            this.DTP_FechaLimite.Size = new System.Drawing.Size(131, 20);
            this.DTP_FechaLimite.TabIndex = 5;
            // 
            // CB_Tarea
            // 
            this.CB_Tarea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Tarea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Tarea.FormattingEnabled = true;
            this.CB_Tarea.Location = new System.Drawing.Point(112, 65);
            this.CB_Tarea.Name = "CB_Tarea";
            this.CB_Tarea.Size = new System.Drawing.Size(131, 21);
            this.CB_Tarea.TabIndex = 3;
            // 
            // TB_Paciente
            // 
            this.TB_Paciente.Location = new System.Drawing.Point(113, 12);
            this.TB_Paciente.Name = "TB_Paciente";
            this.TB_Paciente.Size = new System.Drawing.Size(131, 20);
            this.TB_Paciente.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Medico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Fecha Límite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Equipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tarea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tecnica";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Paciente";
            // 
            // BT_Aceptar
            // 
            this.BT_Aceptar.Location = new System.Drawing.Point(217, 399);
            this.BT_Aceptar.Name = "BT_Aceptar";
            this.BT_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.BT_Aceptar.TabIndex = 29;
            this.BT_Aceptar.Text = "Aceptar";
            this.BT_Aceptar.UseVisualStyleBackColor = true;
            this.BT_Aceptar.Click += new System.EventHandler(this.BT_Aceptar_Click);
            // 
            // BT_Cancelar
            // 
            this.BT_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_Cancelar.Location = new System.Drawing.Point(43, 399);
            this.BT_Cancelar.Name = "BT_Cancelar";
            this.BT_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.BT_Cancelar.TabIndex = 28;
            this.BT_Cancelar.Text = "Cancelar";
            this.BT_Cancelar.UseVisualStyleBackColor = true;
            this.BT_Cancelar.Click += new System.EventHandler(this.BT_Cancelar_Click);
            // 
            // CB_Tecnica
            // 
            this.CB_Tecnica.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Tecnica.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Tecnica.FormattingEnabled = true;
            this.CB_Tecnica.Location = new System.Drawing.Point(112, 38);
            this.CB_Tecnica.Name = "CB_Tecnica";
            this.CB_Tecnica.Size = new System.Drawing.Size(132, 21);
            this.CB_Tecnica.TabIndex = 2;
            // 
            // CB_Equipo
            // 
            this.CB_Equipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Equipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Equipo.FormattingEnabled = true;
            this.CB_Equipo.Location = new System.Drawing.Point(112, 92);
            this.CB_Equipo.Name = "CB_Equipo";
            this.CB_Equipo.Size = new System.Drawing.Size(131, 21);
            this.CB_Equipo.TabIndex = 4;
            // 
            // CB_Medico
            // 
            this.CB_Medico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Medico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Medico.FormattingEnabled = true;
            this.CB_Medico.Location = new System.Drawing.Point(112, 145);
            this.CB_Medico.Name = "CB_Medico";
            this.CB_Medico.Size = new System.Drawing.Size(131, 21);
            this.CB_Medico.TabIndex = 6;
            // 
            // CB_FisicoResponsable
            // 
            this.CB_FisicoResponsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_FisicoResponsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_FisicoResponsable.FormattingEnabled = true;
            this.CB_FisicoResponsable.Location = new System.Drawing.Point(112, 233);
            this.CB_FisicoResponsable.Name = "CB_FisicoResponsable";
            this.CB_FisicoResponsable.Size = new System.Drawing.Size(131, 21);
            this.CB_FisicoResponsable.TabIndex = 9;
            // 
            // CB_FisicoSolicita
            // 
            this.CB_FisicoSolicita.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_FisicoSolicita.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_FisicoSolicita.FormattingEnabled = true;
            this.CB_FisicoSolicita.Location = new System.Drawing.Point(112, 198);
            this.CB_FisicoSolicita.Name = "CB_FisicoSolicita";
            this.CB_FisicoSolicita.Size = new System.Drawing.Size(131, 21);
            this.CB_FisicoSolicita.TabIndex = 8;
            // 
            // TB_Comentario
            // 
            this.TB_Comentario.Location = new System.Drawing.Point(112, 278);
            this.TB_Comentario.Multiline = true;
            this.TB_Comentario.Name = "TB_Comentario";
            this.TB_Comentario.Size = new System.Drawing.Size(180, 81);
            this.TB_Comentario.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Comentario";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "F.Responsable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "F. Solicita";
            // 
            // CB_Motivo
            // 
            this.CB_Motivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Motivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Motivo.FormattingEnabled = true;
            this.CB_Motivo.Location = new System.Drawing.Point(112, 172);
            this.CB_Motivo.Name = "CB_Motivo";
            this.CB_Motivo.Size = new System.Drawing.Size(131, 21);
            this.CB_Motivo.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Motivo";
            // 
            // NuevoPedido
            // 
            this.AcceptButton = this.BT_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancelar;
            this.ClientSize = new System.Drawing.Size(333, 445);
            this.Controls.Add(this.CB_Motivo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CB_FisicoResponsable);
            this.Controls.Add(this.CB_FisicoSolicita);
            this.Controls.Add(this.TB_Comentario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CB_Medico);
            this.Controls.Add(this.CB_Equipo);
            this.Controls.Add(this.CB_Tecnica);
            this.Controls.Add(this.BT_Aceptar);
            this.Controls.Add(this.BT_Cancelar);
            this.Controls.Add(this.DTP_FechaLimite);
            this.Controls.Add(this.CB_Tarea);
            this.Controls.Add(this.TB_Paciente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevoPedido";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo pedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DTP_FechaLimite;
        private System.Windows.Forms.ComboBox CB_Tarea;
        private System.Windows.Forms.TextBox TB_Paciente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Aceptar;
        private System.Windows.Forms.Button BT_Cancelar;
        private System.Windows.Forms.ComboBox CB_Tecnica;
        private System.Windows.Forms.ComboBox CB_Equipo;
        private System.Windows.Forms.ComboBox CB_Medico;
        private System.Windows.Forms.ComboBox CB_FisicoResponsable;
        private System.Windows.Forms.ComboBox CB_FisicoSolicita;
        private System.Windows.Forms.TextBox TB_Comentario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_Motivo;
        private System.Windows.Forms.Label label10;
    }
}