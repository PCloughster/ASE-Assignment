using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    /// <summary>
    /// Drawer is the class which contains all methods relating to graphics drawing
    /// </summary>
    public class Drawer
    {
        public Graphics graphics;
        public Point startingPosition;
        public Boolean isClear;

        Boolean fillMode;
        Point currentPosition;
        Point lastPosition;
        Pen pn;
        Shape shape;
        /// <summary>
        /// Constructor for the class which sets graphics area
        /// sets starting position, and pen 
        /// </summary>
        /// <param name="graphicsArea">pass in the graphics handle for the drawing area</param>
        public Drawer(IntPtr graphicsArea) {
            startingPosition = new Point(0, 0);
            currentPosition = startingPosition;
            pn = new Pen(Color.Blue, 2);
            isClear = true;
            SetGraphicsArea(graphicsArea);
        }
        /// <summary>
        /// constructor for if there is no graphics area currently available
        /// sets starting postion, and pen
        /// </summary>
        public Drawer()
        {
            startingPosition = new Point(0, 0);
            currentPosition = startingPosition;
            pn = new Pen(Color.Blue, 5);
            isClear = true;
        }
        /// <summary>
        /// setter for graphics area 
        /// </summary>
        /// <param name="graphicsArea">handle for form window to draw on</param>
        public void SetGraphicsArea(IntPtr graphicsArea)
        {
            graphics = Graphics.FromHwnd(graphicsArea);
        }
        /// <summary>
        /// Moves the cursor to specified coordinates
        /// </summary>
        /// <param name="x">X coordinate to move to</param>
        /// <param name="y">Y coordinate to move to</param>
        public void MoveTo(int x, int y)
        {
           Point targetPos = new Point(x, y);
           SetCurrentPosition(currentPosition, targetPos);
        }
        /// <summary>
        /// Moves the cursor to a new position and draws a line from the current position
        /// </summary>
        /// <param name="x">new X coordinate</param>
        /// <param name="y">new Y coordinate</param>
        public void DrawTo(int x, int y) 
        {
            Point targetPos = new Point(x, y);
            if (graphics != null)
            {
               graphics.DrawLine(pn, currentPosition, targetPos);
            }
            SetCurrentPosition(currentPosition, targetPos);
            if (isClear == true) { isClear = false; }
        }
        /// <summary>
        /// Clears the screen
        /// </summary>
        public void Clear()
        {
            if (graphics != null) { graphics.Clear(Color.White); }
            isClear = true;
        }
        /// <summary>
        /// Resets cursor position
        /// </summary>
        public void Reset()
        {
            lastPosition = currentPosition;
            currentPosition = startingPosition;
        }
        /// <summary>
        /// Draws a shape based on 2 sides, only accepts triangle and rectangle
        /// </summary>
        /// <param name="shapetype">Circle, Triangle or rectangle</param>
        /// <param name="width">width of shape</param>
        /// <param name="height">height of shape</param>
        public void DrawShape(string shapetype, int width, int height) 
        {
            if (shapetype == "triangle")
            {
                shape = new Triangle(Color.Blue, fillMode, currentPosition.X, currentPosition.Y, width, height);
                if (graphics != null) { shape.Draw(graphics); }
            }
            else if (shapetype == "rectangle")
            {
                 shape = new Rectangle(pn.Color, fillMode, currentPosition.X, currentPosition.Y, width, height);
                 if (graphics != null) { shape.Draw(graphics); }
            }
            else
            {
                
            }
        }
        /// <summary>
        /// Draws a shape based on 1 measurement, accepts rectangle, circle and triangle
        /// </summary>
        /// <param name="measurement">radius of circle, side length of rectangle, 2 equal sides length for triangle</param>
        public void DrawShape(string shapetype, int measurement)
        {
            if (shapetype == "rectangle")
            {
                shape = new Rectangle(pn.Color, fillMode, currentPosition.X, currentPosition.Y, measurement);
                if (graphics != null) { shape.Draw(graphics); }
            }
            else if (shapetype == "circle")
            {
                shape = new Circle(pn.Color, fillMode, currentPosition.X, currentPosition.Y, measurement);
                if (graphics != null) { shape.Draw(graphics); }
            }
            else if (shapetype == "triangle")
            {
                shape = new Triangle(Color.Blue, fillMode, currentPosition.X, currentPosition.Y, measurement, measurement);
                if (graphics != null) { shape.Draw(graphics); }
            }
        }
        /// <summary>
        /// Updates current position and stores last position
        /// </summary>
        /// <param name="curPos">current position</param>
        /// <param name="targetPos">next position</param>
        public void SetCurrentPosition(Point curPos, Point targetPos)
        { 
            lastPosition = curPos;
            currentPosition = targetPos;
        }
        /// <summary>
        /// returns current position
        /// </summary>
        /// <returns>returns current position as an integer array</returns>
        public int[] GetCurrentPosition()
        {
            int[] currentPositionArr = { currentPosition.X, currentPosition.Y }; 
            return currentPositionArr;
        }
        /// <summary>
        /// toggles current fill mode
        /// </summary>
        public void ToggleFill()
        {
            fillMode = !fillMode;
        }
        /// <summary>
        /// returns current fill mode
        /// </summary>
        /// <returns>fill mode boolean</returns>
        public Boolean GetFillMode()
        {
            return fillMode;
        }
        /// <summary>
        /// Sets pen colour returns  an invalid argument exception if colour unsupported
        /// </summary>
        /// <param name="colour">string containing colour name</param>
        /// <exception cref="ArgumentException">returned if colour name unsupported</exception>
        public void SetPenColour(string colour)
        {
            switch (colour)
            {
                case "red":
                    pn.Color = Color.Red;
                    break;
                case "blue":
                    pn.Color = Color.Blue;
                    break;
                case "green":
                    pn.Color = Color.Green;
                    break;
                case "pink":
                    pn.Color = Color.Pink;
                    break;
                case "orange":
                    pn.Color = Color.Orange;
                    break;
                case "yellow":
                    pn.Color = Color.Yellow;
                    break;
                case "purple":
                    pn.Color = Color.Purple;
                    break;
                default:
                    throw new ArgumentException("invalid colour parameter");
            }
        }
        /// <summary>
        /// Gets current pen colour
        /// </summary>
        /// <returns>current pen colour</returns>
        public string GetPenColour()
        {
            return pn.Color.ToString();
        }
        /// <summary>
        /// Gets the shape currently stored
        /// </summary>
        /// <returns>currently stored shape</returns>
        public Shape GetShape()
        {
            return shape;
        }
    }
}
