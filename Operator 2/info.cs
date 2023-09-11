using System;
using System.Collections.Generic;

public class SystemnI
{
	public const bool DEBUG = true;
	public const string VERSION = "v0.0.6 Alpha";

	// Create a dictionary to store the system information
	private Dictionary<string, string> systemInfoDict = new Dictionary<string, string>
	{
		{ "DEBUG", DEBUG.ToString() },
		{ "VERSION", VERSION }
	};

	public string SystemInfo(string? requestedQuery = null, bool illegalexit = true)
	{
		if (requestedQuery == null && illegalexit)
		{
			Console.WriteLine("ERROR: INVALID QUERY SYSTEM FAILURE IMMEDIATE");
			Environment.Exit(1);
			return "";
		}

		if (string.IsNullOrEmpty(requestedQuery))
		{
			requestedQuery = "NULL";
		}
		else
		{
			requestedQuery = requestedQuery.ToUpper();
		}

		if (requestedQuery.Contains(" ") || requestedQuery.Contains("   ") || requestedQuery.Contains("\\"))
		{
			return "PROHIBITED UNICODE CHARACTER: DON'T USE SPACE TAB OR BACKSLASH\nUSE INSTEAD UNDERSCORE \"_\"";
		}

		// Search for the query in the dictionary
		if (systemInfoDict.TryGetValue(requestedQuery, out string result))
		{
			return result;
		}
		else
		{
			return $"QUERY KEY: \"{requestedQuery}\" DOES NOT EXIST ";
		}
	}
}

