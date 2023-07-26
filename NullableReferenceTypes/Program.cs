// Buď mohu zapnout na úrovni souboru ...
// #nullable enable

// nebo na úrovni celého projektu v CSProj
// díky
// <Nullable>enable</Nullable>

// ?. je operátor podmíněného přístupu, kterým ošetřuje vznik
// NullReferenceException
// p.MiddleName?.Length znamená pokud MiddleName není null, vrať délku,
// jinak vrať null.
// ?[] funguje stejně, ale pro pole.

// ??= je operátor podmíněného přiřazení, kterým ošetřuje vznik
// NullReferenceException tím, že nahrazuje null hodnotou, která je vpravo.
// b ??= 10 znamená pokud b je null, přepíše se to 10.

// ?? je operátor potlačení null, kterým ošetřuje vznik
// NullReferenceException tím, že nahrazuje null hodnotou, která je vlevo hodnotou,
// která je vpravo.
// b ?? 10 znamená pokud b je null použije se 10.

// ! je operátor null zapomnění, používáme např. jako 
// public string CustomerName { get; init; } = null!;
// pro vypnutí varování, že tam může být null.
// p.MiddleName!.Length Když víme, že MiddleName tady nikdy nebude null,
// můžeme takto potlačit varování generované statickou analýzou.

var person = new Person("Radek", "Zahradník");

var source = new[]
{
    new Person("Radek", "Zahradník"),
    new Person("Radek", "Zahradník"),
    null
};
source.OrderBy(p => p?.MiddleName?.Length);

Customer? customer = null;

customer ?? throw new ArgumentNullException();

if(customer.Name.Length > 0)
{
    Console.WriteLine(customer.Name);
}

var stringsToCheck = new string?[]
{
    "Radek",
    "Zahradník",
    null,
    "Školení"
};

_ = stringsToCheck.Select(s => s is null ? "asdfasdf" : s);
_ = stringsToCheck.Select(s => s ??= "asdf");
_ = stringsToCheck.Select(s => s ?? "asdf");

record Person(string FirstName, string LastName, string? MiddleName = null);

class MyClass
{
    public static int Sum(int a, int? b)
    {
        b ??= 1;
        return a / b.Value;
    }

    public static int Sum2(int a, int? b) => a / (b ?? 1);

    public static int Sum3(int a, int? b) => a / b.GetValueOrDefault(1);
}

class Customer
{
    public string Name { get; }

    public Customer(string? name) => Name = name ?? "Adolf";
}

class Order
{
    public string CustomerName { get; init; } = null!;
}

