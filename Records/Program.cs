/*
Uživatelský datový typ nejčastěji tvoříme kvůli zachycení kontextu.

V C# můžeme vytvořit 3 typy uživatelských datových typů:
- Třídy (Referenční datový typ)
- Struktury (Hodnotový datový typ)
- Recordy (Hodnotově orientovaný referenční datový typ)
 
# Jak se rozhodnout, co kdy potřebovat?
1. Budu potřebovat hodnotový datový typ?
- Je typ malý? Ano, do cca 16 bajtů -> struktura
- Řeším optimalizaci na hot path? Ano -> může být struktura.
- Budu potřebovat dědičnost? Ne -> může být struktura
- Budu potřebovat nějakou výchozí ne-Null hodnotu? Ano -> Musím použít strukturu.
Ano -> Vytvořím strukturu.
Ne -> 2.

2. Je můj zamýšlený datový typ hodnotově orientovaný?
- Je to nějaká skupina hodnot, které spolu souvisí? -> ANO, může být record
- Jsou tyto hodnoty ideálně neměnné? ANO -> record
- Chci, aby hodnoty byly primárně neměnné? ANO -> record
- Obsahuje třída nějakou logiku, metody -> ANO, třídy.
Ano -> Vytvořím record.
Ne -> Vytvořím třídu.


# Jak vytvořit strukturu?

internal readonly struct Point
{
    public int X { get; }
    public int Y { get; }
}

- Před názvem použijeme klíčové slovo struct.
- readonly znamená, že struktura je jenom pro čtení (možná optimalizace)
 
 # Jak vytvořit record?

record MyRecord; // Minimální definice

 */
Point point = new(11,22);
Point point2 = new();
Print();
Print(point);
Print(point2);

var myRecord = new MyRecord();

var rPoint = new PointRecord(1, 3);

var (x, y) = rPoint;

var newPoint = rPoint with { X = 10 };

var boundary = new Boundary([newPoint, rPoint, newPoint]);

Console.WriteLine(boundary.Points.Count);

var newBoundary = boundary;

boundary.Points.Add(new(33, 44));

Console.WriteLine(newBoundary.Points.Count);

void Print(Point point = default)
{
    Console.WriteLine(point.X);
    Console.WriteLine(point.Y);
}

internal readonly struct Point
{
    private readonly bool _compilerInitialized; // Když to nastaví kompilátor, bude false, když konstruktor tak true.
    private readonly int _x;
    private readonly int _y;

    public Point(int x, int y)
    {
        _x = x;
        _y = y;
        _compilerInitialized = true;
    }

    public int X => _compilerInitialized ? _x : 10;
    public int Y => _compilerInitialized ? _y : 20;
}

record MyRecord;

record PointRecord(int X, int Y);

record Boundary(List<PointRecord> Points);

record Person(int Id, string FullName)
{
    public string FullName { get; set; } = FullName;
}