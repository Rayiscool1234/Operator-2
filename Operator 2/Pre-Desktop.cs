using System;
using System.IO;
using CommandLibrary;

// Pre-Desktop
public class PreDesktop
{
    public bool Debug = true;
    public bool Skip = false;
    public bool ExitNotice = false;
    public bool ExitRequest = false;
    public string Version = "v0.0.4 Alpha";
    public string User;
    public string Password;
    public bool systemHasUser = false;

    public void Welcome()
    {
        Console.WriteLine($"Welcome to OperatorOS 2! {Version}");
        Console.WriteLine("SYSTEM STATEMENT: The user you will create will have Admin permissions");
        Console.WriteLine("Skip?");

        string output = Console.ReadLine();

        if (output == "y" && Debug)
        {
            Skip = true;
            User = "Tester";
            Password = "a";
        }

        
    }

    public bool PromptYesOrNo(string text)
    {
        string value;

        do
        {
            Console.WriteLine($"{text}\nWould you like to continue with this information?\nWARNING: use Y or N or else you will get an error on this version\nEnter the option below\nOption: ");
            value = Console.ReadLine().ToLower();

            if (value == "y") return true;
            if (value == "n") return false;

        } while (value != "y" && value != "n");

        return false;
    }

    public void Bootup()
    {
        Console.WriteLine("OperatorOS 2.0. The new generation of Operations!\n\nYour Operating System is currently preparing. Please standby");
        Thread.Sleep(15000);
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

    }
    public void Logon()
    {
        Console.WriteLine("------------ Signing Operation ------------");
        if (systemHasUser == true) { Console.WriteLine("Sign Up - Creates a new User Profile"); Console.WriteLine("Sign in - Logs in into already existing users"); } else { Console.WriteLine("Sign Up - Creates a new Admin Profile"); Console.WriteLine("Sign in - Unavailable"); }
        
    }

    public static void Main(string[] args)
    {
        

        PreDesktop preDesktop = new PreDesktop();

        preDesktop.Bootup();
        preDesktop.Welcome();
        preDesktop.Logon();
    }
}

// Desktop
public class Desktop
{
    public bool ExitNotice = false;
    public bool ExitRequest = false;
    public string User;

    public void Commandline()
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
            CommandLibrary.CommandLibrary.RunCommand(command);
            command = "";

        } while (!ExitNotice);

        ExitRequest = true;
    }

    public void WelcomeToDesktop()
    {
        Console.WriteLine($"Welcome, {User}. This Operating System is one of the BEST around for your Operating needs!.");
        Console.WriteLine("Need to check for help");

        do
        {
            Commandline();

        } while (!ExitRequest);

        Environment.Exit(0);
    }
}
