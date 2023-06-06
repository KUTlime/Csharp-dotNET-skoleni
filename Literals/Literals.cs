
namespace Literals;

class Literals
{
	static void Main(string[] args)
	{
		// Různé literály pro celočíselné hodnoty
		var value1 = 20; // Int32
		var value2 = 30u; // unsigned Int32
		var value3 = 30U; // unsigned Int32
		var value4 = 30l; // Int64
		var value5 = 30L; // Int64
		var value6 = 30ul; // unsigned long hodnota -> UInt64
		var value7 = 0x4B; // Hexadecimální zápis.
		var value8 = 0b0000_1111; // Binární zápis.

		// var + literály není úplně dobrá praxe.
		// Náchylné na chybu. Nahradit:
		Int32 value9 = 20; // Int32
		UInt32 value10 = 30u; // unsigned Int32
		UInt32 value11 = 30U; // unsigned Int32
		Int64 value12 = 30l; // Int64
		Int64 value13 = 30L; // Int64
		UInt64 value14 = 30ul; // unsigned long hodnota -> UInt64

        // Nebo ještě lépe
        int value15 = 20; // Int32
        uint value16 = 30u; // unsigned Int32
        uint value17 = 30U; // unsigned Int32
        long value18 = 30l; // Int64
        long value19 = 30L; // Int64
        ulong value20 = 30ul; // unsigned long hodnota -> UInt64


        // Celočíselné hodnoty můžeme zadávat opravdu různě:

        Int32 Int32Value1 = 90_946;
		Console.WriteLine(Int32Value1);

		Int32 Int32Value2 = 0x0001_6342;
		Console.WriteLine(Int32Value2);

		Int32 Int32Value3 = 0b0001_0110_0011_0100_0010;
		Console.WriteLine(Int32Value3);

		Int32 Int32Value4 = 0x_0001_6342;       // C# 7.2 a dále.
		Console.WriteLine(Int32Value4);

		Int32 Int32Value5 = 0b_0001_0110_0011_0100_0010;       // C# 7.2 a dále.
		Console.WriteLine(Int32Value5);
		// Výstup:
		//          90946
		//          90946
		//          90946
		//          90946
		//          90946


		// Desetinné literály:
		double Pi = 3.14159;            // Klasika.
		float PiFloat = 314159E-5F;    // Kostrbaté Pi jako float.
		decimal PiDec = 3.14159m;       // Pí jako decimal.
		decimal PiDec2 = 3.14159M;
		//510E          // Neplatné, chybí exponent.
		//210f          // Neplatné, chybí základ nebo desetinná část.
		//.e55          // Neplatné, chybí celočíselná hodnota nebo zlomek.

		// String literály
		string str1 = "Hello!";
		string str2 = @"Hello!"; // Tak, jak je.

		// Espace sekvence
		Console.WriteLine("Hello!\nHello!"); // Zalomení řádku.
		Console.WriteLine("Hello!\tHello!"); // Tabulátor.
		Console.WriteLine("Hello!\\Hello!"); // Vložení zpětného lomítka.
		Console.WriteLine("\"Hello!\""); // Vložení uvozovek do string literálu.

		Console.WriteLine(@" Zpětné lomítko jednouše: \  ");
		Console.WriteLine(@"Hello!
            Hello!"); // Zalomení řádku.

		// Časté použití:
		Console.WriteLine("C:\\Windows\\System32");
		Console.WriteLine(@"C:\Windows\System32");

		// Malé kombo, kdy bereme string tak jak je a
		// do něj vkládáme ještě další textový řetězec.
		Console.WriteLine(@$"C:\{str1}\test");

		// Surové string literály
		Console.WriteLine(""" {"text": "SomeText with "" "}""");

        // Výstup:
        // Hello!
        // Hello!
        // Hello!   Hello!
        // Hello!\Hello!
        // "Hello!"
    }
}
