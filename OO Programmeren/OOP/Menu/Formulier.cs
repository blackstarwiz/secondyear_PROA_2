using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Formulier
    {
        private readonly List<FormulierVraag> vragen = new();

        public Formulier(List<FormulierVraag> vragen)
        {
            this.vragen = vragen.ToList();
        }

        public Formulier()
        {
            vragen = new List<FormulierVraag>();
        }
        public ImmutableList<FormulierVraag> Vragen
        {
            get
            {
                return vragen.ToImmutableList();
            }
        }

        public void VulIn()
        {
            foreach(var vraag in Vragen)
            {
                vraag.ToonVraag();
                vraag.LeesAntwoord();
            }
            Console.WriteLine();
        }

        public void Toon()
        {
            foreach(var vraag in Vragen)
            {
                Console.WriteLine($"{vraag.Tekst} -> {vraag.Antwoord ?? "(leeg)"}");
            }
            Console.WriteLine();
        }
    }
}
