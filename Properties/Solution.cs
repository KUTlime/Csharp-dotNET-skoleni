using System;
using System.Collections.Generic;
using System.Text;

namespace Properties
{
	class Solution
	{
		static void PrintCatalogue(List<IPump> listOfPump)
		{
			foreach (var pump in listOfPump)
			{
				Console.WriteLine($"Pump type: {pump.Type}, fuel: {pump.Fuel}, output: {pump.Output}");
			}

		}
	}
	internal interface IPump
	{
		string Type { get; set; }
		string Fuel { get; set; }
		double Output { get; set; }
	}
	class Pump : IPump
	{
		public string Type { get; set; }
		public string Fuel { get; set; }
		public double Output { get; set; }
	}
}
