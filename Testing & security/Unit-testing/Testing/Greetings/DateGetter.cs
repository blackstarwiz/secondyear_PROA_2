using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings
{
    internal class DateGetter : IDateGetter
    {
        public DayOfWeek GetDate()
        {
            return DateTime.Now.Date.DayOfWeek;
        }
    }
}