using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    /// <summary>
    /// Class for the Circle object, inherits from Shape.cs
    /// </summary>
    public class Circle : Shape
    {
        int radius;
        string shape = "circle";
        /// <summary>
        /// constructor for a cricle taking the radius
        /// </summary>
        /// <param name="colour">colour of circle</param>
        /// <param name="fillType">is circle filled</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="radius">radius of circle</param>
        public Circle(Color colour, Boolean fillType, int x, int y, int radius) : base(colour, fillType, x, y)
        {
            this.radius = radius * 2;
        }
        /// <summary>
        /// Draws the circle on the specified graphics object
        /// </summary>
        /// <param name="g">graphics object to draw circle on</param>
        public override void Draw(Graphics g)
        {
            if (fillType == true)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillEllipse(b, x-(radius /2), y-(radius/2), radius, radius);
            }
            else
            {
                Pen p = new Pen(colour, 2);
                g.DrawEllipse(p, x - (radius / 2), y - (radius / 2), radius, radius);
            }
        }
        /// <summary>
        /// ToString override to include specific circle variables
        /// </summary>
        /// <returns>string of object information</returns>
        public override string ToString()
        {
            return shape + ": "+base.ToString() + "  " + this.radius;
        }
    }
}
