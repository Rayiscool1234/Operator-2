using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_2
{
    internal class Hint
    {
        public void hint(int number)
        {

            switch (number)
            {
                case 0: Console.WriteLine("Confused? Type out \"help <command>\" You will get all the required information about each command\nNeed more info? \"ohelp\" will provide many of its quirks and possible errors"); break;
                case 1: Console.WriteLine("Getting Permission errors?"); break;
            }
        }
    }
}
