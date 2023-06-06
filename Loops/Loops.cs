

// Deklarace lokální proměnné
int a = 10;

// Každá smyčka má svůj obor platnosti,
// který je dán blokem {}.

// while - smyčka s podmínkou na začátku.
while (a < 20)
{
	Console.WriteLine("value of a: {0}", a);
	a++;
}

do
{
    Console.WriteLine("value of a: {0}", a);
    a++;
}
while (a < 20);

// Vždy lepší vyrobit index ve smyčce for,
// abychom neblokovali nadřazený rozsah platnosti (scope).
/*
     * Smyčka for se sklázá ze dvou částí:
     * 1. Hlavička smyčky
     * 2. Tělo smyčky
     *
     * Hlavička se skládá ze 3 částí:
     * 1. Preambule (tj. inicializační část)
     * 2. Podmínková část
     * 3. Postambule (tj. iterační) část
     *
     * Vyhodnocení smyčky for je následující:
     * 1. Provede se preambule, tj. int index = 10. Výsledkem je existence
     * proměnné index v lokálním oboru platnosti oné smyčky. Kdekoliv proměnná
     * index nebude vidět.
     * 2. Provede první vyhodnocení podmínkové části, tj. index < 20. Pokud je
     * vyhodnoceno na pravda, provede se skok do těla smyčky, tj. na příkaz
     * Console.WriteLine("value of a: {0}", index);
     * Pokud je výraz vyhodnocen na nepravda, provede se skok na další řádek za
     * za konec smyčky, tj. Console.ReadLine().
     * 3. Při dokončení příkazů z těla smyčky, tj. Console.WriteLine("value of a: {0}", index);
     * je proveden skok do iterační části smyčky a provede se zde přítomný kód,
     * tj. index++. Následně se provede skok do podmínkové části.
     * 4. Opět se vyhodnotí podmínková část. Pokud je vyhodnocena na pravdu,
     * následuje skok do těla smyčky. Pokud je vyhodnocena na nepravdu, následuje
     * skok na další příkaz za smyčkou, tj. Console.ReadLine().
     * 5. Provede opět celý kód těla smyčky a poté následuje skok do iterační
     * části smyčky, kde se provede přítomný kód, tj. index++. Odtud se opět skočí
     * do podmínkové části.
     * 6. Opět se vyhodnotí podmínková část a cyklus se opakuje.
     */
for (int index = 10; index < 20; index++)
{
    Console.WriteLine("value of a: {0}", index);
}
Console.ReadLine();

// Zanořené smyčky
int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.WriteLine($"A[{i}][{j}]: {array2D[i, j]}");
    }
}

// Funkce break
// Jakmile tok programu dojde k break klauzuli,
// následuje okamžité přerušení vykonávání smyčky
// a skok na další příkaz za smyčkou.
for (int i = 2; i < 100; i++)
{
    for (int j = 2; j <= (i / j); j++)
    {
        if ((i % j) == 0)
        {
            break; // pokud je faktor nalezen, není to prvočíslo.
        }

        if (j > (i / j))
        {
            Console.WriteLine("{0} is prime", i);
        }
    }
    // Pokud bychom chtěli zastavit i druhou smyčku,
    // musí být break i tady.
}

// Funkce continue
// přeskakuje vykonávání zbytku iterace smyčky.
// Po nalezení continue, následuje skod do iterační části smyčky.
for (int i = 1; i <= 10; i++)
{
    if (i < 9)
    {
        continue;
    }
    Console.WriteLine(i);
}

// Definice kolekcí
var list = new List<string> { "Radek", "Eva", "Dušana", "Svatopluk", "Zdeněk" };
var list2 = new HashSet<string> { "Radek", "Eva", "Dušana", "Svatopluk", "Zdeněk" };

// Smyčka "pro každou položku z kolekce..."
// Smyčka funguje tak, že si sama rozloží kolekci na jednotlivé prvky,
// postupně je prochází a vykonává kód, který je uveden v těle foreach
// smyčky.
// Smyčka je provedena právě tolikrát, kolik je položek v kolekci, která
// je předána v hlavičce foreach.
foreach (var item in list)
{
    Console.WriteLine(item);
}

foreach (var item in list2)
{
    Console.WriteLine(item);
}

byte[] byteArray = new byte[10];
foreach (var item in byteArray)
{ 
    Console.WriteLine(item); 
}


var list2D = new List<List<string>>()
{
    new List<string> { "Radek", "Eva", "Dušana", "Svatopluk", "Zdeněk" },
    new List<string> { "Klára", "Ondřej" },
    new List<string> { "Michal", "Tomáš" },
    new List<string> { "Dominik", "Věra" },
    new List<string> { "Tonda", "Honza", "Anička" },
};

foreach (var listOfNames in list2D)
{
    foreach (var name in listOfNames)
    {
        Console.WriteLine(name);
    }
}

// Foreach + continue + break
// Mají stejnou funkci jako u for.
foreach (var listOfNames in list2D)
{
    foreach (var name in listOfNames)
    {
        if (name == "Radek")
        {
            continue;
        }

        if (name == "Anička")
        {
            break;
        }
        Console.WriteLine(name);
    }
}

Console.ReadLine();
