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
        public Node[] nodes;
		public Arc[] arcs;
		
        public MainForm()
        {
            InitializeComponent();
			
			nodes = new Node[6] { 
				new Node(new Point(100, 200), '1'), 
				new Node(new Point(300, 100), '2'),
				new Node(new Point(300, 300), '3'),
				new Node(new Point(500, 100), '4'),
				new Node(new Point(500, 300), '5'),
				new Node(new Point(700, 200), '6')
			};
			
			arcs = new Arc[8] {
				new Arc(new Point(100, 200), new Point(300, 100), 'a'),
				new Arc(new Point(100, 200), new Point(300, 300), 'b'),
				new Arc(new Point(300, 100), new Point(300, 300), 'c'),
				new Arc(new Point(300, 100), new Point(500, 100), 'd'),
				new Arc(new Point(300, 300), new Point(500, 300), 'e'),
				new Arc(new Point(500, 100), new Point(500, 300), 'f'),
				new Arc(new Point(500, 100), new Point(700, 200), 'g'),
				new Arc(new Point(500, 300), new Point(700, 200), 'h'),
			};
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
			
			Font drawFont = new Font("Arial", 16);
    		SolidBrush drawBrush = new SolidBrush(Color.Black);
/*			
            // draw a line
            g.DrawLine(myPen, 0, 0, 200, 200);
			// draw an empty circle
			g.DrawEllipse(myPen, new Rectangle(10, 10, 100, 100));
			// draw a filled circle
			g.FillEllipse(myBrush, new Rectangle(10, 130, 100, 100));
*/
			// draw a triangle
			g.DrawLines(myPen, new Point[4] { new Point(100, 200), new Point(300, 100), new Point(300, 200), new Point(100, 200) });
			g.FillEllipse(myBrush, 180, 130, 40, 40);
			// draw a letter
			g.DrawString("a", drawFont, drawBrush, new RectangleF(190F, 136F, 30F, 30F));
			
            myPen.Dispose();
        }
    }
}
