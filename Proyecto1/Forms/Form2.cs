using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form2 : Form
    {
        string host;
        int ID_Partida;

        public Form2(int ID_Partida, string host)
        {
            InitializeComponent();
            this.host = host;
            this.ID_Partida = ID_Partida;
        }

        private void aceptarbtn_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + Form1.N + "/" + ID_Partida + "/1";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            Form1.server.Send(msg);
            this.Close();
        }

        private void rechazarbtn_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + Form1.N + "/" + ID_Partida + "/0";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            Form1.server.Send(msg);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblinvitacion.Text = this.host + " te ha invitado a una partida.";
        }
    }
}
