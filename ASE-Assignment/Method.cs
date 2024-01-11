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
        /// <summary>
        /// Constructor for all language commands including program and startline
        /// </summary>
        /// <param name="program">the whole program in an array</param>
        /// <param name="startLine">the line in which the codeblock starts</param>
        /// <param name="phrase">stores the codeblock's phrase in an array</param>
        /// <param name="name">stores the name of the method</param>
        /// <param name="paramsReq">number of parameters required for method (unimplemented)</param>
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

