
using NetRom.Weather.Infrastructure.Models;

namespace NetRom.Weather.Infrastructure.Repository
{
    public interface ICityRepository
    {
        Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation);
        Task<IEnumerable<CityModel>> GetAllAsync();
        Task<CityModel?> GetByIdAsync(Guid cityId);
        Task<CityModel> UpdateAsync(CityModel cityModel);
        Task DeleteAsync(Guid cityId);
    }
}
