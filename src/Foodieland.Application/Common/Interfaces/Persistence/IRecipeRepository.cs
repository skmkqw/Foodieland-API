using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IRecipeRepository
{
    Recipe? GetRecipeById(RecipeId recipeId);
    
    void Add(Recipe recipe);
}