using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Open_Weather
{
    public class WeatherService
    {
        private readonly IOpenWeatherMapApi _openWeatherMapApi;

        public WeatherService(IOpenWeatherMapApi openWeatherMapApi)
        {
            _openWeatherMapApi = openWeatherMapApi;
        }


        public string GetCurrentWeatherInAntwerp()
        {
            var temp = _openWeatherMapApi.GetCurrentTemperatureInAntwerp();

            if (temp < 0)
            {
                return "Brrrr, Het is aan het vriezen";
            }

            if (temp < 15)
            {
                return "Het is koud";
            }

            if (temp < 24)
            {
                return "Het is perfect weer";
            }

            return "Het is te warm";
        }
    }
}