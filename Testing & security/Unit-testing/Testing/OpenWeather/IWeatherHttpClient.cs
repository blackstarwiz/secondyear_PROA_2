using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAntwerpen
{
    //mockbaar
    public interface IWeatherHttpClient
    {
        Task<string> GetStringAsync(string url);
    }
}
