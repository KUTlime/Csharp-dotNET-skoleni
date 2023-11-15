namespace Arrays
{
    class Solution
	{
		public static Int32[] GetPrimes(Int32 upperBound)
		{
			Int32[] temp = new Int32[upperBound];
			Int32 lastPrimeIndex = 0;
			for (int i = 0; i <= upperBound; i++)
			{
				if (IsPrime(i))
				{
					temp[lastPrimeIndex] = i;
					lastPrimeIndex++;
				}
			}
			Int32[] result = new Int32[lastPrimeIndex+1];
			Array.Copy(temp, result, lastPrimeIndex);
			return temp;
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

		public static Int32 FindSingleton(Int32[] array)
		{
			Int32 result = 0;
			foreach (var number in array)
			{
				result ^= number; // result = result ^ number;
			}
			return result;
			// {  1,   1,   4,   4,   5} 5 je jedináček
			// {001, 001, 100, 100, 101} z desítkové do binární podoby
			// result ^ number => 000 ^ 001 = 001     (1. číslo z pole: 1)
			// result ^ number => 001 ^ 001	= 000     (2. číslo z pole: 1)
			// result ^ number => 000 ^ 100 = 100     (3. číslo z pole: 4)
			// result ^ number => 100 ^ 100 = 000     (4. číslo z pole: 4)
			// result ^ number => 000 ^ 101 = 101     (5. číslo z pole: 5 a také číslo poslední)
			// result = 0b101 => 5

			// {  1,   4,   1,   5,   4} 5 je jedináček
			// {001, 100, 001, 101, 100} z desítkové do binární podoby
			// result ^ number => 000 ^ 001 = 001     (1. číslo z pole: 1)
			// result ^ number => 001 ^ 100	= 101     (2. číslo z pole: 4)
			// result ^ number => 101 ^ 001 = 100     (3. číslo z pole: 1)
			// result ^ number => 100 ^ 101 = 001     (4. číslo z pole: 5)
			// result ^ number => 001 ^ 100 = 101     (5. číslo z pole: 4 a také číslo poslední)
			// result = 0b101 => 5
		}

		public static void PrintDistinct(Int32[] array)
		{
			var unique = array.Distinct();
			foreach (var item in unique)
			{
				Console.WriteLine(item);
			}
		}

        public static int[] GetPrimeNumbers(int upperBound)
        {
            int[] numbers = new int[upperBound];
            int a = 0;
            bool notPrime;
            for (int i = 2; i <= upperBound; i++)
            {
                notPrime = false;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        notPrime = true;
                        break;
                    }
                }
                if (notPrime == false)
                {
                    numbers[a] = i;
                    a++;
                }
            }
            int[] primeNumbers = new int[a];
            for (int i = 0; i < a; i++)
            {
                primeNumbers[i] = numbers[i];
            }
            return primeNumbers;
        }

        public static int[] GetPrimeNumbersWithList(int upperBound)
        {
            var numbers = new List<int>();
            bool notPrime;
            for (int i = 2; i <= upperBound; i++)
            {
                notPrime = false;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        notPrime = true;
                        break;
                    }
                }
                if (notPrime == false)
                {
                    numbers.Add(i);
                }
            }
            return numbers.ToArray();
        }
    }
}