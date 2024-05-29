using Microsoft.Extensions.Options;
using NetRom.Weather.Application.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace NetRom.Weather.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IOptions<WeatherApiOptions> options, IHttpClientFactory httpClientFactory) 
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<WeatherModel> GetWeatherAsync(double lat, double lon, CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient("weather");
            var queryString = $"?lat={lat}&lon={lon}&units=metric&appid={_options.ApiKey}";

            // cum sa folosim un try - catch in acest punct. Aruncati un custom exception.

            var response = await client.GetAsync(queryString, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                // Ce tip de exceptie am putea arunca din acest punct.
            }

            var body = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(body))
            {
                throw new InvalidDataException("Empty response");
            }
            else
            {
                return JsonConvert.DeserializeObject<WeatherModel>(body);
            }
            // sa definesc un mod de comunicare
            // sa fac un call
            // sa parsez si sa returnez modelul
            throw new NotImplementedException();
        }
    }
}
