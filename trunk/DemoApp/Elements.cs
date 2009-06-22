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
		public String name;
		
		public Node(Point pos, String name)
		{
			this.pos = pos;
			this.name = name;
		}
	}
	
	public struct Arc
	{
		public Point a, b;
		public String name;
		
		public Arc(Point a, Point b, String name)
		{
			this.a = a;
			this.b = b;
			this.name = name;
		}
	}
}
