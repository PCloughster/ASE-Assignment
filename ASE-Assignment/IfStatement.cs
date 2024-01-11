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

    public class IfStatement : LanguageCommand
    {
        string[] condition;
        public string conditionRaw;
        public IfStatement(string[] program, int startLine) : base(program, startLine)
        {
        }
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
