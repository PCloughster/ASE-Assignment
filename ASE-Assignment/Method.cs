using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_assignment
{
    public class Method : LanguageCommand
    {
        int paramsReq;
        public string phrase;
        public string name;
        public Method(string[] program, int startLine) : base(program, startLine)
        {
            string defineLine = program[startLine - 1];
            string[] splitStr = defineLine.Split(" ");
            name = splitStr[1].Trim().ToLower();
            if (splitStr.Length > 2)
            {
                paramsReq = splitStr.Length - 2;
            }
            else
            {
                paramsReq = 0;
            }
        }
        
    }
}

