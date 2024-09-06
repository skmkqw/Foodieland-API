using ErrorOr;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Name,
    string Description,
    int TimeToCook,
    string CreatorId,
    NutritionInformationCommand NutritionInformation,
    List<CookingDirectionCommand> Directions,
    List<IngredientCommand> Ingredients) : IRequest<ErrorOr<Recipe>>;

public record NutritionInformationCommand(int Calories, float Protein, float Carbs, float Fat);

public record CookingDirectionCommand(int StepNumber, string Name, string Description);

public record IngredientCommand(string Name, float Quantity, string Unit);