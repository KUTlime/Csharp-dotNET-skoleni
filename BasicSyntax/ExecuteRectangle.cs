// Uvedení oboru názvů pro objekty.
// Přístup je poté následující: JmenoOboruNazvu.JmenoTridy
using Shapes;

// Použití vytvořené třídy v produkčním kódu.
// C# používá příponu souboru *.cs
// a je dobrá praxe, že každá třída (class)
// má svůj vlastní soubor *.cs
// Proto třídu Rectangle najdeme v souboru Rectangle.cs

var r = new Rectangle();
r.AcceptDetails(); // Volání členské metody, která je definována v třídě Rectangle.
r.Display(); // ------------||----------------
Console.WriteLine(r.Equals(new Rectangle())); // Použití porovnávací funkce.
Console.WriteLine(r.Equals(10)); // Vrátí false.
Console.WriteLine($"Area is: {r.GetArea()}");
Console.ReadLine();
