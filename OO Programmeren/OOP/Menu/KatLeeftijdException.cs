using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class KatLeeftijdException : ArgumentException
    {
        private readonly int meegegevenWaarde;
        private readonly int laagste;
        private readonly int hoogste;

        public KatLeeftijdException(int meegeven, int laagste, int hoogste)
             : base($"{meegeven} is geen geldige leeftijd. De laagste mogelijke leeft is {laagste} jaar, de hoogst mogelijke leeftijd is {hoogste} jaar")

        {
            this.meegegevenWaarde = meegeven;
            this.laagste = laagste;
            this.hoogste = hoogste;
        }

        public int MeegegevenWaarde
        {
            get
            {
                return meegegevenWaarde;
            }
        }

        public int LaagstMogelijkeWaarde
        {
            get
            {
                return laagste;
            }
        }

        public int HoostMogelijkeWaarde
        {
            get
            {
                return hoogste;
            }
        }
    }
}