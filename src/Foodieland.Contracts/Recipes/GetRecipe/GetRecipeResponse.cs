namespace Foodieland.Contracts.Recipes.GetRecipe;

public record GetRecipeResponse(
    string Id,
    string Name,
    string Description,
    int TimeToCook,
    string CreatorId,
    NutritionInformationResponse NutritionInformation,
    List<CookingDirectionResponse> Directions,
    List<IngredientResponse> Ingredients,
    List<string> ReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record NutritionInformationResponse(int Calories, float Protein, float Carbs, float Fat);

public record CookingDirectionResponse(string Id, int StepNumber, string Name, string Description);

public record IngredientResponse(string Id, string Name, float Quantity, string Unit);