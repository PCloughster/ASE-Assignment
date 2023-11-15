using ase_assignment;
using System.Drawing;

namespace ASETests
{
    [TestClass]
    public class DrawingUnitTests
    {
        [TestMethod]
        public void testPenMoves()
        {
            Drawer drawer = new Drawer();

            drawer.MoveTo(50,50);
            int[] penCoordinates = drawer.GetCurrentPosition();
            int[] expectedCoordinates = {50,50};

            Assert.IsTrue(expectedCoordinates.SequenceEqual(penCoordinates));
        }
        [TestMethod]
        public void testPenDraws()
        {
            Drawer drawer = new Drawer();

            drawer.Clear();
            drawer.DrawTo(50, 50);
            int[] penCoordinates = drawer.GetCurrentPosition();
            int[] expectedCoordinates = { 50, 50 };

            Assert.IsFalse(drawer.isClear);
            Assert.IsTrue(expectedCoordinates.SequenceEqual(penCoordinates));
        }
        [TestMethod]
        public void testClearFunctions()
        {
            Drawer drawer = new Drawer();

            drawer.DrawTo(50, 50);
            drawer.Clear();

            Assert.IsTrue(drawer.isClear);
        }
        [TestMethod]
        public void testResetFunctions()
        {
            Drawer drawer = new Drawer();

            int[] startingPosition = { 0, 0 };
            drawer.DrawTo(50, 50);
            drawer.Reset();
            int[] currentPosition = drawer.GetCurrentPosition();

            Assert.IsTrue(currentPosition.SequenceEqual(startingPosition));
        }

    }
}
