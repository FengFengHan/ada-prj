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
	
	public struct Node
	{
		public Point pos;
		public Char name;
		
		public Node(Point pos, Char name)
		{
			this.pos = pos;
			this.name = name;
		}
	}
	
	public struct Arc
	{
		public Point x, y;
		public Char name;
		
		public Arc(Point x, Point y, Char name)
		{
			this.x = x;
			this.y = y;
			this.name = name;
		}
	}
}
