using System.IO;

namespace Exceptions;

/*
#############################################################################
### Výjimky - Exceptions
#############################################################################
    
Výjimky se řídí těmito klíčovými slovy:
# try 
- Označuje blok, kde může nastat výjimka.
- Ohraničený {}
- Zanoření nedává moc smysl, ale lze.
# catch
- Ohraničený {}
- Označuje blok, kam je přesměrován tok programu po vyhození výjimky.
- Alespoň jeden pro právě jeden blog try.
- Můžeme chytat různé výjimky podle typu výjimky.
- Chytáme od nejvíce specifické výjimky k nejvíce obecné výjimce.
# finally
- Blok kódu, který je vykonán vždy, bez ohledu na to, zda výjimka nastala či nikoliv.
- Vhodné pro zavření souboru, uvazření spojení či připojení na db.
- Není povinné.
- Dává se až za catch.
# throw
- Příkaz pro vyhození výjimky.

# Chování programu (pokud není finally), tak
- try -> návrat, pokud vše OK.
- try -> catch -> návrat, pokud nastane výjimka.
- try -> catch (-> catch ...) -> návrat, pokud nastane výjimka.

# Chování programu (pokud JE finally), tak
- try -> finally -> návrat, pokud vše OK.
- try -> catch (-> catch ...) -> finally -> návrat, pokud nastane výjimka.

Syntaxe:
try 
{
    // kód, který může vyhodit výjimku
} 
catch( ExceptionType e1 ) 
{
    // zpracování chyby
} 
catch( ExceptionType e2 ) 
{
    // zpracování chyby
} 
catch( ExceptionType eN ) 
{
    // zpracování chyby
}
catch
{
    // tady spadne všechno ostatní
} 
finally 
{
    // Kód, který má být vykonán vždy.
}
    

Některé druhy systémových výjimek z System.SystemException:
1 	System.IO.IOException               Ošetřuje I/O chyby.
2 	System.IndexOutOfRangeException     Ošetřuje chyby generované při odkazu mimo rozsah pole či kolekci.
3 	System.ArrayTypeMismatchException   Ošetřuje chyby generované při pokusu uložit do jiný typ než je deklarovaný typ pole.
4 	System.NullReferenceException       Ošetřuje chyby generované při referenci na objekt, který je null.
5 	System.DivideByZeroException        Ošetřuje chyby generované při dělení nulou.
6 	System.InvalidCastException         Ošetřuje chyby generované při havárii přetypování.
7 	System.OutOfMemoryException         Ošetřuje chyby generované při nedostatku paměti.
8 	System.StackOverflowException       Ošetřuje chyby generované při přetečení zásobníku.
    
Nebezpečné scénáře:
- Zápis/čtení do souboru.
- Zápis/čtení ze sítě.
- Zápis/čtení z databáze.
- Operace s IO zařízení.
- Konverze hodnot (string -> číslo, string -> datum)

Best Practice při výjimkách:
- Vyhýbejte se výjimkám, pokud je to možné, např. file.CanWrite.
- Používejte předdefinované .NET výjimky.
- Nahraďte chybové kódy výjimkami.
- Nechytejte výjimky, které nezpracováváte.
- Pokud chcete chytat výjimky, které nezpracováváte, např. kvůli logování, používejte "throw;"
- Jména vlastních výjimek ukončete slovem Exception.
- Do vlastních výjimek vložte 3 konstruktory Exception(), Exception(String), Exception(String, Exception).
- Pište čitelné zprávy pro výjimky. Není to slohové cvičení ani žádost o dotaci na nesmyslný projekt.
- Lokalizujte zprávy, pokud je to možné.
- Předávejte maximum možných informací ve vlastních výjimkách.
- Používejte návrhový vzor builder při použití stejného druhu výjimky na více místech v rámci třídy.
*/


class Exceptions
{
	static void Main(string[] args)
	{

		DivNumbers d = new DivNumbers();
		d.Division(25, 0); // Vyhození výjimky.

		Temperature temp = new Temperature();
		try
		{
			temp.ShowTemp();
		}
		catch (TempIsZeroException e)
		{
			Console.WriteLine("TempIsZeroException: {0}", e.Message);
		}


		Console.ReadKey();
	}

	static void ExceptionHandling()
	{
		try
		{
			// Zde patří kód, kde hrozí vyhození výjimky.
		}
		catch (SomeSpecificException ex)
		{
			// Zde musí být kód pro obsluhu výjimek.
			// Chytejte pouze výjimky, které umíte obsloužit.
			// Nikdy nechytejte výjimku System.Excetion bez přehození
			// do vojícího kódu (metoda, která zavolala metodu,
			// ve které výjimka nastala) na konci catch bloku.

			// Zde by se zachytila pouze výjimka SomeSpecificException
			// a všechny ostatní typy by zůstaly nezachycené.
		}

		try
		{
			// Zde patří kód, kde hrozí vyhození výjimky.
		}
		catch (SomeSpecificException ex)
		{
			// Zde musí být kód pro obsluhu výjimek.
		}
		finally
		{
			// Zde patří kód, který se má vykonat po bloku try.
			// Vykoná se vždy, nehledě na vyhození výjimky.
		}

		// Nejčastější varianta try + catch.
		try
		{
			// Zde patří kód, kde hrozí vyhození výjimky.
		}
		catch (System.UnauthorizedAccessException e)
		{
			// Volání vlastní logu.
			LogError(e);
			// Znova vyhození poslední výjimky, která je na zásobníku výjimek nahoře.
			throw;
		}
	}

	private static void LogError(SystemException systemException)
	{
		LogError(systemException);
	}

	private class SomeSpecificException : Exception
	{
	}

	// Zachytávání různých typů výjimek.
	static void WriteToFile(string path, string message)
	{
		try
		{
			// Zde hrozí výjimka, protože StreamWriter nemá oveřovací členskou proměnnou.
			using (var sw = new StreamWriter(path))
			{
				sw.WriteLine(message);
			}
		}
		// Nahoru patří nejspecifičtější výjimky
		catch (DirectoryNotFoundException ex)
		{
			// Nějaký kód na vytvoření potřebné neexistující složky.
			Console.WriteLine(ex);
		}
		catch (FileNotFoundException ex)
		{
			// Kód na vytvoření souboru, který nebyl nalezen.
			Console.WriteLine(ex);
		}
		// Nejméně specifická výjimka patří na konec.
		catch (IOException ex)
		{
			Console.WriteLine(ex);
		}
		catch
		{
			// Zachycení všech výjimek.
		}

		Console.WriteLine("Done");
	}
}

public class DivNumbers
{
	int result;

	public DivNumbers()
	{
		result = 0;
	}

	public void Division(int num1, int num2)
	{
		try
		{
			// Problematické místo.
			result = num1 / num2;
		}
		catch (DivideByZeroException e)
		{
			Console.WriteLine("Exception caught: {0}", e);
		}
		finally
		{
			// Zde se buď vypíše platný výsledek nebo 0.
			Console.WriteLine("Result: {0}", result);
		}
	}
}

// Definice vlastní výjimky.
// MUSÍME odvodit ze třídy System.Exception.
// Jméno končí slovem "Exception".
public class TempIsZeroException : Exception
{
	public string CustomMessage { get; set; } = "Temperature can't be zero!";

	// Definice schématu tří vlastních konstruktorů.
	public TempIsZeroException() : base()
	{
	}

	public TempIsZeroException(string message) : this(message, null)
	{
	}

	public TempIsZeroException(string message, System.Exception? exception) : base(exception?.Message ?? message, exception)
	{
		CustomMessage = message;
	}
}

public class Temperature
{
	int temperature = 0;

	public void ShowTemp()
	{
		if (temperature == 0)
		{
			throw (new TempIsZeroException("Zero Temperature found"));
		}
		else
		{
			Console.WriteLine("Temperature: {0}", temperature);
		}
	}
}


// Demostrace finally
public class EHClass
{
	void ReadFile(int index)
	{
		// Pro spuštění je potřeba nahradit tuto cestu platnou cestou na daném PC.
		string path = @"c:\users\public\test.txt";
		System.IO.StreamReader file = new System.IO.StreamReader(path);
		char[] buffer = new char[10];
		try
		{
			file.ReadBlock(buffer, index, buffer.Length);
		}
		catch (System.IO.IOException e)
		{
			Console.WriteLine("Error reading from {path}. Message = {e.Message}");
		}

		finally
		{
			// Provede se vždy, ať už výjimka nastala nebo ne.
			file.Close();

			// A teď ještě uklidit buffer.
		}
	}
}

// Příklad návrhový vzor builder v kontextu výjimek
class FileReader
{
	// Privátní proměnná
	private string fileName;

	// Kontruktor ukazující na cestu k souboru.
	public FileReader(string path)
	{
		fileName = path;
	}

	// Funkce čtení ze souboru
	public byte[] Read(int bytes)
	{
		byte[] results = FileUtils.ReadFromFile(fileName, bytes);
		if (results == null)
		{
			throw NewFileIoException();
		}
		return results;
	}

	FileReaderException NewFileIoException()
	{
		string description = "My NewFileIOException Description" +
			"Error at file with name " +
			fileName;

		return new FileReaderException(description);
	}

	private class FileReaderException : System.Exception
	{
		public string Message;
		public System.Exception Exception;
		public FileReaderException()
		{

		}

		public FileReaderException(string message)
		{
			Message = message;
		}

		public FileReaderException(string message, System.Exception exception)
		{
			Message = message;
			Exception = exception;
		}
	}
}

internal class FileUtils
{
	public static byte[] ReadFromFile(string fileName, int bytes)
    {
		using FileStream fs = File.Create(fileName);
		var buffer = new byte[bytes];
		fs.Read(buffer, 0, bytes);
		return buffer;
	}
}

// Použití when u catch
// Pokud typ výjimky není dostatečný faktor pro rozlišení chování,
// můžeme použít when (výraz => Pravda/Neprava).
class ExceptionWithWhen
{
	public static void DoSomething()
	{
		try
		{
			throw new ArgumentException("Some argument exception");
		}
		catch (ArgumentException e) when ((DateTime.Now.DayOfWeek >= DayOfWeek.Monday) &&
										  (DateTime.Now.DayOfWeek <= DayOfWeek.Friday))
		{
			// Pokud je pracovní den, tak zpracujeme...
			Console.WriteLine(e);
			throw; // ...a přehodíme výše.
		}
		catch (ArgumentException e)
		{
			// Je víkend, takže... :-)
		}
	}
}
