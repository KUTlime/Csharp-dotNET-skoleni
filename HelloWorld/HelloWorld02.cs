// Přidání systémové knihovny do aplikace HelloWorld

// Obor názvů aplikace, veškerý kód mimo klauzule "using" musí skončit zde.
namespace HelloWorld
{
    // Definice třídy aplikace, zde uložíme vstupní bod pro operační systém.
    class HelloWorld
    {
        // Statická metoda Main - vstupní bod naší C# aplikace.
        // Metoda musí být statická - nepotřebuje objekt.
        // Metoda sama je internal (vysvětleno dále).
        // string[] args - vstupní argumenty z příkazové řádky.
        static void Main(string[] args)
        {
            /* Můj první program v C#
             A toto je vlastně víceřádkový komentář.
            */
            Console.WriteLine("Hello World"); // Tisk hlášení do konzoly.
            Console.ReadKey(); // Pozastavení programu a čekání na vstup uživatele.

            // Středník ; je používán jako ukončovací znak každého řádku s instrukcemi.
        }
    }

    // Platné vstupní body do aplikace_
    // Jedna z následujících možností musí být vždy přítomna v platné C# aplikaci.
    // static void Main()
    // static void Main(string [])
    // static void Main( nějaké argumenty přetížení)
    // static int Main()
    // static int Main(string [])
    // static int Main( nějaké argumenty přetížení)

    class HelloWorld2
    {
        // Main metoda bez argumentů.
        static void Main()
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
        }
    }


    class HelloWorld3
    {
        // Veřejný přístup. 
        // Výchozí přístup je internal, ale to OS nevadí ve volání metody Main.
        // Metoda Main by neměla být veřejná.
        // Pokud je, hrozí volání z jiných tříd, což je v rozporu s její definicí:
        // Metoda Main by měla být volána pouze a jenom při startu aplikace.
        public static void Main(String[] args)
        {
            Console.WriteLine("Main Method");
        }
    }

    // Main public demo class
    class MyClass
    {
        public static void SomeFunction()
        {
            HelloWorld3.Main(new string[0]); // Takto opravdu ne.
            // Metoda Main by měla být volána pouze operačním systémem.
            // Proto by Main metoda nikdy neměla mít klíčové slovo public.
        }
    }

    public class HelloWorld4
    {
        // Další variace přístupu.
        // Pro zvolení verze C#, je nuntné nastavit tuto verzi
        // v nastavení projektu.
        // Pravé tlačítko nad projektem -> Vlastnosti -> Sestavení
        // -> Upřesnit. Zde je položka jazyková verze. Přestně toto
        // určuje verzi C#, která je použita při překladu tohoto projektu.
        // Pro různé projekty v jednom rešení, můžete mít různé verze překladu.
        private protected static void Main(String[] args) // C# 7.2 a vyšší nutné. 
        {
            Console.WriteLine("Main Method");
            Console.ReadKey();
        }
    }

    class HelloWorld5
    {
        // Main metoda bez argumentů,
        // ale s návratovou hodnotou.
        static int Main()
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
            return 0; // Povinné.
        }
    }

    class HelloWorld6
    {
        // Přetížená metoda Main.
        static int Main(int input, string path)
        {
            Console.WriteLine(value: path);
            Console.ReadKey();
            return 0; // Povinné.
        }
    }
}
