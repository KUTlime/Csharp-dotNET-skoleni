Parent parent = new Parent()
{
    Name = GetName("name"),
    Surname = GetName("surname"),
    Age = GetNumberInRange("age", min: 0, max: 100),
    NumberOfChildren = GetNumberInRange("number of children", max: 20),
};

Console.WriteLine($"Hello {parent.Name} {parent.Surname}, you are {parent.Age} years old.");

for (int i = 0; i < parent.NumberOfChildren; i++)
{
    parent.Children.Add(new Child()
    {
        Name = GetName("child name"),
        Age = GetNumberInRange("child age", max: parent.Age)
    });
}

foreach (var child in parent.Children)
{
    Console.WriteLine($"You have a child: {child.Name} that is {child.Age} years old.");
}

string GetName(string propertyName)
{
    string? name;
    do
    {
        Console.WriteLine($"Please, enter your {propertyName}");
        name = Console.ReadLine();
    } while (name is { Length: < 1 });
    return name!;
}

uint GetNumberInRange(string prompt, uint min = uint.MinValue, uint max = uint.MaxValue)
{
    uint number;
    string? input;
    bool isSuccessful;
    do
    {
        Console.WriteLine($"Please, enter your {prompt}");
        input = Console.ReadLine();
        isSuccessful = uint.TryParse(input, out number);
    } while (isSuccessful is false || (min != uint.MinValue && number < min) || (max != uint.MaxValue && number > max));
    return number;
}

class Parent
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public uint Age { get; set; }
    public uint NumberOfChildren { get; set; }
    public List<Child> Children { get; set; } = new();
}

class Child
{
    public string? Name { get; set; }
    public uint Age { get; set; }
}


/*
Založte si nový konzolový projekt ve Visual Studiu.
Vytvořte konzolovou aplikaci, která:
1. Zeptá se uživatele na jeho jméno.
2. ------- || --------------- příjmení.
3. ------- || --------------- věk.
4. Tyto informace uložte do Vámi vytvořené třídy pro tento účel.
5. Vypíše na obrazovku následující hlášení:
Hello NAME LASTNAME, you are X years old.
6. Dále se zeptáme uživatele kolik má dětí.
7. Počet dětí si aplikace uloží a dále se zeptá na
   - Jméno dítěte
   - Věk
   Tyto informace si uložíte zvláště připrané třídy.
8. Vytisknete informace ve formátu
   "You have a child: JMÉNO_DÍTĚTE that is X years old."
   pro všechny děti najednou.
 */