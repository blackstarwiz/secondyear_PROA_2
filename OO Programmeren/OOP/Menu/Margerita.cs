using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Margerita : Pizza
    {
        public Margerita(string[] extraToppings) : base(extraToppings)
        {
            
        }

        public override double UnitPrice => 5;


    }
}
