using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAntwerpen
{
    public class WeatherService
    {
        public string GetCurrentWeatherInAntwerp(float temp)
        {
            //als float bepaalde waarde heeft geeft het een string terug
            if (temp < 0) {
                return "Brrrrrr, it's freeeezzzzziiinnnngg";
            }
            if(temp < 13)
            {
                return "It's cold";
            }
            if(temp < 24)
            {
                return "It's ok";
            }
            return "It's Hotttttttt!!!!, Get some ICE!!!";
        }
    }
}
