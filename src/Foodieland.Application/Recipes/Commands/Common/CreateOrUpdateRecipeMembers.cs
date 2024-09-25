namespace Foodieland.Application.Recipes.Commands.Common;

public record CreateOrUpdateNutritionInformationCommand(int Calories, float Protein, float Carbs, float Fat);

public record CreateOrUpdateCookingDirectionCommand(int StepNumber, string Name, string Description);

public record CreateOrUpdateIngredientCommand(string Name, float Quantity, string Unit);