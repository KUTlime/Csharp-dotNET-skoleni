namespace DataTypes
{
    // C# má tři kategorie proměnných:
    // 1. Hodnotové (alokace na "stacku" a formou stacku (LIFO)) https://en.wikipedia.org/wiki/Stack-based_memory_allocation
    // 2. Referenční (alokace na haldě)
    // 3. Ukazatele (použití pro nespravovaný kód)

    // Překled aliasů zabudovaných datových typů
    // Pokud je použito klíčové s Bool
    // bool System.Boolean
    // byte System.Byte
    // sbyte System.SByte
    // char System.Char
    // decimal System.Decimal
    // double System.Double
    // float System.Single
    // int System.Int32
    // uint System.UInt32
    // long System.Int64
    // ulong System.UInt64
    // short System.Int16
    // ushort System.UInt16
    // object System.Object
    // string System.String

    static class DataTypes
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Size of int: {0}", sizeof(int)); // Zjištění velikosti nativní velikosti celočíselné hodnoty.

			// Trocha (sebe)reflexe
			Type stringType = typeof(string);
			Type doubleType = typeof(System.Double);

			Console.WriteLine(stringType.FullName);
			Console.WriteLine(doubleType.FullName);

            // Výstup:
            // System.String
            // System.Double


            // 
            // #############################################################################
            // ### 1. Hodnotové datové typy
            // #############################################################################

            /*
            Alias | Plný název | Hodnoty
            bool | System.Boolean | 0 .. 255
            byte | System.Byte | 
            char | System.Char |
            decimal | System.Decimal | 
            double | System.Double |
            float | System.Float | 
            int | System.Int32 | 
            long | System.Int64 | 
            sbyte | System.SByte
            short | System.Int16 |
            uint | System.UInt32
            ulong | System.UInt64
            ushort | System.UInt16 | 
            enum | System.Enum
            struct | 
            DateTime | System.DateTime
            Tuple (C# 7.0 a vyšší)

            Tyto všechny proměnné jsou alokovány na stacku.

            */

            /*
            XRZ - Rozepsat UInt64 problematiku 
            XRZ - Přeskládat tuto kapitolu pro logičtější koncepci.
            */

            /*
            #############################################################################
            ### 2. Referenční datové typy
            #############################################################################
            Neobsahují skutečnou hodnotu, pouze referenci na původní hodnotu.
            
            Alias | Plný název | Hodnoty
            object System.Object
            string
            dynamic

            System.Object je základní objekt, ze kterého dědí všechny objekty (hodnotové, ukazatele, uživatelské objekty) v C#.
            Kompilátor automaticky přidá dědění z této třídy do všech uživatelských tříd a struktur.

            A tato klíčová slova jsou použita pro deklaraci referenčních datových typů:
            class
            interface
            delegate
            
            #############################################################################
            ### Boxing - Konverze mezi hodnotovým a referenčním datovým typem
            #############################################################################

            Hodnota -> Objekt | Boxing (zabalení)
            Objekt -> Hodnota | UnBoxing (rozbalení)

            object obj;
            obj = 100; // toto je zabalení (boxing) a není potřeba přetypování
            int value = obj; // toto je rozbalení (unboxing)

            Těmto operacím se snažíme vyhnout!!!

            Zabalení vytváří kopii objektu.
            int i = 46;
            object o = i;   // Zabalení i
            i = 47;   // i je teď 47, ale objekt o ukazuje stále na objekt s hodnotou 46

            // Automatické zabalení
            int i = 1984;
            Console.WriteLine("Favorite numbers: {0}, {1}, {2}", 42, 6, i); // Tři zabalení, která se provedou automaticky.
            #############################################################################


            #############################################################################
            ### Dynamic
            #############################################################################
            Dynamic je datový typ určený za běhu.
            
            Jedná se o klíčové slovo, viz následující syntaxe:
            dynamic d = 20;
            d.GetType(); // System.Int32
            d = "blabla";
            d.GetType(); // System.String

            v kontrastu s tímto:
            var e = 20; 
            e.GetType(); // System.Int32
            Int32 e = 20; // Stejné jako o dva řádky výše, jenom přesně řeknu, jaký je to datový typ.
            e = "asdf"; 
            e.GetType(); // error CS0029: Cannot implicitly convert type 'string' to 'int'
            
            Datový typ objektu d je určen za běhu. Je zde návaznost na klíčové slovo var.
            #############################################################################

            #############################################################################
            ### String - řetězec znaků
            #############################################################################
            
            Alias pro System.String.
            Podporuje Unicode od C# 1.0.

            Více v samostané kapitole.
            #############################################################################
            */


            /*
            #############################################################################
            ### 3. Ukazatele
            #############################################################################
            
            Klasické ukazatale alá C. Více v kapitole Unmanaged code - nespravovaný kód.

            char* pointerToChar;
i           Int* pointerToInteger;

            #############################################################################
            */

			int a = 5;
			Int32 b = a + 2; //OK
			Console.WriteLine(b);

			bool test = true; // popř. false

			// Typová kontrola v C# - toto neprojde.
			//int c = a + test;
			//int integer = test;
			//int integer = (int)test;

			/*
            Celočíselné proměnné:
            1. Signed (se znaménkem) - 1 bit je vyhrazen pro indikaci znaménka.
            2. Unsigned (bez znaménka) - všechny bity popisují velikost.

            // Mohutnost celočíselných datových typů
            // Nejmenší Int16
            Int16 -> Int32 -> Int64

            */

			Console.WriteLine("Celočíselné proměnné:");
			Console.WriteLine($"SByte: velikost[byte]: {sizeof(SByte)}, min: {SByte.MinValue} max: {SByte.MaxValue}");
			Console.WriteLine($"Int16: velikost[byte]: {sizeof(Int16)}, min: {Int16.MinValue} max: {Int16.MaxValue}");
			Console.WriteLine($"Int32: velikost[byte]: {sizeof(Int32)}, min: {Int32.MinValue} max: {Int32.MaxValue}");
			Console.WriteLine($"Int64: velikost[byte]: {sizeof(Int64)}, min: {Int64.MinValue} max: {Int64.MaxValue}");
			Console.WriteLine($"Byte: velikost[byte]: {sizeof(Byte)}, min: {Byte.MinValue} max: {Byte.MaxValue}");
			Console.WriteLine($"UInt16: velikost[byte]: {sizeof(UInt16)}, min: {UInt16.MinValue} max: {UInt16.MaxValue}");
			Console.WriteLine($"UInt32: velikost[byte]: {sizeof(UInt32)}, min: {UInt32.MinValue} max: {UInt32.MaxValue}");
			Console.WriteLine($"UInt64: velikost[byte]: {sizeof(UInt64)}, min: {UInt64.MinValue} max: {UInt64.MaxValue}");

			// Znaky
			Console.WriteLine($"Char: velikost[byte]: {sizeof(char)}, min: {Char.MinValue} max: {Char.MaxValue}");

			/*
            // Desetinná čísla
            1. Float - nejmenší rozsah, vhodné pro nenáročné výpočty s cílem vysoké rychlosti.
            2. Double - double = dvojitý, tj. dvojitá přesnost.
            3. Decimal - menší rozsah než double, ale vyšší přenost. Vhodné pro finanční operace.
            */
			Console.WriteLine($"decimal: velikost[byte]: {sizeof(decimal)}, min: {Decimal.MinValue} max: {Decimal.MaxValue}");
			Console.WriteLine($"float: velikost[byte]: {sizeof(float)}, min: {float.MinValue} max: {float.MaxValue}");
			Console.WriteLine($"double: velikost[byte]: {sizeof(double)}, min: {Double.MinValue} max: {Double.MaxValue}");

			// Bool
			Console.WriteLine($"bool: velikost[byte]: {sizeof(Boolean)}, min: [False] max: [True]");


			// Užitečné členské proměnné
			Console.WriteLine(Int32.MaxValue);
			Console.WriteLine(Int32.MinValue);
			Console.WriteLine(Double.MaxValue);
			Console.WriteLine(Double.NaN);
			Console.WriteLine("Nejmenší možný rozdíl dvou po sobě jdoucích double čísel: {0}", Double.Epsilon);
		}

		static class BestPractises
		{
			private Int32 DontUseInt = 1; // nebo jiné aliasy
			private UInt64 UseFullQualifer = 1;
			private Byte DontUseVarKeywordForValueTypes = 1;
			/*
             var r = new Rectangle()
             // Tady je jasné, co je r, je to objekt typu Rectangle. 

            int i = 10;
            // Co je i teď? Je to Int32? Je to Int64?
            // Tady to asi uhodneme, ale co třeba:
            var j = 10U;
            // Co je teď j?
            // Je lepší rovnou napsat
            UInt32 j = 10U;
            */

			private void UseBasicNameForMethods()
			{
				// Test, zda zadaný řetězec není jenom mezera nebo Null.
				// Používáme statickou metodu IsNullOrWhiteSpace z třídy String,
				// proto je lepší a syntakticky hezčí to napsat jako String.IsNullOrWhiteSpace
				// než string.IsNullOrWhiteSpace.
				// Dáváme tím jasně najevo, že se volá statická funkce, viz kapitola o statice.
				var isNullOrWhiteSpace = string.IsNullOrWhiteSpace("Test");

				// Pokus o převedení textu z stringu do proměnné typu Int32.
				// Klíčové slovíčko var se přeloží jako Int32.
				// Opět platí výše uvedené pro interpretaci integerů.
				Int32.TryParse("3", out var test);
			}
		}
	}
}
