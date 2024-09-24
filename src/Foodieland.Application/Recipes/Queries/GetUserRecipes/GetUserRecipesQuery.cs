using ErrorOr;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetUserRecipes;

public record GetUserRecipesQuery(UserId UserId, int Page, int PageSize) : IRequest<ErrorOr<List<Recipe>>>;