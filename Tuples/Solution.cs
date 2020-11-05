using System;
using System.Collections.Generic;

namespace Tuples
{
	class Solution
	{
		public static (double Average, double Variance, double Deviation) Stats(IEnumerable<double> arr)
		{
			double average = 0;
			double variance = 0;
			double deviation = 0;
			UInt64 count = 0;

			// Average
			foreach (var number in arr)
			{
				average += number;
				count++;
			}
			average /= count;

			// Variance

			// Deviation

			return (average, variance, deviation);
		}
	}
}