using System.Collections;

var test = new MyIterator<string>();

test[2] = "3";
test[3] = "4";

Console.WriteLine(test[3]);

foreach (string item in test)
{
    Console.WriteLine(item);
}

test.Where(x => x is not null).ToList().ForEach(Console.WriteLine);

class MyIterator<T> : IEnumerator<T>, IEnumerable<T>
{
    private int _currentIndex = -1;

    private bool _disposed;

    private T? _firstValue;

    private T? _secondValue;

    private T? _thirdValue;

    private T? _fourthValue;

    private T? _fifthValue;

    private T? _sixthValue;

    public T? this[int index]
    {
        get => index switch
        {
            0 => _firstValue,
            1 => _secondValue,
            2 => _thirdValue,
            3 => _fourthValue,
            4 => _fifthValue,
            5 => _sixthValue,
            _ => throw new ArgumentOutOfRangeException(),
        };

        set => _ = index switch
        {
            0 => _firstValue = value,
            1 => _secondValue = value,
            2 => _thirdValue = value,
            3 => _fourthValue = value,
            4 => _fifthValue = value,
            5 => _sixthValue = value,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public T Current => this[_currentIndex] ?? throw new ArgumentNullException();

    object IEnumerator.Current => Current ?? throw new ArgumentNullException();

    public bool MoveNext()
    {
        _currentIndex++;
        if (_currentIndex < 6)
        {
            return this[_currentIndex] is not null || MoveNext();
        }
        Reset();
        return false;
    }

    public void Reset() => _currentIndex = -1;

    public void Dispose()
    {
        if (this is IDisposable disposable && !_disposed)
        {
            _disposed = true;
            disposable.Dispose();
        }
        if (typeof(IDisposable).IsAssignableFrom(typeof(T)))
        {
            // T implementuje IDisposable
            (_firstValue as IDisposable)?.Dispose();
            (_secondValue as IDisposable)?.Dispose();
            (_thirdValue as IDisposable)?.Dispose();
            (_fourthValue as IDisposable)?.Dispose();
            (_fifthValue as IDisposable)?.Dispose();
            (_sixthValue as IDisposable)?.Dispose();
        }
    }

    public IEnumerator<T> GetEnumerator() => this;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
