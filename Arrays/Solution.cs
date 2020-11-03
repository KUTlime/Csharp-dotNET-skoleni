using System;
using System.Linq;

namespace Arrays
{
	class Solution
	{
		public static Int32 FindSingleton(Int32[] array)
		{
			Int32 result = 0;
			foreach (var number in array)
			{
				result ^= number; // result = result ^ number;
			}
			return result;
		}

		public static void PrintDistinct(Int32[] array)
		{
			var unique = array.Distinct();
			foreach (var item in unique)
			{
				Console.WriteLine(item);
			}
		}
	}
}