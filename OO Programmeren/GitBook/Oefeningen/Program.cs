namespace Oefeningen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MiniDatumValue d1 = new MiniDatumValue();
            d1.Dag = 6;
            d1.Maand = 3;
            d1.Jaar = 2016;
            MiniDatumReference d2 = new MiniDatumReference();
            d2.Dag = 6;
            d2.Maand = 3;
            d2.Jaar = 2016;
            Program.WijzigDatums(d1, d2);
            Console.WriteLine($"value na uitvoering: {d1.Dag}/{d1.Maand}/{d1.Jaar}");
            Console.WriteLine($"reference na uitvoering: {d2.Dag}/{d2.Maand}/{d2.Jaar}");
        }

        public void klok()
        {
            while (true)
            {
                DateTime Tijd = DateTime.Now;
                Console.WriteLine(Tijd.ToString("T"));
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void verjaardag()
        {
            Console.WriteLine("Geef je geboorte jaar in: mm,dd");

            string verjaardagDatum = Console.ReadLine();

            string[] MaadnEnDag = verjaardagDatum.Split(",");
            DateTime verjaardag = new DateTime(DateTime.Now.Year, Convert.ToInt32(MaadnEnDag[0]), Convert.ToInt32(MaadnEnDag[1]));
            TimeSpan dagentotVer = verjaardag - DateTime.Now;
            Console.WriteLine(verjaardag.ToString("D"));

            Console.WriteLine($"dagen tot verjaardag; {Math.Round(dagentotVer.TotalDays)}");
        }

        private struct MiniDatumValue
        {
            public int Dag;
            public int Maand;
            public int Jaar;
        }

        private static void WijzigDatums(MiniDatumValue val, MiniDatumReference reference)
        {
            val.Maand = 2;
            reference.Maand = 2;
        }
    }

    internal class MiniDatumReference
    {
        public int Dag;
        public int Maand;
        public int Jaar;
    }
}