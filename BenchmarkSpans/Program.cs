using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<FunctionBenchmarks>();

[MemoryDiagnoser]
public class FunctionBenchmarks
{
    private string[] _data = [];

    // This runs once per benchmark run, before any measurements
    [GlobalSetup]
    public void Setup()
    {
        _data = new string[N];
        for (int i = 0; i < N; i++)
        {
            _data[i] = $"Item_{i}";
        }
    }

    // Optional: configure iterations, warmup, etc.
    [Params(100, 1000)]
    public int N;

    [Benchmark(Baseline = true)]
    public void Baseline()
    {
        PrintMembers(_data);
    }

    [Benchmark]
    public void WithSpans()
    {
        PrintMembersAsSpan(_data);
    }

    static void PrintMembers(string[] data)
    {
        for (int index = 0; index < data.Length; index++)
        {
            string item = data[index];
            if (item is "-t" or "--task" && index + 1 < data.Length && data[index + 1][0] != '-')
            {
                Console.WriteLine(item);
            }
        }
    }

    static void PrintMembersAsSpan(ReadOnlySpan<string> data)
    {
        int index = 0;
        foreach (ReadOnlySpan<char> unused in data)
        {
            PrintArgument(data, index);
            index++;
        }
    }

    static void PrintArgument(ReadOnlySpan<string> args, in int index)
    {
        if (index + 1 < args.Length && args[index + 1].AsSpan()[0] == '-')
        {
            Console.WriteLine(args[index + 1]);
        }
    }
}

