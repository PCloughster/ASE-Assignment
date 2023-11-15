using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    public class Rectangle:Shape
    {
        int width, height;
        string shape = "rectangle";
        public Rectangle(Color colour, Boolean fillType, int x, int y, int width, int height) : base(colour, fillType, x, y)
        {
            this.width = width;
            this.height = height;
        }
        public Rectangle(Color colour, Boolean fillType, int x, int y, int width) : base(colour, fillType, x, y)
        {
            this.width = width;
            this.height = width;
        }

        public override void Draw(Graphics g)
        {
            if (fillType == true)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillRectangle(b, x, y, width, height);
            }
            else
            {
                Pen p = new Pen(colour, 2); 
                g.DrawRectangle(p, x, y, width, height);
            }
        }

        public override string ToString()
        {
            return shape+": "+base.ToString()+"  "+this.width+","+this.height;
        }
    }
}
