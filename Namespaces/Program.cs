namespace Namespace
{
	/*
    #############################################################################
    ### Obory názvů - namespace
    #############################################################################
    
    Obory názvů řeší:
    - Konflikty názvů tříd
    - Systém organizování tříd v rámci knihovny.
     
     Klíčové slovo namespace:
    - Vymezuje konkrétní jeden obor názvů.

    Klíčové slovo using:
    - Přidává konkrétní obor názvů do prostředí, kam je vložena.

    Syntaxe:
    namespace JménoOboruNázvů {
        // Kód (třídy, rozhraní, struktury, enumy atd.)
    }

    Jeden obor názvů lze zanořit do druhého oboru.

    Použití:
    JménoOboruNázvů.JménoPoložky;
    #############################################################################
    */

	class Namespaces
	{
		static void Main(string[] args)
		{
			FirstNamespace.Foo1 fc = new FirstNamespace.Foo1();
			SecondNamespace.Foo1 fc1 = new SecondNamespace.Foo1();
			SecondNamespace.Foo2 sc = new SecondNamespace.Foo2();
			fc.Func();
			sc.Func();

			// Použití zanořeného oboru názvů
			var myClass = new BusinessModels.MyClass();
			BusinessModels.DbModels.MyClass.SomeFunction();

			Console.ReadKey();
		}
	}

	namespace FirstNamespace
	{
		class Foo1
		{
			public void Func()
			{
				Console.WriteLine("Inside first_space");
			}
		}
	}
	namespace SecondNamespace
	{
		class Foo1
		{
			public void Func()
			{
				Console.WriteLine("Inside first_space");
			}
		}

		class Foo2
		{
			public void Func()
			{
				Console.WriteLine("Inside second_space");
			}
		}
	}


}
// Zanořené obory názvů
namespace BusinessModels
{
	class MyClass
	{
		public static void SomeFunction()
		{
		}
	}

	namespace DbModels
	{
		class MyClass
		{
			public static void SomeFunction()
			{
			}
		}
	}
}
