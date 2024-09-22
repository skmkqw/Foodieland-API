using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly FoodielandDbContext _dbContext;

    public RecipeRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Recipe? GetRecipeById(RecipeId recipeId)
    {
        return _dbContext.Recipes.Find(recipeId);
    }

    public void AddRecipe(Recipe recipe)
    {
        _dbContext.Recipes.Add(recipe);
        _dbContext.SaveChanges();
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _dbContext.Recipes.Remove(recipe);
        _dbContext.SaveChanges();
    }
}