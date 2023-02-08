namespace StringsCsharpEight;

class Program
{
	static string? test = null;
	static void Main(string[] args)
	{
		Console.WriteLine("Hello World!");
		GenerateSomeString(test);
	}

	static string GenerateSomeString(string? entryStr)
	{
		entryStr ??= string.Empty;
		return $"Length is {entryStr.Length}";
	}
}
