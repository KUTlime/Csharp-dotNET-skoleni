
namespace Polymorphism;

/*
#############################################################################
### Polymorfismus - mnohotvarost
#############################################################################
    
Polymorfní = mnohotvaré

Dva druhy:
- Statický (určený během kompilace)
- Dynamický (určený za běhu)

Statický polymorfismus:
- Přetěžování metod
- Přetěžování operátorů

Přetěžování metod:
- Vícero metod stejného názvu v jednom oboru platnosti.
- Metody se nemohou lišit pouze návratovou hodnotou, ale počtem nebo typem parametrů.
- Nelze přetížit pouze na základě návratové hodnoty.

Dynamické přetěžování:
- S využitím abstraktní třídy a virtuálních metod.
- Abstraktní metodu nelze deklarovat mimo abstraktní třídu.
- Nelze vytvořit instanci abstraktní třídy.
- Abstraktní třídu nelze deklarovat jako sealed.

Vituální metody:
- Deklarují se klíčovým slovem virtual v předkovi.
- Potomek může deklarovat stejnojmennou metodu, která buď skrývá nebo rozšiřuje metodu předka.
- Klíčové slovo new skrývá metodu předka.
- Klíčové slovo override rozšiřuje metodu předka. K volání této rozšiřující metody dojde i v tomto případě: TřídaPředka předek = new Potomek(); předek.VirtuálníMetoda();

#############################################################################
*/
static class Program
{
	static void Main(string[] args)
	{
		Printdata p = new Printdata();

		// Call print to print integer
		p.Print(5);

		// Call print to print float
		p.Print(500.263);

		// Call print to print string
		p.Print("Hello C#");


		Rectangle r = new Rectangle(10, 7);
		r.color = Color.RED;
		Console.WriteLine($"Area: {r.Area()}");
		Console.WriteLine($"Area: {r.Name()}");

		var caller = new Caller();
		var rectangle = new RectangleV2(10, 7);
		var triangle = new Triangle(10, 5);

		caller.CallArea(rectangle);
		caller.CallArea(triangle);


		Console.ReadKey();
	}
}

// Příklad přetížení funkcí.
class Printdata
{
	public void Print(int i)
	{
		Console.WriteLine("Printing int: {0}", i);
	}

	public void Print(double f)
	{
		Console.WriteLine("Printing float: {0}", f);
	}

	public void Print(string s)
	{
		Console.WriteLine("Printing string: {0}", s);
	}
}

// Definice čistě abstraktní třídy Shape
abstract class Shape
{
	// Definice proměnné (v rozhraní by nešlo).
	public Color color = Color.BLUE;

	// Čistě abstraktní metoda musí být přepsána (override) v potomcích.
	public abstract double Area();

	// Tato implementace bude přístupná potomkům.
	public virtual double Name()
	{
		Console.WriteLine("Calling a Name method inside Shape.");
		return 0.0;
	}
}

// Obedélní jak potomek tvaru (třídy Shape).
class Rectangle : Shape
{

	private int _length;
	private int _width;

	public Rectangle(int a = 0, int b = 0)
	{
		_length = a;
		_width = b;
	}
	public override double Area()
	{
		Console.WriteLine("Rectangle class area :");
		return (_width * _length);
	}
}

// Změna předka Area je nyní virtuální metodou.
// Třída ShapeV2 nyní nemusí být abstraktní, protože neobsahuje žádnou abstraktní metodu.
class ShapeV2
{
	protected double width; // Pouze pro ukázku volání konstruktorů a parametrů.
	protected double height; // Definice těchto proměnných zde v ShapeV2 nedává moc smysl (např. pro kružnici).

	// Tento konstruktor vynutí definice konstruktorů o stejném počtu parametrů ve všech potomcích třídy ShapeV2.
	public ShapeV2(double a = 0, double b = 0)
	{
		width = a;
		height = b;
	}

	// Virtuální metodu lze definovat mimo abstraktní třídu.
	public virtual double Area()
	{
		Console.WriteLine("Parent class area :");
		return 0;
	}
}
class RectangleV2 : ShapeV2
{
	public RectangleV2(double a = 0, double b = 0) : base(a, b)
	{

	}

	// Aby došlo opravdu k volání metody Area z třídy RectangleV2, je nutné přidat klíčové
	// slovo override, jinak bude zavolána metoda Area z předka, která je označena jako
	// virtuální.
	public override double Area()
	{
		Console.WriteLine("Rectangle class area :");
		return (width * height);
	}
}
class Triangle : ShapeV2
{
	public Triangle(double a = 0, double b = 0) : base(a, b)
	{
	}

	// Aby došlo opravdu k volání metody Area z třídy RectangleV2, je nutné přidat klíčové
	// slovo override, jinak bude zavolána metoda Area z předka, která je označena jako
	// virtuální.
	public override double Area()
	{
		Console.WriteLine("Triangle class area :");
		return (width * height / 2);
	}
}

class Caller
{
	public void CallArea(ShapeV2 sh)
	{
		Console.WriteLine($"Area: {sh.Area()}");
	}
}

public enum Color
{
	RED = 1,
	BLUE = 2,
	GREEN = 3,
}

// ##########################
// New vs. Override keyword
// ##########################

// Define the base class, Car. The class defines two virtual methods,  
// DescribeCar and ShowDetails. DescribeCar calls ShowDetails, and each derived  
// class also defines a ShowDetails method. The example tests which version of  
// ShowDetails is used, the base class method or the derived class method.  
class Car
{
	public virtual void DescribeCar()
	{
		Console.WriteLine("Four wheels and an engine.");
		ShowDetails();
	}

	public virtual void ShowDetails()
	{
		Console.WriteLine("Standard transportation.");
	}
}

// Define the derived classes.  

// Class ConvertibleCar uses the new modifier to acknowledge that ShowDetails  
// hides the base class method.  
class ConvertibleCar : Car
{
	public new void ShowDetails()
	{
		System.Console.WriteLine("A roof that opens up.");
	}
}

// Class Minivan uses the override modifier to specify that ShowDetails  
// extends the base class method.  
class Minivan : Car
{
	public override void ShowDetails()
	{
		System.Console.WriteLine("Carries seven people.");
	}
}

public class TestCar
{
	// Výstup metody:  
	// TestCars  
	// ----------  
	// A roof that opens up.  
	// Carries seven people.  
	public static void TestCars()
	{
		Console.WriteLine("\nTestCars");
		Console.WriteLine("----------");
		ConvertibleCar convertible = new ConvertibleCar();
		Minivan minivan = new Minivan();
		convertible.ShowDetails();   // Volání ConvertibleCar.ShowDetails();
		minivan.ShowDetails();      // Volání Minivan.ShowDetails();
	}

	// Výstup metody:  
	// TestCarsAsBaseClass  
	// ----------  
	// Standard transportation.  
	// Carries seven people. 

	// Slovíčko new nám umožní se dostat k metodě předka, override nikoliv.
	public static void TestCarsAsBaseClass()
	{
		Console.WriteLine("\nTestCarsAsBaseClass");
		Console.WriteLine("----------");
		Car car = new ConvertibleCar();
		Car car2 = new Minivan();
		car.ShowDetails();  // Zde dojde k volání Car.ShowDetails() díky klíčovému slovíčku new.
		car2.ShowDetails(); // Zde dojde k volání Minivan.ShowDetails() díky klíčovému slovíčku overrider.
	}
}
