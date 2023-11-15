namespace Arrays;

static class Program
{
	static void Main(string[] args)
	{
		// Jednoduchá deklarace pole
		int[] arrayName;
		
		// Definice pole o předem známé velikosti, tj. 10 x double.
		double[] balance = new double[10];

        // Vytvoření dynamického pole s dynamickou velikostí
        uint.TryParse(Console.ReadLine(), out uint size);
        var test = new string[size];

        // Přístup na 0tou položku, tj. v pořadí první položku
        // v poli a uložení hodnoty 4500.0.
        // Kolekce (včetně polí) se indexují v C# od NULY!!!!!!!!!!
        balance[0] = 4500.0;

		// Definice pole s inicializací.
		// Inicializace se provádí dohromady s {}, kde pro oddělení
		// používáme operátor ",".
		int[] marks = new int[] { 99, 98, 92, 97, 95 };

		// To samé, pouze bez syntaktického cukru "new Int32[]",
		// který je zbytečný.
		Int32[] marks2 = { 99, 98, 92, 97, 95 };

		// Od C# 12 můžeme obecně výčtem [ prvek, prvek, prvek, .. ]
		int[] marks3 = [99, 98, 92, 97, 95];

		Int32[] score = marks; // Inicializace nového pole ukazatelem na jiné pole.

		// Zjištěním délky pole:
		Int32 scoreLength = score.Length;

		// Inicializace pole přes smyčku
		Int32[] n = new Int32[10];
		for (Int32 i = 0; i < 10; i++)
		{
			n[i] = i + 100;
		}

		// Výpis pole skrze smyčku
		for (int j = 0; j < 10; j++)
		{
			Console.WriteLine("Element[{0}] = {1}", j, n[j]); // Nebo...
			Console.WriteLine($"Element[{j}] = {n[j]}");
		}

		// Inicializace pole přes smyčku (LEPŠÍ VEZE)
		Int32[] m = new Int32[10];
		for (Int32 i = 0; i < m.Length; i++)
		{
			m[i] = i + 100;
		}

		int[] array = { 34, 72, 13, 44, 25, 30, 10 };
		int[] temp = array; // Mělká kopie pole
		Console.Write("Original Array: ");
		foreach (var i in array)
		{
			Console.Write(i + " ");
		}
		Console.WriteLine();

		// Hluboká kopie pole
		int[] arrayCopy = new int[array.Length];
		Array.Copy(array, arrayCopy, array.Length);

		// Převrácení pole od konce
		Array.Reverse(temp); // Musí se volat statická metoda objektu Array.
		Console.Write("Reversed Array: ");
		foreach (int i in temp)
		{
			Console.Write(i + " ");
		}
		Console.WriteLine();

		//Setřídění pole
		Array.Sort(array);
		Console.Write("Sorted Array: ");
		foreach (int i in array)
		{
			Console.Write(i + " ");
		}
		Console.WriteLine();

		Int32 sum = Sum(512, 720, 250, 567, 889);
		Console.WriteLine($"Sum is: {sum}");
		Console.ReadKey();
	}

	// Vícerozměrná pole
	static void MultiArray()
	{
		string[,] names;    // 2D string pole
		Int32[,,] m;        // 3D Int32 pole

		// Inicializace 2D pole
		Int32[,] array34 = new Int32[3, 4]
		{
			{0, 1, 2, 3} ,   // Inicializace řádku 0
            {4, 5, 6, 7} ,   // Inicializace řádku 1
			{8, 9, 10, 11}   // Inicializace řádku 2
        };

		// Inicializace 2D pole bez syntaktického cukru.
		var array56 = new[,]
		{
			{0, 1, 2, 3} ,   // Inicializace řádku 0
            {4, 5, 6, 7} ,   // Inicializace řádku 1
            {8, 9, 10, 11}   // Inicializace řádku 2
        };

		// Inicializace 2D pole bez syntaktického cukru 2.
		Int32[,] array78 =
		{
			{0, 1, 2, 3} ,   // Inicializace řádku 0
            {4, 5, 6, 7} ,   // Inicializace řádku 1
            {8, 9, 10, 11}   // Inicializace řádku 2
        };

        // Inicializace 3D pole bez syntaktického cukru 2.
        Int32[,,] array90 =
		{
			{
				{0, 1, 2, 3} ,   // Inicializace řádku 0,0
				{4, 5, 6, 7} ,   // Inicializace řádku 1,0
				{8, 9, 10, 11}   // Inicializace řádku 2,0
			},
			{
				{ 0, 1, 2, 3} ,   // Inicializace řádku 0,1
				{ 4, 5, 6, 7} ,   // Inicializace řádku 1,1
				{ 8, 9, 10, 11}   // Inicializace řádku 2,1
			}
        };

        // Pole o velikosti 5 řádků, 2 sloupců
        int[,] a = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 } };
        int i, j;

		// Vytištění 2D pole
		for (i = 0; i < 5; i++)
		{
			for (j = 0; j < 2; j++)
			{
				Console.WriteLine("a[{0},{1}] = {2}", i, j, a[i, j]);
			}
		}
	}

	// Pole polí
	static void JaggedArray()
	{
		int[,] arr;       // 2D pole
        int[][] grades;   // Pole polí o dimenzi 2

        int[][] scores = new int[5][];
		for (int i = 0; i < scores.Length; i++)
		{
			scores[i] = new int[i];
		}

		// Dimenziónálně nekonzistentní pole
		var scores2 = new Int32[][]
		{
			new Int32[] { 92, 93, 94 },
			new Int32[] { 85, 66, 87, 88, 89 },
		};

		// Dimenziónálně nekonzistentní pole bez syntaktického cukru.
		Int32[][] scores3 =
		{
			new[] { 92, 93, 94 },
			new[] { 85, 66, 87, 88 },
		};

        // Od C# 12
        Int32[][] scores4 =
        [
            [92, 93, 94],
            [85, 66, 87, 88],
        ];
        Int32 row = 0;
		Int32 column = 0;
		foreach (var line in scores3)
		{
			foreach (var item in line)
			{
				Console.WriteLine($"A[{row},{column}]: {item}");
				column++;
			}
			row++;
		}

		for (int i = 0; i < scores3.Length; i++)
		{
			for (int j = 0; j < scores3[i].Length; j++)
			{
				Console.WriteLine($"A[{i},{j}]: {scores3[i][j]}");
			}
		}
	}

	// Použití klíčového slova params + pole jako parametru do vstupu metody.
	// Řeší případy, kdy nevíme počet vstupních parametrů při volání metody.
	public static Int32 Sum(params Int32[] arr)
	{
		Int32 sum = 0;
		foreach (Int32 integer in arr)
		{
			sum += integer;
		}
		return sum;
	}
}

