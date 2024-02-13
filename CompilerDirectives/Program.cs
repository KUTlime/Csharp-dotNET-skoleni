// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#if DEBUG
record MyDebugRecord();
#endif

#line hidden

#error My custom error

#nullable enable
// V této části kódu bude nullable zapnuté.
#nullable disable

#region Structs
internal readonly struct Point
{
    private readonly bool _compilerInitialized; // Když to nastaví kompilátor, bude false, když konstruktor tak true.
    private readonly int _x;
    private readonly int _y;

#pragma warning disable IDE0290 // Použít primární konstruktor
    public Point(int x, int y)
#pragma warning restore IDE0290 // Použít primární konstruktor
    {
        _x = x;
        _y = y;
        _compilerInitialized = true;
    }

    public int X => _compilerInitialized ? _x : 10;
    public int Y => _compilerInitialized ? _y : 20;
}
#endregion

