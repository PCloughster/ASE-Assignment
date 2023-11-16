using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    /// <summary>
    /// Shape abstract class to be inherited by the other shape classes, triangle, rectangle and circle
    /// </summary>
    public abstract class Shape : Object
    {
        protected Color colour;
        protected int x, y;
        protected Boolean fillType;
        /// <summary>
        /// Constructor for all shapes including colour, fill boolean and coordinates
        /// </summary>
        /// <param name="colour">colour for shape to be drawn in</param>
        /// <param name="fillType">boolean to define whether the shape is filled</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Shape(Color colour, Boolean fillType, int x, int y) 
        {
            this.colour = colour;
            this.fillType = fillType;
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Draw method which must be implemented
        /// </summary>
        /// <param name="g">graphics object needs to be passed for shape to draw on</param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// overrides ToString to better compare shapes to oneanother
        /// </summary>
        /// <returns>string of object information</returns>
        public override string ToString()
        {
            return base.ToString()+this.colour.ToString()+"  "+this.fillType.ToString()+"  "+this.x+","+this.y+" : ";
        }
    }
}
