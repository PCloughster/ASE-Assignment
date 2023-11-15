using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    public class Circle : Shape
    {
        int radius;
        string shape = "circle";
        public Circle(Color colour, Boolean fillType, int x, int y, int radius) : base(colour, fillType, x, y)
        {
            this.radius = radius * 2;
            
        }

        public override void Draw(Graphics g)
        {
            if (fillType == true)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillEllipse(b, x, y, radius, radius);
            }
            else
            {
                Pen p = new Pen(colour, 2);
                g.DrawEllipse(p, x, y, radius, radius);
            }
        }

        public override string ToString()
        {
            return shape + ": "+base.ToString() + "  " + this.radius;
        }
    }
}
