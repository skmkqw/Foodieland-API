using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IRecipeRepository
{
    Recipe? GetRecipeById(RecipeId recipeId);
    
    List<Recipe> GetRecipes(int page, int pageSize);
    
    List<Recipe> GetUserRecipes(UserId userId, int page, int pageSize);
    
    void AddRecipe(Recipe recipe);
    
    void DeleteRecipe(Recipe recipe);
}