using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly FoodielandDbContext _dbContext;

    public RecipeRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Recipe recipe)
    {
        _dbContext.Recipes.Add(recipe);
        _dbContext.SaveChanges();
    }
}