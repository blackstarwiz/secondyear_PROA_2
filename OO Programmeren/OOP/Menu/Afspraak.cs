namespace Menu
{
    internal class Afspraak : IRoosterbaar
    {
        private TimeSpan afspraakDuur;
        private TimeSpan verplaatsing;
        private TimeSpan terugGaan;
        private string omschrijving;

        public Afspraak(TimeSpan duur, TimeSpan verplaats, TimeSpan terug, string afspraak)
        {
            afspraakDuur = duur + verplaats + terug;
            verplaatsing = verplaats;
            terugGaan = terug;
            omschrijving = afspraak;
        }

        public Afspraak()
        {
            afspraakDuur = new TimeSpan();
            verplaatsing = new TimeSpan();
            terugGaan = new TimeSpan();
            omschrijving = string.Empty;
        }

        public TimeSpan TijdsDuur
        {
            get
            {
                return afspraakDuur;//terugsturen van de duur van de afspraak
            }
        }

        public string Omschrijving
        {
            get
            {
                return omschrijving;
            }
        }

        public DateTime RoosterOm(DateTime referentiepunt)
        {
            return referentiepunt - verplaatsing;//
        }

        public void Initialiseer()//lossekoppeling
        {
            Console.WriteLine("Omscrijving?");
            Console.Write("> ");
            omschrijving = Console.ReadLine() ?? "";

            if (omschrijving == "")
                throw new ArgumentNullException("Voer geldige waarde in");

            Console.WriteLine("Aantal minuten heen?");
            Console.Write("> ");
            string minutenHeen = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenHeen, out int heen))
            {
                if (minutenHeen == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            


            Console.WriteLine("Aantal minuten afspraak zelf?");
            Console.Write("> ");
            string minutenAfspraak = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenAfspraak, out int afspraak))
            {
                if (minutenAfspraak == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }
            

            Console.WriteLine("Aantal minuten terug?");
            Console.Write("> ");
            string minutenTerug = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenTerug, out int terug))
            {
                if (minutenTerug == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            if (heen < 0 | afspraak < 0 | terug < 0)
                throw new Exception("Waarde moet positief zijn");

            verplaatsing = new TimeSpan(0, heen, 0);
            afspraakDuur = new TimeSpan(0,afspraak,0);
            terugGaan = new TimeSpan(0, terug, 0);
        }
    }
}