using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TempAntwerpen
{
    //type/template json voor temp te vinden 
    public class OpenWeather_AntwerpTemp
    {
        public Main main { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
    }
}
