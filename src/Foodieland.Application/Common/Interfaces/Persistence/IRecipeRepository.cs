using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IRecipeRepository
{
    Task<Recipe?> GetRecipeById(RecipeId recipeId);
    
    Task<PagedResult<Recipe>> GetRecipes(int page, int pageSize);
    
    Task<PagedResult<Recipe>> GetUserRecipes(UserId userId, int page, int pageSize);
    
    Task AddRecipe(Recipe recipe);
    
    void UpdateRecipe(Recipe recipe);
    
    void DeleteRecipe(Recipe recipe);

    void DeleteRecipesByUserId(UserId userId);
}