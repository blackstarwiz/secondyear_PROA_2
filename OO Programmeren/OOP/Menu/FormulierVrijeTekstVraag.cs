using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class FormulierVrijeTekstVraag : FormulierVraag
    {
        public FormulierVrijeTekstVraag(string tekst) : base(tekst) { }

        public override void ToonVraag()
        {
            Console.WriteLine($"{Tekst}: ");
        }

        public override void LeesAntwoord()
        {
            Antwoord = Console.ReadLine();
        }

       
    }
}
