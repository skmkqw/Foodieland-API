using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

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

    public PagedResult<Recipe> GetRecipes(int page, int pageSize)
    {
        var totalRecipes = _dbContext.Recipes.Count();
        
        var recipes = _dbContext.Recipes
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return new PagedResult<Recipe>(recipes, totalRecipes, page, pageSize);
    }

    public PagedResult<Recipe> GetUserRecipes(UserId userId, int page, int pageSize)
    {
        var totalRecipes = _dbContext.Recipes.Count(r => r.CreatorId == userId);
        
        var userRecipes = _dbContext.Recipes
            .Where(r => r.CreatorId == userId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return new PagedResult<Recipe>(userRecipes, totalRecipes, page, pageSize);
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