using ExceptionAlternative.Coproducts;

Console.WriteLine("Please, enter first number: ");
int firstNumber = int.Parse(Console.ReadLine() ?? "1");
Console.WriteLine("Please, enter second number: ");
int secondNumber = int.Parse(Console.ReadLine() ?? "1");

var result = DivideTwoNumbers(firstNumber, secondNumber);

result.Switch(
	intResult => Console.WriteLine($"Divide operation result: {intResult}"),
	doubleResult => Console.WriteLine($"Divide operation result: {doubleResult:0.00}"),
    _ => Console.WriteLine("Invalid divisor"));

DivideResult DivideTwoNumbers(int firstNumber, int secondNumber)
{
	if(secondNumber is 0)
	{
		return new DivideByZeroException();
    }
	if(firstNumber % secondNumber == 0)
	{
        return firstNumber / secondNumber;
    }
    return firstNumber / (double)secondNumber;
}
