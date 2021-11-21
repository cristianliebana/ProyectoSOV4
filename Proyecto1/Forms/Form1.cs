using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Thread atender;
        public static Socket server;
        public static int A;
        public static string N;
        bool registrado = false;
        delegate void DelegadoDataGridView(DataGridView ListaConectados);
        delegate void DelegadoDataGridView2(DataGridView ListaConectados, string[] respuesta, int k);

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaConectados.ColumnCount = 1;
            ListaConectados.RowCount = 100;
        }
        public void LimpiarDatagrid(DataGridView Listaconectados)
        {
            ListaConectados.Rows.Clear();
        }

        public void AñadirDatagrid(DataGridView ListaConectados, string[] respuesta, int k)
        {
            ListaConectados.Rows.Add(respuesta[k]);
        }

        public void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] respuesta = mensaje.Split('/');
                int codigo = Convert.ToInt32(respuesta[0]);

                switch (codigo)
                {
                    case 0:
                        mensaje = respuesta[1];
                        atender.Abort();
                        break;
                    case 1:
                        mensaje = respuesta[1];
                        MessageBox.Show(mensaje + " se ha registrado correctamente, Ahora inicie sesión!");
                        break;
                    case 2:
                        mensaje = respuesta[1];
                        MessageBox.Show(mensaje + " ha iniciado sesión correctamente");
                        lblconexion.ForeColor = Color.Green;
                        break;
                    case 3:
                        mensaje = respuesta[1];
                        MessageBox.Show("El que ha ganado más partidas es " + mensaje);
                        break;
                    case 4:
                        mensaje = respuesta[1];
                        MessageBox.Show(" Las partidas ganadas en febrero:" + mensaje);
                        break;
                    case 5:
                        mensaje = respuesta[1];
                        MessageBox.Show(" El número de partidas en las que Juan ha obtenido más de 30 puntos es " + mensaje);
                        break;
                    case 6:
                        //ListaConectados.Rows.Clear();
                        int numConectados = Convert.ToInt32(respuesta[1]);
                        DelegadoDataGridView delegado = new DelegadoDataGridView(LimpiarDatagrid);
                        ListaConectados.Invoke(delegado, new object[] { ListaConectados });
                        int j = 0, k = 2;
                        DelegadoDataGridView2 delegado2 = new DelegadoDataGridView2(AñadirDatagrid);
                        while (j < numConectados)
                        {
                            //ListaConectados.Rows.Add(respuesta[k]);
                            ListaConectados.Invoke(delegado2, new object[] { ListaConectados, respuesta, k });
                            j++;
                            k++;
                        }
                        break;
                    case 7:
                        int IdPartida = Convert.ToInt32(respuesta[1]);
                        string host = respuesta[2];
                        Form2 invitacion = new Form2(IdPartida, host);
                        invitacion.ShowDialog();
                        break;

                    default:
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if(A==1)
                {
            
                if (ganado.Checked) 
                {
                    string mensaje = "3/" + Form1.N;
                    
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Form1.server.Send(msg);

                    
                    byte[] msg2 = new byte[80];
                    Form1.server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El que ha ganado más partidas es " + mensaje);

                }
                else if (febrero.Checked) 
                {
                    string mensaje = "4/" + Form1.N;
                    
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Form1.server.Send(msg);

                    
                    byte[] msg2 = new byte[80];
                    Form1.server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(Form1.N + " Las partidas ganadas en febrero:" + mensaje );
                }
                else if (puntos.Checked)
                {
                    string mensaje = "5/" + Form1.N;
                    
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Form1.server.Send(msg);

                    
                    byte[] msg2 = new byte[80];
                    Form1.server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(Form1.N + " El número de partidas en las que Juan ha obtenido más de 30 puntos es " + mensaje );
                }

                }
        }


        private void button3_Click(object sender, EventArgs e) 
        {
            if (A != 1)
            {
                if (registrado == false)
                {
                   
                    IPAddress direc = IPAddress.Parse("147.83.117.22");
                    IPEndPoint ipep = new IPEndPoint(direc, 50001);


                    
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);

                    }
                    catch (SocketException ex)
                    {
                        
                        return;

                    }
                    A = 1;
                    N = usuario.Text;
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                    string mensaje = "2/" + usuario.Text + "/" + password.Text;
                    
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            else
                MessageBox.Show("Ya has iniciado una sesión debes desconectarte primero.");
        }

        private void button4_Click(object sender, EventArgs e) 
        {

            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50001);


           
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);  

            }
            catch (SocketException ex)
            {
                
                return;

            }
            string mensaje = "1/" + usuario.Text + "/" + password.Text;
            
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            registrado = true;
        }

        private void Desconectarbtn_Click(object sender, EventArgs e)
        {
            if (A == 1)
            {
                
                string mensaje = "0/" + N;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


                
                MessageBox.Show("Te has desconectado");
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();
                A = 0;
            }
            else
            {
                MessageBox.Show("Todavía no estás conectado!");
            }
        }

        StringBuilder sb = new StringBuilder();

        private void invitarbtn_Click(object sender, EventArgs e)
        {
            int numParticipantes = 1;
            sb.Append("6/" + N + "/");
            foreach (DataGridViewCell item in ListaConectados.SelectedCells)
            {
                numParticipantes++;
            }
            sb.Append(numParticipantes + "/");
            foreach (DataGridViewCell item in ListaConectados.SelectedCells)
            {
                sb.Append(item.Value.ToString() + "/");
            }

            string mensaje = sb.ToString();
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form abrirjuego = new Form3();
            abrirjuego.Show();

        }


        
}
                
    }




