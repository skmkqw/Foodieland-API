using ErrorOr;
using Foodieland.Application.Recipes.Commands.Common;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.UpdateRecipe;

public record UpdateRecipeCommand(
    UserId UserId,
    RecipeId Id,
    string Name,
    string Description,
    int TimeToCook,
    CreateOrUpdateNutritionInformationCommand NutritionInformation,
    List<CreateOrUpdateCookingDirectionCommand> Directions,
    List<CreateOrUpdateIngredientCommand> Ingredients) : IRequest<ErrorOr<Recipe>>;