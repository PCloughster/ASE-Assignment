using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
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

        public Drawer(IntPtr graphicsArea) {
            startingPosition = new Point(0, 0);
            currentPosition = startingPosition;
            pn = new Pen(Color.Blue, 2);
            isClear = true;
            SetGraphicsArea(graphicsArea);
        }
        public Drawer()
        {
            startingPosition = new Point(0, 0);
            currentPosition = startingPosition;
            pn = new Pen(Color.Blue, 5);
            isClear = true;
        }
        public void SetGraphicsArea(IntPtr graphicsArea)
        {
            graphics = Graphics.FromHwnd(graphicsArea);
        }
        public void MoveTo(int x, int y)
        {
           Point targetPos = new Point(x, y);
           SetCurrentPosition(currentPosition, targetPos);
        }
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
        public void Clear()
        {
            if (graphics != null) { graphics.Clear(Color.White); }
            isClear = true;
        }
        public void Reset()
        {
            lastPosition = currentPosition;
            currentPosition = startingPosition;
        }
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
        public void SetCurrentPosition(Point curPos, Point targetPos)
        { 
            lastPosition = curPos;
            currentPosition = targetPos;
        }
        public int[] GetCurrentPosition()
        {
            int[] currentPositionArr = { currentPosition.X, currentPosition.Y }; 
            return currentPositionArr;
        }
        public void ToggleFill()
        {
            fillMode = !fillMode;
        }
        public Boolean GetFillMode()
        {
            return fillMode;
        }
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
        public string GetPenColour()
        {
            return pn.Color.ToString();
        }
        public Shape GetShape()
        {
            return shape;
        }
    }
}
