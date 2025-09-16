namespace Oefeningen
{
    internal class Program
    {
        DateTime Tijd = DateTime.Now;
        static void Main(string[] args)
        {
            Program test = new Program();

            test.verjaardag();
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
    }
}
