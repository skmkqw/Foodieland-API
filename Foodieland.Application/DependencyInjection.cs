using Foodieland.Application.Services.Authentication;
using Foodieland.Application.Services.Authentication.Commands;
using Foodieland.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Foodieland.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}