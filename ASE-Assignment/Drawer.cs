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
        Point startingPosition;
        Point currentPosition;
        Point lastPosition;
        public Graphics graphics;
        Pen pn;
        public Drawer() {
            startingPosition = new Point(450, 475);
            currentPosition = new Point(450, 475);
            pn = new Pen(Color.Blue, 5);
        }
        public void setGraphicsArea(IntPtr graphicsArea)
        {
            graphics = Graphics.FromHwnd(graphicsArea);
            
        }
        public void MoveTo(int x, int y)
        {
            
        }
        public void DrawTo(int x, int y) 
        {

        }
        public void Clear()
        {

        }
        public void reset()
        {

        }
        public void pen(string colour)
        {

        }
        public void SetCurrentPosition(Point currentPosition, Point targetPos)
        {
            lastPosition = currentPosition;
            currentPosition = targetPos
        }
        public int[] GetCurrentPosition()
        {
            int[] currentPositionArr = {currentPosition.X, currentPosition.Y}; 
            return currentPositionArr;
        }
        public Boolean FillMode()
        {
            return false;
        }
    }
}
