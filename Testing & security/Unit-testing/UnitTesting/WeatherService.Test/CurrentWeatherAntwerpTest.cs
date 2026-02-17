using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Moq;
using Newtonsoft.Json;
using TempAntwerpen;
namespace MessageWeatherService.Test
{
    [TestClass]
    public class CurrentWeatherAntwerpTest
    {
        //check message form under 0 between 15 and max till 24 celecius
        [TestMethod]
        public void WeatherService_Below_0_Returns_Correct(string json)
        { 
            //const string realUrl = "http://api.openweathermap.org/data/2.5/weather?q=Antwerp,BE&appid=bla...&units=metric";
            
            //Arrange
            var mockHttpClient = new Mock<IWeatherHttpClient>();
            mockHttpClient.Setup(x => x.GetStringAsync(It.IsAny<string>())).ReturnsAsync(json);
            Console.WriteLine(mockHttpClient);
            var tempApi = new OpenWeatherMapApi(mockHttpClient.Object);
            WeatherService weatherService = new WeatherService();

            //Act
            float temp = tempApi.GetCurrentTemperatureInAntwerp();
            var result = weatherService.GetCurrentWeatherInAntwerp(temp);

            //Assert
            Assert.AreEqual("Brrrrrr, it's freeeezzzzziiinnnngg", result);
        }
    }
}
