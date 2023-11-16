using ase_assignment;
using System.Drawing;
using System.Reflection.Metadata;
using Rectangle = ase_assignment.Rectangle;

namespace ASETests
{
    /// <summary>
    /// Class used to test Drawer and Shape class functionality
    /// </summary>
    [TestClass]
    public class DrawingUnitTests
    {
        /// <summary>
        /// Tests the MoveTo method by confirming that the coordinates are updated as expected
        /// </summary>
        [TestMethod]
        public void TestPenMoves()
        {
            Drawer drawer = new Drawer();

            drawer.MoveTo(50,50);
            int[] penCoordinates = drawer.GetCurrentPosition();
            int[] expectedCoordinates = {50,50};

            Assert.IsTrue(expectedCoordinates.SequenceEqual(penCoordinates));
        }
        /// <summary>
        /// Tests the DrawTo method by confirming if canvas is still clear and if the coordinates have updated as expected
        /// </summary>
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
        /// <summary>
        /// Tests the clear method by drawing, clearing, and then confirming if the canvas is clear
        /// </summary>
        [TestMethod]
        public void TestClearFunctions()
        {
            Drawer drawer = new Drawer();

            drawer.DrawTo(50, 50);
            drawer.Clear();

            Assert.IsTrue(drawer.isClear);
        }
        /// <summary>
        /// Tests the reset method by moving, then reseting and confirming if coordinates match the starting position
        /// </summary>
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
        /// <summary>
        /// Tests the SetPenColour method by changing the pen colour and confirming the changed colour isn't the same as the initial one
        /// </summary>
        [TestMethod]
        public void TestPenColourChange()
        {
            Drawer drawer = new Drawer();

            drawer.SetPenColour("black");
            string changedColour = drawer.GetPenColour();

            Assert.AreNotEqual("black", changedColour.ToLower());

        }
        /// <summary>
        /// Tests ToggleFill method by recording initial toggle boolean, toggling and then asserting not equal
        /// </summary>
        [TestMethod]
        public void TestFillToggles()
        {
            Drawer drawer = new Drawer();

            Boolean initialFillMode = drawer.GetFillMode();
            drawer.ToggleFill();
            Boolean finalFillMode = drawer.GetFillMode();

            Assert.AreNotEqual(initialFillMode, finalFillMode);
        }
        /// <summary>
        /// Tests DrawShape by constructing a rectangle to the desired specifications, running drawshape with the same specifications and comparing results
        /// </summary>
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
        /// <summary>
        /// Tests DrawShape by constructing a circle to the desired specifications, running drawshape with the same specifications and comparing results
        /// </summary>
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
        /// <summary>
        /// Tests DrawShape by constructing a triangle to the desired specifications, running drawshape with the same specifications and comparing results
        /// </summary>
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
