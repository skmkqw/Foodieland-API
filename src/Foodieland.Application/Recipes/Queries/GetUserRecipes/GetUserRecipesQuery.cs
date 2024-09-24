using ErrorOr;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetUserRecipes;

public record GetUserRecipesQuery(UserId UserId, int Page, int PageSize) : IRequest<ErrorOr<PagedResult<Recipe>>>;