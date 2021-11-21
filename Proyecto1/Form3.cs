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
    public partial class Form3 : Form
    {
        int Tiempo = 0;
        int seleccion,seleccion2;
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                timer1.Interval = 1000;
                Tiempo++;
                label3.Text = (Convert.ToInt32(Tiempo).ToString());
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            seleccion = 2;
            pictureBox4.Image = pictureBox2.Image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            seleccion = 1;
            pictureBox4.Image = pictureBox1.Image;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            seleccion = 3;
            pictureBox4.Image = pictureBox3.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Random numero= new Random();
            seleccion2 = (numero.Next(1,4));
            if (seleccion2 == 1)
            {
                pictureBox5.Image = pictureBox1.Image;

            }
            if (seleccion2 == 2)
            {
                pictureBox5.Image = pictureBox2.Image;

            }
            if (seleccion2 == 3)
            {
                pictureBox5.Image = pictureBox3.Image;

            }
            
            //piedra =1 papel=2 tijera= 3
            if (seleccion == seleccion2)
                label5.Text = "Empate";
            if ((seleccion == 1 && seleccion2 == 3) || (seleccion == 2 && seleccion2 == 1) || (seleccion == 3 && seleccion2 == 2))
                label5.Text = "Has ganado";
            if((seleccion==1 && seleccion2 ==2)|| (seleccion==2 && seleccion2==3)||(seleccion==3 && seleccion2== 1))
                label5.Text = "Has perdido";
            
        }
    }
}
