using Microsoft.Extensions.DependencyInjection;
using NetRom.Weather.Application.Services;

namespace NetRom.Weather.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ICityService, CityService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
