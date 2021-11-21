namespace Cliente
{
    partial class Form2
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
            this.aceptarbtn = new System.Windows.Forms.Button();
            this.rechazarbtn = new System.Windows.Forms.Button();
            this.lblinvitacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aceptarbtn
            // 
            this.aceptarbtn.Location = new System.Drawing.Point(79, 223);
            this.aceptarbtn.Name = "aceptarbtn";
            this.aceptarbtn.Size = new System.Drawing.Size(117, 59);
            this.aceptarbtn.TabIndex = 0;
            this.aceptarbtn.Text = "Aceptar";
            this.aceptarbtn.UseVisualStyleBackColor = true;
            // 
            // rechazarbtn
            // 
            this.rechazarbtn.Location = new System.Drawing.Point(386, 223);
            this.rechazarbtn.Name = "rechazarbtn";
            this.rechazarbtn.Size = new System.Drawing.Size(143, 64);
            this.rechazarbtn.TabIndex = 1;
            this.rechazarbtn.Text = "Rechazar";
            this.rechazarbtn.UseVisualStyleBackColor = true;
            // 
            // lblinvitacion
            // 
            this.lblinvitacion.AutoSize = true;
            this.lblinvitacion.Location = new System.Drawing.Point(83, 105);
            this.lblinvitacion.Name = "lblinvitacion";
            this.lblinvitacion.Size = new System.Drawing.Size(46, 17);
            this.lblinvitacion.TabIndex = 2;
            this.lblinvitacion.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 372);
            this.Controls.Add(this.lblinvitacion);
            this.Controls.Add(this.rechazarbtn);
            this.Controls.Add(this.aceptarbtn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptarbtn;
        private System.Windows.Forms.Button rechazarbtn;
        private System.Windows.Forms.Label lblinvitacion;
    }
}