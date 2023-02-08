namespace Enums;

/*
#############################################################################
### Výčty
#############################################################################
    
Deklarace:
enum <enum_name> {
    enumeration list 
};

enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };
#############################################################################
*/

// Klasická definice enum
// Tento enum bude vnitřně používat Int32
// Sun = 0,
// Mon = 1, ...
// Sat = 6
enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

// Z bajtu odvozený enum, podkladový typ nebude Int32, ale byte.
// Hodnoty nemusí jít přesně po sobě, ale mohou přeskakovat.
enum Score : byte
{
    F = 0,
    E = 50,
    D = 60,
    C = 70,
    B = 80,
    A = 100
}

enum Score2 : byte
{
    Z = 10, // Nemusí být uspořádané
    G = 0, // Mohou mít duplicitní hodnoty
           //F = 1,  // Nesmí mít stejnou nosnou položku
    F = 0,
    E = 50,
    D = 60,
    C = 70,
    B = 80,
    A = 100
}

// Odvozený enum z unsigned datového typu
enum Gain : UInt16
{
    Weak = 100,
    Medium = 1000,
    Strong = 10000,
    Max = UInt16.MaxValue,
}

// Lze definovat i flagy
[Flags]
enum SomeFlag
{
    None        = 0b_0000_0000,  // 0
    Monday      = 0b_0000_0001,  // 1
    Tuesday     = 0b_0000_0010,  // 2
    Wednesday   = 0b_0000_0100,  // 4
    Thursday    = 0b_0000_1000,  // 8
    Friday      = 0b_0001_0000,  // 16
    Saturday    = 0b_0010_0000,  // 32
    Sunday      = 0b_0100_0000,  // 64
    Weekend     = Saturday | Sunday // 0b_0110_0000
}

internal class Enums
{
    static void Main(string[] args)
    {
        // Použití
        Days day = Days.Sun; // Enumy jsou automaticky všechny statické.
        Console.WriteLine(day); // Vypíše Sun

        Int32 WeekdayStart = (Int32)Days.Mon;  // Přetypování čísla přímo na enum.
        Int32 WeekdayEnd = (Int32)Days.Fri;    // Ne příliš bezpečný způsob jak vytvořit enum, ale v praxi se bez toho někdy neobejdeme. 

        Console.WriteLine("Monday: {0}", WeekdayStart);
        Console.WriteLine("Friday: {0}", WeekdayEnd);

        // Test zda je hodnota definována v konkrétním enumu.
        Enum.IsDefined(typeof(Score), 10);

        // Pokus o převedení stringu na konkrétní hodnotu enumu.
        // Metoda si najde správný enum podle enumu, který je uveden za
        // slovem "out". Pro zde nemohu použít "out var".
        Enum.TryParse("50", out Score test);

        // Switche se dají vhodně kombinovat s enumy.
        // Visual studio umí automaticky generovat klauzule case pro
        // jednotlivé hodnoty enumů.
        // Umí taktéž poznat, když se do enumu přidá nová položka a
        // nabídne dovytvoření tohoto chybějícího případu.
        switch (test)
        {
            case Score.F:
                break;
            case Score.E:
                break;
            case Score.D:
                break;
            case Score.C:
                break;
            case Score.B:
                break;
            case Score.A:
                break;
            default:
                // Best practice:
                throw new ArgumentOutOfRangeException(nameof(Score), $"Enum is out of the range with value: {test}");
        }

        Console.ReadKey();
    }
}

