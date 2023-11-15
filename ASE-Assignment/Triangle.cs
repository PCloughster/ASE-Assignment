using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ase_assignment
{
    public class Triangle : Shape
    {
        int side1;
        int side2;
        string shape = "triangle";
        public Triangle(Color colour, Boolean fillType, int x, int y, int side1, int side2) : base(colour, fillType, x, y)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
        public Triangle(Color colour, Boolean fillType, int x, int y, int side1) : base(colour, fillType, x, y)
        {
            this.side1 = side1;
            this.side2 = side1;
        }

        private Point[] SetPoints(int x, int y, int side1, int side2)
        {
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + side1, y);
            Point point3 = new Point(x, y + side2);
            Point[] points =
            { 
                point1 , point2 , point3
            };
            return points;
        }
        public override void Draw(Graphics g)
        {
            Point[] points = SetPoints(x, y, side1, side2);
            if (fillType == true)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillPolygon(b, points);
            }
            else
            {
                Pen p = new Pen(colour, 2);
                g.DrawPolygon(p, points);
            }
        }

        public override string ToString()
        {
            return shape+": "+base.ToString() + "  " + this.side1 + this.side2;
        }
    }
}
