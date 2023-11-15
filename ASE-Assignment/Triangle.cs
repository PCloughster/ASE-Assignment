using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ase_assignment
{
    public class Triangle : Shape
    {
        int sideLength1;
        int sideLength2;
        int height; 
        Point[] points;
        public Triangle(Color colour, Boolean fillType, int x, int y, int sideLength1, int sideLength2) : base(colour, fillType, x, y)
        {
            this.sideLength1 = sideLength1;
            this.sideLength2 = sideLength2;
            Point point1 = new Point(x, y);
            Point point2 = new Point(x+sideLength1, y);
            Point point3 = new Point(x, y+sideLength2);

            Point[] points = {point1, point2, point3};

        }

        public override void Draw(Graphics g)
        {
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
            return base.ToString() + "  " + this.sideLength1 + this.sideLength2;
        }
    }
}
