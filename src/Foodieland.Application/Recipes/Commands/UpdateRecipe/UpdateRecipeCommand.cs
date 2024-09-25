using ErrorOr;
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
    UpdateNutritionInformationCommand NutritionInformation,
    List<UpdateCookingDirectionCommand> Directions,
    List<UpdateIngredientCommand> Ingredients) : IRequest<ErrorOr<Recipe>>;

public record UpdateNutritionInformationCommand(int Calories, float Protein, float Carbs, float Fat);

public record UpdateCookingDirectionCommand(int StepNumber, string Name, string Description);

public record UpdateIngredientCommand(string Name, float Quantity, string Unit);