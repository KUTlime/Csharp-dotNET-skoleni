namespace Properties;

/*
#############################################################################
### Vlastnosti - properties
#############################################################################
    
Vlastnosti významně snižují množství kódu C#, zvyšují zapouzdření a 
přehledňují kód.

Elegantně řeší následující situaci:
private Int32 _someValue = 0;
public Int32 GetSomeValue()
{
    return _someValue;
}
public void SetSomeValue(Int32 value)
{
    _someValue = value;
}

na: 
public Int32 SomeValue {get; set;};


Druhy vlastností.

// Vlastnost bez výchozí hodnoty.
public Int32 SomeValue {get; set;};

// Vlastnost, kterou můžeme číst a zároveň nastavovat, přičemž má výchozí hodnotu.
public Int32 SomeValue {get; set;} = 0;

// Vlastnost, kterou lze pouze iniciovat a poté již jenom číst.
public Int32 SomeValue {get; init;} = 0;

// Vlastnost, která je reálně vypočitávána.
public DateTime Date => new DateTime(2023,02,02);

Existují tři druhy:
- Plné vlastnosti (Full property)
- Auto vlastnosti (Auto property)
- Výrazová kostra (Expression-body property), lze uvést spíše jako samostatnou kategorii, viz https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members

Dobré vědět:
- Platí na ně modifikátory přístupu.
- Sestavují se před konstruktorem třídy.
- Přístup je opět přes operátor "."

*/
class Program
{
	static void Main(string[] args)
	{
		var player = new Player()
		{
			Code = "Spider-man",
			Age = 30,
			Name = "Radek",
		};
		Console.WriteLine(player);

		var player2 = new Player()
		{
			Age = 30,
			Name = "Martin",
		};
		Console.WriteLine(player2);

		var properties = new Student()
		{
			Age = 20,
			Name = "Radek",
			Code = "021022839"
		};

		var person = new Employee("Radek", "", "Zahradník");
		var radek = new EmployeeV2("Radek", "", "Zahradník");

		// Create a new Student object:
		Student s = new Student();

		// Setting code, name and the age of the student
		s.Code = "001";
		s.Name = "Zara";
		s.Age = 9;
		Console.WriteLine($"Student Info:- {s}");

		//let us increase age
		s.Age += 1;
		Console.WriteLine($"Student Info:- {s}");

		var portfolio = new Portfolio();
		portfolio.Product = new Hardware();

		var portfolios = new List<Portfolio>()
		{
			new Portfolio(){Product = new Hardware()},
			new Portfolio(){Product = new Software()},
		};

		foreach (var portFolio in portfolios)
		{
			Console.WriteLine($"Cost is: {portFolio.Product.Cost} and stock supply is: {portFolio.Product.StockSupply}");
		}

		//myClass.Foo2 = Int32.MaxValue; // Nelze kvůli úrovni přístupu.

		Int32 someValue = portfolio.Foo2;

		var myClass2 = new MyClass2();

		myClass2.Foo1 = Int32.MaxValue;

		var circle = new Circle(10);
		Console.WriteLine($"Circle area is {circle.Area}");

		Console.ReadKey();
	}
}

// Plné vlastnosti (full property)
public class PropertiesDemoV1
{
	// Deklarace privátní proměnných pro použití ve vlastnostech.
	private string _code = "N.A";
	private string _name = "not known";
	private int _age = 0;

	// Declare a Code property of type string:
	public string Code
	{
		get
		{
			return _code;
		}
		set
		{
			_code = value;
		}
	}
	//vs. public string Code {get; set;}

	// Declare a Name property of type string:
	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value != null ? value : "";
		}
	}

	// Declare a Age property of type int:
	public int Age
	{
		get
		{
			return _age;
		}
		set
		{
			_age = value;
		}
	}
	public override string ToString()
	{
		return "Code = " + Code + ", Name = " + Name + ", Age = " + Age;
	}
}

// Vlastnostni mohou být i statické.
class Services
{
	public static Int32 UniqueId => 0;
}

class ServicesDemo
{
	Int32 SomeTest()
	{
		return Services.UniqueId;
	}
}

// Použití auto-vlastností (C# 3 a vyšší)
public class Player
{

	// Deklaraci auto vlastností.
	public string Code { get; set; } = "N.A"; // Definice výchozí hodnoty.

	// Deklaraci auto vlastností.
	public string Name { get; set; } = "not known"; // Provedeno před voláním konstruktoru.

	// Deklaraci auto vlastností.
	public int Age { get; set; } = 0;

	public override string ToString()
	{
		return "Code = " + Code + ", Name = " + Name + ", Age = " + Age;
	}
}

// Výchozí hodnota je nadbytečná, pokud proměnné přepisujeme v konstruktoru.
// V konstruktoru můžeme také nastavit vlastnosti, které jsou jinak pouze
// pro čtení.
public class Employee
{
	public Employee(string firstName, string middleName, string lastName)
	{
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
	}

	public string FirstName { get; } //= String.Empty; // Je zbytečné.
	public string MiddleName { get; }
	public string LastName { get; }

}

// Přidán výchozí konstruktor, ve které se nenastavují všechny vlastnosti.
// Konkrétně žádná.
public class EmployeeV2
{
	// Prázdný konstrutor, který nám nenastaví vlastnosti na platné hodnoty,
	// tudíž výchozí hodnoty mají smysl.
	public EmployeeV2()
	{
	}
	// Přetížený konstruktor
	public EmployeeV2(string firstName, string middleName, string lastName)
	{
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
	}

	public string FirstName { get; } = String.Empty; // Už není zbytečné.
	public string MiddleName { get; } = String.Empty;
	public string LastName { get; } = String.Empty;

}

// Definice přístupů u getrů a setrů.
public class AppSettings
{
	// Veřejná vlastnost, kterou ovšem nemůžeme zvenší změnit.
	// Změnit ji lze pouze v rámci třídy AppSettings.
	public Int32 ConnectionPort { get; private set; } = 50000;

	// Privátní metoda, kde mohu změnit onu vlastnost díky privátnímu setru.
	private void TryToFindOpenPort()
	{
		Int32 openPort = 50001;
		// Do some magic
		ConnectionPort = openPort; // Díky privátnímu setteru.
	}

	private Int32 ByteChunkSize { get; set; } = 4; // Private dává smysl pouze pro debugging.

	// Použití těla výrazu 
	public Int32 ByteChunkSizeLarge => 4; // Výrazové tělo (expression body).
	// jsou náhrada za následující kód
	/*
	public Int32 ByteChunkSizeLarge()
	{
		return 4;
	}
	*/
}

// Abstraktní vlastnosti v abstraktní třídě
public abstract class Person
{
	public abstract string Name { get; set; }

	public abstract int Age { get; set; }
}

// Deklarace třídy student, která dědí abstraktní třídu s abstraktními vlastnostmi.
public class Student : Person
{
	// Deklarace nové vlastnosti uvnitř třídy student.
	public string Code { get; set; } = "N.A";

	// Deklarace vlastnosti, která překrývá abstraktní vlastnost obsaženou v třídě Person.
	// Proto má na sobě klíčové slovo override.
	public override string Name { get; set; } = "N.A";

	// Deklarace vlastnosti, která překrývá abstraktní vlastnost obsaženou v třídě Person.
	// Proto má na sobě klíčové slovo override.
	public override int Age { get; set; } = 0;

	public override string ToString()
	{
		return "Code = " + Code + ", Name = " + Name + ", Age = " + Age;
	}
}

// Vlastnosti mohou být součástí rozhraní.
interface IProduct
{
	Int32 Cost { get; set; }
	Int32 StockSupply { get; }

}

// Implementace rozhraní s vlastnostmi
class Hardware : IProduct
{
	// Musíme přidat potřebné vlastnosti s odpovídajícími datovými typy
	// a odpovídajícími modifikátory přístupu jako v rozhaní.
	public int Cost { get; set; } = 100;
	public int StockSupply { get; } = 4; // Absence konstruktoru číní z této vlastnosti readonly pro tuto třídu.
}

class Software : IProduct
{
	public int Cost { get; set; } = 50;
	public int StockSupply { get; } = Int32.MaxValue;
}

// Rozhraní jako vlastnost
class Portfolio
{
	// Definice vlastnosti, která je typu rozhraní a umožňuje použít cokoliv, co rozhraní implementuje.
	public IProduct Product { get; set; } // Můžeme klidně umístit implementaci rozhraní.

	// Tato vlastnost bude viditelná v potomkovi.
	protected internal Int32 Foo1 { get; set; }

	// Tato vlastnost bude mít v potomkovi přístupný setr.
	// Toto půjde přečíst v předkovi, ale nepůjde nastavit v předkovi.
	// V potomkovi půjde obojí.
	public Int32 Foo2 { get; protected set; }
}

class MyClass2 : Portfolio
{

}

// Kalkulované vlastnosti
class Circle
{
	double _radius;
	
	// Konstruktor jako expression body.
	public Circle(double radius) => _radius = radius > 0 ? radius : 0.0;

	public double Perimeter { 
		get 
		{
			return 2 * _radius * Math.PI;
		} 
	}

	public double Area
	{
		get
		{
			return _radius * _radius * Math.PI;
		}
	}
}

class PersonV2
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string? SecondName { get; set; }

	public PersonV2(string fistName, string lastName)
	{
		FirstName = fistName;
		LastName = lastName;
	}
}

class PersonV2Demo
{
	void SomeMethod()
	{
		var person = new PersonV2("radek", "zahradník");
		var person2 = new PersonV2("radek", "zahradník") { SecondName = "Michal"};
	}
}

class PersonV3
{
	public required string FirstName { get; init; }

	public required string LastName { get; init; }

	public string? SecondName { get; init; }
}

class PersonV3Demo
{
    void SomeMethod()
    {
		var person = new PersonV3 
		{ 
			FirstName = "Radek",
			LastName = "Zahradník"
		};
        var person2 = new PersonV3 
		{ 
			FirstName = "Radek",
			LastName = "Zahradník",
			SecondName = "Michal" 
		};

		// Když chci novou person, která má kompbinované vlastnosti
		// když tam mám init;
		var person3 = new PersonV3
		{
			FirstName = "Zadek",
			LastName = person.LastName,
			SecondName = person2.SecondName
		};
        var person4 = new PersonV3
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            SecondName = person2.SecondName
        };

		var person5 = new PersonV4("Radek", "Zahradník") { SecondName = "Michal" };
		var person6 = person5 with { SecondName = null };

    }
}

record PersonV4(string FirstName, string LastName, string? SecondName = null);


class MemberDemo
{
	private int someField;

	public int SomeProperty { get; set; }

	public int SomeMethod()
	{
		return 0;
	}
}