using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Domain.RecipeAggregate.Entities;

public sealed class NutritionInformation : Entity<NutritionInformationId>
{
    public int Calories { get; }
    
    public float Fat { get; }
    
    public float Carbs { get; }
    
    public float Protein { get; }

    private NutritionInformation(NutritionInformationId id, int calories, float fat, float carbs, float protein) : base(id)
    {
        Calories = calories;
        Fat = fat;
        Carbs = carbs;
        Protein = protein;
    }

    public static NutritionInformation Create(int calories, float fat, float carbohydrates, float protein)
    {
        return new NutritionInformation(NutritionInformationId.CreateUnique(), calories, fat, carbohydrates, protein);
    }
}