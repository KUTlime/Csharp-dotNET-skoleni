/*
#############################################################################
### Typové konverze
#############################################################################

Dva typy:
1. Implicitní
- Automatické, typově bezpečné konverze, např. Int16 -> Int32.
2. Explicitní
- Uživatelem požadované přetypování s pomocí operátoru přetypování.
			           
#############################################################################
*/

// Implicitní konverze

Int16 a = Int16.MaxValue; // Tady ještě žádná konverze neprobíhá.
Int32 b = a;              // Tady už proběhne implicitní konverze z Int16 na Int32.

//Int16 c = b; //error CS0266: Cannot implicitly convert type 'int' to 'short'. An explicit conversion exists (are you missing a cast?)
Int16 cExplicit = (Int16)b;


double d = 5673.74;
int i;

// přetypování double to int
i = (Int32)d;
Console.WriteLine(i); // Desetinná část se odřeže!! Viz výstup níže.

// Výstup:
// 5673

// Konverze mezi základními datovými typy:
(Convert.ToInt32("30")).GetType(); // Vrátí Int32
byte someByte = Convert.ToByte(d);
d = Convert.ToDouble(i);

// Bezpečný způsob převedení stringu na datovou položku.
string someValue = "10a";
Int32 value = 0;
// Int32.Parse() lze taky použít, ale tohle je lepší:
if (Int32.TryParse(someValue, out var valueResult))
{
    value = valueResult;
}
var mc = new MyClass();
Console.ReadKey();