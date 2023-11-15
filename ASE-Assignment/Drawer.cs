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

        Point currentPosition;
        Point lastPosition;
        Pen pn;
        
        public Drawer(IntPtr graphicsArea) {
            startingPosition = new Point(0, 0);
            currentPosition = startingPosition;
            pn = new Pen(Color.Blue, 5);
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
        public void Pen(string colour)
        {

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
        public Boolean FillMode()
        {
            return false;
        }
        public void SetPenColour(string colour)
        {
            pn.Color = Color.FromName(colour);
        }
        public string GetPenColour()
        {
            return pn.Color.ToString();
        }
    }
}
