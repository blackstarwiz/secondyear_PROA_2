using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class GetallenCombinatie
    {
        private int getal1;
        private int getal2;

        public int Getal1
        {
            get
            {
                return getal1;
            }
            set
            {
                getal1 = value;
            }
        }

        public int Getal2
        {
            get
            {
                return getal2;
            }
            set
            {
                getal2 = value;
            }
        }

        public double Som()
        {
            return getal1 + getal2;
        }

        public double Verschil()
        {
            return Getal1 - Getal2;
        }

        public double Product()
        {
            return getal1 * getal2;
        }

        public double Quotient()
        {
            return getal1 / getal2;
        }
    }
}