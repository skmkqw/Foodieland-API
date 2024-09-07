using Foodieland.Domain.RecipeAggregate;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IRecipeRepository
{
    void Add(Recipe recipe);
}