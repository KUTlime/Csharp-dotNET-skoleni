using System;
using System.Collections.Generic;

namespace Interfaces
{
	/*
    #############################################################################
    ### Rozhraní - Interface
    #############################################################################
    
    Dobré vedět:
    - Rozhraní definuje syntaktický kontrakt mezi rozhraním a třídou, která rozhraní dědí, tj. implementuje.
    - Jedná se o kontrakt typu Co-Jak.
    - Rozhraní popisuje "Co".
    - Třída, která dědí popisuje "Jak".
    - < C# 8.0 rozhraní neumožňují držet výkonný kód.
    - > C# 8.0 rozhraní budou moci držet výchozí implementaci.
    - Rozhraní v .NETu i obecně v kódu C# třetích stran začínají "I".

    Rozhraní může obsahovat:
    - Metody
    - Vlastnosti
    - Události

    Syntaxe:
    <modifikátory přístupu> interface I<Název rozhraní> 
    {
       // členy rozhraní
       <Návratový typ> <Název členu>;
       <Návratový typ> <Název členu>;
    }

    public interface ITransactions 
    {
       // interface members
       void ShowTransaction();
       double GetAmount();
    }
    #############################################################################
    */
	static class Program
	{
		static void Main(string[] args)
		{
			ITransactions t1 = new Transaction("001", "8/10/2012", 78900.00);
			ITransactions t2 = new BankTrasnaction();
			ITransactions t3 = new BankTrasnaction();

			t1 = t2;
			t3 = new Transaction("002", "2/7/2019", 5000);
			t1.ShowTransaction();
			t2.ShowTransaction();
			t3.ShowTransaction();
			t1 = new Transaction("001", "8/10/2012", 78900.00);
			t1.Name = "t1";
			t2.Name = "t2";
			t3.Name = "t3";

			var transactions = new List<ITransactions>()
			{
				t1,
				t2,
				t3,
			};

			foreach (var transaction in transactions)
			{
				Console.WriteLine($"Item name: {transaction.Name}, cost: {transaction.GetAmount()}");
			}

			IEnumerable<string> test = new List<string>();
			test = new string[10];

			foreach (var item in test)
			{
				Console.WriteLine(item);
			}
			Int32[] arrayOfNumbers = new[] { 1, 2, 2, 3, 33, 4, 4, 5, 6, };
			var listOfNumbers = new List<Int32> { 1, 2, 2, 3, 33, 4, 4, 5, 6, };
			Utils.PrintDistinct(arrayOfNumbers);
			Utils.PrintDistinct(listOfNumbers);
			
			Console.ReadKey();
		}
	}

	public interface ITransactions
	{
		// členy rozhraní
		void ShowTransaction();
		double GetAmount();

		string Name { get; set; }
	}

	// Implementace rozhaní
	public class Transaction : ITransactions
	{
		private string _tCode;
		private string _date;
		private double _amount;

		public Transaction()
		{
			_tCode = " ";
			_date = " ";
			_amount = 0.0;
		}
		public Transaction(string c, string d, double a)
		{
			_tCode = c;
			_date = d;
			_amount = a;
		}
		public double GetAmount()
		{
			return _amount;
		}

		public string Name { get; set; }

		public void ShowTransaction()
		{
			Console.WriteLine("Transaction: {0}", _tCode);
			Console.WriteLine("Date: {0}", _date);
			Console.WriteLine("Amount: {0}", GetAmount());
		}
	}

	class BankTrasnaction : ITransactions
	{
		public void ShowTransaction()
		{
			Console.WriteLine("No transaction");
		}

		public double GetAmount()
		{
			return 0.0;
		}

		public string Name { get; set; }
	}

	interface ISomeOtherInterface
	{
		// Pokud odkomentuji, kompilátor mi řekne, kde všude musím nově implementovat SomeFunction();
		//void SomeFunction(); 
	}


	// Můžeme připojit více než jedno rozhraní
	class MyClass : ITransactions, ISomeOtherInterface
	{
		public void ShowTransaction()
		{
			throw new NotImplementedException();
		}

		public double GetAmount()
		{
			throw new NotImplementedException();
		}

		public string Name { get; set; }
	}

	class Utils
	{
		public static void PrintDistinct(IEnumerable<Int32> array)
		{
			var uniqueNumbers = new HashSet<Int32>();
			foreach (Int32 number in array)
			{
				uniqueNumbers.Add(number);
			}
			foreach (Int32 number in uniqueNumbers)
			{
				Console.WriteLine(number);
			}
		}
	}
}
