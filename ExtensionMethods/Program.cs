using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
	/*
	#############################################################################
	### Metody rozšíření - extension methods
	#############################################################################
	
	Rozšíření zapečetěných tříd.

	Best Practice:
	- Umisťujemě do třídy s názvem <Název typu, který rozšiřujeme>Extensions.
	- Vhodné umístit do stejného jmeného prostoru jako třída, kterou rozšiřujeme.
	  Díky tomu přidáme třídu, která je rozšiřována i její metody rozšíření skrze jeden using.

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
	

	#############################################################################
	*/
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

namespace System
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