using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings
{
    public class Greeter
    {
        private readonly IDateGetter dateGetter;

        public Greeter(IDateGetter dateGetter)
        {
            this.dateGetter = dateGetter;
        }

        public string GetMessage() 
        {
            var date = dateGetter.GetDate();
            if(date == DayOfWeek.Saturday || date == DayOfWeek.Sunday)
            {
                return "Party time.....It's weekend";
            }
            return "Work hard, weekend is on his way....";
        }
    }
}
