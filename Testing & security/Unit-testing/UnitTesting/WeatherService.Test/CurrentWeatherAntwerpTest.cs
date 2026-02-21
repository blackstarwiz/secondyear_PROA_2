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
        public void WeatherService_Below_0_Returns_Correct()
        { 
            const string weatherJsonAntwerp = "{\"main\":{\"temp\":-5.0}}";
            
            //Arrange
            var mockHttpClient = new Mock<IWeatherHttpClient>();
            mockHttpClient.Setup(x => x.GetStringAsync(It.IsAny<string>())).ReturnsAsync(weatherJsonAntwerp);
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
