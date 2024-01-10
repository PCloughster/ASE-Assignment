using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.endLine = endLine - 1;
            this.phrase = program[startLine..endLine];
        }
        
        public void RecordPharase(int startLine, int endLine, string[] program)
        {
            phrase = program[startLine..endLine];
        }
        public string[] ReturnPhrase()
        {
            return phrase;
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
