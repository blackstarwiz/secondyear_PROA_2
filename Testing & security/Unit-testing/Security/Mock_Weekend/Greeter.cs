using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Weekend
{
    public class Greeter
    {
        private readonly IDateGetter _dateGetter;

        public Greeter(IDateGetter dateGetter)
        {
            _dateGetter = dateGetter;
        }


        public string GetMessage()
        {
            var date = _dateGetter.GetDate();
            //als het weekend is laat de geruiker het weten
            if (date == DayOfWeek.Saturday || date == DayOfWeek.Sunday)
            {
                return "Het is weekend";
            }

            return "Nog even het is bijna weekend";
        }
    }
}
