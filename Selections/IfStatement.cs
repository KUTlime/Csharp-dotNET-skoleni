using System;

namespace Selections
{
	class IfStatement
	{
		static void Main(string[] args)
		{
		}

		static void IfStatements()
		{
			// Klauzule if
			// Vykonání nějakého kódu "navíc" (pokud je splněna podmínka).
			Int32 a = 10;

			if (a < 20)
			{
				/* pokud je podmínka true, provede se následující kód */
				Console.WriteLine("a is less than 20");
			}
			Console.WriteLine("value of a is : {0}", a);

			if (a < 20) // Mezery za if je nepovinná
			{
				/* pokud je podmínka true, provede se následující kód */
				Console.WriteLine("a is less than 20");
			}
			Console.WriteLine("value of a is : {0}", a);

			/*
            if a == b
            {
                // Tohle neklapne.
                // Závorky za if jsou naopak povinné.
            }
            */

			// If-Else klauzule
			a = 100;

			/* kontrola podmínky, musí být možné vyhodnotit na pravda/nepravda */
			if (a < 20)
			{
				/* pokud je podmínka true, provede se následující kód */
				Console.WriteLine("a is less than 20");
			}
			else
			{
				/* pokud je podmínka false, provede se následující kód */
				Console.WriteLine("a is not less than 20");
			}
			// Alternativa
			Console.WriteLine(a < 20 ? "a is less than 20" : "a is not less than 20");

			Console.WriteLine("value of a is : {0}", a);
			Console.WriteLine($"value of a is : {a}"); // To samé, co řádek výše.

			// Klauzule If-Else-If
			/* check the boolean condition */
			if (a == 10)
			{
				/* pokud je podmínka true, provede se následující kód */
				Console.WriteLine("Value of a is 10");
			}
			else if (a == 20)
			{
				/* pokud else if podmínka je pravda */
				Console.WriteLine("Value of a is 20");
			}
			else if (a == 30)
			{
				/* pokud else if podmínka je pravda */
				Console.WriteLine("Value of a is 30");
			}
			else
			{
				/* pokud žádná z podmínek není pravdivá */
				Console.WriteLine("None of the values is matching");
			}
			Console.WriteLine("Exact value of a is: {0}", a);

			// Úsporná varianta č.1
			if (a == 10) { Console.WriteLine("Value of a is 10"); }

			// Usporná varianta č.2 #NotABestPractice
			// Vynechání složených závorek {} z ifu.
			// Pokud je podmínka pravdivá, tak se vykoná pouze a jenom
			// následující řádek za if
			if (a == 10)
				Console.WriteLine("Value of a is 10");



			// Zanořená klauzule if

			a = 100;
			int b = 200;

			// Test na hodnotu 100
			if (a == 100)
			{
				/* pokud je podmínka true, provede se následující kód */
				if (b == 200)
				{
					/* pokud je podmínka true, provede se následující kód */
					Console.WriteLine("Value of a is 100 and b is 200");
				}
			}
			Console.WriteLine("Exact value of a is : {0}", a);
			Console.WriteLine("Exact value of b is : {0}", b);

			if (a == 100)
			{
				/* pokud je podmínka true, provede se následující kód */
				if (b == 200)
				{
					/* pokud je podmínka true, provede se následující kód */
					Console.WriteLine("Value of a is 100 and b is 200");
				}
				else
				{
					Console.WriteLine("b is not equal to 200.");
				}
			}

			/*
             static Int32 SomeFunction(Int32 n)
             {
                 if(n > 100)
                 {
                     Console.WriteLine("n is higher than 100");
                     return n;
                 }
                 else
                 {
                     return 0;
                 }

            // Správná alternativa
                 if(n > 100)
                 {
                     Console.WriteLine("n is higher than 100");
                     return n;
                 }
                 return 0;
             }
             */
		}
	}
}
