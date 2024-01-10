using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{

    public class IfStatement : LanguageCommand
    {
        string condition;
        public IfStatement(string[] program, int startLine)
        {
            this.condition = program[startLine];
        }
        public bool CheckCondition(string condition)
        {
            bool result;
            if (this.counter != 0)
            {
                return false;
            }
            else if (this.condition != null)
            {
                string[] condA = condition.Split(" ");
                condA = condA.Skip(1).ToArray();
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
                return true;
            }
        }
    }
}
