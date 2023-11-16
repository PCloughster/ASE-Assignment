using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    /// <summary>
    /// Class for the Rectangle object, inherits from Shape.cs
    /// </summary>
    public class Rectangle : Shape
    {
        int width, height;
        string shape = "rectangle";
        /// <summary>
        /// constructor for a rectangle taking height and width measurements
        /// </summary>
        /// <param name="colour">colour of rectangle</param>
        /// <param name="fillType">is rectangle filled</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">width of rectangle</param>
        /// <param name="height">height of rectangle</param>
        public Rectangle(Color colour, Boolean fillType, int x, int y, int width, int height) : base(colour, fillType, x, y)
        {
            this.width = width;
            this.height = height;
        }
        /// <summary>
        /// constructor for a rectangle taking only the width measurement to draw a square, height is set to be equal to the width
        /// </summary>
        /// <param name="colour">colour of rectangle</param>
        /// <param name="fillType">is rectangle filled</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">width of rectangle</param>
        public Rectangle(Color colour, Boolean fillType, int x, int y, int width) : base(colour, fillType, x, y)
        {
            this.width = width;
            this.height = width;
        }
        /// <summary>
        /// Draws the rectangle on the specified graphics object
        /// </summary>
        /// <param name="g">graphics object to draw rectangle on</param>
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
        /// <summary>
        /// ToString override to include specific rectangle variables
        /// </summary>
        /// <returns>string of object information</returns>
        public override string ToString()
        {
            return shape+": "+base.ToString()+"  "+this.width+","+this.height;
        }
    }
}
