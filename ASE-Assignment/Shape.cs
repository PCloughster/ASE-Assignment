using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    public abstract class Shape : Object
    {
        protected Color colour;
        protected int x, y;
        protected Boolean fillType;
        public Shape(Color colour, Boolean fillType, int x, int y) 
        {
            this.colour = colour;
            this.fillType = fillType;
            this.x = x;
            this.y = y;
        }

        public abstract void Draw(Graphics g);

        public override string ToString()
        {
            return base.ToString()+this.colour.ToString()+"  "+this.fillType.ToString()+"  "+this.x+","+this.y+" : ";
        }
    }
}
