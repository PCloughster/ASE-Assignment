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

        Point currentPosition;
        Point lastPosition;
        Pen pn;
        public Drawer() {
            startingPosition = new Point(450, 475);
            currentPosition = new Point(450, 475);
            pn = new Pen(Color.Blue, 5);
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
            graphics.DrawLine(pn, currentPosition, targetPos);
            SetCurrentPosition(currentPosition, targetPos);
        }
        public void Clear()
        {
            graphics.Clear(Color.White);
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
    }
}
