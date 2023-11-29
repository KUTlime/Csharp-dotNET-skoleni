// https://anthonygiretti.com/wp-content/uploads/2022/09/linq-768x762.png

/*
 * Co je nutné vědět o IEnumerable<T>
 * - Je to odložené vyhodnocení.
 * - Vyhodnocujeme zásadně jenom jednou.
 * - Pokud bychom volali vícekrát nějakou LINQ metodu nad IEnumerable<T>,
 *   můžeme dostat různé výsledky.
 *   Proto nejprve materializujeme, ať pracujeme s fixní kolekcí objektů.
 */

var actors = new List<Person>
{
    new Person("Radek", "Zahradník", DateTime.UtcNow, false),
    new Person("John", "Wick", DateTime.UtcNow.AddYears(-10), false),
    new Person("John", "Wick", DateTime.UtcNow.AddYears(-40), true),
    new Person("Arnold", "Schwarzenegger", DateTime.UtcNow.AddYears(-20), true),
    new Person("Sylvester", "Stallone", DateTime.UtcNow.AddYears(-22), true),
};

var actresses = new List<Person>
{
    new Person("Angelina", "Jolie", DateTime.UtcNow.AddYears(-10), false),
    new Person("Marilyn", "Monroe", DateTime.UtcNow.AddYears(-80), false),
    new Person("Emily", "Blunt", DateTime.UtcNow.AddYears(-15), true),
    new Person("Maryl", "Streep", DateTime.UtcNow.AddYears(-75), true),
    new Person("Jane", "Wick", DateTime.UtcNow.AddYears(-39), true),
};

var wholeCast = new[] { actors, actresses };
var results = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
var resultsWithNull = new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, null };
var stringsToTest = new string[] { "Radek", "Zahradník", "R_a_d_ek" };

int[] zipTo1 = { 1, 2, 3, 4, 5 };
string[] zipTo2 = { "One", "Two", "Three", "Four" };

// Transformace 
actors
    .Select(p => p.LastName)        /* transformace */
    .ToList()                       /* materializace */
    .ForEach(Console.WriteLine);    /* použití */

wholeCast
    .SelectMany(c => c.Select(p => p.LastName))
    .ToList()
    .ForEach(Console.WriteLine);

actors
    .Select(p => (p.FirstName, p.IsMarried))
    .Select(t => t.IsMarried ? $"{t.FirstName} is married" : $"{t.FirstName} is not married")
    .ToList()
    .ForEach(Console.WriteLine);

// Agregace
int max = results.Max();
int min = results.Min();
int count = results.Count();
int sum = results.Sum();
double average = results.Average();
var numberOfOdds = results.Count(n => n % 2 is not 0);

Console.WriteLine($"Count for not null values: {results.Count()}");
Console.WriteLine($"Count with null values: {resultsWithNull.Count()}");
Console.WriteLine($"Average for not null values: {results.Average()}");
Console.WriteLine($"Average with null values: {resultsWithNull.Average()}");

// Filtrace a práce s elementy
actors
    .Where(a => a.IsMarried)
    .ToList()
    .ForEach(Console.WriteLine);

wholeCast
    .SelectMany(c => c.Where(a => a.IsMarried))
    .ToList()
    .ForEach(Console.WriteLine);

var theYoungestSingleActress = actresses
    .Where(a => a.IsMarried == false)
    .OrderBy(a => a.BirthDate)
    .Last();

var theYoungestSingleActress2 = actresses
    .Where(a => a.IsMarried == false)
    .OrderByDescending(a => a.BirthDate)
    .First();

var invalidStrings = stringsToTest.Where(a =>
{
    if (a.Contains('_')) return true;
    if (a.Contains('*')) return true;
    if (a.Contains(':')) return true;
    return false;
});

Console.WriteLine("Distinct By LastName");
actors
    .DistinctBy(a => a.LastName)
    .ToList()
    .ForEach(Console.WriteLine);

// Sets
actors
    .Where(a => a.IsMarried)
    .Union(actresses.Where(a => a.IsMarried))
    .ToList()
    .ForEach(Console.WriteLine);

actors
    .Where(a => a.IsMarried)
    .UnionBy(actresses.Where(a => a.IsMarried), a => a.LastName)
    .ToList()
    .ForEach(Console.WriteLine);

actors.IntersectBy(new[] { "Arnold", "Karel" }, a => a.FirstName);

actors
    .Where(a => a.IsMarried)
    .IntersectBy(
        actresses
            .Where(a => a.IsMarried)
            .Select(a => a.LastName),
        a => a.LastName)
    .ToList()
    .ForEach(Console.WriteLine);

var cast = actors.Union(actresses);

// Kvantifikace
var anyEventNumber = results.Any(n => n % 2 is not 0);
var isAllEvent = results.All(n => n % 2 is not 0);
var hasZero = results.Contains(0);
var hasInvalidString = stringsToTest.Any(s => s.Contains('_'));

// Seskupování
wholeCast
    .SelectMany(a => a.Select(a => a))  /* tzn. flattening - zploštění několika kolekcí na 1 kolekci téhož typu */
    .GroupBy(a => a.IsMarried)
    .ToList()
    .ForEach(g => Console.WriteLine($"The group where Marrided = {g.Key} has count = {g.Count()}"));

wholeCast
    .SelectMany(a => a.Select(a => a))  /* tzn. flattening - zploštění několika kolekcí na 1 kolekci téhož typu */
    .GroupBy(a => a.BirthDate)
    .ToList()
    .ForEach(g => Console.WriteLine($"The group where Birth date = {g.Key} has count = {g.Count()}"));

wholeCast
    .SelectMany(persons => persons.Select(person => person))  /* tzn. flattening - zploštění několika kolekcí na 1 kolekci téhož typu */
    .GroupBy(person => new { person.LastName, person.FirstName })
    .ToList()
    .ForEach(group => Console.WriteLine($"The group where ??? date = {group.Key} has count = {group.Count()}"));

// Sloučení
Console.WriteLine("Join by LastName");
actors
    .Join(
        actresses,
        actress => actress.LastName,
        actor => actor.LastName,
        (actor, actress) => new 
        { 
            LastName = actor.LastName,
            ActorFirstName = actor.FirstName,
            ActressFirstName = actress.FirstName 
        })
    .ToList()
    .ForEach(c => Console.WriteLine($"We have marrige couple with the last name {c.LastName} and names {c.ActorFirstName} & {c.ActressFirstName}"))
    ;

Console.WriteLine("Zip two collections");
zipTo1
    .Zip(zipTo2)
    .ToList()
    .ForEach(t => Console.WriteLine($"We have {t.First} for {t.Second}"));

// Materializace
zipTo1
    .Zip(zipTo2)
    .ToDictionary(key => key.First, value => value.Second)
    .Select(kvp => $"{kvp.Key} = {kvp.Value}")
    .ToList()
    .ForEach(Console.WriteLine);


record Person(string FirstName, string LastName, DateTime BirthDate, bool IsMarried);
