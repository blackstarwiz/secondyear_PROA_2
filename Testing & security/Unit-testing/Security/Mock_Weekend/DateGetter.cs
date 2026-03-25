using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Weekend
{
    public class DateGetter: IDateGetter
    {
        private readonly DayOfWeek _today;

        public DateGetter()
        {
            _today = GetDate();
        }

        public DayOfWeek Today
        {
            get
            {
                return _today;
            }
        }

        public DayOfWeek GetDate()
        {
            return DateTime.UtcNow.DayOfWeek;
        }
    }
}
