using AngelLight.Modules;
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
			Console.Write("    [OVERSEER]\n</ PLEASE ENTER A VALUE TO CONVERT. />\n  << ");
			int Value = Convert.ToInt32(Console.ReadLine());

			SequenceConverter Base10 = new SequenceConverter("0123456789");
			SequenceConverter Base16 = new SequenceConverter("0123456789ABCDEF");
			SequenceConverter Base3 = new SequenceConverter("NOS");
			Base10.UpdateValue(Value);
			Base16.UpdateValue(Value);
			Base3.UpdateValue(Value);

			Console.WriteLine("//PROCESSING//");
			Console.WriteLine($"    [OVERSEER]\n</ THE INPUTTED VALUE IS [{Value}] />");
			Console.WriteLine($"    [OVERSEER]\n</ THE BASE10 VALUE IS [{Base10.ConvertValue()}] />");
			Console.WriteLine($"    [OVERSEER]\n</ THE CONVERTED BASE16 VALUE IS [{Base16.ConvertValue()}] />");
			Console.WriteLine($"    [OVERSEER]\n</ THE CONVERTED BASE3 VALUE IS [{Base3.ConvertValue()}] />");
			Console.WriteLine("    [OVERSEER]\n</ PLEASE RECORD THIS VALUE FOR FUTURE USE. />");
			Console.WriteLine("\n...//>>");
		}
	}
}