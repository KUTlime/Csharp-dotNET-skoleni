namespace Tuples
{
    public class Task
    {
        /*
     * 1. Upravte program z předchozí kapitoly, tj. třídu zaměstnanec, tak aby, se byla
     *    schopna rozdělit na odpovídají tuply:
     *    (UInt64, string, string, DateTime)
     *    (string, string, DateTime).
     *    Dekonstrukci tuplu vyzkoušejte v main metodě při volání Vaší třídy.
     *
     * 2. Napište metodu, která bude ze vstupního pole double počítat statistiku, konkrétně
     *    - aritmetický průměr
     *    - směrodatnou odchylku
     *    - rozptyl
     *    a tato data bude vracet formou tuplu (double, double, double)
     *    Napište si Unit testy pro tuto funkci.
     *
     * 3. Napište metodu rozšíření pro Vaši třídu Person, která vyrobí tuple, kde se předají hodnoty:
     *    - Jméno
     *    - Příjmení
     *    - Datum narození
     *    a použijte tuto metodu v nějakém testovacím kódu, či programu.
     */
        public static (double Average, double Deviation, double Variance) GetStatistics(IEnumerable<double> values)
        {
            var listOfValues = values.ToList();
            if(listOfValues.Count is 0)
            {
                return (0, 0, 0);
            }
            double average = values.Average();
            double variance = 0;
            int count = 0;
            foreach (var item in values)
            {
                variance += Math.Pow(item - average, 2);
                count++;
            }
            variance /= count;
            double deviation = 0;
            deviation = Math.Sqrt(variance);
            return (average, deviation, variance);
        }
	}
}