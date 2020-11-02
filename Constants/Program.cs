using System;

namespace Constants
{
	class Constants
	{
		const double Pi = 3.14159; // Deklarace konstanty, implicitně statické a určené při překladu.

		static void Main(string[] args)
		{
			double r;
			Console.WriteLine("Enter Radius: ");
			r = Convert.ToDouble(Console.ReadLine()); // Lehce nebezpečná cesta

			// Zcela bezpečná cesta
			double temp;
			if (Double.TryParse(Console.ReadLine(), out temp))
			{
				r = temp;
			}
			else
			{
				r = Double.NaN;
			}
			// Alternativa
			r = Double.TryParse(Console.ReadLine(), out var valueResult) ? valueResult : Double.NaN;

			double areaCircle = Pi * r * r;
			Console.WriteLine("Radius: {0}, Area: {1}", r, areaCircle);
			Console.ReadLine();
		}


		void SomeUseOfPi()
		{
			// Proměnné s modifikátorem const jsou automaticky statické.
			// Co znamená statické, viz kapitola o statických proměnných.
			Console.WriteLine($"Pi is: {Pi}");
		}
	}

	namespace BestPractice
	{
		public class WhatToDo
		{
			// Proměnná, která je pouze pro čtení, nastavuje při startu aplikace,
			// protože je statická, to mimo jiné znamená, že ji můžeme při startu
			// aplikace nastavit na libovolnou hodnotu, kterou si např. přečtene
			// z nastavení aplikace.
			public static readonly Int32 servicePort = 50001;
		}

		// Server side
		public class WhatToAvoid
		{
			public const Int32 servicePort = 50001; // Skvělý způsob jak sám sebe střelit do nohy: https://exceptionnotfound.net/const-vs-static-vs-readonly-in-c-sharp-applications/
													// Pokud je konzument mimo knihovnu, není dobré použít const!
		}
	}
}

// Client side of the best practice
namespace ClientOfMyApp
{
	class MyClientApplication
	{
		private Int32 port = Constants.BestPractice.WhatToAvoid.servicePort;
	}

}
