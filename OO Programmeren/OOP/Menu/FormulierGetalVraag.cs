using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class FormulierGetalVraag : FormulierVraag
    {
        private readonly int onderGrens;
        private readonly int bovenGrens;

        public FormulierGetalVraag(string tekst, int onderGrens, int bovenGrens) : base(tekst)
        {
            this.onderGrens = onderGrens;
            this.bovenGrens = bovenGrens;
        }

        public int OnderGrens
        {
            get
            {
                return onderGrens;
            }
        }

        public int BovenGrens
        {
            get
            {
                return bovenGrens;
            }
        }

        public override void ToonVraag()
        {
            Console.WriteLine($"{Tekst} (Tussen {OnderGrens} en {BovenGrens})");
        }

        public override void LeesAntwoord()
        {
            while (true)
            {
                string invoer = Console.ReadLine() ?? "";
                if (int.TryParse(invoer, out int result) && result >= OnderGrens && result <= BovenGrens)
                {
                    Antwoord = invoer;
                    return;// gaat uit de loop als waarde een int is en de waarde tussen ondergrens en bovengrens ligt
                }
                Console.WriteLine($"Fout: voer een getal in tussen {OnderGrens} en {BovenGrens}!");
            }
        }
    }
}