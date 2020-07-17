#define CONSOLE
#define FILE

using System;
using System.Collections.Generic;

namespace ALS.WARDEN
{
	class Core
	{
		#region PROPERTIES
		public static SortedList<string, User> WRD_USERS = 
			new SortedList<string, User>(0);

		public enum Match
		{
			TRUE = 1,
			FALSE = 0,
		}

		#region FORMATTING
		// TODO: Export to Formatting Class/Interface
		private const string ESC = "\u001b";
		private const string WFMT_COLORS_TEAL = "[38;2;0;205;205m";
		private const string WFMT_COLORS_GOLD = "[38;2;255;192;31m";
		private const string WRD_FMT = ESC + WFMT_COLORS_GOLD;
		#endregion FORMATTING
		#endregion PROPERTIES

		#region METHODS
		public static void Start()
		{
			WardenIntro();
			User CurrentUser = VerifyUser();
			Login(CurrentUser);
		}

		public static void WardenIntro()
		{
			Console.WriteLine("WARDEN Activating...");
			Console.WriteLine();
			Console.WriteLine($"Welcome to WARDEN, version {Warden.Version}.");
		}

		public static User VerifyUser()
		{
			User WardenUser;
			Console.Write($"{WRD_FMT}Please enter the user name: ");
			string Name = Console.ReadLine();
			Match result = GetUserMatch(Name);
			switch (result)
			{
				case Match.TRUE:
					WardenUser = GetUser(Name);
					break;
				case Match.FALSE:
					WardenUser = GetNewUser();
					break;
				default:
					WardenUser = GetNewUser();
					break;
			}
			return WardenUser;
		}

		public static void Login(User user)
		{
			Match Matches = GetUserPassword(user);
			while (Matches == Match.FALSE)
			{
				Console.WriteLine($"\n{WRD_FMT}Password incorrect. Please try again.");
				Matches = GetUserPassword(user);
			}
			Console.WriteLine();
			Console.WriteLine("Logging you in...");
		}

		public static Match GetUserMatch(string Name)
		{
			Match CheckMatch = Match.FALSE;
			try
			{
				foreach (User user in WRD_USERS.Values)
				{
					if (user.Name == Name) return Match.TRUE;
					else continue;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Type of error: {e.GetType()}");
				Console.WriteLine($"Message: {e.Message}");
			}
			return CheckMatch;
		}

		public static User GetUser(string Name)
		{
			try
			{
				foreach (User user in WRD_USERS.Values)
				{
					if (user.Name == Name) return user;
					else continue;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Type of error: {e.GetType()}");
				Console.WriteLine($"Message: {e.Message}");
			}
			return null;
		}

		public static User GetNewUser()
		{
			User NewUser = new User();
			return NewUser;
		}

		public static Match GetUserPassword(User user)
		{
			string password = user.GetPassword();
			string passbuffer = "";
			Console.Write($"{WRD_FMT}Enter the user password: ");
			ConsoleKeyInfo inputkey;

			do
			{
				// Eat the input without displaying the character
				inputkey = Console.ReadKey(true);
				// Skip if Backspace or Enter is pressed
				if (inputkey.Key != ConsoleKey.Backspace && inputkey.Key != ConsoleKey.Enter)
				{
					passbuffer += inputkey.KeyChar;
				}
				else if (inputkey.Key == ConsoleKey.Backspace && passbuffer.Length > 0)
				{
					// Remove last character if Backspace is pressed
					passbuffer = passbuffer[0..^1];
				}
			}
			while (inputkey.Key != ConsoleKey.Enter);
			return (passbuffer == password) ? Match.TRUE : Match.FALSE;
		}

		#endregion METHODS
	}
}
