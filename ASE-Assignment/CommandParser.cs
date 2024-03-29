﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ase_assignment
{
    /// <summary>
    /// CommandParser contains all methods relating to interpreting commands from the user and relaying this information to the appropriate methods.
    /// </summary>
    public class CommandParser
    {
        public Dictionary<string, int> variables = new Dictionary<string, int>();
        public Dictionary<string, Method> methods = new Dictionary<string, Method>();
        public string? errorMessage;
        public string? errorLog;
        public bool isTest;
        int upperLimit;
        string[]? parametersStr;
        string? lastCommand;
        string? lastProgram;
        string[] currentProgram;
        Boolean validCommand;
        Boolean intParam;
        Drawer drawer;
        Boolean variableOveride = false;
        int lineNumber = 0;
        int blockCounter;
        Method method;
        IfStatement whileLoop;
        IfStatement ifStatement;
        string varName;
        List<string> methodBuffer = new List<string>();


        public CommandParser(Drawer drawer)
        {
            upperLimit = 900;
            validCommand = true;
            this.drawer = drawer;
            isTest = false;
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
            variableOveride = false;
            bool runCommandPrev;
            if (runCommand == true)
            {
                //this.drawer.DrawTo(100, 100);
                runCommandPrev = true;
            }
            else
            {
                runCommandPrev = false;
            }

            if (blockCounter != 0) { runCommand = false; }
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
                    variableOveride = true;
                    intParam = true;
                    parametersRequired = 0;

                    if (runCommandPrev == true)
                    {
                        if (blockCounter == 1)
                        {
                            ifStatement = new IfStatement(currentProgram, lineNumber);
                            string condition = currentProgram[lineNumber - 1];
                            string[] condArray = condition.Split(" ");
                            ifStatement.SetCondition(PullVariable(condArray));
                        }
                    }
                    else
                    {
                        string condition = currentProgram[lineNumber - 1];
                        string[] condArray = condition.Split(" ");
                        condArray[2] = condArray[2].Trim().ToLower();
                        if (condArray.Length != 4)
                        {
                            validCommand = false;
                            errorMessage = "incorrect number of parameters for a condition provided";
                            break;
                        }
                        else if (condArray[2] != "==" && condArray[2] != "!=" && condArray[2] != ">" && condArray[2] != "<")
                        {
                            validCommand = false;
                            errorMessage = "invalid condition provided: " + condArray[2];
                            break;
                        }
                    }
                    break;
                //blockCounter = ifStatement.counter;
                // get line that command starts on 
                // store line in something like LanguageCommands.setStartLine
                // have a counter to account for nesting loops for example for every if statement detected add 1 to counter and for every endif detected -1 only when counter is 0 record the line number the loop ends on
                case "endif":
                    intParam = false;
                    variableOveride = true;
                    if (blockCounter <= -1)
                    {
                        validCommand = false;
                        errorMessage = "if end present but no beginning";
                        break;
                    }
                    else
                    {
                        if (blockCounter == 0 && ifStatement != null)
                        {
                            //this.drawer.DrawTo(100, 100);
                            ifStatement.SetEndLine(lineNumber);
                            ifStatement.RecordPharase();
                            string phrase = ifStatement.ReturnPhrase();
                            
                            if (ifStatement.CheckCondition() == true)
                            {
                                ParseMultipleCommands(phrase);
                            }
                            ifStatement = null;
                            break;
                            //ParseMultipleCommands("drawto 500 500");
                            //if (runCommandPrev == true && ifStatement.CheckCondition() == true) { ParseMultipleCommands("drawto 500 500"); }
                            
                        }
                    }
                    break;
                case "loop":
                    variableOveride = true;
                    intParam = true;
                    parametersRequired = 0;

                    if (runCommandPrev == true)
                    {
                        if (blockCounter == 1)
                        {
                            whileLoop = new IfStatement(currentProgram, lineNumber);
                            string condition = currentProgram[lineNumber - 1];
                            whileLoop.conditionRaw = condition;
                            string[] condArray = whileLoop.conditionRaw.Split(" ");
                            varName = condArray[1];
                        }
                    }
                    else
                    {
                        string condition = currentProgram[lineNumber - 1];
                        string[] condArray = condition.Split(" ");
                        condArray[2] = condArray[2].Trim().ToLower();
                        if (condArray.Length != 4)
                        {
                            validCommand = false;
                            errorMessage = "incorrect number of parameters for a condition provided";
                            break;
                        }
                        else if (condArray[2] != "==" && condArray[2] != "!=" && condArray[2] != ">" && condArray[2] != "<")
                        {
                            validCommand = false;
                            errorMessage = "invalid condition provided: " + condArray[2];
                            break;
                        }
                    }
                    break;
                case "endloop":
                    intParam = false;
                    variableOveride = true;
                    if (blockCounter <= -1)
                    {
                        validCommand = false;
                        errorMessage = "loop end present but no beginning";
                        break;
                    }
                    else
                    {
                        if (blockCounter == 0 && whileLoop != null)
                        {
                            whileLoop.SetEndLine(lineNumber);
                            whileLoop.RecordPharase();
                            string phrase = whileLoop.ReturnPhrase();
                            string[] condArray = whileLoop.conditionRaw.Split(" ");
                            whileLoop.SetCondition(PullVariable(condArray));



                            bool loopCheck = whileLoop.CheckCondition();
                            while (loopCheck == true)
                            {
                                ParseMultipleCommands(phrase);
                                condArray[1] = varName;
                                whileLoop.SetCondition(PullVariable(condArray));
                                loopCheck = whileLoop.CheckCondition();
                            }
                            whileLoop = null;
                            break;
                        }
                    }
                    break;
                case "method":
                    variableOveride = true;
                    intParam = false;
                    parametersRequired = 0;

                    if (runCommandPrev == true)
                    {
                        if (blockCounter == 1)
                        {
                            method = new Method(currentProgram, lineNumber);
                        }
                    }
                    else
                    {
                        methodBuffer.Add(parametersStr[0]);
                    }
                    break;
                case "endmethod":
                    intParam = false;
                    variableOveride = true;
                    if (blockCounter <= -1)
                    {
                        validCommand = false;
                        errorMessage = "method end present but no beginning";
                        break;
                    }
                    else
                    {
                        if (blockCounter == 0 && method != null)
                        {
                            method.SetEndLine(lineNumber);
                            method.RecordPharase();
                            string phrase = method.ReturnPhrase();
                            method.phrase = phrase;
                            if (methods.ContainsKey(method.name))
                            {
                                methods[method.name] = method;
                            }
                            else
                            {
                                methods.Add(method.name, method);
                            }
                            method = null;
                            break;
                        }
                    }
                    break;
                default:
                    if (line.Contains("==") || line.Contains("!="))
                    {
                        validCommand = false;
                        errorMessage = "invalid command entered";
                        break;
                    }
                    else if (line.Contains("="))
                    {
                        variableOveride = true;
                        parametersRequired = 0;
                        intParam = true;
                        string[] commandArray;
                        string[] operation;
                        int value;
                        string trimmedLine = line.Replace(" ", "");
                        commandArray = trimmedLine.Split('=');
                        if (commandArray.Length == 2)
                        {
                            commandArray[1] = commandArray[1].ToLower().Trim();
                            if (commandArray[1].Contains("+"))
                            {
                                operation = commandArray[1].Split("+");
                                operation = PullVariable(operation);
                                if (operation.Length < 2)
                                {
                                    errorMessage = "Operator included but only one argument provided";
                                    validCommand = false;
                                    break;
                                }
                                else if (operation.Length == 2)
                                {
                                    try
                                    {
                                        value = int.Parse(operation[0]) + int.Parse(operation[1]);
                                    }
                                    catch 
                                    {
                                        validCommand = false;
                                        errorMessage = "invalid arguments for attempted operation";
                                        break;
                                    }
                                }
                                else
                                {
                                    errorMessage = "Only two arguments supported by operators at this time";
                                    validCommand = false;
                                    break;
                                }
                            }
                            else if (commandArray[1].Contains("-"))
                            {
                                operation = commandArray[1].Split("-");
                                operation = PullVariable(operation);
                                if (operation.Length < 2)
                                {
                                    errorMessage = "Operator included but only one argument provided";
                                    validCommand = false;
                                    break;
                                }
                                else if (operation.Length == 2)
                                {
                                    try
                                    {
                                        value = int.Parse(operation[0]) - int.Parse(operation[1]);
                                    }
                                    catch
                                    {
                                        validCommand = false;
                                        errorMessage = "invalid arguments for attempted operation";
                                        break;
                                    }
                                }
                                else
                                {
                                    errorMessage = "Only two arguments supported by operators at this time";
                                    validCommand = false;
                                    break;
                                }
                            }
                            else if (commandArray[1].Contains("*"))
                            {
                                operation = commandArray[1].Split("*");
                                operation = PullVariable(operation);
                                if (operation.Length < 2)
                                {
                                    errorMessage = "Operator included but only one argument provided";
                                    validCommand = false;
                                    break;
                                }
                                else if (operation.Length == 2)
                                {
                                    try
                                    {
                                        value = int.Parse(operation[0]) * int.Parse(operation[1]);
                                    }
                                    catch
                                    {
                                        validCommand = false;
                                        errorMessage = "invalid arguments for attempted operation";
                                        break;
                                    }
                                }
                                else
                                {
                                    errorMessage = "Only two arguments supported by operators at this time";
                                    validCommand = false;
                                    break;
                                }
                            }
                            else if (commandArray[1].Contains("/"))
                            {
                                operation = commandArray[1].Split("/");
                                operation = PullVariable(operation);
                                if (operation.Length < 2)
                                {
                                    errorMessage = "Operator included but only one argument provided";
                                    validCommand = false;
                                    break;
                                }
                                else if (operation.Length == 2)
                                {
                                    try
                                    {
                                        value = int.Parse(operation[0]) / int.Parse(operation[1]);
                                    }
                                    catch
                                    {
                                        validCommand = false;
                                        errorMessage = "invalid arguments for attempted operation";
                                        break;
                                    }
                                }
                                else
                                {
                                    errorMessage = "Only two arguments supported by operators at this time";
                                    validCommand = false;
                                    break;
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (variables.ContainsKey(commandArray[1]))
                                    {
                                        value = variables[commandArray[1]];
                                    }
                                    else
                                    {
                                        value = int.Parse(commandArray[1]);
                                    }
                                }
                                catch
                                {
                                    validCommand = false;
                                    errorMessage = "invalid integer or operation provided, cannot assign variable";
                                    break;
                                }
                            }
                            if (blockCounter == 0)
                            {
                                if (variables.ContainsKey(commandArray[0]))
                                {
                                    if (runCommandPrev == true)
                                    {
                                        variables[commandArray[0]] = value;
                                    }
                                }
                                else
                                {
                                    variables.Add(commandArray[0].Trim().ToLower(), value);
                                }
                            }
                            break;
                        }
                        else
                        {
                            validCommand = false;
                            errorMessage = "variable assignment attempted with too many parameters";
                            break;
                        }
                    }
                    else if (methods.ContainsKey(command) || methodBuffer.Contains(command))
                    {
                        if (methods.ContainsKey(command) != true)
                        {
                            break;
                        }
                        else
                        {
                            ParseMultipleCommands(methods[command].phrase);
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
            line = line.Trim().ToLower();
            string[] fullCommand = line.Split(' ');
            string command = fullCommand[0];
            if (drawer == null && isTest== false)
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
            if (command == "if" || command == "method" || command == "loop")
            {
                blockCounter = blockCounter + 1;
            }
            else if (command == "endif" || command == "endmethod" || command == "endloop")
            {
                blockCounter = blockCounter - 1;
            }
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
            if (variableOveride == true)
            {
                //variableOveride = false;
                return true;
            }
            else if (intParam == true)
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
            //SetCurrentProgram(commands);
            lineNumber = 0;
            blockCounter = 0;
            foreach (string command in commands)
            {
                lineNumber++;
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
            lineNumber = 0;
            blockCounter = 0;
            foreach (string command in commands)
            {
                lineNumber++;
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
            variables.Clear();
            if (errors > 0)
            {
                return false;
            }
            else {
                return true; 
            }

            
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
