namespace Operators;

// Navrhněte metodu, která bude vracet UInt64. Jako vstupní parametr
// bude přebírat n-mocninu 2ky (1. mocnina = 2, 2. mocnina = 4 atd).
// Při testování, můžete N-násobek přečíst jako UInt16 = Console.ReadLine()
// Popřemýšlejte, co mají násobky 2 společné.
class Task
{
    string? input;
    UInt16 power;

    public Task()
    {
        input = Console.ReadLine();
        power = Convert.ToUInt16(input);
    }

    public UInt64 GetPower(UInt16 power) { return (UInt64)2 * power; }
}

