using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
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
}
