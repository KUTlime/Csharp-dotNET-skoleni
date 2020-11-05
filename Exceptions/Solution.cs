using System;

namespace Exceptions
{
	class Solution
	{
		class MyCustomException : Exception
		{
			public bool Important { get; set; } = true;

			public TimeSpan OfficeOpen { get; } = new TimeSpan(9, 0, 0);
			public TimeSpan OfficeClose { get; } = new TimeSpan(15, 0, 0);

			public MyCustomException()
			{
			}

			public MyCustomException(string message) : base(message)
			{
			}

			public MyCustomException(string message, Exception exception) : base(message, exception)
			{
			}

			public override string ToString()
			{
				return base.ToString() + $"Importance: {Important}, Time of occurence: {DateTime.Now.TimeOfDay}";
			}
		}

		public static void SomeMethod()
		{
			try
			{

				throw new MyCustomException("Some nonsense from user") { Important = false, };
				throw new MyCustomException("Hmm, this is weird behaviour...") { Important = true, };
				//Console.WriteLine(); // Nedosažitelný kód.
			}
			catch (MyCustomException e) when (e.Important && DateTime.Now.TimeOfDay > e.OfficeOpen &&
											  DateTime.Now.TimeOfDay < e.OfficeClose)
			{
				Console.WriteLine(e); // Volání přetížené metody ToString()
				throw;
			}
			catch (MyCustomException e)
			{
			}
		}

	}
}