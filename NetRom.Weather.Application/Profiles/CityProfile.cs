using AutoMapper;
using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Profiles
{
    public class CityProfile: Profile
    {
        public CityProfile() 
        {
            CreateMap<CityModelForCreation, CityModel>().ReverseMap();
        }
    }
}
