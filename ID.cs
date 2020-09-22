using System;
using System.Collections.Generic;
using System.Text;

namespace ALS.WARDEN
{
	public struct ID
	{
		private static int _ID = 0;

		public static string NewID()
		{
			_ID++;
			return GetID();
		}

		public static string GetID()
		{
			return _ID.ToString("X");
		}
	}
}
