using AutoMapper;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Infrastructure.Repository;

namespace NetRom.Weather.Application.Services;

public class CityService : ICityService
{
    private IList<CityModel> _cityModels;
    private readonly ICityRepository _cityRepository;

    private IMapper _mapper {  get; set; }

    public CityService( IMapper mapper, ICityRepository cityRepository)
    {
        _mapper = mapper;
        _cityRepository = cityRepository;

        _cityModels = new List<CityModel>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Craiova",
                Latitude = 1,
                Longitude = 21,
                Temperature = 43
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Rm Valcea",
                Latitude = 1,
                Longitude = 34,
                Temperature = 12
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bucuresti",
                Latitude = 21,
                Longitude = 211,
                Temperature = 2
            },
        };
    }

    public async Task<Guid> CreateCityAsync(CityModelForCreation cityModelForCreation)
    {
        var newCity = _mapper.Map<CityModel>(cityModelForCreation);

        var newCityId =  await _cityRepository.CreateAsync(newCity);

        return newCityId;
    }

    public async Task DeleteCityAsync(Guid cityId)
    {
        await _cityRepository.DeleteAsync(cityId);
    }

    public async Task<IEnumerable<CityModel>> GetAllCitiesAsync()
    {
        return (IEnumerable<CityModel>)await _cityRepository.GetAllAsync();
    }

    public async Task<CityModel?> GetByIdCityAsync(Guid cityId)
    {
        var cityModel = await _cityRepository.GetByIdAsync(cityId);
        return cityModel;
    }

    public async Task<CityModel> UpdateCityAsync(CityModel cityModel)
    {
        var updatedCity = await _cityRepository.UpdateAsync(cityModel);
    }
}
