using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
	class Solution
	{
		Log _logger;

		public Solution(Log logger)
		{
			_logger = logger;
		}

		void DoSomething()
		{
			// V nějakém bodě, chci zalogovat, že jsem dospěl až dotoho místa.
			_logger.LogInfo("Teď jsem v tomto bodě.");
			bool someCondition = SomeOtherFunction();
			if (someCondition)
			{
				// Tady zalogovat, že podmínka byla pravdivá a jsem tedy v tomto ifu.
				_logger.LogInfo("Teď jsem pro změnu v tomto bodě.");
			}
		}

		private bool SomeOtherFunction()
		{
			return false;
		}
	}

	class Log
	{
		public void LogInfo(string message)
		{
			// ...
		}

		public void LogWarning(string message)
		{
			// ...
		}

		public void LogError(string message)
		{
			// ...
		}
	}
}
