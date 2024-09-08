using System.Text;
using Foodieland.Application.Common.Interfaces.Authentication;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Interfaces.Services;
using Foodieland.Infrastructure.Authentication;
using Foodieland.Infrastructure.Persistence;
using Foodieland.Infrastructure.Persistence.Repositories;
using Foodieland.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Foodieland.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddPersistence();
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<FoodielandDbContext>(options => options.UseSqlServer());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, 
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });
        return services;
    }
}