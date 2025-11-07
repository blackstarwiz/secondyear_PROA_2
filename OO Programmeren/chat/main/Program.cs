using System.Diagnostics.CodeAnalysis;

namespace main
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            equals tasks = new equals();

            tasks.TaskOne();
            Console.WriteLine("Task 1");
            Console.WriteLine(tasks.ToString());
            Console.WriteLine();

            Console.WriteLine("Task 2");
            var klant1 = new Klant(1001, "Jan");
            var klant2 = new Klant(1001, "Piet");
            var klant3 = new Klant(1002, "Jan");

            var lijst = new List<Klant> { klant1 };
            Console.WriteLine(lijst.Contains(klant2)); // → True
            Console.WriteLine(lijst.Contains(klant3)); // → False

            Console.WriteLine();
            Console.WriteLine("Tasks 3");

            Console.WriteLine();
            Console.WriteLine("Fraction");
            Console.WriteLine();
            var f = new Fraction(1, 2);
            Console.WriteLine($"{f.Numerator}/{f.Denominator}");

            Console.WriteLine("GCD Greatest Common Divisor");

            Console.WriteLine(Fraction.GCD(48, 18));  // 6
            Console.WriteLine(Fraction.GCD(7, 3));    // 1
            Console.WriteLine(Fraction.GCD(-8, 12));  // 4

            Console.WriteLine("Normalisatie");
            var f1 = new Fraction(2, 4);
            var f2 = new Fraction(1, 2);
            var f3 = new Fraction(-1, -2);
            var f4 = new Fraction(3, -6);
            var f5 = new Fraction(0, 5);

            Console.WriteLine(f1); // 1/2
            Console.WriteLine(f2); // 1/2
            Console.WriteLine(f3); // 1/2
            Console.WriteLine(f4); // -1/2
            Console.WriteLine(f5); // 0/1

            Console.WriteLine("IEquatable<Fraction>");
            var f6 = new Fraction(1, 2);
            var f7 = new Fraction(2, 4);
            var f8 = new Fraction(1, 3);
            var f9 = new Fraction(-1, -2);

            Console.WriteLine(f6 == f7);  // True
            Console.WriteLine(f6 == f8);  // False
            Console.WriteLine(f6 == f9);  // True
            Console.WriteLine(f6 != f7);  // False

            Console.WriteLine(object.ReferenceEquals(f6, f7)); // False

            var list = new List<Fraction> { f6 };
            Console.WriteLine(list.Contains(f6));

            Console.ReadKey();
        }

        public readonly struct Fraction
        {
            public long Numerator { get; }
            public long Denominator { get; }

            public Fraction(long numerator, long denominator)
            {
                if (denominator == 0)
                    throw new ArgumentException("Noemer mag geen nul zijn ", nameof(denominator));

                long gcd = GCD(numerator, denominator);

                numerator /= gcd;
                denominator /= gcd;

                if (numerator < 0)
                {
                    denominator = 1;
                }

                if (numerator == 0)
                {
                    denominator = 1;
                }

                Numerator = numerator;
                Denominator = denominator;
            }

            public static long GCD(long a, long b)
            {
                a = Math.Abs(a);//Abs zet negatieve cijfers om naar positief
                b = Math.Abs(b);

                while (b != 0)
                {
                    long temp = b;
                    b = a % b;
                    a = temp;
                }

                return a;
            }

            public bool Equals(Fraction other)
            {
                return Numerator == other.Numerator && Denominator == other.Denominator;
            }

            public override bool Equals(object? obj)
            {
                return obj is Fraction other && Equals(obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Numerator, Denominator);
            }

            public static bool operator ==(Fraction left, Fraction right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Fraction left, Fraction right)
            {
                return !left.Equals(right);
            }

            public override string ToString()
            {
                return Numerator == 0 ? "0" : $"{Numerator}/{Denominator}";
            }
        }
    }
}