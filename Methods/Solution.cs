using System;

namespace Methods
{
	class Solution
	{
		public static UInt64 Factorial(UInt64 n)
		{
			UInt64 result = 1;
			if (n < 2)
			{
				return result;
			}


			for (UInt64 i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public static UInt64 Factorial(Int32 n)
		{
			return n < 0 ? (UInt64)0 : Factorial((UInt64)n);
		}

		public static void Fibonacci(UInt64 upperBound, UInt64 numberOfNumbers = 0)
		{
			UInt64 fibonacci = 1;
			UInt64 fibonacciTemp = 0;
			UInt64 fibonacciTemp2 = 0;
			UInt64 i = 1;
			if (numberOfNumbers != 0)
			{
				for (; i <= numberOfNumbers;)
				{
					FibLocal();
				}
			}
			else
			{
				for (; i < UInt64.MaxValue;)
				{
					if (fibonacci > upperBound)
					{
						break;
					}
					FibLocal();
				}
			}

			void FibLocal()
			{
				fibonacciTemp2 = fibonacci;
				Console.WriteLine($"Fibonacci {i}: {fibonacci}");
				fibonacci += fibonacciTemp;
				fibonacciTemp = fibonacciTemp2;
				i++;
			}
		}
	}
}