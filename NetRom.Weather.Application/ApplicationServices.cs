using Microsoft.Extensions.DependencyInjection;
using NetRom.Weather.Application.Services;
using NetRom.Weather.Infrastructure.Repository;

namespace NetRom.Weather.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ICityService, CityService>();
        services.AddSingleton<ICityRepository, CityRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
