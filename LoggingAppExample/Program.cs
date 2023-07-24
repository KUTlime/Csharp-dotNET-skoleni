using Utils;

namespace LoggingAppExample
{
    class Program
	{
		static void Main(string[] args)
		{
			ILog dynamicLogger = new ConsoleLogger();
			string logType = args[0];
			switch (logType)
			{
				case "/t":
					dynamicLogger = new FileLogger();
					break;
				case "/c":
					dynamicLogger = new ConsoleLogger();
					break;
				default:
					dynamicLogger = new Log();
					break;
			}

			Log.WriteLine($"Hello world");
			Log.Write("Hello world");

			ILog logger = Log.LoggerStatic;

			logger.WriteLine("asdf");


			Console.ReadKey();
		}
	}

}
