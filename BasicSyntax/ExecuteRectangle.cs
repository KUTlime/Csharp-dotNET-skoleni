using System;

// UVedení oboru názvů pro objekty.
// Přístup je poté následující: JmenoOboruNazvu.JmenoTridy
namespace BasicSyntax
{
	// Třída aplikace, která drží vstupní bod.
	public static class ExecuteRectangle
	{
		static void Main(string[] args)
		{
			// Použití vytvořené třídy v produkčním kódu.
			// C# používá příponu souboru *.cs
			// a je dobrá praxe, že každá třída (class)
			// má svůj vlastní soubor *.cs
			// Proto třídu Rectangle najdeme v souboru Rectangle.cs
			Rectangle r = new Rectangle();
			r.AcceptDetails(); // Volání členské metody, která je definována v třídě Rectangle.
			r.Display(); // ------------||----------------
			Console.WriteLine(r.Equals(new Rectangle())); // Použití porovnávací funkce.
			Console.WriteLine(r.Equals(10)); // Vrátí false.
			Console.ReadLine();
		}
	}
}