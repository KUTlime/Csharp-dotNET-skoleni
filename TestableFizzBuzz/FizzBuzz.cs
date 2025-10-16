using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks;

namespace TestableFizzBuzz;

[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
public class FizzBuzz
{
    private readonly Consumer consumer = new Consumer();

    public IEnumerable<string> FunctionalImplementation()
        => Enumerable
            .Range(1, 1_000_000)
            .Select(i => i switch
            {
                _ when i % 5 == 0 && i % 3 == 0 => "FizzBuzz",
                _ when i % 3 == 0 => "Fizz",
                _ when i % 5 == 0 => "Buzz",
                _ => i.ToString(),
            });

    public IEnumerable<string> FunctionalImplementationParallel()
        => Enumerable
           .Range(1, 1_000_000)
           .AsParallel()
           .Select(i => i switch
           {
               _ when i % 5 == 0 && i % 3 == 0 => "FizzBuzz",
               _ when i % 3 == 0 => "Fizz",
               _ when i % 5 == 0 => "Buzz",
               _ => i.ToString(),
           });

    [Benchmark(Baseline = true)]
    public void ConsumeFunctionalImplementation()
        => FunctionalImplementation().Consume(consumer);

    [Benchmark]
    public void ConsumeFunctionalImplementationParallel()
        => FunctionalImplementationParallel().Consume(consumer);

    public IEnumerable<string> ListForImplementation()
    {
        var list = new List<string>();
        for (var i = 1;  i <= 1_000_000; i++)
        {
            if(i % 3 == 0 && i % 5 == 0)
            {
                list.Add("FizzBuzz");
                continue;
            }
            if (i % 3 == 0)
            {
                list.Add("Fizz");
                continue;
            }
            if (i % 5 == 0)
            {
                list.Add("Buzz");
                continue;
            }
            list.Add(i.ToString());
        }
        return list;
    }

    [Benchmark]
    public void ConsumeListForImplementation()
        => ListForImplementation().Consume(consumer);


    public IEnumerable<string> ArrayForImplementation()
    {
        var array = new string[1_000_000];
        for (var i = 1; i <= 1_000_000; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                array[i-1] = "FizzBuzz";
                continue;
            }
            if (i % 3 == 0)
            {
                array[i-1] = "Fizz";
                continue;
            }
            if (i % 5 == 0)
            {
                array[i-1] = "Buzz";
                continue;
            }
            array[i-1] = i.ToString();
        }
        return array;
    }

    [Benchmark]
    public void ConsumeArrayForImplementation()
        => ArrayForImplementation().Consume(consumer);

    public IEnumerable<string> ListWithPlacesForImplementation()
    {
        var list = new List<string>( 1_000_000);
        for (var i = 1; i <=  1_000_000; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                list.Add("FizzBuzz");
                continue;
            }
            if (i % 3 == 0)
            {
                list.Add("Fizz");
                continue;
            }
            if (i % 5 == 0)
            {
                list.Add("Buzz");
                continue;
            }
            list.Add(i.ToString());
        }
        return list;
    }

    [Benchmark]
    public void ConsumeListWithPlacesForImplementation()
        => ListWithPlacesForImplementation().Consume(consumer);

    public IEnumerable<string> YieldForImplementation()
    {
        for (var i = 1; i <=  1_000_000; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                yield return "FizzBuzz";
                continue;
            }
            if (i % 3 == 0)
            {
                yield return "Fizz";
                continue;
            }
            if (i % 5 == 0)
            {
                yield return "Buzz";
                continue;
            }
            yield return i.ToString();
        }
    }

    [Benchmark]
    public void ConsumeYieldForImplementation()
        => YieldForImplementation().Consume(consumer);
}
