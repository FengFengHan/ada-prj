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
		// with this you can control the aspect ratio of the drawing
		public float r = 0.7f;
		
		public int[,] pathCoords;
		// the default path displayed, -1 for none
		public int sel = -1;
		
		public String[] pathStrings;
		
        public MainForm()
        {
            InitializeComponent();
			// the array of nodes
			nodes = new Node[6] { 
				new Node(new Point(100, 200), "1"), 
				new Node(new Point(300, 100), "2"),
				new Node(new Point(300, 300), "3"),
				new Node(new Point(500, 100), "4"),
				new Node(new Point(500, 300), "5"),
				new Node(new Point(700, 200), "6")
			};
			// the array of arcs
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
			// the coordinates of the valid paths
			pathCoords = new int[8,8] {
				{1, 0, 0, 1, 0, 0, 1, 0},
				{0, 1, 0, 0, 1, 0, 0, 1},
				{1, 0, 1, 0, 1, 0, 0, 1},
				{1, 0, 0, 1, 0, 1, 0, 1},
				{0, 1, 1, 1, 0, 0, 1, 0},
				{0, 1, 0, 0, 1, 1, 1, 0},
				{1, 0, 1, 0, 1, 1, 1, 0},
				{0, 1, 1, 1, 0, 1, 0, 1}
			};
			// the name of the valid paths
			pathStrings = new String[8] { "adg", 
				"beh", 
				"aceh", 
				"adfh", 
				"bcdg", 
				"befg", 
				"acefg", 
				"bcdfh" };
			// populate the ListBox of valid paths
			for(int i=0; i<pathStrings.Length; i++) {
				listBox1.Items.Add(pathStrings[i]);
			}
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
		
		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			this.sel = this.listBox1.SelectedIndex;
			this.pictureBox1.Invalidate();
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
			
			Font titleFont = new Font("Arial", (int) 16 );
    		SolidBrush titleBrush = new SolidBrush(Color.Black);
			
			if (sel != -1) {
				g.DrawString("Current path: " + pathStrings[sel],
				             titleFont,
				             titleBrush,
				             new Rectangle(200, 5, 600, 100));
			}
			// draw the arcs
			for(int i=0; i<arcs.Length; i++) {
				g.DrawLine((sel == -1 || pathCoords[sel,i] != 1) ? arcPen : arcSelPen, 
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
			// draw the nodes
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
			nameFont.Dispose();
			nameBrush.Dispose();
			titleFont.Dispose();
			titleBrush.Dispose();
        }
    }
}
