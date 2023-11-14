using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    public class CommandParser
    {
        public string? errorMessage;
        int upperLimit = 150;
        string[]? parametersStr;
        string? lastCommand;
        Boolean validCommand;

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
                    parametersRequired = 0;
                    break;
                case "fill":
                    parametersRequired = 0;
                    break;
                default:
                    validCommand = false;
                    break;
            }
            if (validCommand != false)
            {
                validCommand = true;
                errorMessage = "invalid command entered";
            } 
            return parametersRequired;
        }
        public void ParseLine(string line)
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
            if (ValidParams(parameters, CheckCommand(command)) == true && validCommand== true)
            {
                SetLastCommand(line);
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
        public void ParseSingleCommand(string userInput)
        {
            ParseLine(userInput);
        }
        public void ParseMultipleCommands(string userInput)
        {

        }
        public void SetLastCommand(string command)
        {
            lastCommand = command;
        }
        public String GetLastCommand()
        {
            return lastCommand;
        }
    }
}
