using ase_assignment;

namespace ASETests
{
    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void TestCaseSensitive_SingleCommand()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "MoVeTO 50,50";
            commandParser.ParseSingleCommand(userInput);

            Assert.AreEqual("moveto 50,50", commandParser.GetLastCommand());
        }
        [TestMethod]
        public void TestFunctional_MultiLine()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "moveto 50.50"+ Environment.NewLine+
                               "drawto 26,70"+ Environment.NewLine+
                               "clear";
            commandParser.ParseMultipleCommands(userInput, commandParser.SyntaxCheckProgram(userInput));

            Assert.AreEqual(userInput, commandParser.GetLastProgram());
        }

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
        [TestMethod]
        public void TestInvalidCommands()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "nonsense 1,1";
            commandParser.ParseSingleCommand(userInput);
            Assert.AreEqual("invalid command entered", commandParser.errorMessage);
        }
        [TestMethod]
        public void TestInvalidParamaters()
        {
            CommandParser commandParser = new CommandParser();

            string userInput = "moveto 100000000 100000000";
            commandParser.ParseSingleCommand(userInput);
            Assert.AreEqual("Parameter falls outside of reasonable range(0-900)", commandParser.errorMessage);
        }

    }
}