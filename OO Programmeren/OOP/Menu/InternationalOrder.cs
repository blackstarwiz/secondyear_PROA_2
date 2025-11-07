using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class InternationalOrder : Order
    {
        public InternationalOrder(uint number, double unitPrice) : base(number, unitPrice)
        {

        }

        public override double TotalPrice
        {
            get
            {
                double basisTotaal = Number * unitPrice;
                double verhoogd = basisTotaal * 1.10; // +10%

                if (Number >= 100)
                    verhoogd -= 1000; // vlakke korting

                return verhoogd;
            }
        }
    }
}
