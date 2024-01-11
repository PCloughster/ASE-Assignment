using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ase_assignment
{
    /// <summary>
    /// Class for the IfStatement object, inherits from LanguageCommand.cs
    /// </summary>
    public class IfStatement : LanguageCommand
    {
        string[] condition;
        public string conditionRaw;
        /// <summary>
        /// Constructor for all language commands including program and startline
        /// </summary>
        /// <param name="program">the whole program in an array</param>
        /// <param name="startLine">the line in which the codeblock starts</param>
        /// <param name="phrase">stores the codeblock's phrase in an array</param>
        /// <param name="condition">stores the condition after variables have been converted to their values</param>
        /// <param name="conditionRaw">stores the condition before variables have been converted to their values</param>
        public IfStatement(string[] program, int startLine) : base(program, startLine)
        {
        }
        /// <summary>
        /// Checks the specified condition for the if statement/loop returning a boolean
        /// </summary>
        public bool CheckCondition()
        {
            bool result = false;
            if (this.condition != null)
            {
                
                string [] condA = condition.Skip(1).ToArray();
                if (condA[1].Contains("=="))
                {
                    result = int.Parse(condA[0]) == int.Parse(condA[2]);
                }
                else if (condA[1].Contains("!="))
                {
                    result = int.Parse(condA[0]) != int.Parse(condA[2]);
                }
                else if (condA[1].Contains('<'))
                {
                    result = int.Parse(condA[0]) < int.Parse(condA[2]);
                }
                else if (condA[1].Contains('>'))
                {
                    result = int.Parse(condA[0]) > int.Parse(condA[2]);
                }
                else
                {
                    result = false;
                }
                return result;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks the specified condition for the if statement/loop returning a boolean
        /// </summary>
        public void SetCondition(string[] conditionFiltered)
        {
            condition = conditionFiltered;
        }
        public string[] GetCondition()
        {
            return condition;
        }
    }
}
