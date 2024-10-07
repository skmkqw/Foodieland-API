using Foodieland.Contracts.Recipes.GetRecipe;

namespace Foodieland.Contracts.Recipes.CreateOrUpdateRecipe;

public record CreateOrUpdateRecipeResponse(
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