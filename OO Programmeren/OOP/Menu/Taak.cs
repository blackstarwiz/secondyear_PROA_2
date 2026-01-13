using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Taak : IRoosterbaar
    {
        private TimeSpan tijdsDuur;
        private string omschrijving;

        public Taak(TimeSpan duur, string beschrijving)
        {
            tijdsDuur = duur;
            omschrijving = beschrijving;
        }

        public Taak()
        {
            tijdsDuur = new TimeSpan();
            omschrijving = string.Empty;
        }

        public TimeSpan TijdsDuur
        {
            get
            {
                return tijdsDuur;
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
            return referentiepunt;
        }

        public void Initialiseer()
        {
            Console.WriteLine("Omscrijving?");
            Console.Write("> ");
           omschrijving = Console.ReadLine() ?? "";

            if (omschrijving == "")
                throw new ArgumentNullException("Voer geldige waarde in");

            Console.WriteLine("Aantal minuten werken?");
            Console.Write("> ");
            string minutenWerk = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenWerk, out int minuten))
            {
                if (minutenWerk == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            if (minuten < 0)
                throw new Exception("Waarde moet positief zijn");

            tijdsDuur = new TimeSpan(0, minuten, 0);
        }
    }
}