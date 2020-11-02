﻿using System; // Zahrnutí knihovny System do kódu.

// Definice oboru názvů pro kód.
namespace BasicSyntax
{
	/// <summary>
	/// XML komentář. Velice užitečný pro automatické generování dokumentace ke kódu.
	/// Definice třídy.
	/// </summary>
	public class Rectangle
	{

		// členské proměnné
		double _length; // komentáře na řádku

		/// <summary>
		/// Komentář může být i tady.
		/// </summary>
		double _width;

		// členské vlastnosti
		public String Name { get; set; }

		// členské metody
		/// <summary>
		/// Metoda bez návratové hodnoty.
		/// </summary>
		public void AcceptDetails()
		{ // Začátek metody.
			_length = 4.5;
			_width = 3.5;
		} // Konec metody, uzavřené v bloku {}


		/// <summary>
		/// Metoda s návhratovou hodnotou.
		/// </summary>
		/// <returns>Návratová hodnota.</returns>
		public double GetArea()
		{
			// Pokud není uveden v podpisu funkce void
			// musí tělo funkce obsahovat return,
			// který definuje, co se má vlastně vrátit.
			return _length * _width;
		}

		/// <summary>
		/// Metoda s návhratovou hodnotou a vstupním parametrem.
		/// </summary>
		/// <returns>Návratová hodnota.</returns>
		/// <param name="length">A length parameter commentary.</param>
		public double GetArea(double length)
		{
			return length * length;
		}

		/// <summary>
		/// Další metoda.
		/// </summary>
		public void Display()
		{
			Console.WriteLine("Length: {0}", _length);
			Console.WriteLine("Width: {0}", _width);
			Console.WriteLine("Area: {0}", GetArea());
		}

		/*
        /// <summary>
        /// Multiřádkový komentář.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Length: {_length}");
            Console.WriteLine($"Width: {_width}");
            Console.WriteLine($"Area: {GetArea()}");
        }
        */

		// Přetížení metody z System.Object
		// Metoda porovnává dva objekty stejného typu a vrátí pravdu/nepravdu,
		// podle toho, jestli si délka (_length) a šířka (_width) obou obdélníků odpovídá.
		// (co to je, vysvětleno dále)
		public override bool Equals(object obj)
		{
			// Z příchozího objektu obj se pokusíme vytvořit objekt typu Rectangle.
			var rectangle = obj as Rectangle;
			// Pokud se nám to nepodaří, operátor as nám vrátí null, čili reclangle = null
			if (rectangle == null)
			{
				// Pokud by se tak stalo, okamžitě vrátíme nepravdu, protože tvzení, že si nejsou rovny.
				return false;
			}
			// Tady provedeme samotné srovnání hodnot šířky a délky obou obdélníků.
			return (_length == rectangle._length && _width == rectangle._width);
		}
	}
}