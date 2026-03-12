using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAntwerpen
{
    public class WeatherService
    {
        private OpenWeatherMapApi _weatherApi;

        public WeatherService(OpenWeatherMapApi weatherApi)
        {
            _weatherApi = weatherApi;
        }

        public string GetCurrentWeatherInAntwerp()
        {
            float temp = 0;
            try {
                temp = _weatherApi.GetCurrentTemperatureInAntwerp();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
