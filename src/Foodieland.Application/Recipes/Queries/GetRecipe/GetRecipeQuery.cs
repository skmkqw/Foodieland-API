using ErrorOr;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetRecipe;

public record GetRecipeQuery(RecipeId RecipeId) : IRequest<ErrorOr<Recipe>>;