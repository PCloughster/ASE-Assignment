using ase_assignment;

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
            int[] expectedCoordinates = { 50, 50 };
            Assert.AreEqual(expectedCoordinates, penCoordinates);
        }
        [TestMethod]
        public void testPenDraws()
        {
            Drawer drawer = new Drawer();
            drawer.Clear();
            drawer.DrawTo(50, 50);
            Boolean isEmpty = drawer.graphics.IsClipEmpty;

            Assert.IsFalse(isEmpty);
        }
        [TestMethod]
        public void testClearFunctions()
        {
            Drawer drawer = new Drawer();
            drawer.DrawTo(50, 50);
            Boolean isEmpty = drawer.graphics.IsClipEmpty;

            Assert.IsTrue(isEmpty);
        }

    }
}
