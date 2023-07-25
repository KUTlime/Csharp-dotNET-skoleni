namespace Lecture
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

	Druhy oborů názvů:
	- Block scoped (nejstarší)
	- File scoped (novější)
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

			var bCustomer = new Models.Business.Customer();
			var dto = new Models.DTOs.Customer();
			var dbEntity = new Models.DatabaseEntities.Customer();

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
namespace Models
{
	namespace Business
	{
		class Customer
		{

		}
	}

	namespace DatabaseEntities
	{
		class Customer
		{
			public static void SomeFunction()
			{
			}
		}
	}

	namespace DTOs
	{
		class Customer
		{
		}
	}
}
