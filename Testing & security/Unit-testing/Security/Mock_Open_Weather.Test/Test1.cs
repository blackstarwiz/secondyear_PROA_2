using Moq;

namespace Mock_Open_Weather.Test
{
    [TestClass]
    public sealed class WeatherServiceTest
    {
        [TestMethod]
        [DataRow(34)]
        [DataRow(-4)]
        [DataRow(-3)]
        [DataRow(-2)]
        [DataRow(-1)]
        public void GetCurrentWeatherInAntwerp_Returns_Correct_String(float temp)
        {
            //Arrange
            var mockWeatherMapApi = new Mock<IOpenWeatherMapApi>();
            mockWeatherMapApi.Setup(x => x.GetCurrentTemperatureInAntwerp()).Returns(temp);

            var weatherService = new WeatherService();
            //Action
            var result = weatherService.GetCurrentWeatherInAntwerp();
            //Assert

            Assert.AreEqual("Brrrr, Het is aan het vriezen",result);
        }
    }
}
