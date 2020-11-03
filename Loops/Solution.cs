using System;
using System.Collections.Generic;
using System.Text;

namespace Loops
{
	class Solution
	{
		static void Execute()
		{
			bool repeateEntry;
			do
			{
				repeateEntry = Selections.Solution.TaskOne();
			} while (repeateEntry);
		}

		static void AlternativeExecute()
		{
			byte result;
			do
			{
				Console.WriteLine("Zadejte číslo od 0 do 9:");
			} while (!byte.TryParse(Console.ReadLine(), out result) || result > 9 || result < 0 );
		}
	}
}
