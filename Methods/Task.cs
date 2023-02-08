namespace Methods;

// 1. Napište metodu, která vypočítá faktoriál bez rekurze.
// 2. Napište metodu, která vytiskne tzn. Fibonacciho posloupnost.
// 3. Napište metodu, pro generování prvočísel od 0 do horní závory včetně, která bude vstupem metody.
// 4. Napište metodu, která pro zadané číslo zkusí najít všechny kombinace prvočíselných dělitelů.
class Task
{
}

static class SolutionNew
{
    public static UInt128 Factorial(UInt32 input)
    {
        UInt128 factorial = 1;
        for(UInt32 i = 2; i <= input; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    public static void Fibbonaci(UInt32 upperBound)
    {
        Console.WriteLine($"Printing Fibbonaci nubmers up to {upperBound}");
        UInt32 fib = 0;
        UInt32 firstNumber = 0;
        UInt32 secondNumber = 1;
        UInt32 thirdNumber = 1;
        if(upperBound == 0) { Console.WriteLine(fib); return; };
        while (fib <= upperBound)
        {
            Console.WriteLine(fib);
            firstNumber += secondNumber;
            secondNumber += thirdNumber;
            thirdNumber = firstNumber + secondNumber;
            fib = thirdNumber;
        }
    }
}
