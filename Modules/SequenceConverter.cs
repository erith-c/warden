using System;

namespace AngelLight.Modules
{
	public class SequenceConverter
	{
		public string Sequence { get; set; }
		public int Value { get; set; }

		public SequenceConverter()
		{
			Sequence = "";
			Value = 0;
		}
		public SequenceConverter( string sequence )
		{
			Sequence = sequence;
			Value = 0;
		}

		public void UpdateSequence( string sequence ) => this.Sequence = sequence;
		public void UpdateValue( int value ) => this.Value = value;
		public void Update( string sequence, int value )
		{
			UpdateSequence(sequence); UpdateValue(value);
		}

		public int GetNumberOfDigits( int value, int numtimes = 1 )
		{
			if (value >= this.Sequence.Length)
			{
				numtimes++;
				return GetNumberOfDigits( value / this.Sequence.Length, numtimes );
			}
			return numtimes;
		}

		public string ConvertValue()
		{
			string ConvertedValue = "";
			int NumberOfDigits = this.GetNumberOfDigits( this.Value );
			int tempmax, tempval = 0;

			for (int i = NumberOfDigits; i > 0; i--)
			{
				this.Value -= tempval;

				tempmax = (int)Math.Pow(this.Sequence.Length, i - 1);
				tempval = this.Value / tempmax;
				ConvertedValue += this.Sequence[tempval];

				tempval *= tempmax;
			}

			return ConvertedValue;

		}
	}
}
