using System;

namespace ALS.WARDEN
{
	#region WARDEN
	public static class Warden
	{
		public const string Name = "WARDEN";
		public static string Version = "0.1.0.0";

		public static void Message(string message)
		{
			Prompt(Name);
			Console.WriteLine(message);
		}
		public static void Prompt(string Name)
		{
			if (Name == Warden.Name) Console.Write($"{Name}: ");
			else Console.Write($"{Name} => ");
		}
		public static string Listen()
		{
			return Console.ReadLine();
		}
	}
	/*
	 * //===------:[ WARDEN ]:---======\\
	 * ||------------<META>------------||
	 * ||							   ||
	 * ||------------<DATA>------------||
	 * ||-------------<//>-------------||
	 * \\======---/----<>----\------===//
	 * 
	 * <GOLD>WARDEN<W_CNS>: Dialogue	# Message
	 * <TEAL>{UserName}<Dflt>:			# Prompt
	 */
	#endregion WARDEN
}
