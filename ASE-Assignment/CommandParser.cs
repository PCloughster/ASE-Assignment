using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ase_assignment
{
    public class CommandParser
    {
        public string? errorMessage;
        public string? errorLog;
        int upperLimit = 150;
        string[]? parametersStr;
        string? lastCommand;
        string? lastProgram;
        Boolean validCommand = true;

        public int CheckCommand(string command)
        {
            int parametersRequired = 0;
            switch (command)
            {
                case "moveto":
                    parametersRequired = 2;
                    break;
                case "drawto":
                    parametersRequired = 2;
                    break;
                case "clear":
                    parametersRequired = 0;
                    break;
                case "reset":
                    parametersRequired = 0;
                    break;
                case "pen":
                    parametersRequired = 1;
                    break;
                case "fill":
                    parametersRequired = 0;
                    break;
                default:
                    validCommand = false;
                    errorMessage = "invalid command entered";
                    break;
            }
            return parametersRequired;
        }
        public void ParseLine(string line, Boolean runCommand)
        {
            int[]? parameters;
            line = line.Trim().ToLower();
            string[] fullCommand = line.Split(' ');
            string command = fullCommand[0];
            if (fullCommand.Length == 2)
            {
                parametersStr = fullCommand[1].Split(',', '.');
                parameters = Array.ConvertAll(parametersStr, int.Parse);
            }
            else
            {
                parametersStr = fullCommand.Skip(1).ToArray();
                parameters = Array.ConvertAll(parametersStr, int.Parse);
            }
            CheckCommand(command);
            if (ValidParams(parameters, CheckCommand(command)) == true && validCommand== true)
            {
                if (runCommand == true)
                {
                    SetLastCommand(line);
                }
            }
            else
            {
                if (ValidParams(parameters, CheckCommand(command)) == false)
                {
                    throw new ArgumentOutOfRangeException(errorMessage);
                }
                if (validCommand == false)
                {
                    throw new ArgumentException(errorMessage);
                }
            }
        }
        public Boolean ValidParams(int[] parameters, int parametersRequired)
        {
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
                        if (parameter > upperLimit || parameter < 1)
                        {
                            errorMessage = "Parameter falls outside of reasonable range(1-" + upperLimit + ")";
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
        public void SaveProgram(string fileName, string[] currentProgram)
        {
            File.WriteAllLines(fileName, currentProgram);
        }
        public string LoadProgram(string programName)
        {
            string lines = "";
            string[] program = File.ReadAllLines(programName);
            lines = string.Join(Environment.NewLine, program);
            return lines;
        }
        public void ParseSingleCommand(string userInput)
        {
            ParseLine(userInput, true);
        }
        public void ParseMultipleCommands(string userInput)
        {
            string[] commands = ProgramArray(userInput);

            foreach (string command in commands)
            {
                ParseLine(command, true);
                SetLastProgram(userInput);
            }

        }
        public Boolean SyntaxCheckProgram(String program)
        {
            string[] commands = ProgramArray(program);
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
                    errorLog+=("Line " + i + ":" + errorMessage + Environment.NewLine);
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
        public string[] ProgramArray(string program)
        {
            string[] commandArray = program.Split(Environment.NewLine);
            commandArray = commandArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return commandArray;
        }
        public void SetLastProgram(string program)
        {
            lastProgram = program;
        }
        public string GetLastProgram()
        {
            return lastProgram;
        }
        public void SetLastCommand(string command)
        {
            lastCommand = command;
        }
        public string GetLastCommand()
        {
            return lastCommand;
        }
    }
}
