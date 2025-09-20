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
                if (start % 4== 0)
                {
                    counterSchikkel++;
                }
            }

            return counterSchikkel;
        }
    }
}