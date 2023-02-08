namespace Classes;

static class Test2
{
	public static int Test { get; } = 0;
}
class Classes
{
/*
#############################################################################
### Třídy - uživatelem definované datové typy
#############################################################################
Zápis třídy:
<úroveň přístupu> <Oblast platnosti> class JménoTřídy
{
	// členské proměnné
	<úroveň přístupu> <Oblast platnosti> <datový typ> JménoProměnné;
	<úroveň přístupu> <Oblast platnosti> <datový typ> JménoProměnné2;
	...
	<úroveň přístupu> <Oblast platnosti> <datový typ> JménoProměnnéN;
           
	// členské metody
	<úroveň přístupu> <Oblast platnosti> <návratový typ> JménoFunkce(<Seznam parametrů>)
	{
		// tělo metody
	}
	<úroveň přístupu> <Oblast platnosti> <návratový typ> JménoFunkce2(<Seznam parametrů>)
	{
		// tělo metody
	}
	...
	<úroveň přístupu> <Oblast platnosti> <návratový typ> JménoFunkceN(<Seznam parametrů>)
	{
		// tělo metody
	}
}

Dále je dobré vědět:
- Přístup k členským proměnným skrze operátor .
- Výchozí modifikátor přístupu pro třídy je internal.
- Výchozí modifikátor přístupu pro členské proměnné je private.
- Můžeme vytvářet zanořené třídy, tj. třídy uvnitř tříd. Použití např. při složité návratové hodnotě nebo volání metody, viz příklad níže.

#############################################################################

*/
	static void Main(string[] args)
	{
		var callingConstructorDemo = new CallingConstructorDemo();

		Box box1 = new Box();   // Vytváření instance objektu Box1 jako typu Box.
		Box box2 = new Box();   // Volání výchozícho konstruktoru.
		double volume = 0.0;    // Definice pomocné proměnné

		// box 1 specifikace, operátor přístupu . a přímá manipulace s členskými proměnnými
		box1.Height = 5.0;
		box1.Length = 6.0;
		box1.Breadth = 7.0;

		// box 2 specifikace
		box2.Height = 10.0;
		box2.Length = 12.0;
		box2.Breadth = 13.0;

		// Veřejné spočítání objemu
		volume = box1.Height * box1.Length * box1.Breadth;
		Console.WriteLine("Volume of Box1 : {0}", volume);

		// volume of box 2
		Console.WriteLine("Volume of Box2 : {0}", box2.GetVolume());

		var box3 = new BoxV2();
		var box4 = new BoxV2();

		// Deklarace Box3 typu BoxV2
		// Nastavení vlastností objektu Box3
		box3.SetLength(6.0);
		box3.SetBreadth(7.0);
		box3.SetHeight(5.0);

		// Deklarace Box4 typu BoxV2
		box4.SetLength(12.0);
		box4.SetBreadth(13.0);
		box4.SetHeight(10.0);

		// Získání objemu z box3
		volume = box3.GetVolume();
		Console.WriteLine("Volume of Box1 : {0}", volume);

		// volume of box 4
		Console.WriteLine($"Volume of Box2 : {box4.GetVolume()}");

		var box5 = new BoxV3();
		var box6 = new BoxV3(10, 0.1, 51.3);

		var box7 = new BoxV4(); // Předá volání do druhého konstruktoru s hodnotami 0,0,0

		Utils.LogPath = @"C:\ProgramData\MyApp\Log";    // Přístup ke statické proměnné
		Utils.WriteToLog("Test");               // Přístup ke statické funkci

		var utilsInstance = new Utils();
		utilsInstance.Prefix = "001_"; // Tady můžeme změnit nestatickou veřejnou proměnnou.
		utilsInstance.WriteToLogFile("Test", "Log.log");

		Utils2.SomeMethod();

		Console.ReadKey();
	}
}

// Box je implicitně definován jako internal
class Box
{
	public double Length;   // Délka
	public double Breadth;  // Hloubka
	public double Height;   // Výška

	public double GetVolume()
	{
		return Breadth * Height * Height;
	}
}

// O zapouzdření vylepšená verze boxu z předchozích řádků.
class BoxV2
{
	// proměnné jsou implicitně definovány jako privátní.
	double _length;   // Délka
	double _breadth;  // Hloubka
	double _height;   // Výška

	public void SetLength(double len)
	{
		_length = len < 0.0 ? 0 : len;
	}
	public void SetBreadth(double bre)
	{
		_breadth = bre < 0.0 ? 0 : bre;
	}
	public void SetHeight(double hei)
	{
		_height = hei < 0.0 ? 0 : hei;
	}
	public double GetVolume()
	{
		return _length * _breadth * _height;
	}
}

// O kontruktor/destruktor vylepšená verze.
// Syntaxe konstruktoru je následující:
// NázevTřídy()
// {
//     // Tělo konstruktoru   
// }
// Syntaxe destruktoru je následující:
// ~NázevTřídy()
// {
//     // Tělo konstruktoru   
// }
class BoxV3
{
	double _length;   // Délka
	double _breadth;  // Hloubka
	double _height;   // Výška

	public BoxV3(double length, double breadth, double height)
	{
		Console.WriteLine("The box is being build.");
		_length = length > 0.0 ? length : 0.0;
		_breadth = breadth > 0.0 ? breadth : 0.0;
		_height = height > 0.0 ? height : 0.0;
	}
	/*
        BoxV3(double length = 0, double breadth = 0, double height = 0)
        {
            Console.WriteLine("The box is being build.");
            _length = length;
            _breadth = breadth;
            _height = height;
        }
        */
	// Explicitní výchozí konstruktor (konstruktor bez parametrů)
	public BoxV3()
	{
		Console.WriteLine("Výchozí konstruktor pro BoxV3");
		_length = 0;
		_breadth = 0;
		_height = 0;
	}

	// Explicitní destruktor
	~BoxV3()
	{
		Console.WriteLine("The box is being discarded.");
	}

	public void SetLength(double len)
	{
		_length = len;
	}
	public void SetBreadth(double bre)
	{
		_breadth = bre;
	}
	public void SetHeight(double hei)
	{
		_height = hei;
	}
	public double GetVolume()
	{
		return _length * _breadth * _height;
	}
}

class BoxV4
{
	double _length;   // Délka
	double _breadth;  // Hloubka
	double _height;   // Výška

	public BoxV4(double length, double breadth, double height)
	{
		Console.WriteLine("The box is being build.");
		SetLength(length);
		SetBreadth(breadth);
		SetHeight(height);
	}

	// Zřetězení konstruktorů
	public BoxV4() : this(0, 0, 0)
	{}

	public void SetLength(double length)
	{
		_length = length > 0.0 ? length : 0.0;
	}
	public void SetBreadth(double breadth)
	{
		_breadth = breadth > 0.0 ? breadth : 0.0;
	}
	public void SetHeight(double height)
	{
		_height = height > 0.0 ? height : 0.0;
	}
	public double GetVolume()
	{
		return _length * _breadth * _height;
	}
}

// Význam oboru platnosti
class Utils
{
	public static string LogPath = @"C:\Program Data\MyApp\Log"; // Lze nastavovat zvenčí.
	private static string LogName = "Log.log";                      // Nelze nastavit zvenčí.

	public string Prefix = DateTime.UtcNow.ToString("s") + "_";

	// Nestatická metoda uvnitř nestatické třídy.
	// Vyžaduje instanci.
	public void WriteToLogFile(string message, string fileName)
	{
		using (var file = new StreamWriter(LogPath + (Prefix + fileName), true))
		{
			file.WriteLineAsync(message);
		}
	}

	// Statická metoda uvnitř nestatické třídy.
	// Lze volat napřímo.
	public static void WriteToLog(string message)
	{
		using (var file = new StreamWriter(LogPath + LogName, true))
		{
			file.WriteLineAsync(message);
		}
	}
}

// Definice plně statické třídy
// Veškerý obsah musí být statický a nelze vytvořit žádný
// nestatický obsah uvnitř třídy.
public static class Utils2
{
	public static string name = String.Empty;
	//public string name = String.Empty; // Není OK
	static Utils2()
	{
		Console.WriteLine("A default static constructor");
	}
	public static void SomeMethod()
	{
	}

	//public void SomeNonStaticMethod()
	//{
	//}
}

class CallingConstructorDemo
{
	private Int32 _someValue1 = 0;
	private Int32 _someValue2 = 0;
	private Int32 _someValue3 = 0;

	// Volání přetíženého konstruktoru s pomocí slova this
	public CallingConstructorDemo() : this(0, 0, 0)
	{
		Console.WriteLine("A default constructor.");
	}

	// Tento konstruktor bude opravdu zavolán při volání výchozí konstruktoru.
	public CallingConstructorDemo(Int32 someValue1, Int32 someValue2, Int32 someValue3)
	{
		_someValue1 = someValue1;
		_someValue2 = someValue2;
		_someValue3 = someValue3;
	}
}

class MetadataPublisher
{
	public Int32 SomeMetadataProperty { get; set; }

	public MetadataPublisher(Int32 myHappyProperty)
	{
		SomeMetadataProperty = myHappyProperty;
	}


	public void PublishMetadatas()
	{
		// Tady můžeme vrátit třídu, která drží více návratových hodnot, ale je to zbytečné, protože pokud známe tuple, viz příslušná kapitola,
		// obejdeme se úplně bez zanořené třídy.
		// Stejně tak můžeme vytvořit zanořenou třídu pro komplikované volání privátní metody DoSomeSophisticatedWork
		var returnMultipleValues = DoSomeSophisticatedWork(1, 2, "first string", "second string");
		// Můžeme tedy nahradit tímto:
		// ... nějaký kód
		// Vytvoření pomocné proměnné pro uložení komplikovaných vstupů do zanořené třídy.
		var complicatedInputHolder = new ComplicatedInputHolder(1, 2, "first string", "second string");
		// Využití instance zanořené třídy při volání, nemusím už otrocky vypisovat. Vypíšu jednou někde a pak používám.
		returnMultipleValues = DoSomeSophisticatedWork(complicatedInputHolder);


		PublishMetada(returnMultipleValues.returnValue1);
		PublishMetada(returnMultipleValues.returnValue2);
	}

	private void PublishMetada(Object returnValue2)
	{
		// Publikování příchozího artefaktu.
	}

	private ReturnMultipleValues DoSomeSophisticatedWork(Int32 firstMetadata, Int32 secondMetadata,
		string thirdMetada, string fourthMetada)
	{
		// ... do some stuff
		SomeMetadataProperty = 0;
		// ... do some other stuff

		return new ReturnMultipleValues()
		{
			returnValue1 = 1,
			returnValue2 = 2,
		};
	}

	private ReturnMultipleValues DoSomeSophisticatedWork(ComplicatedInputHolder complicatedInputHolder)
	{
		return DoSomeSophisticatedWork(
			complicatedInputHolder.InputOne,
			complicatedInputHolder.InputTwo,
			complicatedInputHolder.InputThree,
			complicatedInputHolder.InputFour);
	}

	// Vykomentováno, protože pouhý rozdíl návratové hodnoty není dostatečný pro přetížení, musel bych si vybrat, kterou verzi nechat.
	//private (Int32, Int32) DoSomeSophisticatedWork(ComplicatedInputHolder complicatedInputHolder)
	//{
	//    return (0, 0);
	//}


	// Vytvoření zanořené třídy ReturnMultipleValues
	private class ReturnMultipleValues
	{
		public Int32 returnValue1 { get; set; }
		public Int32 returnValue2 { get; set; }
	}

	private class ComplicatedInputHolder
	{
		public Int32 InputOne { get; set; }

		public Int32 InputTwo { get; set; }

		public string InputThree { get; set; }

		public string InputFour { get; set; }

		public ComplicatedInputHolder(int iputOne, int inputTwo, string inputThree, string inputFour)
		{
			InputOne = iputOne;
			InputTwo = inputTwo;
			InputThree = inputThree;
			InputFour = inputFour
		}
	}
}

class Response
{
	public class WithSuccessfulExit
	{
		public int Code { get; } = 0;
	}

    public class WithErrorExit
    {
        public int Code { get; } = 1;
    }
}

class Test
{
	void Demo()
	{
        _ = Response.WithErrorExit.Code;
		_ = Response.WithSuccessfulExit.Code;
    }
}
