using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
			
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            Pen myPen = new Pen(Color.Tomato, 5);
			SolidBrush myBrush = new SolidBrush(Color.Aqua);
			
            // draw a line
            g.DrawLine(myPen, 0, 0, 200, 200);
			// draw an empty circle
			g.DrawEllipse(myPen, new Rectangle(10, 10, 100, 100));
			// draw a filled circle
			g.FillEllipse(myBrush, new Rectangle(10, 130, 100, 100));

            myPen.Dispose();
        }
    }
}
