using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace ase_assignment
{
    /// <summary>
    /// Language command abstract class to be inherited by the other language classes, if, and method
    /// </summary>
    public abstract class LanguageCommand : Object
    {
        int startLine;
        int endLine;
        string[] phrase;
        string[] program;
        /// <summary>
        /// Constructor for all language commands including program and startline
        /// </summary>
        /// <param name="program">the whole program in an array</param>
        /// <param name="startLine">the line in which the codeblock starts</param>
        /// <param name="phrase">stores the codeblock's phrase in an array</param>
        public LanguageCommand(string[] program, int startLine)
        {
            this.program = program;
            this.startLine = startLine - 1;
        }
        /// <summary>
        /// Record phrase used to narrow down the whole program to the commands required for this codeblock
        /// </summary>
        public void RecordPharase()
        {
            startLine += 1;
            endLine = endLine - 1;
            phrase = program[startLine..endLine];
        }
        /// <summary>
        /// Returns the phrase
        /// </summary>
        public string ReturnPhrase()
        {
            string lines = string.Join(Environment.NewLine, phrase);
            return lines;
        }
        /// <summary>
        /// sets the code block start line
        /// </summary>
        public void SetStartLine(int lineNum)
        {
            startLine = lineNum;
        }
        /// <summary>
        /// sets the code block end line
        /// </summary>
        public void SetEndLine(int lineNum)
        {
            endLine = lineNum;
        }
        /// <summary>
        /// gets the code block start line
        /// </summary>
        public int GetStartLine()
        {
            return startLine;
        }
        /// <summary>
        /// gets the code block end line
        /// </summary>
        public int GetEndLine()
        {
            return endLine;
        }
    }
}
