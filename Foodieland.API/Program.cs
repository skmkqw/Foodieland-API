// using Foodieland.API.Middleware;

using Foodieland.API.Filters;
using Foodieland.Application;
using Foodieland.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
}


var app = builder.Build();
{
    // app.UseMiddleware<ExceptionHandlingMiddleware>();
    
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}