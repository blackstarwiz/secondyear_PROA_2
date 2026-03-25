using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Mock_Open_Weather
{
    public class OpenWeatherMapApi: IOpenWeatherMapApi
    {
        private string url = "https://api.openweathermap.org/data/2.5/weather?q=Antwerp,BE&appid=b1a90ec4d94d84ecf2a3f2bb634b970d&units=metric";

        public float GetCurrentTemperatureInAntwerp()
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();

                var response = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var temp = JsonConvert.DeserializeObject<OpenWeather>(response).main.temp;
                
                return temp;
                
            }
        }
    }
}
