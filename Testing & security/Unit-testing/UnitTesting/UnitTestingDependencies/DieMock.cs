using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDependencies
{
    public class DieMock : IDie
    {
        //Hier gaan we een Dobbelsteen maken die een bepaalde waarde instelt/terug geeft
        // om te zien dat de function van de NumberGame degelijk nu werkt
        private readonly int result;

        public DieMock(int result)
        {
            this.result = result;
        }

        public int Roll()
        {
            return result;
        }
    }
}