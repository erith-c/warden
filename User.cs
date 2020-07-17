#define DEBUG
#undef DEBUG

using System;
using static System.Console;

namespace ALS.WARDEN
{
	public class User
	{
		#region Properties
		public string Name { get; set; }
		private string Password { get; set; }
		#endregion Properties

		#region Constructors
		public User()
		{
			this.Name = SetUserName();
			SetPassword();
		}
		public User(string Name, string Pass)
		{
			this.Name = Name;
			this.Password = Pass;
		}
		#endregion Constructors

		#region Methods
		#region User Name
		private string SetUserName()
		{
			string namebuffer;
			Write($"\u001b[38;2;0;205;205mEnter a user name: \u001b[0m");
			namebuffer = ReadLine();
			WriteLine(namebuffer);
			return namebuffer;
		}

		public string GetUserName()
		{
			return this.Name;
		}
		#endregion User Name

		#region User Password
		public string CreatePassword()
		{
#if DEBUG
			WriteLine("In CreatePassword()");
#endif
			string pwdbuffer = "";
			ConsoleKeyInfo inputkey;
			do
			{
#if DEBUG
				WriteLine("In do...while loop of CreatePassword()");
#endif
				// Eat the input without displaying the character
				inputkey = ReadKey(true);
				// Skip if Backspace or Enter is pressed
				if (inputkey.Key != ConsoleKey.Backspace && inputkey.Key != ConsoleKey.Enter)
				{
					pwdbuffer += inputkey.KeyChar;
				}
				else if (inputkey.Key == ConsoleKey.Backspace && pwdbuffer.Length > 0)
				{
					// Remove last character if Backspace is pressed
					pwdbuffer = pwdbuffer[0..^1];
				}
			}
			while (inputkey.Key != ConsoleKey.Enter);
			Write("\n");
#if DEBUG
			WriteLine($"Password: {pwdbuffer}");
#endif
			return pwdbuffer;
		}

		private void SetPassword()
		{
			Write($"Please enter a password: ");
			this.Password = CreatePassword();
			bool DoubleCheck = CheckPassword(this.Password);
			if (DoubleCheck)
			{
				WriteLine("Password saved successfully.");
			}
			else
			{
				while (!DoubleCheck)
				{
					WriteLine("Password incorrect. Please try again.");
					DoubleCheck = CheckPassword(this.Password);
				}
			}
		}

		public string GetPassword()
		{
			return this.Password;
		}

		
		private bool CheckPassword(string pwd)
		{
			Write($"Enter the password for verification: ");
			string password = CreatePassword();
			if (password == pwd)
			{
				return true;
			}
			else
			{
				WriteLine("Passwords do not match.");
				return false;
			}
		}
		#endregion User Password
		#endregion Methods
	}

}