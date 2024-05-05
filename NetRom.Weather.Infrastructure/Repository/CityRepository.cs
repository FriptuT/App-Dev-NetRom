using NetRom.Weather.Infrastructure.Models;
using AutoMapper;

namespace NetRom.Weather.Infrastructure.Repository
{
    public class CityRepository : ICityRepository
    {
        private IList<CityModel> _cityModels;
        private IMapper _mapper { get; set; }

        public CityRepository(IMapper mapper)
        {
            _mapper = mapper;

        }
        public Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation)
        {
            var newCity = _mapper.Map<CityModel>(cityModelForCreation);

            _cityModels.Add(newCity);

            return Task.FromResult(newCity.Id);
        }

        public async Task DeleteAsync(Guid cityId)
        {
            _cityModels = await Task.FromResult(_cityModels.Where(c => c.Id == cityId).ToList());
        }

        public async Task<IEnumerable<CityModel>> GetAllAsync()
        {
            return await Task.FromResult(_cityModels);
        }

        public async Task<CityModel?> GetByIdAsync(Guid cityId)
        {
            var cityModel = await Task.FromResult(_cityModels.FirstOrDefault(c => c.Id == cityId));
            return cityModel;
        }

        public async Task<CityModel> UpdateAsync(CityModel cityModel)
        {
            var entity = _cityModels.FirstOrDefault(c => c.Id == cityModel.Id);

            if (entity == null)
            {
                throw new Exception("orasul nu exista");
            }
            entity.Name = cityModel.Name;
            entity.Latitude = cityModel.Latitude;
            entity.Longitude = cityModel.Longitude;

            return await Task.FromResult(cityModel);
        }

    }
}
