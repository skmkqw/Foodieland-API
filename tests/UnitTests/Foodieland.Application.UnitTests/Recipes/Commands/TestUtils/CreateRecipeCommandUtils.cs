using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.UnitTests.TestUtils.Constants;

namespace Foodieland.Application.UnitTests.Recipes.Commands.TestUtils;

public static class CreateRecipeCommandUtils
{
    public static CreateRecipeCommand CreateCommand() =>
        new CreateRecipeCommand(
            Constants.Recipe.Name,
            Constants.Recipe.Description,
            Constants.Recipe.TimeToCook,
            Constants.User.UserId.Value,
            CreateNutritionInformationCommand(),
            CreateDirectionsCommand(2),
            CreateIngredientsCommand(3)
        );

    public static List<CreateCookingDirectionCommand> CreateDirectionsCommand(int directionCount) =>
        Enumerable.Range(1, directionCount + 1)
            .Select(index =>  new CreateCookingDirectionCommand(
                index,
                Constants.Recipe.DirectionNameFromIndex(index),
                Constants.Recipe.DirectionDescriptionFromIndex(index)
            )).ToList();
    
    public static List<CreateIngredientCommand> CreateIngredientsCommand(int ingredientCount) =>
        Enumerable.Range(0, ingredientCount)
            .Select(index =>  new CreateIngredientCommand(
                Constants.Recipe.IngredientNameFromIndex(index),
                10,
                "grams"
            )).ToList();

    public static CreateNutritionInformationCommand CreateNutritionInformationCommand() =>
        new CreateNutritionInformationCommand(
            Constants.Recipe.Calories,
            Constants.Recipe.Protein,
            Constants.Recipe.Carbs,
            Constants.Recipe.Fats
        );

}