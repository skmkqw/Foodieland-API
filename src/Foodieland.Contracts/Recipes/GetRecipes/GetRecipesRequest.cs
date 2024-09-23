namespace Foodieland.Contracts.Recipes.GetRecipes;

public record GetRecipesRequest(int Page = 1, int PageSize = 10);