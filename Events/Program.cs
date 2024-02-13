var foo = new FooForEvents();

// Subscriber One
foo.SampleEvent += (sender, args) =>
{
    if(sender is FooForEvents)
    {
        Console.WriteLine($"[{args.TimeStamp}] Event happend, message: {args.Message}");
        args.Message = "Altered message";
        return;
    }
    Console.WriteLine("Some unexpected sender raised the event.");
};

// Subscriber 2
foo.SampleEvent += (sender, args) =>
{
    if (sender is FooForEvents)
    {
        FooBarHandler.Handle(args);
    }
};

foo.TriggerEvent("Hello Radek");

var foo2 = new FooForEventsWithImmutableEventArgs();

// Subscriber One
foo2.SampleEvent += (sender, args) =>
{
    if (sender is FooForEventsWithImmutableEventArgs)
    {
        Console.WriteLine($"[{args.TimeStamp}] Event happend 2, message: {args.Message}");
        args = args with { Message = "Altered message" };
        return;
    }
    Console.WriteLine("Some unexpected sender raised the event.");
};

foo2.SampleEvent += (sender, args) =>
{
    if (sender is FooForEventsWithImmutableEventArgs)
    {
        Console.WriteLine($"[{args.TimeStamp}] Event happend 2, message: {args.Message}");
        return;
    }
    Console.WriteLine("Some unexpected sender raised the event.");
};

foo2.TriggerEvent("Hello Radek");

class FooForEvents
{
    public event EventHandler<SampleEventArgs>? SampleEvent;

    public FooForEvents()
    {
    }
    internal void TriggerEvent(string message)
    {
        var sampleEvent = SampleEvent;
        sampleEvent?.Invoke(this, new(message, DateTime.UtcNow));
    }
}

class SampleEventArgs(string message, DateTime timeStamp) : EventArgs
{
    public string Message { get; set; } = message;
    public DateTime TimeStamp { get; } = timeStamp;
};

class FooBarHandler
{
    public static void Handle(SampleEventArgs args)
    {
        Console.WriteLine($"[{args.TimeStamp}] Message recieved: {args.Message}");
    }
}

// Better practice alá Radek

/// <summary>
/// Immutable ancestor class for all immutable event args.
/// </summary>
public record EventRecordArgs()
{
    public static EventRecordArgs Empty = new EventRecordArgs();
}

record SampleImmutableEventArgs(string Message, DateTime TimeStamp);

class FooForEventsWithImmutableEventArgs
{
    public event EventHandler<SampleImmutableEventArgs>? SampleEvent;

    internal void TriggerEvent(string message)
    {
        var sampleEvent = SampleEvent;
        sampleEvent?.Invoke(this, new(message, DateTime.UtcNow));
    }
}