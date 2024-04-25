using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;

public interface ICityService
{
    Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation);
    Task<IEnumerable<CityModel>> GetAllAsync();
    Task<CityModel?> GetByIdAsync(Guid cityId);
    Task<CityModel> UpdateAsync(CityModel cityModel);
    Task DeleteAsync(Guid cityId);
}
