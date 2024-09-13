using FluentAssertions;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.Entities;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Application.UnitTests.TestUtils.Recipes.Extensions;

public static partial class RecipeExtensions
{
    public static void ValidateCreatedFrom(this Recipe recipe, CreateRecipeCommand createRecipeCommand)
    {
        recipe.Name.Should().Be(createRecipeCommand.Name);
        recipe.Description.Should().Be(createRecipeCommand.Description);
        recipe.TimeToCook.Should().Be(createRecipeCommand.TimeToCook);
        recipe.CreatorId.Value.Should().Be(createRecipeCommand.CreatorId);
        VaildateNutritionInformation(recipe.NutritionInformation, createRecipeCommand.NutritionInformation);
        recipe.Directions.Zip(createRecipeCommand.Directions).ToList().ForEach(pair => ValidateDirection(pair.First, pair.Second));
        recipe.Ingredients.Zip(createRecipeCommand.Ingredients).ToList().ForEach(pair => ValidateIngredient(pair.First, pair.Second));


        static void VaildateNutritionInformation(NutritionInformation nutritionInformation,
            CreateNutritionInformationCommand nutritionInformationCommand)
        {
            nutritionInformation.Calories.Should().Be(nutritionInformationCommand.Calories);
            nutritionInformation.Protein.Should().Be(nutritionInformationCommand.Protein);
            nutritionInformation.Carbs.Should().Be(nutritionInformationCommand.Carbs);
            nutritionInformation.Fat.Should().Be(nutritionInformationCommand.Fat);
        }

        static void ValidateDirection(CookingDirection cookingDirection,
            CreateCookingDirectionCommand createCookingDirectionCommand)
        {
            cookingDirection.Id.Should().NotBeNull();
            cookingDirection.Name.Should().Be(createCookingDirectionCommand.Name);
            cookingDirection.Description.Should().Be(createCookingDirectionCommand.Description);
            cookingDirection.StepNumber.Should().Be(createCookingDirectionCommand.StepNumber);
        }

        static void ValidateIngredient(Ingredient ingredient, CreateIngredientCommand createIngredientCommand)
        {
            ingredient.Id.Should().NotBeNull();
            ingredient.Name.Should().Be(createIngredientCommand.Name);
            ingredient.Quantity.Should().Be(createIngredientCommand.Quantity);
            ingredient.Unit.Should().Be(createIngredientCommand.Unit);
        }
    }
}