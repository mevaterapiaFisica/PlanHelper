namespace PlanHelper
{
    partial class ListaPacientes
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
            this.LB_Pacientes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LB_Pacientes
            // 
            this.LB_Pacientes.FormattingEnabled = true;
            this.LB_Pacientes.Location = new System.Drawing.Point(12, 12);
            this.LB_Pacientes.Name = "LB_Pacientes";
            this.LB_Pacientes.Size = new System.Drawing.Size(437, 381);
            this.LB_Pacientes.TabIndex = 0;
            // 
            // ListaPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 409);
            this.Controls.Add(this.LB_Pacientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ListaPacientes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Pacientes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Pacientes;
    }
}