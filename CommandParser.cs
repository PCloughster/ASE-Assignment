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
            if (ValidParams(parameters) == true && ValidCommand(command) == true)
            {
                SetLastCommand(line);
            }
        }
        public Boolean ValidParams(int[] parameters)
        {

            int parametersRequired = 2;
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
        public Boolean ValidCommand(string command)
        {
            return true;
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
