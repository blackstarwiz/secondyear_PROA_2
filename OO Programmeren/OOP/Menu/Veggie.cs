using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Veggie : Pizza
    {

        public Veggie(string[] extraToppings) : base(extraToppings)
        {

        }

        public override double UnitPrice => 6;
    }
}
