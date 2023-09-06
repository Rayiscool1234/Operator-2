public class PreDesktop
{
    public bool DEBUG;
    public string VERSION;
    public bool Skip = false;
    public bool ExitNotice = false;
    public bool ExitRequest = false;
    public string User;
    public string Password;
    public bool systemHasUser = false;

    public void Welcome()
    {
        Console.WriteLine($"Welcome to OperatorOS 2! {VERSION}");
        if (!systemHasUser)
        {
            Console.WriteLine("SYSTEM STATEMENT: The user you will create will have Admin permissions");
        }

        if (DEBUG) {
            Console.WriteLine("Skip?");
            string output = Console.ReadLine();
            if (output == "y")
            {
                Skip = true;
                User = "Tester";
                Password = "a";
            }
        }
        
    }

    public bool PromptYesOrNo(string text)
    {
        string value;

        do
        {
            Console.WriteLine($"{text}\nWould you like to continue with this information?\nEnter the option below\nOption: ");
            value = Console.ReadLine().ToLower();

            if (value == "y") return true;
            if (value == "n") return false;

        } while (value != "y" && value != "n");

        return false;
    }

    public void Bootup()
    {
        SystemnI systemni = new SystemnI();
        Console.WriteLine("OperatorOS 2.0. The new generation of Operations!\n\nYour Operating System is currently preparing. Please standby");
        VERSION = systemni.SystemInfo("VERSION");
        if (systemni.SystemInfo("DEBUG") == "True")
        {
            DEBUG = true;
        }
        else if (systemni.SystemInfo("DEBUG") == "False")
        {
            DEBUG = false;
        }
        else
        {
            Console.WriteLine("ERROR: ILLEGAL CONFIG");
                Environment.Exit(2);
        }
        Thread.Sleep(1000);
        Console.WriteLine("Logon menu activated!");
    }

    public void UserSave()
    {
        Console.WriteLine("Saving Credentials\nSaved Credentials");

        // Assuming you have somewhere to save the passwords.
        // PasswordA = Password;
        // UserA = User;

        using (StreamWriter UserCredentials = new StreamWriter("UserCredentials.txt"))
        {
            UserCredentials.WriteLine(User);
            UserCredentials.WriteLine(Password);
        }


    }

    public int UserSignUp()
    {
        if (Skip) return 0;

        bool yesOrNo;

        do
        {
            Console.WriteLine("Please Enter your Username");
            Console.Write("Username: ");
            User = Console.ReadLine();

            Console.WriteLine("Please Enter a easy to remember and secure password as you can't change later");
            Console.Write("Password: ");
            Password = Console.ReadLine();

            yesOrNo = PromptYesOrNo(User);

        } while (!yesOrNo);

        UserSave();

        return 0;
    }

    public void UserSignIn()
    {
        // TODO: Implement User Sign-in logic
        Console.WriteLine("501: NOT IMPLEMENTED");
        Logon();

    }
    public void Logon()
    {
        string option;
        bool x = false;
        do
        {
            
            Console.WriteLine("------------ Signing Operation ------------");
            if (systemHasUser == true) { Console.WriteLine("Sign Up - Creates a new User Profile"); Console.WriteLine("Sign in - Logs in into already existing users"); } else { Console.WriteLine("Sign Up - Creates a new Admin Profile"); Console.WriteLine("Sign in - Unavailable"); }
            option = Console.ReadLine();
            if (string.IsNullOrEmpty(option) == false)
            {
                option.ToLower();
                if (option == "sign up" || option == "sign in" && systemHasUser == true)
                {
                    x = true; Console.WriteLine($"{option} command");
                }
            }
            else
            {
                Console.WriteLine("Invalid string");

            }
            if (x == false)
            {
                Console.WriteLine("Failed to choose. Please try again");

            }
            Thread.Sleep(500);
            Console.Clear();
        } while (x == false);
        if (option == "sign up")
        {
            UserSignUp();
        }
        else if (option == "sign in")
        {
            UserSignIn();
        }
        else
        {
            Console.WriteLine("SYSTEM WIDE ERROR: PLEASE CONTACT THE REPOS");
            Console.WriteLine("Press enter to continue......");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }

    public static void Main(string[] args)
    {
        

        PreDesktop preDesktop = new PreDesktop();
        preDesktop.Bootup();
        preDesktop.Welcome();
        preDesktop.Logon();
        
        Desktop desktop = new Desktop();
        desktop.Sync(preDesktop.User);
        desktop.WelcomeToDesktop();
    }
}

// Desktop
public class Desktop
{
    public bool ExitNotice = false;
    public bool ExitRequest = false;
    public string? User;

    public void Sync(string user = "ELOF") { User = user; }

    private void Commandline()
    {
        string command;

        do
        {
            Console.Write($"{User}>> ");
            command = Console.ReadLine();

            if (command == "exit")
            {
                ExitNotice = true;
            }
            if (string.IsNullOrEmpty(command) == false)
            {
                CommandLibrary.CommandLibrary.RunCommand(command);
            }
            command = "";

        } while (!ExitNotice);

        ExitRequest = true;
    }

    public void WelcomeToDesktop()
    {
        Console.WriteLine($"Welcome, {User}. This Operating System is one of the BEST around for your Operating needs!.");
        Console.WriteLine("Need to check for help or need commands?");
        Console.WriteLine("Just do chelp and help!");

        do
        {
            Commandline();

        } while (!ExitRequest);

        Environment.Exit(0);
    }
}
