using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Operator_2
{
    internal class Pre_Desktop
    {
        static void Main()
        {
            Console.WriteLine("Welcome to OperatorOS 2.0\nWe are currently began starting on preparing your system, Be patient as we setup your system");
            Thread.Sleep(15000);
            Console.WriteLine("System pre setup is done.\nCould you please choose an option before booting into the System");
            Console.WriteLine("Fresh Boot up ~ This boots the system into a fresh enviroment with no users or custom programs !!WARNING: DON'T CHOOSE THIS OPTION IF YOU DON't WANT TO LOSE YOUR USERS OR PROGRAMS!!");
            Console.WriteLine("Continue current Enviroment ~ OPTIONNOTIMPLEMENTED");
            string Optionchoicen = Console.ReadLine();
            Console.WriteLine(Optionchoicen);
        }
    }
}
