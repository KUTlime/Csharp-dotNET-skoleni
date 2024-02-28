namespace Methods;

/*
#############################################################################
### Metody (Funkce) aneb procedurální programování
#############################################################################
        
Druhy metod:
- Statické (Voláme skrze název třídy.)
- Nestatické (Potřebují instanci třídy a voláme skrze název instance třídy.)

Použití metody vyžaduje:
- Definici funkce
- Zavolání funkce

Definice:
<modifikátor přístupu> <static> <návratový typ> <Jméno> (<Seznam parametrů>) 
{
    Tělo metody
    Práce s parametry
    Příprava návratové hodnoty
}

Definice výrazová těla:
<modifikátor přístupu> <static> <návratový typ> <Jméno> (<Seznam parametrů>) => právě 1 instrukce;

Seznam parametrů při definici:
(<modifikátor parametru> <datový typ> <název parametru>, <modifikátor parametru> <datový typ> <název parametru>)


Seznam parametrů při volání:
[název parametru 1]: <modifikátor argumentu> <argument 1>, [název parametru 2]: <modifikátor argumentu> <argument 2>

Definice:
public Int32 Sum(ref Int32 firstOperand, ref Int32 secondOperand) {...}

Volání:
int c = Sum(ref a, ref b) {...}

Volání s názvem parametrů:
int c = Sum(firstOperand: ref a, secondOperand: ref b) {...}
#############################################################################
*/
class Program
{
	// Povinná metoda každého C# programu.
	static void Main(string[] args)
	{
		Console.WriteLine(SolutionNew.Factorial(1));
		Console.WriteLine(SolutionNew.Factorial(2));
		Console.WriteLine(SolutionNew.Factorial(3));

		SolutionNew.Fibbonaci(1);
		SolutionNew.Fibbonaci(2);
		SolutionNew.Fibbonaci(3);
		SolutionNew.Fibbonaci(10);
		// Lokální proměnné

		int a = 100;
		int b = 200;
		var methods = new Methods();
		int ret = methods.FindMax(a, b);
		int ret2 = Methods.FindMaxStatic(a, b);
		int ret3 = methods.FindMax(num1: a, num2: b); // Přidány názvy parametrů.
		Console.WriteLine(format: "Message: {0}", arg0: 10);
		Console.WriteLine(format: "Message: {0}", arg0: 10); // Mezera nehraje roli.
		Console.WriteLine(format: "Message: {0}", 10); // Vynechání lze, ale až od C# 7.3 a vyšší.
		Console.WriteLine(arg0: 10, format: "Message: {0}"); // Pořadí u pojmenovaných argumentů taktéž nehraje roli.

		Console.WriteLine("Max value is : {0}", ret);

		Console.WriteLine("Factorial of 7 is : {0}", methods.Factorial(7));
		Console.WriteLine("Factorial of 8 is : {0}", methods.Factorial(8));


		Console.WriteLine("Before swap, value of a : {0}", a);
		Console.WriteLine("Before swap, value of b : {0}", b);

		// Volání swap funkce
		methods.Swap(a, b);

		Console.WriteLine("After swap, value of a : {0}", a);
		Console.WriteLine("After swap, value of b : {0}", b);

		methods.Swap(ref a, ref b);
		//methods.SwapRef(a, b); // Nelze
		methods.SwapRef(ref a, ref b); // ref povinné, protože je v definici.

		Console.WriteLine("Befora SwapOut, value of a: {0}, value of b : {1}", a, b);
		methods.SwapOut(ref a, ref b, out a, out b);
		Console.WriteLine("After SwapOut, value of a: {0}, value of b : {1}", a, b);

		Console.WriteLine("After ref swap, value of a : {0}", a);
		Console.WriteLine("After ref swap, value of b : {0}", b);

		Console.WriteLine("Before method call, value of a : {0}", a);


		methods.GetSomeValue(out a);

		Console.WriteLine("After method call, value of a : {0}", a);

		methods.GetValues(out a, out b);
		Console.WriteLine("After method call, value of a : {0}", a);
		Console.WriteLine("After method call, value of b : {0}", b);

		Int32 c;
		Int32 d;
		methods.GetValues(out c, out d);
		Console.WriteLine("After method call, value of a : {0}", c);
		Console.WriteLine("After method call, value of b : {0}", d);

		methods.GetValues(out Int32 e, out var f);
		Console.WriteLine("After method call, value of a : {0}", e);
		Console.WriteLine("After method call, value of b : {0}", f);

		// Použití "in" funkce - konstantní parametry u volání funkce
		Console.WriteLine($"Sum of {a} and {b} is {methods.Sum(in a, in b)}");
		Console.WriteLine($"Sum of {a} and {b} is {methods.Sum(a, b)}"); // U volání není nutné použít in, to se doplní samo.

		methods.PrintNumber(10.12345); // Automaticky se použije 3 desetinná místa, protože to je výchozí hodnota 2. parametru.
		methods.PrintNumber(10.12345, 2);


		Solution.Fibonacci(1000);
		Solution.Fibonacci(1000, 20);

		Console.ReadLine();

		Methods.Test(0, 1, 2, 4);
		Methods.Test(0, fourth: 4);
    }
}

class Methods
{
	// Jednoduchá veřejná funkce
	public Int32 FindMax(Int32 num1, Int32 num2)
	{
		return num1 > num2 ? num1 : num2;
	}

    // Jednoduchá veřejná funkce (kompaktní)
    public Int32 FindMaxCopmact(Int32 num1, Int32 num2) => num1 > num2 ? num1 : num2;

    // Jednoduchá statická veřejná funkce
    public static Int32 FindMaxStatic(Int32 num1, Int32 num2)
	{
		return num1 > num2 ? num1 : num2;
	}

	// Rekurzivní funkce
	public Int32 Factorial(Int32 num)
	{
		// 0 a 1.
		if (num < 2)
		{
			return 1;
		}

		return num * Factorial(num - 1);
		// Hrozná prasárna pro zásobník volání.
	}

	// Předávání parametrů hodnotou
	// Dochází dvakrát k boxingu (zabalení), konkrétně
	// hodnoty x a y.
	public void Swap(Int32 x, Int32 y)
	{
		var temp = x;
		x = y;    /* put y into x */
		y = temp; /* put temp into y */
		// return; // nepovinné a je odebráno při automatickém formátování kódu.
	}

	// Přetížená funkce prohození s předáním referencí
	public void Swap(ref Int32 x, ref Int32 y)
	{
		var temp = x;
		x = y;    /* put y into x */
		y = temp; /* put temp into y */
	}

	// Parametry definované s ref musí být při volání funkce
	// definovány taktéž jako ref, tj. jako reference.
	public void SwapRef(ref Int32 x, ref Int32 y)
	{
		var temp = x;
		x = y;    /* put y into x */
		y = temp; /* put temp into y */
	}

	// Několika násobný výstup z funkce
	// Klíčové slovo out říká kompilátoru,
	// že proměnná bude inicializována později.
	public bool GetSomeValue(out Int32 x)
	{
		x = 5;
		return true;
	}

	// Definice swap funkce (prohození) pomocí ref a out parametrů.
	public void SwapOut(ref Int32 a, ref Int32 b, out Int32 x, out Int32 y)
	{
		x = b;
		y = a;
	}

	// Několikanásobné použití out
	public void GetValues(out Int32 x, out Int32 y)
	{
		Console.WriteLine("Enter the first value: ");
		x = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Enter the second value: ");
		y = Convert.ToInt32(Console.ReadLine());
	}

	public Int32 Sum(in Int32 a, in Int32 b)
	{
		//a++; // Nelze
		return a + b;
	}

	// Lokálně definované funkce, tj. funkce definované uvnitř dalších funkcí.
	public void PrintNames(List<string> childrens)
	{
		Int32 i = 1; // Globální proměnná pro PrintNames metodu.
		foreach (var children in childrens)
		{
			PrintName(children); // Volání lokální funkce.
		}

		void PrintName(string name)
		{
			Console.WriteLine($"Name is {name} and he/she is my {i}. children");
			i++; // Inkrementujeme globální proměnnou z volající funkce.
		}
	}

	public void SomeOtherFunction()
	{
		PrintNames(new List<string>() { "Jméno", "Jméno2" });
		//PrintName();  // Zde nedostupné.
	}

	// Výchozí hodnoty parametrů
	// U vstupních parametrů funkcí můžeme definovat výchozí hodnotu.
	// Ta bude použita pokud u volání funkce nezadáme žádnou hodnotu,
	// např. PrintNumber(3.14159) povede na PrintNumber(3.14159,3).
	// Parametry s výchozí hodnotou musí stát vždy nejvíc vpravo a 
	// nesmí být mezi nimi žádný bez výchozí hodnoty.
	public void PrintNumber(double number, byte numberOfDecimalPlaces = 3)
	{
		Console.WriteLine($"Number: {number:numberOfDecimalPlaces}");
	}

	public static void Test(int first = 0, int second = 0, int third = 0, int fourth = 4)
	{ }
}
