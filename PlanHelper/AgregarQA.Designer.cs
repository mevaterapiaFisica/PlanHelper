namespace PlanHelper
{
    partial class AgregarQA
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
            this.DGV_QAAgregar = new System.Windows.Forms.DataGridView();
            this.BT_AgregarQACancelar = new System.Windows.Forms.Button();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipoQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_AgregarQAAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QAAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_QAAgregar
            // 
            this.DGV_QAAgregar.AllowUserToAddRows = false;
            this.DGV_QAAgregar.AllowUserToDeleteRows = false;
            this.DGV_QAAgregar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_QAAgregar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.EquipoQA});
            this.DGV_QAAgregar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.DGV_QAAgregar.Location = new System.Drawing.Point(25, 12);
            this.DGV_QAAgregar.Name = "DGV_QAAgregar";
            this.DGV_QAAgregar.RowHeadersVisible = false;
            this.DGV_QAAgregar.Size = new System.Drawing.Size(483, 374);
            this.DGV_QAAgregar.TabIndex = 2;
            // 
            // BT_AgregarQACancelar
            // 
            this.BT_AgregarQACancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_AgregarQACancelar.Location = new System.Drawing.Point(135, 401);
            this.BT_AgregarQACancelar.Name = "BT_AgregarQACancelar";
            this.BT_AgregarQACancelar.Size = new System.Drawing.Size(75, 23);
            this.BT_AgregarQACancelar.TabIndex = 3;
            this.BT_AgregarQACancelar.Text = "Cancelar";
            this.BT_AgregarQACancelar.UseVisualStyleBackColor = true;
            this.BT_AgregarQACancelar.Click += new System.EventHandler(this.BT_AgregarQACancelar_Click);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Seleccionar.Width = 20;
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
            // BT_AgregarQAAceptar
            // 
            this.BT_AgregarQAAceptar.Location = new System.Drawing.Point(330, 401);
            this.BT_AgregarQAAceptar.Name = "BT_AgregarQAAceptar";
            this.BT_AgregarQAAceptar.Size = new System.Drawing.Size(75, 23);
            this.BT_AgregarQAAceptar.TabIndex = 4;
            this.BT_AgregarQAAceptar.Text = "Agregar";
            this.BT_AgregarQAAceptar.UseVisualStyleBackColor = true;
            this.BT_AgregarQAAceptar.Click += new System.EventHandler(this.BT_AgregarQAAceptar_Click);
            // 
            // AgregarQA
            // 
            this.AcceptButton = this.BT_AgregarQAAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_AgregarQACancelar;
            this.ClientSize = new System.Drawing.Size(527, 434);
            this.Controls.Add(this.BT_AgregarQAAceptar);
            this.Controls.Add(this.BT_AgregarQACancelar);
            this.Controls.Add(this.DGV_QAAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgregarQA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AgregarQA";
            this.Load += new System.EventHandler(this.AgregarQA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QAAgregar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_QAAgregar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipoQA;
        private System.Windows.Forms.Button BT_AgregarQACancelar;
        private System.Windows.Forms.Button BT_AgregarQAAceptar;
    }
}