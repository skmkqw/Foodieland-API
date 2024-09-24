using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetRecipes;

public record GetRecipesQuery(int Page, int PageSize) : IRequest<PagedResult<Recipe>>;