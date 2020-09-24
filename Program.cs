using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;

namespace ALS.WARDEN
{
	class Program
	{
		static int NumberOfDigits(int value, string sequence, int numtimes = 1)
		{
			if (value >= sequence.Length)
			{
				numtimes++;
				return NumberOfDigits(value / sequence.Length, sequence, numtimes);
			}
			return numtimes;
		}

		static string GetCode(int value, string sequence)
		{
			string code = "";
			int numdigits = NumberOfDigits(value, sequence);
			int temp, val = 0;

			for (int i = numdigits; i > 0; i--)
			{
				value -= val;
				temp = (int)Math.Pow(sequence.Length, i - 1);
				val = value / temp;
				code += sequence[val];
				val *= temp;
			}
			return code;
		}

		static void Main(string[] args)
		{
			//Core.Start();
			Console.WriteLine("<<//...\n");
			Console.WriteLine("//===================================//" +
							  "    </ THE [OVERSEER] GREETS YOU />    " +
							  "\\\\===================================\\\\");
			Console.Write("    [OVERSEER]\n</ PLEASE ENTER A SEQUENCE. />\n  << ");
			string Sequence = Console.ReadLine();
			Console.WriteLine($"[Sequence]: \"{Sequence}\"");
			Console.Write("    [OVERSEER]\n</ PLEASE ENTER A VALUE TO CONVERT. />\n  << ");
			int Value = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("//PROCESSING//");
			Console.WriteLine($"    [OVERSEER]\n</ THE CONVERTED VALUE IS [{GetCode(Value, Sequence)}] />");
			Console.WriteLine("    [OVERSEER]\n</ PLEASE RECORD THIS VALUE FOR FUTURE USE. />");
			Console.WriteLine("\n...//>>");
		}
	}
}