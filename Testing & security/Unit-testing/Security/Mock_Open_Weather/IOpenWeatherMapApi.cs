using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Open_Weather
{
    public interface IOpenWeatherMapApi
    {
        float GetCurrentTemperatureInAntwerp();
    }
}
