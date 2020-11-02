using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Strings
{
	class Strings
	{
		/*
        #############################################################################
        ### Stringy - Textové řetězce
        #############################################################################

        Dobré vědět:
        - Referenční typ
        - Neměnný (immutable)
        - < C# 8.0 - může obsahovat null
        - >= C# 8.0 - nemůže obsahovat null.
        - Paměťová náročnost: 20+(n/2)*4 bajtů (n/2 zaokrouhleno dolů)

        Vytvoření stringu:
        - Přiřazení literálu.
        - Konstruktoru třídy string.
        - Použitím operátoru, např. +
        - Návratová hodnota z metody nebo vlastnosti.
        - Formátováním a převedením z jiných datových typů.

        Typy stringů (literálů):
        - Klasický, např. "C:\\Windows\\System32"
        - Univerzální (Verbatim), např. @"C:\Windows\System32"
        - Interpolovaný (C# 6 a vyšší), např. $"Výsledek: {result}"
        - Kompozitně formátovaný, např. Console.WriteLine("Result: {0}", result);
        
        Kompozitní vs. interpolované formátování:
        - String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now);
        - $"Name = {name}, hours = {DateTime.Now:hh}";

        Escape sekvence:
        \' - single quote, needed for character literals
        \" - double quote, needed for string literals
        \\ - backslash
        \0 - Unicode character 0
        \a - Alert (character 7)
        \b - Backspace (character 8)
        \f - Form feed (character 12)
        \n - New line (character 10)
        \r - Carriage return (character 13)
        \t - Horizontal tab (character 9)
        \v - Vertical quote (character 11)
        \uxxxx - Unicode escape sequence for character with hex value xxxx
        \xn[n][n][n] - Unicode escape sequence for character with hex value nnnn (variable length version of \uxxxx)
        \Uxxxxxxxx - Unicode escape sequence for character with hex value xxxxxxxx (for generating surrogates)

        #############################################################################
        */
		static void Main(string[] args)
		{
			// Vytváření stringů

			// Z literálů
			string fname, lname;    // Deklarace stringů
			fname = "Radek";        // Inicializace z literálu
			lname = "Zahradník";    // ----||----

			// Spojení stringů
			char[] letters = { 'H', 'e', 'l', 'l', 'o' };
			string[] sarray = { "Vítejte", "na", "mém", "školení." };
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
			Console.WriteLine("Unicode character: \u06B0");

			// Volání funkce (Kompozitně formátovaný string)
			string multiple = String.Format("0x{0:X} {0:E} {0:N} {0:C}", Int64.MaxValue); // 0x7FFFFFFFFFFFFFFF 9,223372E+018 9 223 372 036 854 775 807,00 9 223 372 036 854 775 807,00 Kč"
			string multiple2 = $"0x{Int64.MaxValue:X} {Int64.MaxValue:E} {Int64.MaxValue:N} {Int64.MaxValue:C}"; // Interpolovaný string

			// Operátor sčítání stringů
			string fullname = fname + lname;
			Console.WriteLine("Full Name:\t \"{0}\"", fullname);
			Console.WriteLine($"Full Name:\t \"{fullname}\"");

			//Použití konstruktoru { 'H', 'e', 'l', 'l','o' };
			string greetings = new String(letters);
			//string greetings2 = new String("asdf"); // Pouze znakové pole
			Console.WriteLine("Greetings: {0}", greetings);

			//Návratová hodnota z metody
			string msg = String.Join(" ", sarray);
			Console.WriteLine("Message: {0}", msg);

			//Formátování stringů
			double value = 12345.6789;
			Console.WriteLine(value.ToString("C", provider: System.Globalization.CultureInfo.CurrentCulture));
			Console.WriteLine(value.ToString("C3", System.Globalization.CultureInfo.CurrentCulture));
			Console.WriteLine(value.ToString("C3", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
			Console.WriteLine(value.ToString("C3", System.Globalization.CultureInfo.CreateSpecificCulture("cs-CZ")));
			Console.WriteLine(value.ToString("C3", System.Globalization.CultureInfo.CreateSpecificCulture("da-DK")));


			string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
				"Ebenezer", "Francine", "George" };
			decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80, 16.75m };

			// Formátování: [Pořadí parametru],[Pozice parametru]:[Příznak] 
			Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");
			for (int ctr = 0; ctr < names.Length; ctr++)
			{
				Console.WriteLine("{0,-20} {1,5:N1}", names[ctr], hours[ctr]);
				Console.WriteLine($"{names[ctr],-20} {hours[ctr],5:N1}");
			}

			// Výstup:
			//       Name                 Hours
			//
			//       Adam                  40.0
			//       Bridgette              6.7
			//       Carla                 40.4
			//       Daniel                82.0
			//       Ebenezer              40.3
			//       Francine              80.0
			//       George                16.8

			// Vložení složených závorek
			int someNumber = 6324;
			string output = string.Format("{0}{1:D}{2}", "{", someNumber, "}");
			Console.WriteLine(output);
			Console.WriteLine($"{"{"}{someNumber:D}{"}"}");
			Console.WriteLine($"{{{someNumber:D}}}");   // Alternativa 
														// The example displays the following output:
														//       {6324}

			// Formátování pomocí operátoru + na více řádků pro lepší čitelnost.
			// Visual Studio umí při zmáčknutí Enteru v dlouhém řetězci automaticky
			// přidat + na konec řádku a správně string rozdělit.
			Console.WriteLine("Test" +
							  " Test " +
							  "Test.");
			Console.WriteLine("Some very" +
							  " long text line " +
							  "which I would " +
							  "like to break.");

			// Formátování času a data
			string formatString1 = String.Format("{0:dddd MMMM}", DateTime.Now);
			string formatString2 = String.Format("{0:dddd MMMM}", DateTime.UtcNow); // #BestPractise
			string formatString3 = $"{DateTime.Now:dddd MMMM}";
			string formatString4 = DateTime.Now.ToString("dddd MMMM");

			DateTime waiting = new DateTime(2012, 10, 10, 17, 58, 1);
			string chat = String.Format("Message sent at {0:t} on {0:D}", waiting);
			Console.WriteLine("Message: {0}", chat);

			// Formátování data dle kultury
			var cultures = new System.Globalization.CultureInfo[]
			{
				System.Globalization.CultureInfo.GetCultureInfo("en-US"),
				System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
				System.Globalization.CultureInfo.GetCultureInfo("nl-NL"),
				System.Globalization.CultureInfo.InvariantCulture
			};

			var date = DateTime.Now;
			var number = 31_415_926.536;
			FormattableString message = $"{date,20}{number,20:N3}";
			foreach (var culture in cultures)
			{
				var cultureSpecificMessage = message.ToString(culture);
				Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
			}

			// Výstup:
			// en-US       5/17/18 3:44:55 PM      31,415,926.536
			// en-GB      17/05/2018 15:44:55      31,415,926.536
			// nl-NL        17-05-18 15:44:55      31.415.926,536
			//            05/17/2018 15:44:55      31,415,926.536

			// Výstup pro UK culture
			DateTime.UtcNow.ToString("s"); //"2019-02-06T09:33:02"
			DateTime.UtcNow.ToString("D"); // "06 February 2019"
			DateTime.UtcNow.ToString("d"); // "06/02/2019"
			DateTime.UtcNow.ToString("F"); // "06 February 2019 09:33:55"
			DateTime.UtcNow.ToString("f"); // "06 February 2019 09:34"
			DateTime.UtcNow.ToString("G"); // "06/02/2019 09:34:20"
			DateTime.UtcNow.ToString("g"); // "06/02/2019 09:34"
			DateTime.UtcNow.ToString("M"); // "6 February"
			DateTime.UtcNow.ToString("O"); // "2019-02-06T09:34:51.9233709Z"
			DateTime.UtcNow.ToString("R"); // "Wed, 06 Feb 2019 09:35:00 GMT"
			DateTime.UtcNow.ToString("T"); // "09:35:09"
			DateTime.UtcNow.ToString("t"); // "09:38"
			DateTime.UtcNow.ToString("U"); // "06 February 2019 09:39:09"
			DateTime.UtcNow.ToString("u"); // "2019-02-06 09:39:21Z"
			DateTime.UtcNow.ToString("Y"); // "February 2019"
			DateTime.UtcNow.ToString("yyyy-M-d dddd"); // "2019-2-6 Wednesday"
			DateTime.UtcNow.ToString("h:mm:ss tt zz"); // "9:40:23 AM +01"
			DateTime.UtcNow.ToString("HH:mm:ss tt zz"); // "09:40:38 AM +01"
			DateTime.UtcNow.ToString("hh:mm:ss t z"); // "09:41:52 A +1"
			DateTime.UtcNow.ToString("HH:mm:ss tt zz", new CultureInfo("cs-CZ")); // "09:45:18 dop. +01" v CZ kultuře.

			// Třídění stringů

			string[] values = { "able", "ångström", "apple", "Æble", "Windows", "Visual Studio" };
			Array.Sort(values);
			DisplayArray(values);

			// Třídění dle švédštiny
			string originalCulture = CultureInfo.CurrentCulture.Name;
			Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");
			Array.Sort(values);
			DisplayArray(values);

			// Obnovení původního nastavení kultury.
			Thread.CurrentThread.CurrentCulture = new CultureInfo(originalCulture);


			void DisplayArray(string[] arr)
			{
				Console.WriteLine("Sorting using the {0} culture:",
					CultureInfo.CurrentCulture.Name);
				foreach (string item in arr)
					Console.WriteLine("   {0}", item);

				Console.WriteLine();
			}



			// Základní metody pro práci se stringy

			string str1 = "This is test";
			string str2 = "This is text";

			// Kulturně agnostické porovnávání stringů
			if (String.CompareOrdinal(str1, str2) == 0)
			{
				Console.WriteLine(str1 + " and " + str2 + " are equal.");
			}
			else
			{
				Console.WriteLine(str1 + " and " + str2 + " are not equal.");
			}

			// Ekvivalent s pomocí přetížení metody Compare.
			if (String.Compare(str1, str2, StringComparison.Ordinal) == 0)
			{
				Console.WriteLine(str1 + " and " + str2 + " are equal.");
			}
			else
			{
				Console.WriteLine(str1 + " and " + str2 + " are not equal.");
			}

			string str = "This is test";
			if (str.Contains("test"))
			{
				Console.WriteLine("The sequence 'test' was found.");
			}

			// Část stringu
			str = "Last night I dreamt of San Pedro"; // Co se stane, když uděláme toto?
			str = "Last night I dreamt of San Pedros"; // A teď?
			Console.WriteLine(str);
			string substr = str.Substring(startIndex: 23);
			Console.WriteLine(substr);
			string substr2 = str.Substring(startIndex: 10, length: 10);
			Console.WriteLine(substr2);


			string[] starray = new string[]{"Down the way nights are dark",
				"And the sun shines daily on the mountain top",
				"I took a trip on a sailing ship",
				"And when I reached Jamaica",
				"I made a stop"};

			str = String.Join("\n", starray);

			Console.ReadKey();
		}
	}
}
