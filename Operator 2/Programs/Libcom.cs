namespace CommandLibrary
{
    public static class CommandLibrary
    {
        private static bool scheduledShutdown = false;
        private static int counter = 0;
        private static bool highPermission = false;
        private static bool ranCommand = false;

        private static string passwordA = "NaP";
        private static string userA;
        private static string runnableCommand = "Non HR perms:\ncalculator-permissions\nHR perms:\ngivepermissions-logininfo-update";
        private static string credit = "OperatorOS\nDesigned by Rayan\nCreated by Rayan\nConcept by Rayan\nThank you for using this Applications";

        private static string com = "chelp-help-run-hp-credits-about-test";

        private static bool Find(string input, string searchTerm)
        {
            // Perform case-insensitive search
            var lowercaseInput = input.ToLower();
            var lowercaseSearchTerm = searchTerm.ToLower();

            // Use String.Contains() method to search for the term
            return lowercaseInput.Contains(lowercaseSearchTerm);
        }

        public static void RunCommand(string command)
        {

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
                    HighPermission();
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
                // Continue with the rest of your commands...
                default:
                    Console.WriteLine($"Command \"{command}\" not recognized.");
                    break;
            }
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

        private static void HighPermission()
        {
            // Implementation...
        }

        private static void Run()
        {
            
        }

        private static void Help()
        {
            Console.WriteLine("QnA\nQ: How do we add applications\nA: You could but you need to have access to the source files which we have open source so add any function that seems fit\nQ: Why do some applications say they are under development\nA: Because these applicatons are planned in the future\nThat's it (if you want to know where to ask these question send them in the Github as a issue)");
        }

        private static void CommandHelp()
        {
            Console.WriteLine($"These are the commands (these dashes are spaces)\n{com}");
        }

        private static void Credits()
        {
            Console.WriteLine(credit);
        }

        // Continue adding the rest of your functions...
    }
}