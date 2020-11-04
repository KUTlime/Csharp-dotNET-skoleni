using System;

namespace Operators
{
	class Solution
    {
        static UInt64 GenerateMultipleOfTwo(UInt16 n)
        {
            const UInt64 two = 2;
            return n == 0 ? 1 : two << (n - 1);
        }
        /*
        static void Main()
        {
            Console.WriteLine(GenerateMultipleOfTwo(2));
        }
        */
    }
}


