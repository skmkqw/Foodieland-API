using ErrorOr;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    string Name,
    string Description,
    int TimeToCook,
    Guid CreatorId,
    CreateNutritionInformationCommand NutritionInformation,
    List<CreateCookingDirectionCommand> Directions,
    List<CreateIngredientCommand> Ingredients) : IRequest<ErrorOr<Recipe>>;

public record CreateNutritionInformationCommand(int Calories, float Protein, float Carbs, float Fat);

public record CreateCookingDirectionCommand(int StepNumber, string Name, string Description);

public record CreateIngredientCommand(string Name, float Quantity, string Unit);