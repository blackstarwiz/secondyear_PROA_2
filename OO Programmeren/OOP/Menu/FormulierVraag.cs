using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public abstract class FormulierVraag
    {
        private string tekst;
        private string? antwoord;

        protected FormulierVraag(string tekst)
        {
            this.tekst = tekst;
        }

        public string Tekst
        {
            get
            {
                return tekst;
            }
        }

        public string? Antwoord
        {
            get
            {
                return antwoord;
            }
            protected set
            {
                antwoord = value;
            }
        }

        public abstract void ToonVraag();

        public abstract void LeesAntwoord();
    }
}