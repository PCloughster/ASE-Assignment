using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ase_assignment
{
    /// <summary>
    /// CommandParser contains all methods relating to interpreting commands from the user and relaying this information to the appropriate methods.
    /// </summary>
    public class CommandParser
    {
        Dictionary<string, int> variables = new Dictionary<string, int>();
        public string? errorMessage;
        public string? errorLog;
        int upperLimit;
        string[]? parametersStr;
        string? lastCommand;
        string? lastProgram;
        string[] currentProgram;
        Boolean validCommand;
        Boolean intParam;
        Drawer drawer;

        public CommandParser(Drawer drawer)
        {
            upperLimit = 900;
            validCommand = true;
            this.drawer = drawer;
        }
        public CommandParser()
        {
            upperLimit = 900;
            validCommand = true;
        }
        /// <summary>
        /// the CheckCommand method is used both to check command validity and call upon the Drawer class to execute the commands.
        /// </summary>
        /// <param name="command">command to be checked or run</param>
        /// <param name="runCommand">if false commands are only syntaxed checked and not run</param>
        /// <param name="parametersStr">parameters string from user input</param>
        /// <returns></returns>
        public int CheckCommand(string command, bool runCommand, string[] parametersStr, string line)
        {
            int[] parameters;
            int parametersRequired = 0;
            validCommand = true;
            switch (command)
            {
                case "moveto":
                    if (intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); }
                    if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse);  this.drawer.MoveTo(parameters[0], parameters[1]); }
                    parametersRequired = 2;
                    intParam = true;
                    break;
                case "drawto":
                    if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.DrawTo(parameters[0], parameters[1]); }
                    parametersRequired = 2;
                    intParam = true;
                    break;
                case "clear":
                    if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.Clear(); }
                    parametersRequired = 0;
                    intParam = true;
                    break;
                case "reset":
                    if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.Reset(); }
                    parametersRequired = 0;
                    intParam = true;
                    break;
                case "pen":
                    if (runCommand == true) { this.drawer.SetPenColour(parametersStr[0]); }
                    parametersRequired = 1;
                    intParam = false;
                    break;
                case "fill":
                    if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.ToggleFill(); }
                    parametersRequired = 0;
                    intParam = true;
                    break;
                case "triangle":
                    intParam = true;
                    if (parametersStr.Length == 2)
                    {
                        if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.DrawShape("triangle", parameters[0], parameters[1]); }
                        parametersRequired = 2;
                    }
                    else if (parametersStr.Length == 1)
                    {
                        if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.DrawShape("triangle", parameters[0]); }
                        parametersRequired = 1;
                    }
                    break;
                case "rectangle":
                    intParam = true;
                    if (parametersStr.Length == 2)
                    {
                        if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.DrawShape("rectangle", parameters[0], parameters[1]); }
                        parametersRequired = 2;
                    }
                    else if (parametersStr.Length == 1)
                    {
                        if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.DrawShape("rectangle", parameters[0]); }
                        parametersRequired = 1;
                    }
                    break;
                case "circle":
                    if (runCommand == true && intParam == true) { parameters = Array.ConvertAll(parametersStr, int.Parse); this.drawer.DrawShape("circle", parameters[0]); }
                    parametersRequired = 1;
                    intParam = true;
                    break;
                case "if":
                    intParam = true;
                    // get line that command starts on 
                    // store line in something like LanguageCommands.setStartLine
                    // have a counter to account for nesting loops for example for every if statement detected add 1 to counter and for every endif detected -1 only when counter is 0 record the line number the loop ends on
                    break;
                case "endif":
                    intParam = true;
                    // get line this happens on then store the line this ends on
                    break;
                case "loop":
                    intParam = true;

                    break;
                case "endloop":
                    intParam = true;

                    break;
                case "method":
                    intParam = true;
                    .

                    break;
                case "endmethod":
                    intParam = true;

                    break;
                default:
                    // we can put some bullshit here to parse the variable assignment
                    // so like if line contains an = sign then do setting the variable shouldn't be too fucking hard 
                    // if line contains = take line, split at = sign [0] is name and [1] is value, save to dictionary

                    if (line.Contains("="))
                    {
                        intParam = true;
                        string[] commandArray;
                        string[] operation;
                        commandArray = line.Split('=');
                        if (commandArray.Length == 2)
                        {

                            if (commandArray[1].Contains("+"))
                            {
                                operation = commandArray[1].Split("+");
                            }
                            else if (commandArray[1].Contains("-"))
                            {

                            }
                            else if (commandArray[1].Contains("*"))
                            {

                            }
                            else if (commandArray[1].Contains("/"))
                            {

                            }
                            else
                            {

                            }
                            if (variables.ContainsKey(commandArray[0])){
                                variables[commandArray[0]] = int.Parse(commandArray[1]);
                            }
                            else
                            {
                                variables.Add(commandArray[0].Trim().ToLower(), int.Parse(commandArray[1]));
                            }
                            // add item to dictionary commandArray[0] name commandArray[1] value
                            validCommand = true;
                            break;
                        }
                        else
                        {
                            validCommand = false;
                            errorMessage = "variable assignment attempted with too many parameters";
                            break;
                        }
                    }
                    else
                    {
                        validCommand = false;
                        errorMessage = "invalid command entered";
                        break;
                    }
            }
            return parametersRequired;
        }
        /// <summary>
        /// ParseLine is used to parse a line of user input, format the data and pass it to ValidParams and CheckCommand for testing. Once the line is confirmed as valid the method will pass the line back to CheckCommand for it to be ran.
        /// </summary>
        /// <param name="line">full command line to parse</param>
        /// <param name="runCommand">boolean that determines whether the line needs to be ran</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if parameters themselves are invalid</exception>
        /// <exception cref="ArgumentException">Thrown if command isn't recognised</exception>
        public void ParseLine(string line, Boolean runCommand)
        {
            intParam = false;
            int x = 0;
            line = line.Trim().ToLower();
            string[] fullCommand = line.Split(' ');
            string command = fullCommand[0];
            if (drawer == null)
            {
                runCommand = false;
            }
            if (fullCommand.Length == 2)
            {
                parametersStr = PullVariable(fullCommand[1].Split(',', '.'));
            }
            else
            {
                parametersStr = PullVariable(fullCommand.Skip(1).ToArray());
            }
            CheckCommand(command, false, parametersStr, line);
            if (ValidParams(parametersStr, CheckCommand(command, false, parametersStr, line)) == true && validCommand == true)
            {
                SetLastCommand(line);
                if (runCommand == true)
                {
                    CheckCommand(command, true, parametersStr, line);
                }
            }
            else
            {
                if (ValidParams(parametersStr, CheckCommand(command, false, parametersStr, line)) == false)
                {
                    throw new ArgumentOutOfRangeException(errorMessage);
                }
                if (validCommand == false)
                {
                    throw new ArgumentException(errorMessage);
                }
            }
        }

        // replaces all instances of a variable in a string collection with the int the variable corresponds with
        public string[] PullVariable(string[] parametersStr)
        {
            int x = 0;
            foreach (string param in parametersStr)
            {
                if (variables.ContainsKey(param))
                {
                    parametersStr[x] = variables[param].ToString();
                }
                x++;
            }
            return parametersStr;
        }
        /// <summary>
        /// Confirms if parameters are valid for a command and saves an error message to errorMessage if required
        /// </summary>
        /// <param name="parametersStr">Parameters passed into method</param>
        /// <param name="parametersRequired">integer containing number of parameters required by the command</param>
        /// <returns>true or false to confirm if parameters are valid</returns>
        public Boolean ValidParams(string[] parametersStr, int parametersRequired)
        {
            int[] parameters;
            if (intParam == true)
            {
                try
                {
                    parameters = Array.ConvertAll(parametersStr, int.Parse);
                }
                catch (Exception)
                {
                    errorMessage = "INT Parameters required, recieved string";
                    return false;
                }
                if (parametersRequired > 0)
                {
                    if (parameters == null)
                    {
                        errorMessage = "No parameters provided, required paramters = " + parametersRequired;
                        return false;
                    }
                    else if (parameters.Length == parametersRequired)
                    {
                        foreach (int parameter in parameters)
                        {
                            if (parameter > upperLimit || parameter < 0)
                            {
                                errorMessage = "Parameter falls outside of reasonable range(0-" + upperLimit + ")";
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        errorMessage = "Invalid number of parameters provided for this command, required paramters = " + parametersRequired;
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (parametersRequired > 0)
                {
                    if (parametersStr == null)
                    {
                        errorMessage = "No parameters provided, required paramters = " + parametersRequired;
                        return false;
                    }
                    else if (parametersStr.Length == parametersRequired)
                    {
                        return true;
                    }
                    else
                    {
                        errorMessage = "Invalid number of parameters provided for this command, required paramters = " + parametersRequired;
                        return false;
                    }
                }
                else { return true; }
            }
        }
        /// <summary>
        /// writes the program from array form to a file
        /// </summary>
        /// <param name="fileName">file the program is saved in</param>
        /// <param name="currentProgram">array containing each line of the current program</param>
        public void SaveProgram(string fileName, string[] currentProgram)
        {
            File.WriteAllLines(fileName, currentProgram);
        }
        /// <summary>
        /// Loads program from .txt file to the current window
        /// </summary>
        /// <param name="programName">file name for saved program</param>
        /// <returns>full program as a string</returns>
        public string LoadProgram(string programName)
        {
            string lines = "";
            string[] program = File.ReadAllLines(programName);
            lines = string.Join(Environment.NewLine, program);
            return lines;
        }
        /// <summary>
        /// Clears the error log then parses the single command input by the user
        /// </summary>
        /// <param name="userInput"></param>
        public void ParseSingleCommand(string userInput)
        {
            errorLog = "";
            try
            {
                ParseLine(userInput, true);
            }
            catch (Exception e)
            {
                errorLog += (e + errorMessage + Environment.NewLine);
            }
        }
        /// <summary>
        /// Parses program from multi-line window and sets last run program
        /// </summary>
        /// <param name="userInput">string containing all instructions</param>
        public void ParseMultipleCommands(string userInput)
        {
            string[] commands = ProgramArray(userInput);
            SetCurrentProgram(commands);
            foreach (string command in commands)
            {
                ParseLine(command, true);
                SetLastProgram(userInput);
            }

        }

        public void SetCurrentProgram(string[] program)
        {
            currentProgram = program;
        }
        public string[] GetCurrentProgram()
        {
            return currentProgram;
        }
        /// <summary>
        /// method which checks the syntax of a program passed to it without running any commands
        /// </summary>
        /// <param name="program">string containing the program</param>
        /// <returns></returns>
        public Boolean SyntaxCheckProgram(String program)
        {
            string[] commands = ProgramArray(program);
            SetCurrentProgram(commands);
            errorLog = "";
            int i = 1;
            int errors = 0;
            foreach (string command in commands)
            {
                try
                {
                    ParseLine(command, false);
                }
                catch (Exception)
                {
                    errorLog+=("Line " + i + ": " + errorMessage + Environment.NewLine);
                    errors++;
                }
                i++;
            }
            if (errors > 0)
            {
                return false;
            }
            else { return true; }
        }
        /// <summary>
        /// Converts the program string to an array 
        /// </summary>
        /// <param name="program">program string input</param>
        /// <returns>program array output</returns>
        public string[] ProgramArray(string program)
        {
            string[] commandArray = program.Split(Environment.NewLine);
            commandArray = commandArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return commandArray;
        }
        /// <summary>
        /// sets a string to contain the last program to be run
        /// </summary>
        /// <param name="program">last program run</param>
        public void SetLastProgram(string program)
        {
            lastProgram = program;
        }
        /// <summary>
        /// Returns the last program run
        /// </summary>
        /// <returns>last run program</returns>
        public string GetLastProgram()
        {
            return lastProgram;
        }
        /// <summary>
        /// sets the last command run to the string input
        /// </summary>
        /// <param name="command">command to set as last command</param>
        public void SetLastCommand(string command)
        {
            lastCommand = command;
        }
        /// <summary>
        /// primarily used for testing returns last run command
        /// </summary>
        /// <returns></returns>
        public string GetLastCommand()
        {
            return lastCommand;
        }
        /// <summary>
        /// sets the drawrer object to be used if not already defined
        /// </summary>
        /// <param name="drawer">drawer object to be used</param>
        public void SetDrawer(Drawer drawer)
        {
            this.drawer = drawer; 
        }
    }
}
