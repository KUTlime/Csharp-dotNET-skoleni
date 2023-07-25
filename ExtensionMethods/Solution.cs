using System.Diagnostics.CodeAnalysis;

namespace ExtensionMethods
{
    public static class Solution
	{
		public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, int chunkSize)
		{
			for (int i = 0; i < chunkSize && queue.Count > 0; i++)
			{
				yield return queue.Dequeue();
			}
		}
	}
}

namespace System
{
	public static class StringExtensions
	{
        public static bool IsValidValue([MaybeNull]this string? value) => string.IsNullOrWhiteSpace(value) is not true;

		public static bool IsValidPath([MaybeNull] this string? path) => File.Exists(path);
    }
}

