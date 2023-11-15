using ase_assignment;
using System.Drawing;

namespace ASETests
{
    [TestClass]
    public class DrawingUnitTests
    {
        [TestMethod]
        public void TestPenMoves()
        {
            Drawer drawer = new Drawer();

            drawer.MoveTo(50,50);
            int[] penCoordinates = drawer.GetCurrentPosition();
            int[] expectedCoordinates = {50,50};

            Assert.IsTrue(expectedCoordinates.SequenceEqual(penCoordinates));
        }
        [TestMethod]
        public void TestPenDraws()
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
        public void TestClearFunctions()
        {
            Drawer drawer = new Drawer();

            drawer.DrawTo(50, 50);
            drawer.Clear();

            Assert.IsTrue(drawer.isClear);
        }
        [TestMethod]
        public void TestResetFunctions()
        {
            Drawer drawer = new Drawer();

            int[] startingPosition = { 0, 0 };
            drawer.DrawTo(50, 50);
            drawer.Reset();
            int[] currentPosition = drawer.GetCurrentPosition();

            Assert.IsTrue(currentPosition.SequenceEqual(startingPosition));
        }
        [TestMethod]
        public void TestPenColourChange()
        {
            Drawer drawer = new Drawer();

            drawer.SetPenColour("black");
            string changedColour = drawer.GetPenColour();

            Assert.AreNotEqual("black", changedColour.ToLower());

        }

    }
}
