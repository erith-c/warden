using System;
using System.Collections.Generic;
using System.Text;

namespace ALS.WARDEN
{
	public struct ID
	{
		private static int _ID = 0;

		public static string GetID()
		{
			_ID++;
			return _ID.ToString("X");
		}
	}
}
