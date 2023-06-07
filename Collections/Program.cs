using System.Collections;
using System.Globalization;

namespace Collections;

/*
#############################################################################
### Kolekce
#############################################################################

Dva druhy:
- Generické (uvedené spolu s C# 2).
- Negenerické (uvedené v 1. verzi C#).

Generické:
- Používají deklaraci generického typu <>
- System.Collections.Generic.

Negenerické:
- Vyžadují balení a rozbalování položek, proto neefektivní.
- Zastaralé a nepoužívají se.

#############################################################################
*/
static class Program
{
	static void Main(string[] args)
	{
		// Seznam
		var list = new List<string>();
		var list2 = new List<object>(); // Lze uložit na jednotlivé položky cokoliv.

		// Nyní mohu přidávat položky
		list2.Add(0);
		list2.Add("Radek");
		list2.Add(DateTime.Now);
		list2.Add(new Int32[10]);

		foreach (var item in list2)
		{
			Console.WriteLine(item.GetType());
		}

		// Definice seznamu s konkrétní přednastavenou hodnotou na 10.
		var list1 = new List<string>(10);

		list2.Remove("Radek");
		Console.WriteLine(list2[1]);
		list2.Add("Zahradník");
		list2.Add("Zahradník");

		var list3 = new List<string> { "Radek", "Zahradník" };
		var list4 = new List<string> 
		{ 
			"Radek",
			"Zahradník"
		};

		// Slovník
		var dictionary = new Dictionary<string, string>();

		// Kapacita pro 10 položek
		var dictionary2 = new Dictionary<string, string>(10);
		
		// Inicializace
		Dictionary<string, int> guys = new Dictionary<string, int>
		{
			{"Galileo", 1564},
            {"Magellan", 1480},
			{"Voltaire", 1694},
			{"Kepler", 1571},
			{"Keaton", 1895}
		};

		// (C# 6) Initialization with new dictionary initializer
		Dictionary<string, int> newGuys = new Dictionary<string, int>
		{
			["Galileo"] = 1564,
			["Magellan"] = 1480,
			["Voltaire"] = 1694,
			["Kepler"] = 1571,
			["Keaton"] = 1895
		};

		// Přepis položky (duplicity)
		//newGuys.Add("Galileo",1564); // Výjimka
		if (newGuys.ContainsKey("Galileo"))
		{
			newGuys["Galileo"] = 1564;
		}
		else
		{
			newGuys.Add("Galileo", 1564);
		}

		newGuys["Galileo"] = 1566; // Bezpečná a jednoduchá variata jak přepsat nebo založit položku ve slovníku.
		
		// Vyzvednutí položky s kontrolou
		Int32 year = 0;
		if (newGuys.ContainsKey("Galileo"))
		{
			year = newGuys["Galileo"];
		}


		string someText = "One cannot think well, love well, " +
						  "sleep well, if one has not dined well.";

        SortedDictionary<char, int> charCounter = new SortedDictionary<char, int>();
		
		foreach (char c in someText)
		{
			if (!charCounter.ContainsKey(c))
			{ 
				charCounter.Add(c, 1); 
			}
			else
			{
				// charCounter[c] is of type int,
				//   c is of type char
				charCounter[c]++;
			}
		}

		Console.WriteLine("Found {0} unique characters", charCounter.Keys.Count);

		foreach (KeyValuePair<char, int> kvp in charCounter)
		{
			Console.WriteLine("[{0}] - {1} instances", kvp.Key, kvp.Value);
		}

		// SortedDictionary
		var sortedDictionary = new SortedDictionary<string, Int32>()
		{
			["Galileo"] = 1564,
			["Magellan"] = 1480,
			["Voltaire"] = 1694,
			["Kepler"] = 1571,
			["Keaton"] = 1895
		};
		foreach (var kvp in sortedDictionary)
		{
			Console.WriteLine($"Key: {kvp.Key}, value: {kvp.Value}");
		}

		// Concurrent
		ConcurentDemo();

		// Hashset - Umožňuje uložit pouze unikátní položky.
		var hashSet = new HashSet<string>();

		hashSet.Add("Radek");
		hashSet.Add("Radek");
		hashSet.Add("Radek");

		// Stack
		// Typ fronty LIFO
		// Přeplněný výtah
		var stack = new Stack<byte>();
		stack.Push(0);
		stack.Push(0);
		stack.Push(0);
		stack.Pop(); // Vrací a odebírá z kolekce
		stack.Peek(); // Vrací položku z vrcholu zásobníku, přičemž položka tam zůstane.



		// Queue
		// Typ fronty FIFO
		// Fronta na poště s lístečkovým systémem.
		var bytes = new Queue<byte>();
		bytes.Enqueue(0);
		bytes.Enqueue(0);
		bytes.Enqueue(0);
		bytes.Dequeue();
		bytes.Dequeue();
		bytes.Dequeue();
	}

	//static ConcurrentDictionary<string, string> customers = new ConcurrentDictionary<string, string>();
	static Dictionary<string, string> customers = new Dictionary<string, string>();

	private static void ConcurentDemo()
	{
		var thread1 = new Thread(new ThreadStart(AddItem));
		var thread2 = new Thread(new ThreadStart(AddItem));

		thread1.Start();
		thread2.Start();
	}

	private static void AddItem()
	{
		customers.Add("Radek", "Zahradník");
	}
}


public class Example
{
	public static void SortingDemo()
	{
		// Create a new SortedDictionary of strings, with string keys 
		// and a case-insensitive comparer for the current culture.
		SortedDictionary<string, string> openWith =
			new SortedDictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

		// Add some elements to the dictionary.
		openWith.Add("txt", "notepad.exe");
		openWith.Add("bmp", "paint.exe");
		openWith.Add("DIB", "paint.exe");
		openWith.Add("rtf", "wordpad.exe");

		// Try to add a fifth element with a key that is the same 
		// except for case; this would be allowed with the default
		// comparer.
		try
		{
			openWith.Add("BMP", "paint.exe");
		}
		catch (ArgumentException)
		{
			Console.WriteLine("\nBMP is already in the dictionary.");
		}

		// List the contents of the sorted dictionary.
		Console.WriteLine();
		foreach (KeyValuePair<string, string> kvp in openWith)
		{
			Console.WriteLine("Key = {0}, Value = {1}", kvp.Key,
				kvp.Value);
		}

		var sortedDictionary = new SortedDictionary<string, string>(new MyCustomComparer());
	}
}

public class MyCustomComparer : IComparer<string>
{
	public int Compare(string x, string y)
	{
		return String.Compare(x, y, CultureInfo.CreateSpecificCulture("cs-CZ"), CompareOptions.IgnoreCase);
	}
}

