/*
 * Vytvořte konzolovou aplikaci, která vytiskne příchozí parametry z příkazové řádky
 * tak, aby nedocházelo ke zbytečným alokacím stringů.
 * Kdo chce, může si rozšířit logiku o další chování, např. o přepínače, tj.
 * aplikace udělá konkrétní přepínač, např. -t., vypíše hodnotu argumentu následující
 * za ním.
 * Vytiskněte vstupní argumenty pokud jste v Debug režimu.
 */

var spanArgs = args.AsSpan();
#if DEBUG
foreach (string arg in spanArgs)
{
    Console.WriteLine(arg);
}
#endif

int index = 0;
foreach (ReadOnlySpan<char> arg in spanArgs)
{
    _ = arg switch
    {
        "-t" or "--task" => PrintArgument(spanArgs, index),
        "-i" or "--index" => Task.CompletedTask,
        _ => Task.CompletedTask,
    };
    index++;
}

static Task PrintArgument(ReadOnlySpan<string> args, in int index)
{
    if (index + 1 < args.Length && args[index + 1].AsSpan()[0] != '-')
    {
        Console.WriteLine(args[index + 1]);
    }

    return Task.CompletedTask;
}
