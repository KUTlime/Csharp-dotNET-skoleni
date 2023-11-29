using System.Collections;

namespace Interfaces;

class Solution
{
	static void Test()
	{
		var myArray = new MyArray(10);
		foreach (var item in myArray)
		{
			Console.WriteLine(item);
		}
	}
	class MyArray : IEnumerable<Int32>, IEnumerator
	{
		private int[] _array;
		private int position;

		public MyArray(Int32 numberOfItems)
		{
			_array = new Int32[numberOfItems];
			for (int i = 0; i < numberOfItems; i++)
			{
				_array[i] = i;
			}
		}

		public object Current => _array[position];

		public bool MoveNext()
		{
			position++;
			return (position < _array.Length);
		}

		public void Reset()
		{
			position = -1;
		}

		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			return this;
		}
	}
}

public class MyArray<TItem> : IEnumerable<TItem>
{
    TItem[] _array;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemCount"></param>
    /// <param name=""></param>
    public MyArray(int itemCount, params TItem[] args)
    {
        if (itemCount != args.Length)
        {
            throw new ArgumentException(nameof(itemCount), "Item count must match the number of inputed values.");
        }
        _array = new TItem[itemCount];
        for (int i = 0; i < itemCount; i++)
        {
            _array[i] = args[i];
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator<TItem> GetEnumerator() =>
        ((IEnumerable<TItem>)_array).GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _array.GetEnumerator();
}
