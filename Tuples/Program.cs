namespace Tuples;

/*
#############################################################################
### Tuple - řazená kolekce (členů)
#############################################################################

Dobré vedět:
- Do C# 6 se jednano o referenční datové typy.
- V C# 7.x nová verze tuplů jako hodnotový datový typ.
- C# 7.2 a vyšší umožňuje nejvyšší možnou flexibilitu práce s tuply.

Význam a použití:
- "Lehká" verze kolekce předem známých datových typů, např. RGB koordináty.
- Nízká režie a náklady na konstrukci a přenos.
- Návratové hodnoty z funkce.
- Hodnoty, co spolu souvisí.

Syntaxe:
([nepovidnné]<Název člena>: <Datový typ člena> <jméno člena>, [nepovidnné]<Název člena>: <Datový typ člena> <jméno člena>, [nepovidnné]<Název člena>: <Datový typ člena> <jméno člena)
var (<jméno člena>, <jméno člena>, <jméno člena) // Datový typ je odvozen z datových typů již existujících členů.

Dobré vědět:
- Když chceme převést nebo rozložit uživatelský datový typ na kolekci řazených členů nebo členy samotné, voláme metodu Deconstruct.
- Metod pro dekonstrukci může být ve třídě více, ale zamezíme tím použití var klíčového slova. Kompliátor totiž nebude
  vědět, jakou metodu má zavolat, viz příklad níže.
- Ideální pro použití jako návratové hodnoty z funkce, když potřebujeme předat více než jeden parametr a nechceme vyrábět třídu pro tento účel.

#############################################################################
*/
class Tuples
{
    static void Main(string[] args)
    {
        // Nepojmenovaný
        var tuple1 = ("one", "two");
        Console.WriteLine(tuple1.Item1); // Item1 zvoleno automaticky, proto nepojmenovaný.
        Console.WriteLine(tuple1.Item2);

        // Pojmenovaný
        var tuple2 = (first: "one", second: "two");
        Console.WriteLine(tuple2.first); // first se odvodil z názvu parametru, proto pojmenovaný.
        Console.WriteLine(tuple2.second);

        // Automaticky pojmenované (C# 7.2)
        double sum = 12.5;
        Int32 count = 5;
        var accumulation = (count, sum);
        Console.WriteLine(accumulation.count); // count se odvodilo z názvu instance proměnné, která byla použita při tvorbě.
        Console.WriteLine(accumulation.sum);

        // Pojmenované tuply jsou lepší nej nepojmenované.
        // Pojmenované --> Pokud pracujeme s literály, viz příklad výše. Tady mají svůj smysl.
        // V jiných případech (za předpokladu komplace C# 7.2) stačí využít automatického pojmenování. 

        // Porovnávání tuplů
        var left1 = (a: 5, b: 10);
        var right1 = (a: 5, b: 10);
        var right11 = (c: 5, d: 10);
        var rightDiff = (a: 5, b: 10, c: 13);
        Console.WriteLine(left1 == right1); // vrátí 'true'
        Console.WriteLine(left1 == right11); // vrátí 'true', jména členů jsou ignorovány
        //Console.WriteLine(left1 == rightDiff); // Neprojde, protože máme jinou kardinalitu tuplů --> jiný počet položek.

        // Tuply a nullable 
        var left2 = (a: 5, b: 10);
        var right2 = (a: 5, b: 10);
        (int a, int b)? nullableTuple = null;
        nullableTuple = right2;
        Console.WriteLine(left2 == nullableTuple); // taktéž vrátí true

        // Tuply a konverze
        // Povýšená konverze ( operátor == pro Int32 je povýšen na práci s nullable datovými typy)
        var left = (a: 5, b: 10);
        (int? a, int? b) nullableMembers = (5, 10); // Tuple dvou nullable Int32.
        Console.WriteLine(left == nullableMembers); // taktéž vrátí true

        // převedený typ je (Int64, Int64)
        (long a, long b) longTuple = (5, 10);
        Console.WriteLine(left == longTuple); // taktéž vrátí true

        // porovnání je provedeno pro (Int64, Int64) tuply
        (long a, long b) longFirst = (5, 10);
        (int a, long b) longSecond = (5, 10);
        Console.WriteLine(longFirst == longSecond); // taktéž vrátí true

        // Role jmen při porovnání
        (int a, string b) pair = (1, "Hello");
        (int b, string a) another = (1, "Hello");
        Console.WriteLine(pair == another); // true. Jména se na porovnání nepodílejí.
        Console.WriteLine(pair == (z: 1, y: "Hello")); // warning: literal obsahuje jiná jména
        Console.WriteLine(pair == (a: 1, b: "Hello")); // Warning free řešení.

        // Zanořené tuply a jejich porovnání
        (int, (int, int)) nestedTuple = (1, (2, 3));
        Console.WriteLine(nestedTuple == (1, (2, 3)));

        // Tuply a počet argumentů + typy 
        // Následující tuply jsou ekvivalentní
        // Jediný rozdíl je ve jménu členů
        var unnamed = (42, "The meaning of life");
        (int, string) anonymous = (16, "a perfect square");
        var named = (Answer: 42, Message: "The meaning of life");
        var differentNamed = (SecretConstant: 42, Label: "The meaning of life");

        Console.WriteLine(unnamed.Item1);

        unnamed = named;

        Console.WriteLine(unnamed.Item2);

        named = unnamed;
        // 'named' má stále členy pojmenované
        // jako 'answer' a 'message':
        Console.WriteLine($"{named.Answer}, {named.Message}");

        // unnamed do unnamed:
        anonymous = unnamed;
        Console.WriteLine(anonymous.Item1);

        // named tuples.
        named = differentNamed;
        // 'named' má stále členy pojmenované
        // jako 'answer' a 'message':
        Console.WriteLine($"{named.Answer}, {named.Message}");

        // Na závěr implicitní konverze
        (long, string) conversion = named; // named = (int, string)

        // Does not compile.
        // CS0029: Cannot assign Tuple(int,int,int) to Tuple(int, string)
        var differentShape = (1, 2, 3);
        // named = differentShape;

        // Tuple jako návratová hodnota funkce (nepojmenovaný).
        var value1 = ReturnUnnamedTuple();
        Console.WriteLine(value1.Item1);
        Console.WriteLine(value1.Item2);
        Console.WriteLine(value1.Item3);

        // Pojmenovaný tuple jako návratová hodnota (pojmenovaný).
        var value2 = ReturnNamedTuple();
        Console.WriteLine(value2.index);
        Console.WriteLine(value2.value);
        Console.WriteLine(value2.name);

        // Ukázka dekompozice uživatelského typu
        var p = new Person("Althea", "Goodwin");
        var (first, last) = p;

        // Dekompozice implemntována ve třídy Student formou metody rozšíření
        var (firstName, lastName, myGrade) = new Student(firstName: "Radek", lastName: "Zahradník", gpa: 1.0);

        // Dekompozice implementována ve třídě Person
        var (firstName1, lastName2) = new Student(firstName: "Radek", "Zahradník", 1.0);

        var student = new Student(firstName: "Radek", lastName: "Zahradník", gpa: 1.0);
        student.Deconstruct(out first, out last, out myGrade); // Volání metody rozšíření
        student.Deconstruct(out var first1, out var last2, out var gpa); // Volání metody rozšíření s definicí vlastních argumentů
        (string name1, string name2, double grade) = student; // Dekompozice přes operátor přiřazení, který si zavolá metodu rozšíření.

        Console.ReadKey();
    }

    // Funkce, která vrací nejpojmenovaný tuple.
    public static (int, double, string) ReturnUnnamedTuple() => (0, 0.0, "Hello world!");

    // Funkce, která vrací pojmenovaný tuple.
    public static (int index, double value, string name) ReturnNamedTuple() => (0, 0.0, "Hello world!");
}

public class Person
{
    public string FirstName { get; }
    public string LastName { get; }

    public Person(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    // Speciální metoda pro dekonstrukci třídy na tuple
    // konkrétně na tuple(string, string)
    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }

    // Pokud nadefinujeme tuto další metodu Deconstruct,
    // nejsme schopni udělat toto:
    // var (first, second) = p; // dekompilace instance třídy.
    //public void Deconstruct(out Int32 firstName, out Int32 lastName)
    //{
    //    firstName = 1;
    //    lastName = 0;
    //}
}

public class Student : Person
{
    public double GPA { get; }
    public Student(string firstName, string lastName, double gpa) : base(firstName, lastName)
    {
        GPA = gpa;
    }
}

public static class StudentExtensions
{
    public static void Deconstruct(this Student s, out string first, out string last, out double gpa)
    {
        first = s.FirstName;
        last = s.LastName;
        gpa = s.GPA;
    }
}