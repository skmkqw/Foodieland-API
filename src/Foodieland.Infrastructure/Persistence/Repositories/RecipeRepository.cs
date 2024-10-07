using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly FoodielandDbContext _dbContext;

    public RecipeRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Recipe?> GetRecipeById(RecipeId recipeId)
    {
        return await _dbContext.Recipes.FindAsync(recipeId);
    }

    public async Task<PagedResult<Recipe>> GetRecipes(int page, int pageSize)
    {
        var totalRecipes = await _dbContext.Recipes.CountAsync();
        
        var recipes = await _dbContext.Recipes
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResult<Recipe>(recipes, totalRecipes, page, pageSize);
    }

    public async Task<PagedResult<Recipe>> GetUserRecipes(UserId userId, int page, int pageSize)
    {
        var totalRecipes = await _dbContext.Recipes.CountAsync(r => r.CreatorId == userId);
        
        var userRecipes = await _dbContext.Recipes
            .Where(r => r.CreatorId == userId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResult<Recipe>(userRecipes, totalRecipes, page, pageSize);
    }

    public async Task AddRecipe(Recipe recipe)
    {
        await _dbContext.Recipes.AddAsync(recipe);
    }

    public void UpdateRecipe(Recipe recipe)
    {
        _dbContext.Recipes.Update(recipe);
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _dbContext.Recipes.Remove(recipe);
    }

    public void DeleteRecipesByUserId(UserId userId)
    {
        var userRecipes = _dbContext.Recipes.Where(r => r.CreatorId == userId);
        _dbContext.Recipes.RemoveRange(userRecipes);
    }
}