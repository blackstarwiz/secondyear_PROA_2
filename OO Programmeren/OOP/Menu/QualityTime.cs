using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class QualityTime : IRoosterbaar
    {
        private string omschrijving = string.Empty;
        private TimeSpan duur = TimeSpan.Zero;

        public QualityTime(string om, TimeSpan tijd)
        {
            omschrijving = om;
            duur = tijd;
        }


        public QualityTime()
        {

        }

        public string Omschrijving
        {
            get
            {
                return omschrijving;
            }
        }

        public TimeSpan TijdsDuur
        {
            get
            {
                return duur;
            }
        }

        public DateTime RoosterOm(DateTime referentiepunt)
        {
            return referentiepunt;
        }

        public void Initialiseer()
        {
            Console.WriteLine("Omschrijving quality time?");
            omschrijving = Console.ReadLine() ?? string.Empty;

            if (omschrijving == "")
                throw new ArgumentNullException("Omschrijving mag niet leeg zijn");

            Console.WriteLine("Aantal minuten quality time");
            Console.Write("> ");

            if (!int.TryParse(Console.ReadLine(), out int minuten) || minuten <= 0)
                throw new ArgumentException("Aantal minuten moet positief zijn");

            duur = TimeSpan.FromMinutes(minuten);
        }
    }
}
