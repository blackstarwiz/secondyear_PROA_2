using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Open_Weather
{
    public class OpenWeather
    {

        public Main main { get; set; }

    }

    public class Main
    {
        public float temp { get; set; }
    }
}
