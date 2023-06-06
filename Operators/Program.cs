using System;

namespace Operators
{
	class Operators
    {
        /*
        #############################################################################
        ### Typy operátorů
        #############################################################################
        Podle typu operace:
        - Arithmetické
        - Relační
        - Logické
        - Bitové (operující na bity)
        - Přiřazovací
        - Různé

        a + b | + označuje operátor, {a,b} jsou operandy a celé to označujeme za operaci.

        Podle počtu operandů:
        - Unární    (1 operand)
        - Binární   (2 operandy)
        - Ternární  (3 operandy)
        #############################################################################
        */

        static void Main(string[] args)
        {
        }

        static void ArithmeticOperators()
        {
            int a = 21;
            int b = 10;
            int c;

            // Binární aritmetické operátory
            c = a + b;
            Console.WriteLine("Line 1 - Value of c is {0}", c);

            c = a - b;
            Console.WriteLine("Line 2 - Value of c is {0}", c);

            c = a * b;
            Console.WriteLine("Line 3 - Value of c is {0}", c);

            c = a / b;
            Console.WriteLine("Line 4 - Value of c is {0}", c);

            c = a % b; // Modulo operace, zbytek po celočíselném dělení
            Console.WriteLine("Line 5 - Value of c is {0}", c);

            // Unární aritmetické operátory

            // Odstranění syntaktického cukru a = a + 1 => ++a

            // Postfixová varianta - nejprve se uloží hodnota a do c,
            // pak se a zvyšší o 1.
            c = a++;  // Ekvivalent: c = a; a = a + 1
            Console.WriteLine("Line 6 - Value of c is {0}, a: {1}", c, a);

            // Postfixová varianta - nejprve se uloží hodnota a do c,
            // pak se a sníží o 1.
            c = a--; // Ekvivalent: c = a; a = a - 1
            Console.WriteLine("Line 7 - Value of c is {0}, a: {1}", c, a);

            // Prefixová varianta - nejprve se zvyšší a o 1, výsledek se 
            // uloží do c.
            c = ++a; // Ekvivalent: a = a + 1; c = a;
            Console.WriteLine("Line 6 - Value of c is {0}, a: {1}", c, a);

            // Prefixová varianta - nejprve se sníží a o 1, výsledek se 
            // uloží do c.
            c = --a;
            Console.WriteLine("Line 7 - Value of c is {0}, a: {1}", c, a);

            // ++++a; // Nelze.

            // Prefixová varianta:
            // a = a + 1;
            // c = a;
            // c = ++a;

            // Postfixová varianta:
            // c = a;
            // a = a + 1;
            // c = a++;
        }

        static void RelationOperators()
        {
            int a = 21;
            int b = 10;

            // Porovnání dvou objektů na rovnost
            if (a == b)
            {
                Console.WriteLine("Line 1 - a is equal to b");
            }
            else
            {
                Console.WriteLine("Line 1 - a is not equal to b");
            }

            // Menší než
            if (a < b)
            {
                Console.WriteLine("Line 2 - a is less than b");
            }
            else
            {
                Console.WriteLine("Line 2 - a is not less than b");
            }

            // Větší než
            if (a > b)
            {
                Console.WriteLine("Line 3 - a is greater than b");
            }
            else
            {
                Console.WriteLine("Line 3 - a is not greater than b");
            }

            /* Prohodíme a a b */
            a = 5;
            b = 20;

            // Menší nebo rovno
            if (a <= b)
            {
                Console.WriteLine("Line 4 - a is either less than or equal to  b");
            }

            // Větší nebo rovno
            if (b >= a)
            {
                Console.WriteLine("Line 5-b is either greater than or equal to b");
            }

            // Nerovná se
            if (a != b)
            {
                Console.WriteLine("a is not equal to b");
            }
        }

        static void LogicalOperators()
        {
            bool a = true;
            bool b = true;

            // Logické A (AND)
            if (a && b)
            {
                Console.WriteLine("Line 1 - Condition is true");
            }

            // Logické NEBO (OR)
            if (a || b)
            {
                Console.WriteLine("Line 2 - Condition is true");
            }

            /* lets change the value of  a and b */
            a = false;
            b = true;

            if (a && b)
            {
                Console.WriteLine("Line 3 - Condition is true");
            }
            else
            {
                Console.WriteLine("Line 3 - Condition is not true");
            }

            if (!(a && b))
            {
                Console.WriteLine("Line 4 - Condition is true");
            }
        }

        static void BitwiseOperators()
        {
            int a = 60;            /* 60 = 0011 1100 */
            int b = 13;            /* 13 = 0000 1101 */
            int c = 0;

            // Bitové A (AND)
            c = a & b;             /* 12 = 0000 1100 */
            Console.WriteLine("Line 1 - Value of c is {0}, binary: {1}", c, Convert.ToString(c, 2));

            // Bitové NEBO (OR)
            c = a | b;             /* 61 = 0011 1101 */
            Console.WriteLine("Line 2 - Value of c is {0}, binary: {1}", c, Convert.ToString(c, 2));

            // Bitové exkluzivní NEBO (XOR)
            c = a ^ b;             /* 49 = 0011 0001 */
            Console.WriteLine("Line 3 - Value of c is {0}, binary: {1}", c, Convert.ToString(c, 2));

            // Bitový doplněk
            c = ~a;                /*-61 = 1100 0011 */
            Console.WriteLine("Line 4 - Value of c is {0}, binary: {1}", c, Convert.ToString(c, 2));

            // Levý bitový posun
            c = a << 2;      /* 240 = 1111 0000 */
            Console.WriteLine("Line 5 - Value of c is {0}, binary: {1}", c, Convert.ToString(c, 2));

            // Pravý bitový posun
            c = a >> 2;      /* 15 = 0000 1111 */
            Console.WriteLine("Line 6 - Value of c is {0}, binary: {1}", c, Convert.ToString(c, 2));
        }

        static void AssignmentOperators()
        {
            int a = 21;
            int c;
            c = a; // jednoduché přiřazení

            var d = a; // automatické přiřazení datového typu (není to dobrá praxe pro hodnotové datové typy).
            Int32 e = a; // Lepší varianta.

            Console.WriteLine("Line 1 - =  Value of c = {0}", c);

            c += a; // c = c + a;
            Console.WriteLine("Line 2 - += Value of c = {0}", c);

            c -= a; // c = c - a;
            Console.WriteLine("Line 3 - -=  Value of c = {0}", c);

            c *= a; // c = c * a;
            Console.WriteLine("Line 4 - *=  Value of c = {0}", c);

            c /= a; // c = c / a;
            Console.WriteLine("Line 5 - /=  Value of c = {0}", c);

            c = 200;
            c %= a; // c = c % a;
            Console.WriteLine("Line 6 - %=  Value of c = {0}", c);

            c <<= 2; // c = c << 2;
            Console.WriteLine("Line 7 - <<=  Value of c = {0}", c);

            c >>= 2; // c = c >> 2;
            Console.WriteLine("Line 8 - >>=  Value of c = {0}", c);

            c &= 2; // c = c & 2;
            Console.WriteLine("Line 9 - &=  Value of c = {0}", c);

            c ^= 2; // c = c ^ 2;
            Console.WriteLine("Line 10 - ^=  Value of c = {0}", c);

            c |= 2; // c = c | 2;
            Console.WriteLine("Line 11 - |=  Value of c = {0}", c);
        }

        // Operátory ostatní
        static unsafe void MiscellaneousOperators()
        {
            // Sizeof - zjištění velikosti
            Console.WriteLine("The size of int is {0}", sizeof(Int32));
            Console.WriteLine("The size of short is {0}", sizeof(short));
            Console.WriteLine("The size of double is {0}", sizeof(double));

            // Zjištění typu
            Console.WriteLine("The type of double is {0}", typeof(double));

            // Příklad použití ternálního operátoru (3 operandy):
            Int32 a, b;
            a = 10;
            b = (a == 1) ? 20 : 30;
            Console.WriteLine("Value of b is {0}", b);

            b = (a == 10) ? 20 : 30;
            Console.WriteLine("Value of b is {0}", b);

            // Test datového typu
            if (a is Int32 number)
            {
                Console.WriteLine("a is an 32-bit long integer with value: {0}", number);
            }

            // Operátor new - vytvoření nové instance třídy
            Derived d = new Derived();

            // Operátor as - bezpečné přetypování na daný datový typ
            Base e = d as Base;
            if (e is not null)
            {
                Console.WriteLine(b.ToString());
            }

            int* pointer = &a;

            // ?? Operátor propagace nullu
            // V překladu do srozumitelné češtiny to znamená
            // že pokud je vlevo null, použij to, co je v pravo.
            // ?. podmíněný přístup, pokud je něco null, vrať null a funkci nevolej.
            //    pokud není null, zavolej funkci a vrať návratovou hodnotu.
            int? test = null;
            Console.WriteLine(test?.ToString() ?? "It was null");

            // ??= Opetorátor potlačení nullu
            // Pokud je v proměnné test null, přepiš null hodnotou 42.
            test ??= 42;

            string str = "RadekZahradník";
            var R = str[0];
            var Z = str?[5];
            var k = str[str.Length - 1];
            var k1 = str[^1];
            var adekZ = str[1..5];
        }

        /*
        Category 	    Operator 	                        Associativity
        Postfix 	    () [] -> . ++ -- 	                Left to right
        Unary 	        + - ! ~ ++ -- (type)* & sizeof 	    Right to left
        Multiplicative 	* / % 	                            Left to right
        Additive 	    + - 	                            Left to right
        Shift 	        << >> 	                            Left to right
        Relational 	    < <= > >= 	                        Left to right
        Equality 	    == != 	                            Left to right
        Bitwise AND 	& 	                                Left to right
        Bitwise XOR 	^ 	                                Left to right
        Bitwise OR 	    | 	                                Left to right
        Logical AND 	&& 	                                Left to right
        Logical OR 	    || 	                                Left to right
        Conditional 	?: 	                                Right to left
        Assignment 	    = += -= *= /= %=>>= <<= &= ^= |= 	Right to left
        Comma 	        , 	                                Left to right
        */

        static void OperatorsPrecedense()
        {
            int a = 20;
            int b = 10;
            int c = 15;
            int d = 5;
            int e;
            e = (a + b) * c / d;     // ( 30 * 15 ) / 5
            Console.WriteLine("Value of (a + b) * c / d is : {0}", e);

            e = ((a + b) * c) / d;   // (30 * 15 ) / 5
            Console.WriteLine("Value of ((a + b) * c) / d is  : {0}", e);

            e = (a + b) * (c / d);   // (30) * (15/5) {0}", e);

            e = a + (b * c) / d;    //  20 + (150/5) {0}", e);
        }
    }



    class Base
    {
        public override string ToString()
        {
            return "Base";
        }
    }
    class Derived : Base
    { }
}


