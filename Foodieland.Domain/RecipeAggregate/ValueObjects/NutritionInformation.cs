using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.RecipeAggregate.ValueObjects;

public sealed class NutritionInformation : ValueObject
{
    public int Calories { get; }
    
    public float Fat { get; }
    
    public float Carbs { get; }
    
    public float Protein { get; }

    private NutritionInformation(int calories, float fat, float carbs, float protein)
    {
        Calories = calories;
        Fat = fat;
        Carbs = carbs;
        Protein = protein;
    }

    public static NutritionInformation Create(int calories, float fat, float carbohydrates, float protein)
    {
        return new NutritionInformation(calories, fat, carbohydrates, protein);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Calories;
        yield return Fat;
        yield return Carbs;
        yield return Protein;
    }
}