string sentence = "asd fas 0 1 asdf asdf asdf asdf";
Console.WriteLine(CountWords(sentence));

string[] words = ["Ahoj", "Světe", "Hello", "Word"];

var span = words[1..3].AsSpan();
Console.WriteLine($"Same memory? {ReferenceEquals(span[0], words[1])}");

span[0] = "Test"; // New memory is allocated for this

Console.WriteLine(words[0]);
Console.WriteLine(words[1]);
Console.WriteLine(words[2]);
Console.WriteLine(words[3]);

Console.WriteLine(span.Length);
Console.WriteLine(span[0]);
Console.WriteLine(span[1]);

Console.WriteLine($"Same memory? {ReferenceEquals(span[0], words[1])}");
Console.WriteLine($"Same memory? {ReferenceEquals(span[1], words[2])}");

var readOnlySpan = new ReadOnlySpan<string>(words);
// readOnlySpan[0] = "Test";

uint CountWords(string? word) => word switch
{
    { } str => str switch
    {
        { Length: 0 } => 0,
        _ => CountWordBeginning(str),
    },
    _ => 0,
};

uint Something(string number) => number switch
{
    "first" => 1,
    "second" => 2,
    _ => 0,
};

static uint CountWordBeginning(ReadOnlySpan<char> sentence)
{
    uint numberOfWords = 0;
    bool notInWord = true;
    foreach (var character in sentence)
    {
        if(char.IsLetterOrDigit(character))
        {
            if (notInWord)
            {
                numberOfWords++;
                notInWord = false;
                continue;
            }
            continue;
        }
        notInWord = true;
    }
    return numberOfWords;
}
