using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_2
{
    internal class Hint
    {
        public static void hint(int number)
        {

            switch (number)
            {
                case 0: Console.WriteLine("Confused? Type out \"help <command>\" You will get all the required information about each command\nNeed more info? \"ohelp <command>\" will provide many of its quirks and possible errors"); break;
                case 1: Console.WriteLine("Getting Permission errors? Typing hp can allow you to run commands that require such privileges. Including updating your current OperatorOS to a newer version"); break;
                case 2: Console.WriteLine("Do you know that you can Log out your current session and log into other users or administrator accounts? even if you do. You might be shocked it used to be not a feature for the Original OperatorOS 2"); break;
                case 3: Console.WriteLine("Do you ever wonder how to run your favorite CLI apps? You can do \"fla\" to navigate through files and execute your desired apps"); break;
                case 4: Console.WriteLine("Want to talk to other computers? You can do that using \"cola\" (Communcation LAN) and send messages to your friends or people!"); break;
                case 5: Console.WriteLine("Have you heard about doing updates? If you do, you can easily do so or check one! Just as advice to always update to the newest version for you own sake"); break;
                case 6: Console.WriteLine("Do you like sounds? Well, you will see in the future ;)"); break;
                case 7: Console.WriteLine("Have you ever wondered how to make commands faster? Introducing the single line arguments that allow you to receive results faster!"); break;
                case 8: Console.WriteLine("Want to have fun? There are many games in this OS that you can have fun with! Just type \"game (games)\""); break; 
                case 9: Console.WriteLine("Do you have printers? You should use our community app that interfaces with printers allowing you to print anything you like!"); break;
                case 10: Console.WriteLine("Like being a developer? You can program anything with our new text editor! try running \"bk\" with our run command!"); break;
                case 11: Console.WriteLine("Take your time :) type \"time\" and watch how much time you have! including options for 24 or 12 hour"); break; 
                case 12: Console.WriteLine("you have to wish for a miracle that your app will work without randomly failing. We don't have that! we have clear error reporting handling that developers can follow. not all developers do follow it however we have alerts for that. Keep a clear eye for any messages like this: \"CRITICAL WARNING: THERE IS NO CLEAR ERROR HANDLING. WE HAVE NO GUARANTEE FOR A EASY EXPERIENCE\""); break; 
                case 13: Console.WriteLine("Want to message your friends without having to use \"cola\" you can use many of our community made messaging apps. Some even have notification!"); break;
                case 14: Console.WriteLine("Worried about security of using fla? you can use our safer version called sfla which has way less abilities. only allowing printing, reading and ask for higher permission. But nothing external"); break;
            }
        }
    }
}
