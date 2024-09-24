namespace Foodieland.Contracts.Recipes.Common;

public record GetRecipesResponse(List<GetRecipeResponse> Recipes, Pagination Pagination);

public record Pagination(int Page, int PageSize, int TotalRecipes);