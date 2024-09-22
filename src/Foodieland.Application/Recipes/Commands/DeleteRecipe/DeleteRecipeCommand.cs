using ErrorOr;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.DeleteRecipe;

public record DeleteRecipeCommand(RecipeId RecipeId, UserId CreatorId) : IRequest<ErrorOr<Unit>>;