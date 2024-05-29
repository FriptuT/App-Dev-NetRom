using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services
{
    public interface IWeatherService
    {
        // FA un call la webservice paseaza lat si long si parseaza raspunsul
       Task<WeatherModel> GetWeatherAsync(double lat, double lon, CancellationToken cancellationToken = default);
    }
}
