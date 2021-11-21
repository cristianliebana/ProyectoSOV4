namespace Cliente
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ganado = new System.Windows.Forms.RadioButton();
            this.febrero = new System.Windows.Forms.RadioButton();
            this.puntos = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Desconectarbtn = new System.Windows.Forms.Button();
            this.lblconexion = new System.Windows.Forms.Label();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.invitarbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // ganado
            // 
            this.ganado.AutoSize = true;
            this.ganado.Location = new System.Drawing.Point(25, 255);
            this.ganado.Margin = new System.Windows.Forms.Padding(4);
            this.ganado.Name = "ganado";
            this.ganado.Size = new System.Drawing.Size(257, 21);
            this.ganado.TabIndex = 3;
            this.ganado.TabStop = true;
            this.ganado.Text = "Dime quien ha ganado mas partidas";
            this.ganado.UseVisualStyleBackColor = true;
            // 
            // febrero
            // 
            this.febrero.AutoSize = true;
            this.febrero.Location = new System.Drawing.Point(25, 284);
            this.febrero.Margin = new System.Windows.Forms.Padding(4);
            this.febrero.Name = "febrero";
            this.febrero.Size = new System.Drawing.Size(334, 21);
            this.febrero.TabIndex = 4;
            this.febrero.TabStop = true;
            this.febrero.Text = "Dime cuantas partidas se han jugado en febrero";
            this.febrero.UseVisualStyleBackColor = true;
            // 
            // puntos
            // 
            this.puntos.AutoSize = true;
            this.puntos.Location = new System.Drawing.Point(25, 313);
            this.puntos.Margin = new System.Windows.Forms.Padding(4);
            this.puntos.Name = "puntos";
            this.puntos.Size = new System.Drawing.Size(504, 21);
            this.puntos.TabIndex = 5;
            this.puntos.TabStop = true;
            this.puntos.Text = "Dime el numero de partidas en las que Juan ha obtenido mas de 30 puntos";
            this.puntos.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 360);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(116, 114);
            this.usuario.Margin = new System.Windows.Forms.Padding(4);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(132, 22);
            this.usuario.TabIndex = 7;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(116, 140);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(132, 22);
            this.password.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 188);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Iniciar Sesion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(151, 188);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Registrarse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Contraseña:";
            // 
            // Desconectarbtn
            // 
            this.Desconectarbtn.Location = new System.Drawing.Point(150, 360);
            this.Desconectarbtn.Name = "Desconectarbtn";
            this.Desconectarbtn.Size = new System.Drawing.Size(114, 28);
            this.Desconectarbtn.TabIndex = 21;
            this.Desconectarbtn.Text = "Desconectar";
            this.Desconectarbtn.UseVisualStyleBackColor = true;
            this.Desconectarbtn.Click += new System.EventHandler(this.Desconectarbtn_Click);
            // 
            // lblconexion
            // 
            this.lblconexion.AutoSize = true;
            this.lblconexion.Location = new System.Drawing.Point(48, 23);
            this.lblconexion.Name = "lblconexion";
            this.lblconexion.Size = new System.Drawing.Size(76, 17);
            this.lblconexion.TabIndex = 22;
            this.lblconexion.Text = "Conectado";
            // 
            // ListaConectados
            // 
            this.ListaConectados.AllowUserToAddRows = false;
            this.ListaConectados.AllowUserToDeleteRows = false;
            this.ListaConectados.AllowUserToResizeColumns = false;
            this.ListaConectados.AllowUserToResizeRows = false;
            this.ListaConectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaConectados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListaConectados.BackgroundColor = System.Drawing.Color.White;
            this.ListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListaConectados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaConectados.DefaultCellStyle = dataGridViewCellStyle1;
            this.ListaConectados.Dock = System.Windows.Forms.DockStyle.Right;
            this.ListaConectados.Location = new System.Drawing.Point(1239, 0);
            this.ListaConectados.MultiSelect = false;
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.ReadOnly = true;
            this.ListaConectados.RowHeadersVisible = false;
            this.ListaConectados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ListaConectados.RowTemplate.Height = 24;
            this.ListaConectados.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ListaConectados.ShowCellErrors = false;
            this.ListaConectados.ShowCellToolTips = false;
            this.ListaConectados.ShowEditingIcon = false;
            this.ListaConectados.ShowRowErrors = false;
            this.ListaConectados.Size = new System.Drawing.Size(247, 632);
            this.ListaConectados.TabIndex = 23;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // invitarbtn
            // 
            this.invitarbtn.Location = new System.Drawing.Point(67, 483);
            this.invitarbtn.Name = "invitarbtn";
            this.invitarbtn.Size = new System.Drawing.Size(143, 45);
            this.invitarbtn.TabIndex = 24;
            this.invitarbtn.Text = "Invitar";
            this.invitarbtn.UseVisualStyleBackColor = true;
            this.invitarbtn.Click += new System.EventHandler(this.invitarbtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 38);
            this.button1.TabIndex = 25;
            this.button1.Text = "Jugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 632);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.invitarbtn);
            this.Controls.Add(this.ListaConectados);
            this.Controls.Add(this.lblconexion);
            this.Controls.Add(this.Desconectarbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.puntos);
            this.Controls.Add(this.febrero);
            this.Controls.Add(this.ganado);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ganado;
        private System.Windows.Forms.RadioButton febrero;
        private System.Windows.Forms.RadioButton puntos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Desconectarbtn;
        private System.Windows.Forms.Label lblconexion;
        private System.Windows.Forms.DataGridView ListaConectados;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button invitarbtn;
        private System.Windows.Forms.Button button1;
    }
}

