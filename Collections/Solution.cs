namespace Collections
{
    class Solution
	{
		public static Int32[] GetPrimes(Int32 upperBound)
		{
			var listOfPrimes = new List<Int32>();
			for (int i = 0; i <= upperBound; i++)
			{
				if (IsPrime(i))
				{
					listOfPrimes.Add(i);
				}
			}
			return listOfPrimes.ToArray();
		}

		private static bool IsPrime(Int32 p)
		{
			for (int i = 2; i < p; i++)
			{
				if (p % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		public static Int32[] GetDistinct(Int32[] array)
		{
			var uniqueNumbers = new HashSet<Int32>();
			foreach (Int32 number in array)
			{
				uniqueNumbers.Add(number);
			}
			return uniqueNumbers.ToArray();
		}

        public static void PrintDistinct(Int32[] uniqueNumbers)
        {
		    foreach (Int32 number in uniqueNumbers)
            {
                Console.WriteLine(number);
            }
        }

        public static Int32 FindSingleton(Int32[] array)
		{
			// Musíme ošetřit, když pole je prázdné.
			if (array.Length == 0)
			{
				throw new ArgumentException("Entry array can't be empty.");
			}
			// Vstuní pole musí mít lichý počet prvků.
			if (array.Length % 2 == 0)
			{
				throw new ArgumentException("Entry array has to have an odd length.");
			}
			var listOfNumbers = array.ToList();
			listOfNumbers.Sort();
			
			// Nyní je pole v následujícím stavu: { 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6 }; // Tady je 4 jako jedináček
			var queue = new Queue<Int32>(listOfNumbers.Count);
			foreach (Int32 number in listOfNumbers)
			{
				queue.Enqueue(number);
			}
			Int32 firstElement;
			Int32 secondElement;

			// Nyní budeme odebírat z fronty po dvou prvcích a kontrolovat, jestli to
			// a) vůbec jde a pokud ano,
			// b) jestli si prvky odpovídají.
			// Pokud ne, tak první z nich je hledaný jedináček.
			while (queue.Count > 0)
			{
				firstElement = queue.Dequeue();
				if (queue.TryDequeue(out secondElement))
				{
					if (firstElement == secondElement)
					{
						continue;
					}
					return firstElement;
				}
				else
				{
					return firstElement;
				}
			}
			throw new ArgumentException("Entry array is in unknow state.");
		}

		public static bool IsPalindrome(string str) =>
			str.Equals(new string(str.Reverse().ToArray()));
	}
}
