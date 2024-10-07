using Foodieland.Contracts.Common;
using Foodieland.Contracts.Recipes.GetRecipe;

namespace Foodieland.Contracts.Recipes.GetRecipes;

public record GetRecipesResponse(List<GetRecipeResponse> Recipes, Pagination Pagination);

