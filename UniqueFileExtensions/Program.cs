args
    .Where(argument => Path.Exists(argument))
    .SelectMany(path => Directory.EnumerateFiles(path))
    .Select(filePath => new FileInfo(filePath).Extension)
    .Distinct()
    .ToList()
    .ForEach(extension => Console.WriteLine(extension));

/*
var extensions = new HashSet<string>();
foreach(var path in args)
{
    if(!Path.Exists(path)) continue;

    var files = Directory.EnumerateFiles(path);
    foreach (var file in files)
    {
        var extesionStart = file.LastIndexOf('.');
        var extension = file.Substring(extesionStart);
        if (extensions.Add(extension))
        {
            Console.WriteLine(extension);
        };
    }
}
*/