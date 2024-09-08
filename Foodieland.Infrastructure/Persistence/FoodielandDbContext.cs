using Foodieland.Domain.RecipeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Foodieland.Infrastructure.Persistence;

public class FoodielandDbContext : DbContext
{
    public FoodielandDbContext(DbContextOptions<FoodielandDbContext> options) : base(options) 
    {
    }
    
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.
            ApplyConfigurationsFromAssembly(typeof(FoodielandDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}