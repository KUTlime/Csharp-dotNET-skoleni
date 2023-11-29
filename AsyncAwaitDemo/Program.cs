var client = new HttpClient();

var result = await client.GetAsync("https://bbc.com");

var response = await result.Content.ReadAsStringAsync();

var logger = new FileLoggger("Test.txt");
await logger.WriteMethod(response);

public class FileLoggger 
{
    private readonly string _fileName;

    public FileLoggger(string fileName) => _fileName = fileName;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public async Task WriteMethod(string message)
    {
        await File.WriteAllTextAsync(_fileName, message, default);
    }

    private async Task<int> Demo() => 0;

    private async Task<(int, string)> Demo2() => (0, "Test");
}