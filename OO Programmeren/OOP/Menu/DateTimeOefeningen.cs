using System.Globalization;

namespace Menu
{
    internal class DateTimeOefeningen
    {
        public static string DagVanDeWeek()
        {
            string dagVanDeWeek = DateTime.Now.ToString("dddd");

            if (dagVanDeWeek == "")
                throw new Exception("Dag kon niet gelezen worden");
            return dagVanDeWeek;
        }

        public static long Ticks2000Programma()
        {
            //begin en currentDate zijn DateTime objects
            //waarbij begin een start datum heeft dat in dit geval begin 2000 is
            // currentDate is de datum van vandaag (systeem datum)
            DateTime begin = new DateTime(2000, 1, 1);
            DateTime currentDate = DateTime.Now;

            //we trekken de begin ticks (kleiner) van de currentDate ticks (groter) af
            //om zo het verschil te zien hoeveel ticks er zijn al geweest
            long ticksCounter = currentDate.Ticks - begin.Ticks;

            return ticksCounter;
        }

        public static int SchrikkeljaarProgramma(int input)
        {
            int start = new DateTime(input, 1, 1).Year;
            int current = DateTime.Now.Year;
            int counterSchikkel = 0;

            if (start > current)
                throw new Exception("Ingevoerd jaar telt niet");

            for (; start <= current; start++)
            {
                if (start % 4 == 0)
                {
                    counterSchikkel++;
                }
            }

            return counterSchikkel;
        }

        public static double ArrayTimerProgramma()
        {
            DateTime startTimer = DateTime.Now;
            DateTime endTimer = DateTime.Now;
            int[] million = new int[1000000];

            for (int i = 0; i < million.Length; i++)
            {
                million[i] = i + 1;
                endTimer.AddSeconds(1);
            }

            TimeSpan interval = endTimer - startTimer;
            string resultInterval = interval.ToString();

            return interval.TotalMilliseconds;
        }

        private void Verjaardag()
        {
            Console.WriteLine("Geef je geboorte jaar,maand,dag in: yyyy,mm,dd");

            string verjaardagDatum = Console.ReadLine();

            string[] MaadnEnDag = verjaardagDatum.Split(",");
            DateTime verjaardag = new DateTime(DateTime.Now.Year, Convert.ToInt32(MaadnEnDag[0]), Convert.ToInt32(MaadnEnDag[1]));
            TimeSpan dagentotVer = verjaardag - DateTime.Now;
            Console.WriteLine(verjaardag.ToString("D"));

            Console.WriteLine($"dagen tot verjaardag; {Math.Round(dagentotVer.TotalDays)}");
        }

        public static string VerjaardagProgramma()
        {
            return "Uitleg snap ik niet --vraag de lector uitleg";
        }

        public static void EigenObjectOefeningen()
        {
            GetallenCombinatie paar1 = new GetallenCombinatie();
            paar1.Getal1 = 12;
            paar1.Getal2 = 34;
            Console.WriteLine("Paar:" + paar1.Getal1 + ", " + paar1.Getal2);
            Console.WriteLine("Som = " + paar1.Som());

            Console.WriteLine("Verschil = " + paar1.Verschil());
            Console.WriteLine("Product = " + paar1.Product());

            if (paar1.Getal1 == 0 || paar1.Getal2 == 0)
            {
                Console.WriteLine("Quotient = Fout: " + paar1.Quotient());
            }
            else
            {
                Console.WriteLine("Quotient  = " + paar1.Quotient().ToString("N3"));
            }
        }
    }
}