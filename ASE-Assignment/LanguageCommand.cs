using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace ase_assignment
{
    public abstract class LanguageCommand : Object
    {
        int startLine;
        int endLine;
        public int counter = 0;
        string[] phrase;
        string[] program;
        public LanguageCommand(string[] program, int startLine)
        {
            this.program = program;
            this.startLine = startLine - 1;
        }
        
        public void RecordPharase()
        {
            startLine += 1;
            endLine = endLine - 1;
            phrase = program[startLine..endLine];
        }
        public string ReturnPhrase()
        {
            string lines = string.Join(Environment.NewLine, phrase);
            return lines;
        }
        public void SetStartLine(int lineNum)
        {
            startLine = lineNum;
        }
        public void SetEndLine(int lineNum)
        {
            endLine = lineNum;
        }
        public int GetStartLine()
        {
            return startLine;
        }
        public int GetEndLine()
        {
            return endLine;
        }
        public void IncreaseCounter()
        {
            counter++;
        }
        public void DecreaseCounter()
        {
            counter--;
        }
        public int GetCounter() { return counter; } 
    }
}
