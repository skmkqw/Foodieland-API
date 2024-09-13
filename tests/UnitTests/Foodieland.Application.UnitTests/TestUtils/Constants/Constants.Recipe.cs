namespace Foodieland.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Recipe
    {
        public const string Name = "Pasta Carbonara";
        
        public const string Description = "Delicious italian pasta";

        public const int TimeToCook = 25;
        
        public const int Calories = 100;

        public const float Protein = 25.3f;
        
        public const float Carbs = 31.4f;
        
        public const float Fats = 10.1f;

        public const string IngredientName = "Pasta";
        
        public const float Quantity = 200f;
        
        public const string Unit = "g";

        public const int StepNumber = 1;
        
        public const string DirectionName = "Boil Water";

        public const string DirectionDescription = "Boil water to cook the pasta";
        
        public static string DirectionNameFromIndex(int index) => $"Direction {index}";
        
        public static string DirectionDescriptionFromIndex(int index) => $"Description for direction {index}";
        
        public static string IngredientNameFromIndex(int index) => $"Ingredient {index}";
    }
}