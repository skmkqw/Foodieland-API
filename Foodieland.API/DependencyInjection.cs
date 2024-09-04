using Foodieland.API.Mapping;

namespace Foodieland.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappers();
        return services;
    }
}