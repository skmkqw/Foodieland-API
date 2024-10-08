using Foodieland.API;
using Foodieland.Application;
using Foodieland.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration); 
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseAuthentication();
    
    app.UseHttpsRedirection();
    
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}