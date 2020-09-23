using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;

namespace ALS.WARDEN
{
	class Program
	{
		static void Main(string[] args)
		{
			//Core.Start();
			string base10 = "0123456789";
			int myvalue = 101;
			Console.WriteLine("Sequence start:\n<<//...");

			//(int x, int y) numtimes = GetRecursion(myvalue, base10);
			//Console.WriteLine($"<! GetRecursion returned ({numtimes.x}, {numtimes.y}) >");
			int numdigits = GetNumDigits(myvalue, base10);
			Console.WriteLine($"<! GetNumDigits returned {numdigits} >");
			//string v = GetValue(myvalue, base10);

			Console.WriteLine("\n...//>>");
		}
		
		static (int, int) GetRecursion(int value, string sequence, int numtimes = 0)
		{
			Console.WriteLine($"<<//...In GetRecursion()...//>>");
			if (value >= sequence.Length)
			{
				Console.WriteLine($"<! value: {value, 3}, new test: {value - sequence.Length, 3} >");
				Console.WriteLine($"<! numtimes: {numtimes, 3}, value: {value - sequence.Length, 3} >");
				Console.WriteLine();
				return GetRecursion(value - sequence.Length, sequence, ++numtimes);
			}
			Console.WriteLine($"<<//...Returning [{numtimes, 3},{value, 3}]...//>>");
			return (numtimes, value);
		}

		static int GetNumDigits(int value, string sequence)
		{
			int digits = 1;
			Console.WriteLine($"<<//...In GetNumDigits()...//>>");
			(int t, int r) numdigits = GetRecursion(value, sequence);
			Console.WriteLine($"<! ({numdigits.t},{numdigits.r}) >");
			if (numdigits.t >= sequence.Length)
				return digits + GetNumDigits(numdigits.t, sequence);
			return numdigits.t;
		}

		static string GetValue(int value, string sequence)
		{
			string converted = "";
			int digits = 1;
			if (value > sequence.Length)
			{
				digits = GetNumDigits(value, sequence);
			}
			int tempval = value;
			for (int i = digits; i > 0; i--)
			{
				Console.WriteLine($"<! tempval: {tempval} >");
				int digmax = (int)Math.Pow(sequence.Length, i - 1);
				Console.WriteLine($"<! digmax: {digmax} >");
				int times = 0;
				do
				{
					times++;
					tempval -= digmax;
					Console.WriteLine($"<! times: {times}, tempval: {tempval} >");
				} while (tempval >= digmax);
				converted += times;
				Console.WriteLine($"<! converted: {converted} >");
			}
			Console.WriteLine($"<<//...Returning [{converted}]...//>>");
			return converted;
		}

		//static int GetNumDigits(int value, string sequence)
		//{
		//	//Console.WriteLine($"Value: {value}");
		//	//Console.WriteLine("GetNumDigits()...");
		//	int numdigits = 1;
		//	int numtimes = 0;
		//	if (value > sequence.Length)
		//	{
		//		//Console.WriteLine("Getting number of times...");
		//		numtimes = numtimes + GetNumTimes(value, sequence);
		//		numdigits++;
		//	}
		//	//Console.WriteLine($"Number of times: {numtimes}");
		//	//Console.WriteLine($"Number of digits: {numdigits}");
		//	if (numtimes > sequence.Length)
		//	{
		//		//Console.WriteLine("<<//OVERSEER IS SEEN//>>");
		//		//Console.WriteLine($"Recursing...");
		//		int tempval = numtimes - (numtimes - sequence.Length);
		//		return numdigits + GetNumDigits(value - sequence.Length*tempval, sequence);
		//	}
		//	//Console.WriteLine($"Returning {numdigits}");
		//	return numdigits;
		//}

		//static string GetValue(int value, string sequence)
		//{
		//	string strval = "";
		//	int numdigits = GetNumDigits(value, sequence);
		//	int tempval = value;
			
		//	for (int i = numdigits; i > 0; i--)
		//	{
		//		Console.WriteLine($"<! i = {i}");
		//		int maxval = (int)Math.Pow(sequence.Length, i);
		//		if (tempval > maxval)
		//		{
		//			Console.WriteLine($"<! tempval: {tempval}, maxval: {maxval} >");
		//			Console.WriteLine($"<! {maxval} / {tempval} = {maxval / tempval} >");
		//			int val = maxval / tempval;
		//			Console.WriteLine($"<! val is {val} >");
		//			strval += sequence[val];
		//			Console.WriteLine($"<! Value: {strval} >");
		//			tempval -= maxval;
		//		}
		//		else if (tempval < maxval)
		//		{
		//			Console.WriteLine($"<<//OVERSEER IS SEEN//>>");
		//			Console.WriteLine($"<! tempval: {tempval}, maxval: {maxval} >");
		//			int tempmax = (int)Math.Pow(sequence.Length, i - 1);
		//			Console.WriteLine($"<! tempval: {tempval}, maxval: {tempmax} >");
		//			Console.WriteLine($"<! {tempval} / {tempmax} = {(int)(tempval / tempmax)} >");
		//			int val = tempval / tempmax;
		//			strval += sequence[val];
		//			Console.WriteLine($"<! Value: {strval}");
		//		}
		//		else
		//		{
		//			Console.WriteLine($"<<//...null...//>>");
		//		}
		//	}

		//	return strval;
		//}
	}
}