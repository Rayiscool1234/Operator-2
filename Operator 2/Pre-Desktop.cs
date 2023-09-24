using CommandLibrary;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

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
    public bool systemGotUser = false;
    public bool signin = false;
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
            Console.WriteLine($"{text}\nWould you like to continue with this information?\nEnter the option below\nHint: Use y or n to choose!\nOption: ");
            value = Console.ReadLine().ToLower();

            if (value == "y") return true;
            if (value == "n") return false;

        } while (value != "y" && value != "n");

        return false;
    }
    public string Censoredinput(string text)
    {
        string censorText = "";
        Console.Write(text);
        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            // Handle Enter key
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

            // Handle Backspace key
            if (key.Key == ConsoleKey.Backspace)
            {
                if (censorText.Length > 0)
                {
                    censorText = censorText.Remove(Password.Length - 1);
                    Console.Write("\b \b");  // Move cursor back, overwrite with space, move cursor back again
                    cursorLeft--;
                }
                continue;
            }

            censorText += key.KeyChar;
            Console.Write("*");
            cursorLeft++;

            
        }
        Console.SetCursorPosition(cursorLeft, cursorTop);
        Console.Write("\n");
        return censorText;
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
        if (File.Exists("UserCredentials.txt"))
        {
            systemGotUser = true;
        }
        if (systemGotUser == true)
        {
            systemHasUser = true;

        }
        Console.WriteLine("Logon menu activated!");
    }

    public void UserSave()
    {
        Console.WriteLine("Saving Credentials\nSaved Credentials");

        CommandLibrary.CommandLibrary lib = new CommandLibrary.CommandLibrary();
        lib.sync(User, Password);


        using (StreamWriter UserCredentials = new StreamWriter("UserCredentials.txt"))
        {
            UserCredentials.WriteLine(User);
            UserCredentials.WriteLine(Password);
        }


    }
    void UserLoad()
    {
        if (File.Exists("UserCredentials.txt"))
        {
            Console.WriteLine("Loading Credentials");

            // Read from file
            using (StreamReader UserCredentials = new StreamReader("UserCredentials.txt"))
            {
                User = UserCredentials.ReadLine();
                Password = UserCredentials.ReadLine();
            }

            Console.WriteLine("Loaded Credentials");
        }
        else
        {
            Console.WriteLine("Credentials file does not exist.");
        }
    }

public int UserSignUp()
    {
        if (Skip) { UserSave(); return 0; } 
         
        bool yesOrNo;

        do
        {
            Console.WriteLine("Please Enter your Username");
            Console.Write("Username: ");
            User = Console.ReadLine();

            Console.WriteLine("Please Enter a easy to remember and secure Password as you can't change later");
            Password = Censoredinput("Password: ");
            yesOrNo = PromptYesOrNo(User);
            if (yesOrNo == false)
            {
                Console.Clear();
            }

        } while (!yesOrNo);

        UserSave();

        return 0;
    }

    public void UserSignIn()
    {
        // TODO: Implement User Sign-in logic
        UserLoad();
        Console.Write("Please provide the your username and password\nUser: ");
        string? insuser = Console.ReadLine();
        if (string.IsNullOrEmpty(insuser))
        {
            Console.WriteLine("WARN: illegal username");
            Logon();
        }
        string? inspassword = Censoredinput("Password: ");
        if (string.IsNullOrEmpty(inspassword))
        {
            Console.WriteLine("WARN: illegal password");
            Logon();
        }
        if (inspassword == Password && insuser == User) {
            User = insuser;
            Password = inspassword;
            signin = true;
            UserSave();
        } else
        {
            Console.WriteLine("Your username or password is wrong. Please try again by inputting 2");
            Logon();
        }
    }
    public void Logon()
    {
        string option;
        bool x = false;
        do
        {
            
            Console.WriteLine("------------ Signing Operation ------------");
            if (systemHasUser == true) { Console.WriteLine("1. Sign Up - Creates a new User Profile"); Console.WriteLine("2. Sign in - Logs in into already existing users"); } else { Console.WriteLine("1. Sign Up - Creates a new Admin Profile"); Console.WriteLine("2. Sign in - Unavailable"); }
            Console.Write("Option: ");
            option = Console.ReadLine();
            if (string.IsNullOrEmpty(option) == false)
            {
                option = option.ToLower();
                if (option == "1" || option == "2" && systemHasUser == true)
                {
                    if (option == "1")
                    {
                        x = true; Console.WriteLine("Sign up command");
                    } else
                    {
                        x = true; Console.WriteLine("Sign in command");
                    }
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
        if (option == "1")
        {
            UserSignUp();
        }
        else if (option == "2")
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
        desktop.Sync(preDesktop.User, preDesktop.Password);
        desktop.WelcomeToDesktop(preDesktop.signin);
    }
}

// Desktop
public class Desktop
{
    public bool ExitNotice = false;
    public bool ExitRequest = false;
    public string? User;
    public string? Password;

    public void Sync(string user = "ELOF", string password = "ELOP") { User = user; Password = password; }

    private void Commandline()
    {
        CommandLibrary.CommandLibrary lib = new CommandLibrary.CommandLibrary();
        string command;
        do
        {
            Console.Write($"{User}>> ");
            command = Console.ReadLine();

            if (command == "exit")
            {
                ExitNotice = true;
            }
            if (string.IsNullOrEmpty(command) == false && command != "exit")
            {
                lib.RunCommand(command);
            }
            command = "";

        } while (!ExitNotice);

        ExitRequest = true;
    }
    public void WelcometoDesktopa()
    {
        Console.WriteLine($"Welcome back, {User}. We wish you the best!");
        Console.WriteLine("REMINDER: Need to check for help or need commands?");
        Console.WriteLine("Just do chelp and help!");
        CommandLibrary.CommandLibrary lib = new CommandLibrary.CommandLibrary();
        lib.sync(User, Password);
        do
        {
            Commandline();

        } while (!ExitRequest);

        Environment.Exit(0);


    }
    public void WelcomeToDesktop(bool signin)
    {
        if (signin == false)
        {
            Console.WriteLine($"Welcome, {User}. This operating system is one of the best for meeting your computing needs!");
            Console.WriteLine("Need to check for help or need commands?");
            Console.WriteLine("Just do chelp and help!");
            CommandLibrary.CommandLibrary lib = new CommandLibrary.CommandLibrary();
            lib.sync(User, Password);
            do
            {
                Commandline();

            } while (!ExitRequest);

            Environment.Exit(0);
        } else
        {
            WelcometoDesktopa();
        }
    }
}
