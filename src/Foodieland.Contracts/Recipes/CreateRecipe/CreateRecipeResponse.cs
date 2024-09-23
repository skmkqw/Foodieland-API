using Foodieland.Contracts.Recipes.Common;

namespace Foodieland.Contracts.Recipes.CreateRecipe;

public record CreateRecipeResponse(
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