using Foodieland.Application.Recipes.Commands.Common;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.UnitTests.TestUtils.Constants;

namespace Foodieland.Application.UnitTests.Recipes.Commands.TestUtils;

public static class CreateRecipeCommandUtils
{
    public static CreateRecipeCommand CreateCommand(
        List<CreateOrUpdateCookingDirectionCommand>? directions = null,
        List<CreateOrUpdateIngredientCommand>? ingredients = null) =>
        new CreateRecipeCommand(
            Constants.Recipe.Name,
            Constants.Recipe.Description,
            Constants.Recipe.TimeToCook,
            Constants.User.UserId.Value,
            CreateNutritionInformationCommand(),
            directions ?? CreateDirectionsCommand(1),
            ingredients ?? CreateIngredientsCommand(1)
        );

    public static List<CreateOrUpdateCookingDirectionCommand> CreateDirectionsCommand(int directionCount) =>
        Enumerable.Range(1, directionCount + 1)
            .Select(index =>  new CreateOrUpdateCookingDirectionCommand(
                index,
                Constants.Recipe.DirectionNameFromIndex(index),
                Constants.Recipe.DirectionDescriptionFromIndex(index)
            )).ToList();
    
    public static List<CreateOrUpdateIngredientCommand> CreateIngredientsCommand(int ingredientCount) =>
        Enumerable.Range(0, ingredientCount)
            .Select(index =>  new CreateOrUpdateIngredientCommand(
                Constants.Recipe.IngredientNameFromIndex(index),
                10,
                "grams"
            )).ToList();

    public static CreateOrUpdateNutritionInformationCommand CreateNutritionInformationCommand() =>
        new CreateOrUpdateNutritionInformationCommand(
            Constants.Recipe.Calories,
            Constants.Recipe.Protein,
            Constants.Recipe.Carbs,
            Constants.Recipe.Fats
        );

}