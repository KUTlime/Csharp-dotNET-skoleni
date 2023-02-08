namespace Selections;

class SwitchStatementsCsharpSeven
{
/*
#############################################################################
### switch a mapování typů před a po C# verzi 7.0
#############################################################################
Před:
case constant:

A bool literal, either true or false.
Any integral constant, such as an int, a long, or a byte.
The name of a declared const variable.
An enumeration constant.
A char literal.
A string literal.

If expr and constant are integral types, the C# equality operator determines whether the expression returns true (that is, whether expr == constant).
Otherwise, the value of the expression is determined by a call to the static Object.Equals(expr, constant) method.


Po (tj. 7.0 a vyšší):

#############################################################################
*/

	static void SwitchStatements()
	{
		// Základní funkcionalita před C# 7.0
		switch (DateTime.Now.DayOfWeek)
		{
			case DayOfWeek.Sunday:
			case DayOfWeek.Saturday:
				Console.WriteLine("The weekend");
				break;
			case DayOfWeek.Monday:
				Console.WriteLine("The first day of the work week.");
				break;
			case DayOfWeek.Friday:
				Console.WriteLine("The last day of the work week.");
				break;
			default:
				Console.WriteLine("The middle of the work week.");
				break;
		}

		// Switch s případy podle typů - C# 7.0 a vyšší
		Int32 sum = 0;
		object item = new object();

		switch (item)
		{
			//  A null reference.
			case null:
				break;
			// A single zero value.
			case 0:
				break;
			// A single value.
			case int val:
				sum += val;
				break;
			// A non-empty collection.
			case IEnumerable<object> subList when subList.Any():
				foreach (var itemFromCollection in subList)
				{
					Console.WriteLine(itemFromCollection);
				}
				break;
			// An empty collection.
			case IEnumerable<object> subList:
				break;

			// A value that is neither an integer nor a collection.
			default:
				throw new InvalidOperationException("unknown item type");
		}

		// switch s rozsahem hodnot
		// U case si vytvoříme pomocnou proměnnou, ideálně stejného
		// datového typu, která nám slouží k např. porovnání za kauzulí
		// when.
		// Tímto dojde k přejmenování "i" na "n", které funguje jako
		// zástupný alias. Datový typ musí být shodný u všech case
		// případů.
		Int32 i = 63;
		switch (i)
		{
			case Int32 n when (n >= 100):
				Console.WriteLine($"I am 100 or above: {n}");
				break;

			case var n when (n < 100 && n >= 50):
				Console.WriteLine($"I am between 99 and 50: {n}");
				break;

			case var n when (n < 50):
				Console.WriteLine($"I am less than 50: {n}");
				break;
		}

		Int32 points = 0;
		char grade = ' ';

		switch (i)
		{
			case int n when (n < 50):
				grade = 'F';
				break;
			case var n when (n >= 50 && n < 60):
				grade = 'E';
				break;
            case var n when (n >= 60 && n < 70):
                grade = 'D';
                break;
            case var n when (n >= 70 && n < 80):
                grade = 'C';
                break;
            case var n when (n >= 80 && n < 90):
                grade = 'B';
                break;
            case var n when (n >= 90):
                grade = 'A';
                break;
        }

		// Výše uvedené se dá celé přepsat s pomocí C# 9.0
		// a pattern matching funkce.
		var newGrade = points switch
		{
            var n when n < 50 => 'F',
			var n when (n >= 50 && n < 60) => 'E',
			var n when (n >= 60 && n < 70) => 'D',
			var n when (n >= 70 && n < 80) => 'C',
			var n when (n >= 80 && n < 90) => 'B',
			var n when (n >= 90) => 'A',
            _ => ' '
		};

		// Dá se ještě zjednodušit
		var newGrade1 = points switch
		{
			_ when points < 50 => 'F',
			_ when (points >= 50 && points < 60) => 'E',
			_ when (points >= 60 && points < 70) => 'D',
			_ when (points >= 70 && points < 80) => 'C',
			_ when (points >= 80 && points < 90) => 'B',
			_ when (points >= 90) => 'A',
			_ => ' '
		};
    }
    public readonly struct Point
    {
        public Point(int x, int y) => (X, Y) = (x, y);

        public int X { get; }
        public int Y { get; }
    }

    static Point Transform(Point point) => point switch
    {
        { X: 0, Y: 0 } => new Point(0, 0),
        { X: var x, Y: var y } when x < y => new Point(x + y, y),
        { X: var x, Y: var y } when x > y => new Point(x - y, y),
        { X: var x, Y: var y } => new Point(2 * x, 2 * y),
    };
}
