using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Auto
    {
        private string autoType = "";
        private IAandrijving aandrijving;
        
        public Auto(string autotype,IAandrijving aandrijving)
        {
            this.autoType = autotype;
            this.aandrijving = aandrijving;
        }

        public string AutoType
        {
            get
            {
                return autoType;
            }
        }

        public IAandrijving Aandrijving
        {
            get
            {
                return aandrijving;
            }
        }


        public void ToonHuidigeAandrijving()
        {
            Console.WriteLine($"Auto: {AutoType} - huidige aandrijving: {Aandrijving.GetType().Name.Replace("Aandrijving", "")}");
        }
    }
}
