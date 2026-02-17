using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TempAntwerpen
{
    public class OpenWeatherMapApi
    {
        private readonly IWeatherHttpClient _client;
        private string url = "https://api.openweathermap.org/data/2.5/weather?q=Antwerp,BE&appid=b1a90ec4d94d84ecf2a3f2bb634b970d&units=metric";
        

        public OpenWeatherMapApi(IWeatherHttpClient client)
        {
            _client = client;
        }

        //geeft float terug van temp in antwerpen
        public float GetCurrentTemperatureInAntwerp()
        {
            var httpResponse = _client.GetStringAsync(url).GetAwaiter().GetResult();
            if (httpResponse == null)
                throw new ArgumentNullException("Response doesn't contain valid string");
            //we gebruiken onze class OpenWeather om deserialze te kunnen doen op de nodige waarde die we zoeken
            var weather = JsonConvert.DeserializeObject<OpenWeather>(httpResponse);

            if (weather?.main == null)
            {
                throw new InvalidOperationException("Failed to retrieve temperature data from OpenWeatherMap API.");
            }

            return weather.main.temp;

            //No loose coupeling versie 1
            //using (var httpClient = new HttpClient())
            //{
            //    var httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();
            //    var response = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //    var weather = JsonSerializer.Deserialize<OpenWeather>(response);
            //    if (weather?.main == null)
            //    {
            //        throw new InvalidOperationException("Failed to retrieve temperature data from OpenWeatherMap API.");
            //    }
            //    return weather.main.temp;
            //}
        }
    }
}