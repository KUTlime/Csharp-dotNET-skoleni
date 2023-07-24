namespace Strings
{
    class BestPractice
	{
		/*
         #############################################################################
         ### Co nedělat
         #############################################################################
         - Nepoužívat přetížení porovnání stringů (String.Compare) bez explicitních/implicitních pravidel porovnání.
         - Nepoužívejte StringComparison.InvariantCulture obecně při práci se stringy.
         - Netestujte návratovou hodnotu String.Compare nebo CompareTo na 0 jako test shodnosti stringů.
         - Neukládejte data podléhající národnostnímu formátování ve stringu. 
         #############################################################################

         #############################################################################
         ### Co dělat
         #############################################################################
         - Používejte přetížené String.Equals pro testy shodnosti.
         - Používejte String.Compare nebo CompareTo pro třídění stringů dohromady s enumem pro definici typu porovnání.
         - Používejte kulturně invariantní zobrazení dat pro string podobu dat, která nejsou stringy.
         - Používejte String.ToUpperInvariant pro normalizaci stringu kvůli porovnání, rychlejší než String.ToLowerInvariant.
         - Používejte nelingvistické StringComparison.Ordinal nebo StringComparison.OrdinalIgnoreCase hodnoty pro lepší výkon nebo místo operací založených na CultureInfo.InvariantCulture při porovnávání lingvisticky invariantních dat.
         #############################################################################
         */

		static void AvoidDefault()
		{
			//Místo tohoto
			string url = "http://radekzahradnik.cz";
			string protocol = GetProtocol(url);
			if (String.Equals(protocol, "http"))
			{
				// Kód pro http protokol.
			}
			else
			{
				throw new InvalidOperationException();
			}
			// Toto
			if (String.Equals(protocol, "http", StringComparison.OrdinalIgnoreCase))
			{
				// ...Code to handle HTTP protocol.
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		static void Performance()
		{
			string strA = "asdfasdf";
			string strB = "ASDFASDF";
			String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase); // Rychlejší varianta než následující řádek.
			String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(), StringComparison.Ordinal); // Rychlejší varianta než následující řádek.
			String.Compare(strA.ToLowerInvariant(), strB.ToLowerInvariant(), StringComparison.Ordinal);
		}

		private static string GetProtocol(object url)
		{
			throw new NotImplementedException();
		}
	}
}