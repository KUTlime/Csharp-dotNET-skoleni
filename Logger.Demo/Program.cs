var loggers = new List<ILogger>
{
    new FileLoggger("Log.log"),
    new ConsoleLogger(),
};

loggers.ForEach(l =>
{
    l.Log(LogLevel.Information, "This is an information");
    l.Log(LogLevel.Warning, "This is a warning");
    l.Log(LogLevel.Error, "This is an error");
});


public enum LogLevel
{
    Error,
    Warning,
    Information,
}

public interface ILogger
{
    void Log(LogLevel severity, string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(LogLevel severity, string message)
    {
        ConsoleColor originalColorState = Console.ForegroundColor;
        Console.ForegroundColor = ResolveColorFrom(severity);
        WriteMessageToConsole(severity, message);
        Console.ForegroundColor = originalColorState;
    }

    private void WriteMessageToConsole(LogLevel severity, string message) =>
        Console.WriteLine($"[{DateTime.UtcNow}] [{severity}] {message}");

    private ConsoleColor ResolveColorFrom(LogLevel severity) => severity switch
    {
        LogLevel.Information => ConsoleColor.Green,
        LogLevel.Warning => ConsoleColor.Yellow,
        LogLevel.Error => ConsoleColor.Red,
        _ => ConsoleColor.White,
    };
}

public class FileLoggger : ILogger
{
    private string _fileName;

    public FileLoggger(string fileName) => _fileName = fileName;

    public void Log(LogLevel severity, string message) => 
        File.AppendAllText(_fileName, GetMessage(severity, message));

    private string GetMessage(LogLevel severity, string message) =>
        $"[{DateTime.UtcNow}] [{severity}] {message}\n";
}

