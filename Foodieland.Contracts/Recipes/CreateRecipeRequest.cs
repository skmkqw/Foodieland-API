namespace Foodieland.Contracts.Recipes;

public record CreateRecipeRequest(
    string Name,
    string Description,
    int TimeToCook,
    NutritionInformation NutritionInformation,
    List<CookingDirection> Directions,
    List<Ingredient> Ingredients);

public record NutritionInformation(int Calories, float Protein, float Carbs, float Fat);

public record CookingDirection(int StepNumber, string Name, string Description);

public record Ingredient(string Name, float Quantity, string Unit);