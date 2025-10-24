using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class InternationalRegisteredLetter : RegisteredLetter
    {
        public override double Distance { get => base.Distance; set => base.Distance = value; }

        public override byte Duration
        {
            get
            {

                double checkDays = Math.Ceiling(base.Distance / 50);

                return base.Duration = Convert.ToByte(checkDays); ;
            }
        }

        public override double Price
        {
            get
            {
                if (base.Distance > 100)
                {
                    return base.Price = Math.Floor(base.Distance / 100) * 20;
                }
                else
                {
                    return base.Price = 20.00;
                }

            }
        }
    }
}
