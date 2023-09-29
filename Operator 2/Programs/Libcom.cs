using Operator_2.Programs;
using System.ComponentModel.Design;

namespace CommandLibrary
{
    public class CommandLibrary
    {
        private static bool scheduledShutdown = false;
        private static int counter = 0;
        private bool highPermission = false;
        private static bool ranCommand = false;

        private string passwordA = "NaP";
        private string userA;
        private static string runnableCommand = "Non HR perms:\ncalculator-permissions\nHR perms:\ngivepermissions-logininfo-update";
        private static string credit = "OperatorOS 2\nDesigned by Rayan\nCreated by Rayan\nConcept by Rayan\nThank you for using this Applications";

        private static string com = "chelp-help-run-hp-credits-about-test-query-logout\nTemp commands: calculator";

        private static bool Find(string input, string searchTerm)
        {
            // Perform case-insensitive search
            var lowercaseInput = input.ToLower();
            var lowercaseSearchTerm = searchTerm.ToLower();

            // Use String.Contains() method to search for the term
            return lowercaseInput.Contains(lowercaseSearchTerm);
        }

        public void RunCommand(string command)
        {
            command = command.ToLower();
            switch (command)
            {
                case "testerror":
                    // ErrorHandler(); // Call your ErrorHandler function
                    break;
                case "test":
                    Test();
                    break;
                case "about":
                    About();
                    break;
                case "hp":
                    Highpermission();
                    break;
                case "run":
                    Run();
                    break;
                case "help":
                    Help();
                    break;
                case "chelp":
                    CommandHelp();
                    break;
                case "credits":
                    Credits();
                    break;
                case "clear":
                    Clear();
                    break;
                case "query":
                    SystemnI systemnI = new SystemnI();
                    Console.WriteLine("Enter Query detail: ");
                    string x = Console.ReadLine();
                    Console.WriteLine(systemnI.SystemInfo(x, false));
                    break;
                case "calculator":
                    CalculatorHandler();
                    break;
                case "logout":
                    Logout();
                    break;
                default:
                    Console.WriteLine($"Command \"{command}\" is neither an internal command or an external program. Could not be Recongized");
                    break;
            }
        }
        public void sync(string? User, string? password) { userA = User; passwordA = password; }
        private void Highpermission()
        {
            
            if (counter >= 3)
            {
                Console.WriteLine($"Hello, {userA}. We must request your password before giving you High Perms");
                Console.WriteLine("Enter your password: ");
                string Passwd = Console.ReadLine();
                if (Passwd == passwordA)
                {
                    Console.WriteLine("Your password is accepted! You will have permissions in future running commands");
                    highPermission = true; Console.WriteLine("Permission escalation done...");
                }
                else { Console.WriteLine("System Permission failure! Try again"); }
            } 
            else { Console.WriteLine("Too many attempts try again later"); }
        }
        private static void Test()
        {
            Console.WriteLine("Hello, world");
        }

        private static void About()
        {
            SystemnI systemnI = new SystemnI();
            Console.WriteLine(systemnI.SystemInfo("VERSION"));
        }
        private static void Logout()
        {

            Console.WriteLine("Logging out");
            PreDesktop preDesktop = new PreDesktop();
            preDesktop.systemGotUser = true;
            preDesktop.systemHasUser = true;
            preDesktop.User = "";
            preDesktop.Password = " ";
            Desktop desktop = new Desktop();
            desktop.User = "";
            desktop.Password = "";
            preDesktop.Logon();
            desktop.Sync(preDesktop.User, preDesktop.Password);
            desktop.WelcomeToDesktop(preDesktop.signin);
            return;
            

        }
        private static void Run()
        {
            Console.WriteLine($"This command is under development.\nThis is what you should expect from this command:\n1. Be able to run advanced programs\n2. Run custom code using compiled code!\n3. Be able to run code without browsing using single line arguments!\nRegarding that. This is what you should expect\n{runnableCommand}");
        }

        private static void Help()
        {
            Console.WriteLine("QnA\nQ: How do we add applications\nA: Its currently not possible in this version however later on you have the ability to run any .exe file you wish or DLL!\nQ: Why do some applications say they are under development\nA: Because these applicatons are planned in the future\nThat's it (if you want to know where to ask these question send them in the Github as a issue)");
        }

        private static void CommandHelp()
        {
            Console.WriteLine($"These are the commands (these dashes are spaces)\n{com}");
        }

        private static void Credits()
        {
            Console.WriteLine(credit);
        }
        private void CalculatorHandler()
        {
            Console.WriteLine("Select Operation:\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Conversion\n6) Cancel");
            string choice = Console.ReadLine();
            Operation op = Operation.Addition; // Default operation
            double[] numbers;

            switch (choice)
            {
                case "1":
                    op = Operation.Addition;
                    break;
                case "2":
                    op = Operation.Subtraction;
                    break;
                case "3":
                    op = Operation.Multiplication;
                    break;
                case "4":
                    op = Operation.Division;
                    break;
                case "5":
                    op = Operation.Conversion;
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid operation selected");
                    return;
            }

            if (op != Operation.Conversion)
            {
                Console.WriteLine("Enter numbers separated by space:");
                numbers = Array.ConvertAll(Console.ReadLine().Split(' '), Double.Parse);
                GCalculator calc = new GCalculator(numbers, op);
                try
                {
                    
                    calc.Calculate();
                } catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Select Conversion:\n1) InchesToFeet\n2) FeetToYards\n3) YardsToMiles");
                string convChoice = Console.ReadLine();
                Conversion conv = Conversion.InchesToFeet; // Default conversion

                switch (convChoice)
                {
                    case "1":
                        conv = Conversion.InchesToFeet;
                        break;
                    case "2":
                        conv = Conversion.FeetToYards;
                        break;
                    case "3":
                        conv = Conversion.YardsToMiles;
                        break;
                    default:
                        Console.WriteLine("Invalid conversion selected");
                        return;
                }

                Console.WriteLine("Enter number to convert:");
                numbers = new double[] { Double.Parse(Console.ReadLine()) };
                CCalculator ccalc = new CCalculator(numbers, op, conv);
                ccalc.Calculate();
            }
        }


        private static void Clear()
        {
            Console.Clear();
        }
        
    }
}