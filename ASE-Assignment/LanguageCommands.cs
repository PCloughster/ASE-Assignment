using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    internal class LanguageCommands
    {
        int startLine;
        int endLine;
        string[] phrase;
        string[] program;
        public LanguageCommands(string[] programU)
        {
            program = programU;
        }
        
        public void RecordPharase(int startLine, int endLine, string[] program)
        {
            phrase = program[startLine..endLine]; 
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
        public void CheckCondition(string startLine)
        {

        }

    }
}
