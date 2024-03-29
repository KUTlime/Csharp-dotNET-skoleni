﻿/*
#############################################################################
### Metody rozšíření - extension methods
#############################################################################

Rozšíření (zapečetěných) tříd.

Syntaxe:
namespace <Jmenný prostor rozšiřované třídy>
{
    public static class <Jméno rozšiřované třídy>Extensions
    {
        public static <Návratový typ> <Jméno metody>(this <Datový typ rozšiřované třídy> <Název instance rozšiřované třídy>[,...<Datový typ> <Jméno argumentu>])
        {
            ...
        }
    }
}

Best Practice:
- Umisťujeme do třídy s názvem <Název typu, který rozšiřujeme>Extensions.
- Vhodné umístit do stejného jmenného prostoru jako třída,
  kterou rozšiřujeme pokud chceme používat všude.
  Díky tomu přidáme třídu, která je rozšiřována i její metody rozšíření skrze jeden using.

#############################################################################
*/
namespace ExtensionMethods
{
    class ExtensionMethods
	{
		static void Main(string[] args)
		{
			var bytes = new Queue<Byte>();
			bytes.Enqueue(0);
			bytes.Enqueue(0);
			bytes.Enqueue(0);
			bytes.Enqueue(0);

			// Použití metody rozšíření
			List<byte> list = bytes.DequeueChunk(2).ToList();
			byte[] arr = bytes.DequeueChunk(2).ToArray();
		}
	}
}

namespace System.Collections.Generic
{
	public static class QueueExtensions
	{
		public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, Int32 chunkSize)
		{
			for (int i = 0; i < chunkSize && queue.Count > 0; i++)
			{
				// yield - počkej, dokud se neprovede celý for a teprve potom návrat.
				yield return queue.Dequeue();
			}
		}
	}
}