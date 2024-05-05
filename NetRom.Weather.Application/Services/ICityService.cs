using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;

public interface ICityService
{
    Task<Guid> CreateCityAsync(CityModelForCreation cityModelForCreation);
    Task<IEnumerable<CityModel>> GetAllCitiesAsync();
    Task<CityModel?> GetByIdCityAsync(Guid cityId);
    Task<CityModel> UpdateCityAsync(CityModel cityModel);
    Task DeleteCityAsync(Guid cityId);
}
