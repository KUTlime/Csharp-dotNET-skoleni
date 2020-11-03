using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Classes
{
	class StaticVsNonStatic
	{
		static void Dummy()
		{
			// Jak zjistím delku nějakého textového řetězce?
			string someString = "RadekZahradník";
			Console.WriteLine("Délka řetězce je: " + someString.Length);

			Console.WriteLine("Je délka textového řetězce větší než 5? " + ((someString.Length > 5) ? "Ano" : "Ne") );
			
			// Test jestli textový řetězec neobsahuje slovíčko prdel
			Console.WriteLine("Obsahuje prdel? " + (someString.Contains("prdel") ? "Ano" : "Ne") );

			string someString2 = "someStringWithPrdel";
			Console.WriteLine("Obsahuje prdel? " + (someString2.Contains("prdel") ? "Ano" : "Ne") );

			Console.WriteLine("Obsahuje kunda? " + (someString.Contains("kudna") ? "Ano" : "Ne"));
			Console.WriteLine("Obsahuje kunda? " + (someString2.Contains("kudna") ? "Ano" : "Ne"));

			// Chci to teď zvalidovat pořádně (správně)
			Console.WriteLine("Je to v pohodě? " + (new Validation().Validate(someString) ? "Ano" : "Ne"));
			Console.WriteLine("Je to v pohodě? " + (Validation.BetterValidate(someString2) ? "Ano" : "Ne"));

		}
	}

	class Validation
	{
		static List<string> prohibitedWords = new List<string>()
		{
			"prdel",
			"kunda"
		};

		public bool Validate(string str)
		{
			bool result = true;
			foreach (string badWord in prohibitedWords)
			{
				result &= !str.Contains(badWord); // result = result & s negací výsledku str.Contains(...)
			}
			return result;
		}

		public static bool BetterValidate(string str)
		{
			foreach (string badWord in prohibitedWords)
			{
				if (str.Contains(badWord))
				{
					return false;
				}
			}
			return true;
		}
	}

	// Klíčovým slovíčkem static u názvu třídy přímo zamezujeme vytvoření
	// instance této třídy.
	// Nesmíme zapomenout, že výchozí prázdný konstruktor se přidá automaticky.
	static class Test
	{
		// Tady klíčové slovičko static znamená, že tato metoda nepotřebuje žádné
		// proměnné třídy pro svou práci a může pracovat samostatně, bez nějakého
		// konkrétního stavu.
		public static void DoSomething()
		{
		}
	}
}
