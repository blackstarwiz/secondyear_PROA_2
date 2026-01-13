using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class AandrijvingCNG : IAandrijving
    {
        public void EnergieToevoegen()
        {
            Console.WriteLine($"<EnergieToevoegen> - <{this.GetType().Name.Replace("Aandrijving", "")}>");
        }

        public void Vertragen(int kmPerUurPerSecond, int doelSnelheid)
        {
            Console.WriteLine($"<Vertagen> - <{this.GetType().Name.Replace("Aandrijving", "")}>");
        }

        public void Versnellen(int kmPerUurPerSeconden, int doelSnelheid)
        {
            Console.WriteLine($"<Versnellen> - <{this.GetType().Name.Replace("Aandrijving", "")}>");
        }
    }
}
