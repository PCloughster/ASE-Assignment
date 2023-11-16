using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ase_assignment
{
    /// <summary>
    /// Class for the Triangle object, inherits from Shape.cs
    /// </summary>
    public class Triangle : Shape
    {
        int side1;
        int side2;
        string shape = "triangle";
        /// <summary>
        /// constructor for a right-angled triangle taking two side measurements
        /// </summary>
        /// <param name="colour">colour of triangle</param>
        /// <param name="fillType">is triangle filled</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="side1">side1 length</param>
        /// <param name="side2">side2 length</param>
        public Triangle(Color colour, Boolean fillType, int x, int y, int side1, int side2) : base(colour, fillType, x, y)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
        /// <summary>
        /// constructor for a right-angled triangle taking one side measurements
        /// 
        /// side2 length is set to side1 length to keep the rest of the class the same
        /// </summary>
        /// <param name="colour">colour of triangle</param>
        /// <param name="fillType">is triangle filled</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="side1">side1 length</param>
        public Triangle(Color colour, Boolean fillType, int x, int y, int side1) : base(colour, fillType, x, y)
        {
            this.side1 = side1;
            this.side2 = side1;
        }
        /// <summary>
        /// generates the vertices of the triangle from the provided coordinates and sides
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        /// <param name="side1">added to X coordinate to generate second vertex</param>
        /// <param name="side2">added to Y coordinate to generate third vertex</param>
        /// <returns>vertices of the triangle</returns>
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
        /// <summary>
        /// Draws the triangle on the specified graphics object
        /// </summary>
        /// <param name="g">graphics object to draw triangle on</param>
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
        /// <summary>
        /// ToString override to include specific triangle variables
        /// </summary>
        /// <returns>string of object information</returns>
        public override string ToString()
        {
            return shape+": "+base.ToString() + "  " + this.side1 + this.side2;
        }
    }
}
