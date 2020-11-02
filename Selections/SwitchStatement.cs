using System;

namespace Selections
{
	class SwitchStatement
	{
		public enum Color { Red, Green, Blue }

		static void SwitchStatements()
		{
			Int32 caseSwitch = 1;

			switch (caseSwitch)
			{
				case 1:
					Console.WriteLine("Case 1");
					break;
				case 2:
					Console.WriteLine("Case 2");
					break;
				default:
					Console.WriteLine("Default case");
					break;
			}

			Color c = (Color)(new Random()).Next(0, 3); // Generuji číslo od 0 do 3, přetypuji na enum Color
														// (viz začátek tohoto souboru) a pak použiji ve switchi.
			switch (c)
			{
				case Color.Red:
					Console.WriteLine("The color is red");
					break;
				case Color.Green:
					Console.WriteLine("The color is green");
					break;
				case Color.Blue:
					Console.WriteLine("The color is blue");
					break;
				default:
					Console.WriteLine("The color is unknown.");
					break;
			}
			// Ekvivalent k následujícímu kódu:
			if (c == Color.Red)
			{
				Console.WriteLine("The color is red");
			}
			else if (c == Color.Green)
			{
				Console.WriteLine("The color is green");
			}
			else if (c == Color.Blue)
			{
				Console.WriteLine("The color is blue");
			}
			else
			{
				Console.WriteLine("The color is unknown.");
			}

			// Vícenásobný case a funkce break
			switch (caseSwitch)
			{
				case 1:
					Console.WriteLine("Case 1");
					break;
				case 2:
					Console.WriteLine("Case 2");
					break;
				case 3:
				case 4:
					Console.WriteLine("Case 3 || 4");
					break;
				default:
					Console.WriteLine("Default case");
					break;
			}
		}
	}
}
