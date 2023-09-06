public class SystemnI
{
    public const bool DEBUG = false;
    public const string VERSION = "v0.0.6 Alpha";
    
    public string SystemInfo(string? requestedQuery = null)
	{
        if (requestedQuery == null) { Console.WriteLine("ERROR: INVALID QUERY SYSTEM FAILURE IMMEDIATE"); Environment.Exit(1); return ""; }
        switch (requestedQuery)
        {
            case "DEBUG":
                return DEBUG.ToString();
            case "VERSION":
                return VERSION;
            default:

                return "";






        }
	}
}
