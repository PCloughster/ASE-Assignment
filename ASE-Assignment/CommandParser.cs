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
        int upperLimit;
        string[]? parametersStr;
        string? lastCommand;
        string? lastProgram;
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
        public int CheckCommand(string command, bool runCommand, string[] parametersStr)
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
                default:
                    validCommand = false;
                    errorMessage = "invalid command entered";
                    break;
            }
            return parametersRequired;
        }
        public void ParseLine(string line, Boolean runCommand)
        {
            intParam = false;
            int[]? parameters;
            line = line.Trim().ToLower();
            string[] fullCommand = line.Split(' ');
            string command = fullCommand[0];
            if (drawer == null)
            {
                runCommand = false;
            }
            if (fullCommand.Length == 2)
            {
                parametersStr = fullCommand[1].Split(',', '.');
            //    parameters = Array.ConvertAll(parametersStr, int.Parse);
            }
            else
            {
                parametersStr = fullCommand.Skip(1).ToArray();
            //    parameters = Array.ConvertAll(parametersStr, int.Parse);
            }
            CheckCommand(command, false, parametersStr);
            if (ValidParams(parametersStr, CheckCommand(command, false, parametersStr)) == true && validCommand == true)
            {
                SetLastCommand(line);
                if (runCommand == true)
                {
                    CheckCommand(command, true, parametersStr);
                }
            }
            else
            {
                if (ValidParams(parametersStr, CheckCommand(command, false, parametersStr)) == false)
                {
                    throw new ArgumentOutOfRangeException(errorMessage);
                }
                if (validCommand == false)
                {
                    throw new ArgumentException(errorMessage);
                }
            }
        }
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
        public void ParseMultipleCommands(string userInput, Boolean syntaxCheck)
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
        public void SetDrawer(Drawer drawer)
        {
            this.drawer = drawer; 
        }
    }
}
