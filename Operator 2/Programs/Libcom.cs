using Operator_2.Programs;
using System.ComponentModel.Design;
using System.Reflection;

namespace CommandLibrary
{
    public class CommandLibrary
    {
        private static bool scheduledShutdown = false;
        private static int counter = 0;
        private static bool highPermission = false;
        private static bool ranCommand = false;

        private static string passwordA = "NaP";
        private static string userA;
        private static string runnableCommand = "Non HR perms:\ncalculator-permissions\nHR perms:\ngivepermissions-logininfo-update";
        private static string credit = "OperatorOS 2\nDesigned by Rayan\nCreated by Rayan\nConcept by Rayan\nThank you for using this Applications";

        private static string com = "chelp-help-run-hp-credits-about-test-query-logout\nTemp commands: calculator";
        private static bool PANICMODE = false;
        private static bool Find(string input, string searchTerm)
        {
            // Perform case-insensitive search
            var lowercaseInput = input.ToLower();
            var lowercaseSearchTerm = searchTerm.ToLower();

            // Use String.Contains() method to search for the term
            return lowercaseInput.Contains(lowercaseSearchTerm);
        }

        public static void RunCommand(string command, string[] args = null)
        {
            bool argse;
            if (args == null) { argse = false; }
            else 
            { 
                argse = true;
                for (int i = 0; i < args.Length; i++)
                {
                    args[i] = args[i].ToLower();
                }
            }
            bool commandran = false;
            command = command.ToLower();
            switch (command)
            {
                case "testerror":
                    // ErrorHandler(); // Call your ErrorHandler function
                    commandran = true;
                    break;
                case "test":
                    Test();
                    commandran = true;
                    break;
                case "about":
                    About();
                    commandran = true;
                    break;
                case "hp":
                    Highpermission();
                    break;
                case "run":
                    if (argse == true)
                    {
                        Run(args);
                    }
                    else
                    {
                        Run();
                    }
                    commandran = true;
                    break;
                case "help":
                    Help();
                    commandran = true;
                    break;
                case "chelp":
                    CommandHelp();
                    commandran = true;
                    break;
                case "credits":
                    Credits();
                    commandran = true;
                    break;
                case "clear":
                    Clear();
                    commandran = true;
                    break;
                case "query":
                    SystemnI systemnI = new SystemnI();
                    Console.WriteLine("Enter Query detail: ");
                    string x = Console.ReadLine();
                    Console.WriteLine(systemnI.SystemInfo(x, false));
                    commandran = true;
                    break;
                case "calculator":
                    CalculatorMenu();
                    commandran = true;
                    break;
                case "logout":
                    Logout();
                    commandran = true;
                    break;
                case "loading":
                    Random rand = new Random();
                    Operator_2.Hint.hint(rand.Next(14));
                    commandran = true;
                    break;
                case "debugq":
                    DebugQuery();
                    commandran = true;
                    break;
                case "panic":
                    panic();
                    break;
                default:
                    Console.WriteLine($"Command \"{command}\" is not an internal command, an external program or a special command. Could not be Recongized");
                    break;

                
            }
            if (commandran)
            {
                if (counter > 0)
                {
                    counter--;
                }
            }
        }
        public static void sync(string? User, string? password) { userA = User; passwordA = password; }
        private static void Highpermission()
        {
            if (highPermission) { Console.WriteLine("Your permission have been descalated"); highPermission = false; return; }
            if (counter < 15)
            {
                Console.WriteLine($"Hello, {userA}. We must request your password before giving you High Perms");
                string Passwd = PreDesktop.Censoredinput("Enter your password: ");
                if (Passwd == passwordA)
                {
                    Console.WriteLine("Your password is accepted! You will have permissions in future running commands");
                    highPermission = true; Console.WriteLine("Permission escalation done...");
                    counter = 0;
                }
                else { Console.WriteLine("System Permission failure! Try again"); counter += 5; }
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
        private static void Run(string[] args = null)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine(runnableCommand);
            }
            else
            {
                Console.WriteLine(string.Join(" ", args));
            }
        }
        public static string[] HandleCommandLineArgs(string input)
        {
            string[] tokens = input.Split(' ');
            string command = tokens[0];
            string[] arguments = new string[tokens.Length - 1];
            Array.Copy(tokens, 1, arguments, 0, arguments.Length);
            return tokens;
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

        private static void CalculatorMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════╗");
                Console.WriteLine("║    OperatorOS Calcs    ║");
                Console.WriteLine("╠════════════════════════╣");
                Console.WriteLine("║ 1) Addition            ║");
                Console.WriteLine("║ 2) Subtraction         ║");
                Console.WriteLine("║ 3) Multiplication      ║");
                Console.WriteLine("║ 4) Division            ║");
                Console.WriteLine("║ 5) Conversion          ║");
                Console.WriteLine("║ 6) Back to Commands    ║");
                Console.WriteLine("╚════════════════════════╝");
                Console.Write("Select an option [1–6]: ");

                var choice = Console.ReadLine()?.Trim();
                switch (choice)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        RunBasicCalc(choice);
                        break;
                    case "5":
                        RunConversion();
                        break;
                    case "6":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RunBasicCalc(string opChoice)
        {
            var op = opChoice switch
            {
                "1" => Operation.Addition,
                "2" => Operation.Subtraction,
                "3" => Operation.Multiplication,
                "4" => Operation.Division,
                _ => throw new InvalidOperationException()
            };

            Console.Write("Enter numbers separated by spaces: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;

            var nums = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var calc = new GCalculator(nums, op);
            try
            {
                calc.Calculate();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private static void RunConversion()
        {
            Console.WriteLine("Conversions:");
            Console.WriteLine("1) Inches → Feet");
            Console.WriteLine("2) Feet → Yards");
            Console.WriteLine("3) Yards → Miles");
            Console.Write("Select [1–3]: ");
            var c = Console.ReadLine();

            var conv = c switch
            {
                "1" => Conversion.InchesToFeet,
                "2" => Conversion.FeetToYards,
                "3" => Conversion.YardsToMiles,
                _ => throw new InvalidOperationException()
            };

            Console.Write("Enter value: ");
            if (!double.TryParse(Console.ReadLine(), out var v)) return;

            var ccalc = new CCalculator(new[] { v }, Operation.Conversion, conv);
            ccalc.Calculate();

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to return to calculator menu…");
            Console.ReadKey(intercept: true);
        }

        /*
        private static void CalculatorHandler()
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
        */

        private static void Clear()
        {
            Console.Clear();
        }
        private static void DebugQuery()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("################################################");
            Console.WriteLine("##############  WARNING: DEBUG MODE  ###########");
            Console.WriteLine("################################################");
            Console.WriteLine("Debug mode will activate after submitting the password! This poses potential security risks.");
            Console.WriteLine("Do not use this mode for casual curiosity. THIS CAN POSE A THREAT TO YOUR SYSTEM.");
            Console.WriteLine("################################################");
            Console.WriteLine("##############  DANGER AHEAD  ##################");
            Console.WriteLine("Whether you're a user, administrator, or tester, you're exposing your system to unwanted threats. Especially if you have been instructed to enable this mode.");
            Console.WriteLine("Please enter your password.");
            Console.ResetColor();

            string? Passwd = PreDesktop.Censoredinput("Password: ");
            if (Passwd == passwordA)
            {
                Console.WriteLine("Authorized! Debug mode is now active. Proceed with caution.");
                while (true)
                {
                    Console.Write("Enter debug query: ");
                    string query = Console.ReadLine();
                    if (!string.IsNullOrEmpty(query))
                    {

                        // If the query is "all", display all static variables
                        if (query.ToLower() == "all")
                        {
                            DisplayAllStaticVariables();
                            continue;
                        }
                        if (query == "exit")
                        {
                            break;
                        }

                        FieldInfo field = typeof(CommandLibrary).GetField(query, BindingFlags.Static | BindingFlags.NonPublic);

                        if (field != null)
                        {
                            object value = field.GetValue(null);
                            Console.WriteLine($"Result: {value}");
                        }
                        else
                        {
                            Console.WriteLine("Variable not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid query.");
                    }
                }
            }
        }
        static void DisplayAllStaticVariables()
        {
            FieldInfo[] fields = typeof(CommandLibrary).GetFields(BindingFlags.Static | BindingFlags.NonPublic);

            Console.WriteLine("All static variables:");
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(null);
                Console.WriteLine($"{field.Name}: {value}");
            }
        }
        private static void panic()
        {
            
            if (PANICMODE)
            {
                
                Console.ResetColor();
                Clear();
                Console.WriteLine("SYSTEM NOW OPTIMAL. OPTIONAL APPLICATION WILL RUN WITHOUT HP REQUIREMENT"); PANICMODE = false;
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Red;
            PANICMODE = true;
            Clear();
            Console.WriteLine("SECURITY PANIC ACTIVATED. ALL PROGRAMS THAT ARE NOT CRITICAL IS PASSWORD PROTECTED UNTIL YOU TYPE PANIC AGAIN.\nYOUR SCREEN WILL BE RED FOR THE REMAINING OF THE PANIC BUTTON'S USE");
            Console.WriteLine("!!SYSTEM LOCKDOWN!!");
        }
    }
}