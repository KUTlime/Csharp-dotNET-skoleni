namespace Utils
{
    public interface ILog
	{
		void WriteLine(string message);
		void Write(string message);
	}

	public class Log : ILog
	{
		public ILog Logger { get; set; } = new ConsoleLogger();
		public static ILog LoggerStatic { get; set; } = new ConsoleLogger();


		public static void WriteLine(string message)
		{
		}

		void ILog.Write(string message)
		{
			Logger.Write(message);
		}

		void ILog.WriteLine(string message)
		{
			Logger.WriteLine(message);
		}

		public static void Write(string message)
		{
			Console.Write($"[{DateTime.UtcNow}]: {message}");
		}
	}

	public class ConsoleLogger : ILog
	{
		public void WriteLine(string message)
		{
			Console.WriteLine($"[{DateTime.UtcNow}]: {message}");
		}

		public void Write(string message)
		{
			Console.Write($"[{DateTime.UtcNow}]: {message}");
		}
	}

	public class FileLogger : ILog
	{
		public void WriteLine(string message)
		{
			throw new NotImplementedException();
		}

		public void Write(string message)
		{
			throw new NotImplementedException();
		}
	}
}
