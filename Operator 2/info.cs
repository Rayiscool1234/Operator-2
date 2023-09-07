public class SystemnI
{
    public const bool DEBUG = true;
    public const string VERSION = "v0.0.6 Alpha";
    
    public string SystemInfo(string? requestedQuery = null, bool illegalexit = true)
	{
        if (requestedQuery == null && illegalexit) { Console.WriteLine("ERROR: INVALID QUERY SYSTEM FAILURE IMMEDIATE"); Environment.Exit(1); return ""; }
        switch (requestedQuery)
        {
            case "DEBUG":
                return DEBUG.ToString();
            case "VERSION":
                return VERSION;
            default:

                return "QUERY DOES NOT EXIST";






        }
	}
}
