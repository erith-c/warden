using System;

namespace AngelLight.Overseer
{
	class Program
	{
		static void OSMain(string[] args)
		{
			using (var MainWindow = new Window(800, 600, "Overseer"))
			{
				MainWindow.Run(60.0);
			}
			Console.Write("<<//...");
			Console.WriteLine();
			Console.Write("OPENING CONNECTION...");
			Console.WriteLine();
			Console.Write("CONNECTION ESTABLISHED. AUTHORIZATION TOKEN REQUIRED.\n");
			Console.Write("<<[Authorization]: ");

			ConsoleKeyInfo OS_KeyInput = Console.ReadKey(); // Set to true to hide password.
			string OS_UTF_PassKey = "";
			while (OS_KeyInput.Key != ConsoleKey.Enter)
			{
				OS_UTF_PassKey += OS_KeyInput.KeyChar;
				OS_KeyInput = Console.ReadKey(); // Set to true to hide password.
			}
			Console.WriteLine();

			string OS_AuthToken = OS_UTF_PassKey;
			while (OS_AuthToken != "ALS2020OS")
			{
				Console.Write("INVALID TOKEN. AUTHORIZATION TOKEN REQUIRED.\n");
				Console.Write("<<[Authorization]: ");
				OS_AuthToken = Console.ReadLine();
			}
		}
	}
}
