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
		public int[,] paths;
		public int sel = 0;
		public float r = 1f;
		
        public MainForm()
        {
            InitializeComponent();
			
			nodes = new Node[6] { 
				new Node(new Point(100, 200), "1"), 
				new Node(new Point(300, 100), "2"),
				new Node(new Point(300, 300), "3"),
				new Node(new Point(500, 100), "4"),
				new Node(new Point(500, 300), "5"),
				new Node(new Point(700, 200), "6")
			};
			
			arcs = new Arc[8] {
				new Arc(new Point(100, 200), new Point(300, 100), "a"),
				new Arc(new Point(100, 200), new Point(300, 300), "b"),
				new Arc(new Point(300, 100), new Point(300, 300), "c"),
				new Arc(new Point(300, 100), new Point(500, 100), "d"),
				new Arc(new Point(300, 300), new Point(500, 300), "e"),
				new Arc(new Point(500, 100), new Point(500, 300), "f"),
				new Arc(new Point(500, 100), new Point(700, 200), "g"),
				new Arc(new Point(500, 300), new Point(700, 200), "h"),
			};
			paths = new int[8,8] {
				{1, 0, 0, 1, 0, 0, 1, 0},
				{0, 1, 0, 0, 1, 0, 0, 1},
				{1, 0, 1, 0, 1, 0, 0, 1},
				{1, 0, 0, 1, 0, 1, 0, 1},
				{0, 1, 1, 1, 0, 0, 1, 0},
				{0, 1, 0, 0, 1, 1, 1, 0},
				{1, 0, 1, 0, 1, 1, 1, 0},
				{0, 1, 1, 1, 0, 1, 0, 1}
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
            
            Pen nodePen = new Pen(Color.Brown, 2);
			Pen arcPen = new Pen(Color.Brown, 4);
			Pen arcSelPen = new Pen(Color.Aqua, 4);
			SolidBrush nodeBrush = new SolidBrush(Color.LightGray);
			
			Font nameFont = new Font("Arial", (int) 16 * r);
    		SolidBrush nameBrush = new SolidBrush(Color.Black);
			
			for(int i=0; i<arcs.Length; i++) {
				g.DrawLine(paths[sel,i] == 1 ? arcSelPen : arcPen, 
				           new PointF(arcs[i].a.X * r, arcs[i].a.Y * r), 
				           new PointF(arcs[i].b.X * r, arcs[i].b.Y * r));
				g.DrawString(arcs[i].name, 
				             nameFont, 
				             nameBrush, 
				             new RectangleF((arcs[i].a.X + arcs[i].b.X + (arcs[i].a.X == arcs[i].b.X ? 20 : 0))/2 * r, 
				                            (arcs[i].a.Y + arcs[i].b.Y + (arcs[i].a.X != arcs[i].b.X ? 20 : 0))/2 * r, 
				                            40 * r, 
				                            40 * r));
			}
			
			for(int i=0; i<nodes.Length; i++) {
				g.FillEllipse(nodeBrush, 
				              new RectangleF((nodes[i].pos.X-20) * r, 
				                             (nodes[i].pos.Y-20) * r, 
				                             40 * r, 
				                             40 * r));
				g.DrawEllipse(nodePen, 
				              new RectangleF((nodes[i].pos.X-20) *r, 
				                             (nodes[i].pos.Y-20) * r, 
				                             40 * r, 
				                             40 * r));
				g.DrawString(nodes[i].name, 
				             nameFont, 
				             nameBrush, 
				             new RectangleF((nodes[i].pos.X-8) *r, 
				                            (nodes[i].pos.Y-13) * r, 
				                            40 * r, 
				                            40 * r));
			}
			
            arcPen.Dispose();
			nodePen.Dispose();
			nodeBrush.Dispose();
        }
    }
}
