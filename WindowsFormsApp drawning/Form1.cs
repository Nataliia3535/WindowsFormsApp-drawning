using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_drawning
{
    public partial class Form1 : Form
    {
        string mode;
        Bitmap p; int X, Y; int Xc, Yc;
        Bitmap p1;
        public Form1()
        {
            mode = "Лінія";
            p = new Bitmap(1000, 1000);
            p1 = new Bitmap(1000, 1000);
            InitializeComponent();
            X = Y = 0;
            
        }

        

        private void зберегтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                p.Save(saveFileDialog1.FileName);
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    p = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = p;
                }
            }
           

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mode = "Лінія";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            mode = "Прямокутник";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            mode = "Коло";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Xc = e.X;
            Yc = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen pen; pen = new Pen(Color.Black);
            Graphics g; g = Graphics.FromImage(p);
            if (mode == "Прямокутник")
            {
               
                g.DrawRectangle(pen, Xc, Yc, e.X - Xc, e.Y - Yc);
            }
            if (mode == "Коло")
            {

                g.DrawEllipse(pen, Xc, Yc, e.X - Xc, e.Y - Yc);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen pen; pen = new Pen(Color.Black);
            Graphics g; g = Graphics.FromImage(p);
            Graphics g1; g1 = Graphics.FromImage(p1);
            if (e.Button==MouseButtons.Left)
            {
                if (mode == "Лінія")
                {
                    g.DrawLine(pen, X, Y, e.X, e.Y);
                }
                if (mode=="Прямокутник")
                {
                    g1.Clear(Color.White);
                    g1.DrawRectangle(pen, X, Y, e.X-Xc, e.Y-Yc);
                }
                if (mode == "Коло")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(pen, X, Y, e.X - Xc, e.Y - Yc);
                }
                g1.DrawImage(p, 0, 0);
                pictureBox1.Image = p1;
            }
            X = e.X; Y = e.Y;
        }
    }
}
