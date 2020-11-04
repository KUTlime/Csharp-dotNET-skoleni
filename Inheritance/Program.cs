﻿using Microsoft.CSharp.RuntimeBinder;
using System;

namespace Inheritance
{
	/*
    ############################################################################
    ### Dědičnost
    #############################################################################
     
    Dědičnost vyjadřuje vztah:
    - je nějaký ...
    - je typ ...
    - je druh ...

    Umožňuje znovuvyužití kódu, lepší členění a správu kódu.

    Syntaxe:
    <modifikátory přístupu> <Obor platnosti> class <Předek>
    {
        // Členské proměnné
        ...
        public Int32 someValue = 0;
        protected Int32 someProtectedValue = 0;
    }
    <modifikátory přístupu> <Obor platnosti> class <Potomek1> : Předek
    {
        ...
        public double someDoubleValue = 0;          // Musím volit nekonfliktní názvy proměnných.
        protected double someOtherDoubleValue = 0;  // Musím volit nekonfliktní názvy proměnných.
        ...
        public void SomeFunction()
        {
            someValue = 1;          // Přístup do proměnné předka, konkrétně třídy Předek
            someProtectedValue = 1; // Přístup do proměnné předka, konkrétně třídy Předek
        }
    }

    <modifikátory přístupu> <Obor platnosti> class <Potomek2> : <Potomek1>
    {
       ...
       public void SomeFunction()
       {
           someValue = 1;               // Přístup do proměnné předka, konkrétně třídy Předek
           someDoubleValue = 1;         // Přístup do proměnné předka, konkrétně třídy Potomek1
           //someProtectedValue = 1;    // Už nelze
           someOtherDoubleValue = 1;    // Přístup do proměnné předka, konkrétně třídy Potomek1
       }
    }

    Dobré vědě:
    - C# nepodporuje vícenásobnou dědičnost.
    - C# podporuje sestavování funkcionality pomocí rozhraní (interface).
    
    */
	static class Program
	{
		static void Main(string[] args)
		{
			Circle circle = new Circle();

			circle.SetOriginX(5.0);
			circle.SetOriginY(0.0);

			// Tisk oblasti - volání příslušné metody.
			Console.WriteLine("Total area: {0}", circle.GetArea());

			Tabletop t = new Tabletop(4.5, 7.5);
			t.Display();

			var triangle = new Triangle();
			triangle.IsIsoscelesTriangle(); // Použití metody rozšíření.

			var elipse = new Ellipse(10.0, 5.0);
			elipse.SetOriginX(0.0);
			elipse.SetOriginY(0.0);
			elipse.SetWidth(5);
			elipse.SetHeight(7);
			double area = elipse.GetArea();

			// Tisk oblasti - volání příslušné metody.
			Console.WriteLine("Total area: {0}", area);
			Console.WriteLine("Total paint cost: ${0}", elipse.GetCost(costPerSquareMeter: 10));


			Console.ReadKey();
		}
	}

	// Rozhraní
	// Toto rozhraní přidává nezbytnost implementace metody GetArea()
	internal interface IArea
	{
		double GetArea();
	}

	public interface IPaintCost
	{
		double GetCost(double costPerSquareMeter);
	}

	// Předek
	// třída obecného tvaru
	class Shape : IArea
	{
		// Metoda nastavení počátku (těžiště) tvaru do kartézké souřadnice X.
		public void SetOriginX(double w)
		{
			X = w;
		}
		// Metoda nastavení počátku (těžiště) tvaru do kartézké souřadnice Y.
		public void SetOriginY(double h)
		{
			Y = h;
		}
		// Souřadnice středu tvaru.
		protected double X;
		protected double Y;
		public virtual double GetArea()
		{
			return 0;
		}
	}

	// Odvozená třída
	// Kružnice
	class Circle : Shape
	{
		private double _radius = 0; // Buď public nebo udělat nějakou přístupovou metodu.

		public Circle()
		{}

		public Circle(double r)
		{
			_radius = r;
		}
		
		public override double GetArea()
		{
			return Math.PI * _radius * _radius;
		}
	}

	class Rectangle : Shape
	{
		//členské proměnné
		protected double Length;
		protected double Width;

		public Rectangle(double length, double width)
		{
			Console.WriteLine("A default constructor for a rectangle.");
			Length = length;
			Width = width;
		}
		public override double GetArea()
		{
			return Length * Width;
		}
		public void Display()
		{
			Console.WriteLine("Length: {0}", Length);
			Console.WriteLine("X: {0}", Width);
			Console.WriteLine("Area: {0}", GetArea());
		}
	}

	// Odvozená třída
	class Tabletop : Rectangle
	{
		private double _cost;

		public Tabletop(double length, double width) : base(length, width) // volání bázového konstruktoru
		{ }

		public double GetCost()
		{
			_cost = GetArea() * 70;
			return _cost;
		}
		// Musíme přidat klíčové slovo new
		public new void Display()
		{
			base.Display(); // Volání bázové metody Display(), Rectangle.Display()
			Console.WriteLine("Cost: {0}", GetCost());
		}
	}

	// Odvozená třída
	class Ellipse : Shape, IPaintCost
	{
		private double _length;
		private double _width;

		public Ellipse(double length, double width)
		{
			_length = length;
			_width = width;
		}

		public override double GetArea()
		{
			return (_width * _length * Math.PI);
		}
		public double GetCost(double costPerSquareMeter)
		{
			return costPerSquareMeter * GetArea();
		}

		public void SetWidth(double width)
		{
			_width = width;
		}

		public void SetHeight(double length)
		{
			_length = length;
		}
	}

	// Potomek má nižší restrikci přístupu než předek.
	// Nelze použít.
	//public class Square : Shape
	//{
	//}

	internal class Square : Shape
	{
	}

	// Sealed - zapečetěná třída
	// Tuto třídu už nelze dědit. Rozšíření zapečetěné třídy lze pouze skrze
	// extenzní metodu.
	internal sealed class Triangle : Shape
	{
		public double a = 0;
		public double b = 0;
		public double c = 0;
	}


	public static class TriangleExtensions
	{
		// Extenzní metoda
		// Musí být statická a jako první parametr musí přebírat typ, který rozšiřuje
		// a musí this.
		internal static bool IsIsoscelesTriangle(this Triangle triangle)
		{
			return Math.Abs(triangle.a - triangle.b) < 10 * Double.Epsilon;
		}
	}

	// Tohle nepůjde zkompilovat.
	// Triangle je sealed.
	//internal sealed class IsoscelesTriangle : Triangle
	//{
	//}


	namespace AbstractDemo
	{
		// Podobný přístup jako přes rozhraní.
		// Abstraktní metoda může být pouze v abstraktní třídě.
		// Abstraktní metody musí být implementovány v potomkovi, stejně jako rozhraní.
		// Nemůžeme ale operovat jako s proměnnou.
		abstract class Shape
		{
			protected double X;
			protected double Y;
			public abstract double GetArea();

			public virtual void Print()
			{ }
		}

		class Circle : Shape
		{
			public Circle(double originX, double originY)
			{
				X = originX;
				Y = originY;
			}
			public override double GetArea()
			{
				Console.WriteLine("Circle");
				return 0;
			}

			public override void Print()
			{
				base.Print();
			}

			public void DoSomething()
			{
				Shape shape = new Circle(0, 0);
				shape.GetArea();
			}
		}
	}
}
