namespace Arrays
{
    // 1. Napište metodu, pro generování prvočísel od 0 do horní závory včetně, která bude vstupem funkce.
    //    Funkce tyto prvočísla vrátí jako pole - návratová hodnota.
    //    public int[] GetPrimeNumbers(int upperBound) { ... }
    //    Pro vstup upperBound = 10, funkce musí vrátit: 2, 3, 5, 7,
    //    Pro vstup upperBound = 20, funkce musí vrátit: 2, 3, 5, 7, 11, 13, 17, 19
    // 2. Napište metodu, která pro zadané číslo zkusí najít všechny kombinace prvočíselných dělitelů.
    //    Funkce vrátí 2D pole dělitelů.
    // 3. Vytvořte si nový projekt a ve funkci Main vypište všechny vstupní parametry, tj. projděte vstupní pole.
    //    Zkuste si také zavolat s parametry. Pro volání buď použijte CMD nebo nastavení projektu -> Debug
    //    -> CommandLine Arguments 
    // 4. Obohaťte svou aplikaci z 3. o tok programu, který bude reagovat na argumenty předané z příkazové 
    //    řádky.
    // 5. Najděte singleton v poli číselných dvojic. Vytvořte si neuspořádané pole dvojic čísel a jedno číslo
    //    v něm nechte pouze jednou. Napište funkci, která najte a vrátí tuto položku v poli.
    // 6. Napište funkci, která vypíše unikátní hodnoty ze vstupního pole čísel.
    class Task
	{
        static void TaskFive()
		{
			Int32[] array = { 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6 }; // Tady je 4 jako jedináček
			Int32[] array2 = { 1,2,3,4,5,6,1,2,4,5,6 };			// Tady je 3 jako jedináček.
		}
	}
}
