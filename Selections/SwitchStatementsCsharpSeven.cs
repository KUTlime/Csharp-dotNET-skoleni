using System;
using System.Collections.Generic;
using System.Linq;

namespace Selections
{
	class SwitchStatementsCsharpSeven
	{
		/*
        #############################################################################
        ### switch a mapování typů před a po C# verzi 7.0
        #############################################################################
        Před:
        case constant:

        A bool literal, either true or false.
        Any integral constant, such as an int, a long, or a byte.
        The name of a declared const variable.
        An enumeration constant.
        A char literal.
        A string literal.

        If expr and constant are integral types, the C# equality operator determines whether the expression returns true (that is, whether expr == constant).
        Otherwise, the value of the expression is determined by a call to the static Object.Equals(expr, constant) method.


        Po (tj. 7.0 a vyšší):

        #############################################################################
        */

		static void SwitchStatements()
		{
			// Základní funkcionalita před C# 7.0
			switch (DateTime.Now.DayOfWeek)
			{
				case DayOfWeek.Sunday:
				case DayOfWeek.Saturday:
					Console.WriteLine("The weekend");
					break;
				case DayOfWeek.Monday:
					Console.WriteLine("The first day of the work week.");
					break;
				case DayOfWeek.Friday:
					Console.WriteLine("The last day of the work week.");
					break;
				default:
					Console.WriteLine("The middle of the work week.");
					break;
			}

			// Switch s případy podle typů - C# 7.0 a vyšší
			Int32 sum = 0;
			object item = new object();

			switch (item)
			{
				//  A null reference.
				case null:
					break;
				// A single zero value.
				case 0:
					break;
				// A single value.
				case int val:
					sum += val;
					break;
				// A non-empty collection.
				case IEnumerable<object> subList when subList.Any():
					foreach (var itemFromCollection in subList)
					{
						Console.WriteLine(itemFromCollection);
					}
					break;
				// An empty collection.
				case IEnumerable<object> subList:
					break;

				// A value that is neither an integer nor a collection.
				default:
					throw new InvalidOperationException("unknown item type");
			}

			// switch s rozsahem hodnot
			// U case si vytvoříme pomocnou proměnnou, ideálně stejného
			// datového typu, která nám slouží k např. porovnání za kauzulí
			// when.
			// Tímto dojde k přejmenování "i" na "n", které funguje jako
			// zástupný alias. Datový typ musí být shodný u všech case
			// případů.
			Int32 i = 63;
			switch (i)
			{
				case Int32 n when (n >= 100):
					Console.WriteLine($"I am 100 or above: {n}");
					break;

				case var n when (n < 100 && n >= 50):
					Console.WriteLine($"I am between 99 and 50: {n}");
					break;

				case var n when (n < 50):
					Console.WriteLine($"I am less than 50: {n}");
					break;
			}
		}
	}
}
