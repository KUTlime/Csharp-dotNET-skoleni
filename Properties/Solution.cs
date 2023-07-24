namespace Properties
{
    class Solution
	{
		static IEnumerable<Product> GenerateData()
		{
			return new List<Product>
			{
				new Turbo("111", "MyTurbo", 10000),
				new Turbo("112", "MyTurboFromBosh", "Bosh", 10000),
				new EWP("113", "MyEWP", 5000, Rotation.Angle0),
				new EWP("114", "MyOtherEWP", 1000, Rotation.Angle120),
				new BrakeSensor("115", "MyBrakeSensor", 1234)
			};
		}
		static void Main()
		{
			// TODO: Ohlídat, že zvolená možnost je opravdu v rozsahu daného enumu
			ProductType selectedOption = (ProductType)ExecuteMenu();
			var data = GenerateData();
			PrintCatalogue(data.Where(p => p.ProductType == selectedOption));
		}

		private static int ExecuteMenu()
		{
			Int32 selectedOptionNumber;
			do
			{
				PrintMenu();
			} while (!Int32.TryParse(Console.ReadLine(), out selectedOptionNumber));
			return selectedOptionNumber;
		}

		private static void PrintMenu()
		{
			Console.WriteLine("Select product type cataloge:");
			string[] enumNames = Enum.GetNames(typeof(ProductType));
			var enumValues = Enum.GetValues(typeof(ProductType));
			for (int i = 0; i < enumNames.Length; i++)
			{
				Console.WriteLine($"For {enumNames[i]}, please type {(Int32)enumValues.GetValue(i)}");
			}
		}

		static void PrintCatalogue(IEnumerable<Product> list)
		{
			foreach (var pump in list)
			{
				Console.WriteLine($"Product name: {pump.Name}, id: {pump.ProductId}, price: {pump.Price}");
			}
		}
	}
	/*
	internal interface IPump
	{
	}

	class Pump : IPump
	{
		public string PumpName { get; set; }
		public string Fuel { get; set; }
		public string Performance { get; set; }
		public List<Product> Products { get; set; }
		public List<Workflow> Workflow { get; set; }
	}
	class Turbocharger
	{
		public string TurbochargerName { get; set; }
		public string Fuel { get; set; }
		public string Performance { get; set; }
		public List<Product> Products { get; set; }
		public List<Workflow> Workflow { get; set; }
	}
	class Senzor
	{
		public string SenzorName { get; set; }
		public string Accuracy { get; set; }
		public string Sensitivity { get; set; }
		public List<Product> Products { get; set; }
		public List<Workflow> workflow { get; set; }
	}
	class Actuator
	{
		public string ActuatorName { get; set; }
		public List<Product> Products { get; set; }
		public List<Workflow> Workflows { get; set; }
	}
	class Ventil
	{
		public string Name { get; set; }
		public string Pressure { get; set; }
		public List<Product> Products { get; set; }
		public List<Workflow> Workflow { get; set; }
	}

	class Workflow //výrobní postup
	{
	}
	*/
	abstract class Product : Type
	{
		public Product(string productId, string name, decimal price, ProductType product) : base(product)
		{
			ProductId = productId;
			Name = name;
			Price = price;
		}
		public Product(string productId, string name, string supplier, decimal price, ProductType product) : base(product)
		{
			ProductId = productId;
			Name = name;
			Price = price;
			Supplier = supplier;
		}
		public string ProductId { get; }
		public string Name { get; }
		public string Supplier { get; } = "Continental Corporation";
		public decimal Price { get; }
	}
	abstract class Type
	{
		public Type(ProductType productType)
		{
			ProductType = productType;
		}
		public ProductType ProductType { get; protected set; }
	}
	class EWP : Product
	{
		public EWP(string productId, string name, decimal price, Rotation rotation) : base(productId, name, price, ProductType.EWP)
		{
			Rotation = rotation;
		}
		public EWP(string productId, string name, string supplier, decimal price, Rotation rotation) : base(productId, name, supplier, price, ProductType.EWP)
		{
			Rotation = rotation;
		}
		public Rotation Rotation { get; set; } //120° nebo 0°
		public Voltage Voltage { get; set; } = Voltage.Volt12;
	}
	class Turbo : Product
	{
		public Turbo(string productId, string name, decimal price) : base(productId, name, price, ProductType.Turbo)
		{
		}
		public Turbo(string productId, string name, string supplier, decimal price) : base(productId, name, supplier, price, ProductType.Turbo)
		{
		}
	}
	class BrakeSensor : Product
	{
		public BrakeSensor(string productId, string name, decimal price) : base(productId, name, price, ProductType.Sensor)
		{
		}

		public BrakeSensor(string productId, string name, string supplier, decimal price) : base(productId, name, supplier, price, ProductType.Sensor)
		{
		}
	}
	enum ProductType
	{
		Pump,
		Turbo,
		Sensor,
		EWP
	}
	enum Rotation
	{
		Angle0 = 0,
		Angle120 = 120
	}
	enum Voltage
	{
		Volt24 = 24,
		Volt12 = 12
	}
}

