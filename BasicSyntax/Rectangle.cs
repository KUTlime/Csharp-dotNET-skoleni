// Definice oboru názvů pro kód.
namespace BasicSyntax;

/// <summary>
/// XML komentář. Velice užitečný pro automatické generování dokumentace ke kódu.
/// Definice třídy.
/// <remarks>
/// Test
/// </remarks>
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
	public string? Name { get; set; }

	// členské metody
	/// <summary>
	/// Metoda bez návratové hodnoty.
	/// Metoda be vstupních parametrů.
	/// </summary>
	public void AcceptDetails()
	{ // Začátek metody.
		_length = 4.5;
		_width = 3.5;
	} // Konec metody, uzavřené v bloku {}


	/// <summary>
	/// Metoda s návratovou hodnotou.
	/// </summary>
	/// <returns>Návratová hodnota.</returns>
	public double GetArea()
	{
		// Pokud není uveden v podpisu funkce void
		// musí tělo funkce obsahovat return,
		// který definuje, co se má vlastně vrátit.
		return _length * _width;
	}

	public double GetAreaByExpression() => _length * _width;

	/// <summary>
	/// Metoda s návratovou hodnotou a vstupním parametrem.
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
		Console.WriteLine($"Length: {_length}");
		Console.WriteLine($"Width: {_width}");
		Console.WriteLine($"Area: {GetArea()}");
	}

	/*
        /// <summary>
        /// Multi řádkový komentář.
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