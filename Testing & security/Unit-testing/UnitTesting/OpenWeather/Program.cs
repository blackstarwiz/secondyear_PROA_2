using TempAntwerpen;

namespace OpenWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var today = new OpenWeatherMapApi(new RealWeatherHttpClient()).GetCurrentTemperatureInAntwerp();
            var messageWeatherService = new WeatherService();
            Console.WriteLine("Temperatuur in Antwerpen is op dit moment: {0} graden", today);
            Console.WriteLine(messageWeatherService.GetCurrentWeatherInAntwerp(today));
            Console.Write("Druk op Enter: ");
            Console.ReadKey();
        }
    }
}
