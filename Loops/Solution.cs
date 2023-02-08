namespace Loops;

class Solution
{
	static void Execute()
	{
		bool repeateEntry;
		do
		{
			repeateEntry = Selections.Solution.TaskOne();
		} while (repeateEntry);
	}

	static void AlternativeExecute()
	{
		byte result;
		do
		{
			Console.WriteLine("Zadejte číslo od 0 do 9:");
		} while (!byte.TryParse(Console.ReadLine(), out result) || result > 9 || result < 0 );
	}
}

class AnotherSolution
{
	static void Main()
	{
		byte value;
		string? input;
        do
		{
			Console.WriteLine("Please, enter a number between 0-9:");
			input = Console.ReadLine();
        }
		while (!SingleDigit.TryParse(input, out value));
		Console.WriteLine($"You have entered {value}");
	}

	class SingleDigit
	{
		public static bool TryParse(string? input, out byte value)
		{
            if (input is null)
            {
                value = default;
                return false;
            }

            if (byte.TryParse(input, out value))
            {
				return IsBetweenZeroAndNine(value);
            };
			return false;
        }
        private static bool IsBetweenZeroAndNine(byte value) => value is >= 0 and < 10;
    }
}
