using ase_assignment;

namespace ASETests
{
    /// <summary>
    /// Class used to test command parser functionality
    /// </summary>
    [TestClass]
    public class CommandParserTests
    {
        /// <summary>
        /// Method used to confirm whether the ParseSingleCommand method is case sensitive
        /// </summary>
        [TestMethod]
        public void TestCaseSensitive_SingleCommand()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "MoVeTO 50,50";
            commandParser.ParseSingleCommand(userInput);

            Assert.AreEqual("moveto 50,50", commandParser.GetLastCommand());
        }
        /// <summary>
        /// Confirms whether  the user input is read correctly by the program by comparing it to the inital string
        /// </summary>
        [TestMethod]
        public void TestFunctional_MultiLine()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "moveto 50.50"+ Environment.NewLine+
                               "drawto 26,70"+ Environment.NewLine+
                               "clear";
            commandParser.ParseMultipleCommands(userInput);

            Assert.AreEqual(userInput, commandParser.GetLastProgram());
        }
        /// <summary>
        /// Test method which uses the SaveProgram method from command parser and then reads the file back to confirm whether it has been saved correctly
        /// </summary>
        [TestMethod]
        public void TestSave()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "moveto 50.50" + Environment.NewLine +
                               "drawto 26,70" + Environment.NewLine +
                               "clear";
            string[] commands = commandParser.ProgramArray(userInput);
            commandParser.SaveProgram("test1.txt", commands);
            string[] program = File.ReadAllLines("test1.txt");
            string lines = "";
            lines = string.Join(Environment.NewLine, program);
            Assert.AreEqual(lines, userInput);
            File.Delete("test1.txt");

        }
        /// <summary>
        /// Test method which saves a file then tests the LoadProgram method to see if the saved program is the same as the initial string
        /// </summary>
        [TestMethod]
        public void TestLoad()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "moveto 50.50" + Environment.NewLine +
                               "drawto 26,70" + Environment.NewLine +
                               "clear";
            string[] userInputA = userInput.Split(Environment.NewLine);
            userInputA = userInputA.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            File.WriteAllLines("test2.txt", userInputA);
            string loadedProgram = commandParser.LoadProgram("test2.txt");
            Assert.AreEqual(loadedProgram, userInput);
            File.Delete("test2.txt");

        }
        /// <summary>
        /// enters an invalid command to see if an error message is recieved
        /// </summary>
        [TestMethod]
        public void TestInvalidCommands()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "nonsense 1,1";
            commandParser.ParseSingleCommand(userInput);
            Assert.AreEqual("invalid command entered", commandParser.errorMessage);
        }
        /// <summary>
        /// enters out of scope parameter to confirm if an error message is recieved
        /// </summary>
        [TestMethod]
        public void TestInvalidParamaters()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "moveto 100000000 100000000";
            commandParser.ParseSingleCommand(userInput);
            Assert.AreEqual("Parameter falls outside of reasonable range(0-900)", commandParser.errorMessage);
        }
        [TestMethod]
        public void TestVariablesSave()
        {
            CommandParser commandParser = new CommandParser();
            string userInput = "a=100";

            commandParser.ParseSingleCommand(userInput);
            Assert.AreEqual(100, commandParser.variables["a"]);
        }
        [TestMethod]
        public void TestVariablesCanbeAdded()
        {
            CommandParser commandParser = new CommandParser();
            string userInput = "a=100";
            string userInput2 = "b=100+a";

            commandParser.ParseSingleCommand(userInput);
            commandParser.ParseSingleCommand(userInput2);
            Assert.AreEqual(200, commandParser.variables["b"]);
        }
    }
}