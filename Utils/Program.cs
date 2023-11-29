namespace Utils;

public interface ILogger
{
	void WriteLine(string message);
	void Write(string message);
}

public class Log : ILogger
{
	public ILogger Logger { get; set; } = new ConsoleLogger();
	public static ILogger LoggerStatic { get; set; } = new ConsoleLogger();


	public static void WriteLine(string message)
	{
	}

	void ILogger.Write(string message)
	{
		Logger.Write(message);
	}

	void ILogger.WriteLine(string message)
	{
		Logger.WriteLine(message);
	}

	public static void Write(string message)
	{
		Console.Write($"[{DateTime.UtcNow}]: {message}");
	}
}

public class ConsoleLogger : ILogger
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

public class FileLogger : ILogger
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
