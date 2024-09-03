using Foodieland.Application.Common.Interfaces;
using Foodieland.Application.Common.Services;
using Foodieland.Infrastructure.Authentication;
using Foodieland.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Foodieland.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}