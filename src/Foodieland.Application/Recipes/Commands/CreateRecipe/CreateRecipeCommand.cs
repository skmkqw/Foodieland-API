using ErrorOr;
using Foodieland.Application.Recipes.Commands.Common;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Name,
    string Description,
    int TimeToCook,
    Guid CreatorId,
    CreateOrUpdateNutritionInformationCommand NutritionInformation,
    List<CreateOrUpdateCookingDirectionCommand> Directions,
    List<CreateOrUpdateIngredientCommand> Ingredients) : IRequest<ErrorOr<Recipe>>;