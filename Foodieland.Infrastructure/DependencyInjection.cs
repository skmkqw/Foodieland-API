using Foodieland.Application.Common.Interfaces;
using Foodieland.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Foodieland.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}