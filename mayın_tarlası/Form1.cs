using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayın_tarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KolayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tarlaYap(10 , 10);
        }
        private void OrtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tarlaYap(15, 15);
        }

        private void ZorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tarlaYap(20, 20);
        }

        int secilen;
        void tarlaYap(int satir, int sutun)
        {
            flowLayoutPanel1.Controls.Clear();

            int mayin = (satir * sutun) / 10;

            Random rnd = new Random();

            int[] mayinlar = new int[mayin];
            
            for (int i = 0; i < mayin; i++)
            {
                secilen = rnd.Next(0, satir * sutun);

                while(mayinlar.Contains(secilen))
                {
                    secilen = rnd.Next(0, satir * sutun);
                }
                mayinlar[i] = secilen;

            }

            for (int i = 0; i < satir*sutun; i++)
            {
                Button btn = new Button();
                btn.Height = btn.Width = 25;
                btn.BackColor = Color.Gray;

                if (mayinlar.Contains(i))
                {
                    btn.Tag = true;
                }
                else
                {
                    btn.Tag = false;
                    
                }

                btn.Click += Btn_Click;
                btn.Margin = new Padding(4, 4, 0, 0);
                flowLayoutPanel1.Controls.Add(btn);
            }

            flowLayoutPanel1.Width = sutun * 30;
            flowLayoutPanel1.Height = satir * 30;
            this.Width = flowLayoutPanel1.Width + 40;
            this.Height = flowLayoutPanel1.Height + 70;
        }
        
        private void Btn_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;

            if((bool) tiklanan.Tag==true)
            {
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                   Button btn = item as Button;

                    if ((bool) btn.Tag==true)
                    {
                        btn.BackColor = Color.Red;
                        btn.BackgroundImage = pictureBox1.Image;
                        btn.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        btn.BackColor = Color.Gray;
                    }
                }

                MessageBox.Show("Yandın");
                flowLayoutPanel1.Controls.Clear();
                
            }
            else
            {
                tiklanan.BackColor = Color.Green;
            }
        }
    }
}
