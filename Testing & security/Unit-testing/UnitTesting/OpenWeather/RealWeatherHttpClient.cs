using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAntwerpen
{
    public class RealWeatherHttpClient : IWeatherHttpClient
    {
        private readonly HttpClient _client = new();

        public async Task<string> GetStringAsync(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}
