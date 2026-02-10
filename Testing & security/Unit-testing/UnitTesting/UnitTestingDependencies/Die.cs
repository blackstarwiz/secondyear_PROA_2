using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDependencies
{
    public class Die : IDie
    {
        private static readonly Random random = new Random();

        public int Roll()
        {
            return random.Next(5) + 1;
        }
    }
}
