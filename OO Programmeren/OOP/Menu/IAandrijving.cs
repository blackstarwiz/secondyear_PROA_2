using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal interface IAandrijving
    {
        void EnergieToeboeging();

        void Vertragen(int kmPerUurPerSeconde, int doelSnelheid);

        void Versnellen(int kmPerUurPerSeconde, int doelSnelheid);


    }
}
