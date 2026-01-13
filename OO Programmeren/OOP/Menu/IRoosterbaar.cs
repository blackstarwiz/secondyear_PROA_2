using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal interface IRoosterbaar
    {
        public TimeSpan TijdsDuur { get; }

        public string Omschrijving { get; }

        public DateTime RoosterOm(DateTime referentiepunt);

        public void Initialiseer();
    }
}
