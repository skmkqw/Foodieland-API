using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private static readonly List<Recipe> _recipes = new();
    public void Add(Recipe recipe)
    {
        _recipes.Add(recipe);
    }
}