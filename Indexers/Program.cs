
/*
 * Indexer znamená použití operátoru [] pro danou třídu.
 * 
 * class Test {...}
 * var test = new Test();
 * test[0] = ...;
 * 
 * Syntaxe:
 * public Návratový_Typ this[Typ_indexu index]
 * {
 *   get {...; return ...}
 *   set {...}
 * }
 * 
 * Indexovat lze podle libovolného datového typu, nemusí to být int.
 * 
*/
var test = new StudentNames();


test[0] = "firstValue";
test[1] = "secondValue";
test[2] = "thirdValue";
Console.WriteLine(test[1]);

class StudentNames
{
    private readonly List<string> _value = [];

    public string this[int index]
    {
        // return value of stored at studentName array
        get => _value[index];

        // assigns value to studentName
        set => _value.Add(value);
    }
}
