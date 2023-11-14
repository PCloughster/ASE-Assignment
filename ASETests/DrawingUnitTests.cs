using ase_assignment;

namespace ASETests
{
    [TestClass]
    public class DrawingUnitTests
    {
        [TestMethod]
        public void testPenMoves()
        {
            CommandParser commandParser = new CommandParser();
            Drawer drawer = new Drawer();

            commandParser.ParseSingleCommand("moveto 50,50");
            int[] penCoordinates = drawer.GetCurrentLocation();
            int[] expectedCoordinates = { 50, 50 };
            Assert.AreEqual(expectedCoordinates, penCoordinates);
        }

    }
}
