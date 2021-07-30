namespace PlanHelper
{
    partial class Conexion
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
            this.L_Texto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // L_Texto
            // 
            this.L_Texto.AutoSize = true;
            this.L_Texto.Location = new System.Drawing.Point(45, 29);
            this.L_Texto.Name = "L_Texto";
            this.L_Texto.Size = new System.Drawing.Size(35, 13);
            this.L_Texto.TabIndex = 0;
            this.L_Texto.Text = "label1";
            // 
            // Conexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 213);
            this.Controls.Add(this.L_Texto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Conexion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlanHelper V2: Búsqueda en base de datos";
            this.Shown += new System.EventHandler(this.Conexion_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Texto;
    }
}