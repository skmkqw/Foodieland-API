using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.UserAggregate;
using Foodieland.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Foodieland.Infrastructure.Persistence;

public class FoodielandDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public FoodielandDbContext(DbContextOptions<FoodielandDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(FoodielandDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}