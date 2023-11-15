using ase_assignment;
using System.Drawing;
using System.Reflection.Metadata;
using Rectangle = ase_assignment.Rectangle;

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
        [TestMethod]
        public void TestFillToggles()
        {
            Drawer drawer = new Drawer();

            Boolean initialFillMode = drawer.GetFillMode();
            drawer.ToggleFill();
            Boolean finalFillMode = drawer.GetFillMode();

            Assert.AreNotEqual(initialFillMode, finalFillMode);
        }
        [TestMethod]
        public void TestRectangle()
        {
            Drawer drawer = new Drawer();
            Shape comparisonRectangle = new Rectangle(Color.Blue, false, 0, 0, 20, 20);

            drawer.DrawShape("rectangle", 20, 20);
            Shape actualRectangle = drawer.GetShape();
            string comparisonRectangleStr = comparisonRectangle.ToString();
            string actualRectangleStr = actualRectangle.ToString();
            Assert.AreEqual(comparisonRectangleStr, actualRectangleStr);
        }
        [TestMethod]
        public void TestCircle()
        {
            Drawer drawer = new Drawer();

            Shape comparisonCircle = new Circle(Color.Blue, false, 0, 0, 20);
            drawer.DrawShape("circle", 20);
            Shape actualCircle = drawer.GetShape();
            string comparisonCircleStr = comparisonCircle.ToString();
            string actualCircleStr = actualCircle.ToString();
            Assert.AreEqual(comparisonCircleStr, actualCircleStr);
        }
        [TestMethod]
        public void TestTriangle()
        {
            Drawer drawer = new Drawer();

            Shape comparisonTriangle = new Triangle(Color.Blue, false, 0, 0, 20, 20);
            drawer.DrawShape("triangle", 20);
            Shape actualTriangle = drawer.GetShape();
            string comparisonTriangleStr = comparisonTriangle.ToString();
            string actualTriangleStr = actualTriangle.ToString();
            Assert.AreEqual(comparisonTriangleStr, actualTriangleStr);
        }
    }
}
