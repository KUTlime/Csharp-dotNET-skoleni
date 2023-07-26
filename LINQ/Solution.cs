namespace LINQ;

internal class Solution
{
    public void Demo()
    {
        var randomGen = new Random();
        var source = Enumerable
            .Range(1, 100)
            .Select(_ => randomGen.Next(1, 30))
            .ToList();

        var min = source.Min();
        var max = source.Max();
        var countOf24 = source.Count(n => n is 24);
        var doubleValues = source.Select(n => n * 2);
        var modus = source
            .GroupBy(a => a)
            .OrderBy(g => g.Count())
            .Last();
    }
}
