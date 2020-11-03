using System;

namespace Encapsulation
{
	class Encapsulation
	{
		/*
        #############################################################################
        ### Řízení přístupu (zapouzdření)
        #############################################################################
        
        Modifikátory přístupu:
        - public
        - protected 
        - internal
        - private

        Úrovně přístupu:
        - public
        - protected
        - internal
        - protected internal
        - private
        - private protected

        Public:
        - Neomezený přístup.

        Protected:
        - Chráněný přístup
        - Limitovaný pouze v rámci samotné třídy a třídy dědící v 1. generaci z chráněné třídy.
        
        Internal:
        - Interní přístup
        - Pouze v rámci knihovny (assembly).
        
        Protected internal:
        - Chráněný interní přístup.
        - Pouze v rámci knihovny (assembly) nebo třídy děděné z chráněné třídy.
        
        Private
        - Privátní (soukromý) přístup
        - Limitovaný pouze v rámci samotné třídy.
        
        Private protected
        - Chráněný Privátní (soukromý) přístup.
        - Limitovaný pouze v rámci samotné třídy nebo třídy dědící z chráněné třídy v rámci aktuální knihovny.
        #############################################################################
        */

		static void Main(string[] args)
		{
			PointTest p = new PointTest();
			// Přímý veřejný přístup k proměnným
			p.x = 10;
			p.y = 15;
			Console.WriteLine("x = {0}, y = {1}", p.x, p.y);

			var protectedPoint = new ProtectedPoint();
			//protectedPoint.x = 10;
			//protectedPoint.y = 10;

			var derivedPoint = new DerivedPoint();
			//derivedPoint.x = 10; // stále nepřístupné

		}

		// Veřejná třída
		public class PointTest
		{
			// Veřejné proměnné
			public int x;
			public int y;
		}
		// Třída veřejná, ale členská data jsou už protected.
		public class ProtectedPoint
		{
			protected int x;
			protected int y;
		}

		// Odvozený bod
		public class DerivedPoint : ProtectedPoint
		{
			// Funkce nastavení chráněných členů
			static void SomeFunction()
			{
				ProtectedPoint protectedPoint = new ProtectedPoint();
				DerivedPoint derivedPoint = new DerivedPoint();

				// Error CS1540, because x can only be accessed by
				// classes derived from A.
				// protectedPoint.x = 10; 

				// OK, because this class derives from A.
				derivedPoint.x = 10;
				Console.WriteLine("x = {0}, y = {1}", derivedPoint.x, derivedPoint.y);

				var employee = new Employee();

				Console.ReadKey();
			}
		}

		// Interní, tj. přístupná v rámci stejné knihovny (assembly)
		internal class InternalPoint
		{
			internal int x;
			internal int y;
		}

		public class SomeClass
		{
			static void SomeFunction()
			{
				var internalPoint = new InternalPoint();
				internalPoint.x = 10;
				internalPoint.y = 10;

			}
		}

		// Veřejný bod s internal členskými proměnnými.
		// Veřejný kvůli viditelnosti v _17_Encapsulation_2 knihovně.
		// Tato třída není vidět v _17_Encapsulation_2, protože je zanořena 
		// uvnitř třídy, která je internal
		public class PublicInternalPoint
		{
			internal int x;
			internal int y;
		}
	}

	public class PublicInternalPoint
	{
		internal int x;
		internal int y;
	}
}

namespace Encapsulation
{
	// Assembly1.cs
	// Compile with: /target:library
	public class BaseClass
	{
		protected internal int MyValue = 0;
	}

	// TestAccess vidí na BaseClass.MyValue díky slovíčku internal.
	class TestAccess
	{
		void Access()
		{
			BaseClass baseObject = new BaseClass();
			baseObject.MyValue = 5;
		}
	}

	// Assembly2.cs
	// Compile with: /reference:Assembly1.dll
	// Odvozená třída z BaseClass, která je v knihovně Assembly1.
	// DerivedClass vidí na třídu BaseClass díky slovíčku protected.
	class DerivedClass : BaseClass
	{
		static void SomeFunction()
		{
			BaseClass baseObject = new BaseClass();
			DerivedClass derivedObject = new DerivedClass();

			// Error CS1540, because myValue can only be accessed by
			// classes derived from BaseClass.
			// baseObject.myValue = 10;

			// OK, protože tato třída dědí z BaseClass.
			derivedObject.MyValue = 10;
		}
	}

	// Private
	// var employee = new Employee()
	// employee.i = 10; // Nebude fungovat díky slovíčku private.
	class Employee
	{
		private int i;
		double d;   // privátní jako výchozí stav
	}

	// Třída dle OOP
	class Employee2
	{
		private string name = "FirstName, LastName";
		private double salary = 100.0;

		public string GetName()
		{
			return name;
		}

		public double Salary
		{
			get { return salary; }
		}
	}

	class PrivateTest
	{
		static void Main3()
		{
			Employee2 e = new Employee2();

			// Data jsou nepřístupná. Takto k nim nemůžeme přistoupit.
			//    string n = e.name;
			//    double s = e.salary;

			// Přístup ke jménu skrze metodu.
			string n = e.GetName();

			// Přístup k vlastnosti (vysvětleno dále).
			double s = e.Salary;
		}
	}

	// private protected funguje v C# 7.2 a vyšší
	// Assembly1.cs  
	// Kompilováno jako: /target:library  (tzn. knihovna = Assembly1) 
	public class BaseClass2
	{
		private protected int MyValue = 0;
	}

	// Assembly1.cs  
	// Kompilováno jako: /target:library  (tzn. knihovna = Assembly1) 
	public class DerivedClass1 : BaseClass2
	{
		void Access()
		{
			BaseClass2 baseObject = new BaseClass2();

			// Error CS1540, protože myValue je definována jako privátní
			// a nemohu tak skrze instanci BaseClass2 přistupovat k této proměnné.
			// baseObject.myValue = 5;  

			// Zde máme přístup, protože DerivedClass1 je odvozená od BaseClass2.
			MyValue = 5;
		}
	}

	// Assembly2.cs  
	// Compile with: /reference:Assembly1.dll  
	class DerivedClass2 : BaseClass2
	{
		void Access()
		{
			// Error CS0122, protože k myValue lze přistoupit
			// pouze v rámci Assembly1 a ne v Assembly2 nebo jiné.
			// myValue = 10;
		}
	}
}

// Úrovně přístupu:
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/accessibility-levels
