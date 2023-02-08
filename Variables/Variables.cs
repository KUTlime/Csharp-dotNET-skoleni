// Deklarace (alokace paměti) proměnných
// Pouze říkáme, že existuje nějaká proměná, jakého datového typu proměnná bude,
// ale nenastavujeme její hodnotu nebo odkaz na paměť, kde je hodnota uložena.

Int16 a; // Stejné, jako kdybych napsal Int16 a = default;
Int32 b;
double c;


// Definice - deklaruje existenci proměnné a zároveň nastavujeme její hodnoty.
Int32 d = 3, f = 5;             // Inicializace d a f dohromady. d a f jsou oba typu Int32
byte z = 22;                    // Inicializace z samostatně. #BestPractise
const double pi = 3.14159;      // Inicializace konstantní proměnné pí
char x = 'x';                   // Inicializace znaku.
string text = "Some text";


// Inicializace (přiřazení hodnoty) proměnných
a = 10;
b = 20;
c = a + b;
Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);  // Tady proběhne 3krát zabalení.
Console.WriteLine($"a = {a}, b = {b}, c = {c}");  // Interpolovaný string, viz kapitola o stringu.


/*
#############################################################################
### Lhodnota vs Rhodnota (Lvalue, Rvalue)
#############################################################################

Lhodnota - může se objevit na obou stranách =
Rhodnota - může se objevit pouze vpravo od =

int number = 20;              // Tohle dává smysl.
20 = number;                  // Tohle nedává smysl.
number = FunctionCall();      // Tohle dává smysl.
FunctionCall() = number;      // Tohle nedává smysl.

#############################################################################
*/
Console.ReadLine();