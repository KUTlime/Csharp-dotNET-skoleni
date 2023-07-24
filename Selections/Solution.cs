namespace Selections
{
    public class Solution
	{
		public static bool TaskOne()
		{
			Console.WriteLine("Zadejte číslo od 0 do 9:");
			switch (Console.ReadLine())
			{
				case "1":
					PrintToConsole("jedna");
					break;
				case "2":
					PrintToConsole("dva");
					break;
				case "3":
					PrintToConsole("tři");
					break;
				case "4":
					PrintToConsole("čtyři");
					break;
				case "5":
					PrintToConsole("pět");
					break;
				case "6":
					PrintToConsole("šest");
					break;
				case "7":
					PrintToConsole("sedm");
					break;
				case "8":
					PrintToConsole("osm");
					break;
				case "9":
					PrintToConsole("devět");
					break;
				default:
					PrintToConsole("Neznámé číslo");
					return false;
			}
			return true;
		}

		static void TaskTwo(int points)
		{
			switch (points)
			{
				case int p when p >= 90 && p <= 100:
					PrintGradeToConsole('A');
					break;
				case int p when 80 <= p && p < 90:
					PrintGradeToConsole('B');
					break;
				case int p when 70 <= p && p < 80:
					PrintGradeToConsole('C');
					break;
				case int p when 60 <= p && p < 70:
					PrintGradeToConsole('D');
					break;
				case int p when 50 <= p && p < 60:
					PrintGradeToConsole('E');
					break;
				case int p when p < 50 && p >= 0:
					PrintGradeToConsole('F');
					break;
				default:
					Console.WriteLine("Neznámá hodnota.");
					break;
			}
		}
		
		static void PrintToConsole(string number)
		{
			Console.WriteLine("Zadali jste " + number);
		}

		static void PrintGradeToConsole(char grade)
		{
			Console.WriteLine("Dostali jste: " + grade);
		}
	}
}
