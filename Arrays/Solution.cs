using System;
using System.Linq;

namespace Arrays
{
	class Solution
	{
		public static Int32[] GetPrimes(Int32 upperBound)
		{
			Int32[] temp = new Int32[upperBound];
			Int32 lastPrimeIndex = 0;
			for (int i = 0; i <= upperBound; i++)
			{
				if (IsPrime(i))
				{
					temp[lastPrimeIndex] = i;
					lastPrimeIndex++;
				}
			}
			Int32[] result = new Int32[lastPrimeIndex];
			Array.Copy(temp, result, lastPrimeIndex);
			return temp;
		}

		private static bool IsPrime(Int32 p)
		{
			for (int i = 2; i < p; i++)
			{
				if (p % i == 0)
				{
					return false;
				}
			}
			return true;
		}

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