using Foodieland.Domain.Common.Models;
using Foodieland.Domain.Recipe.Entities;
using Foodieland.Domain.Recipe.ValueObjects;

namespace Foodieland.Domain.Recipe;

public sealed class Recipe : AggregateRoot<RecipeId>
{
    public string Name { get; }

    public string Description { get; }

    public int TimeToCook { get; }
    
    public NutritionInformation? NutritionInformation => _nutritionInformation;
    
    public IReadOnlyList<CookingDirection> Directions => _directions.AsReadOnly();
    
    private NutritionInformation? _nutritionInformation;

    private readonly List<CookingDirection> _directions = new();
    
    private Recipe(RecipeId id, string name, string description, int timeToCook) : base(id)
    {
        Name = name;
        Description = description;
        TimeToCook = timeToCook;
    }

    public static Recipe Create(string name, string description, int timeToCook)
    {
        return new Recipe(RecipeId.CreateUnique(), name, description, timeToCook);
    }

    public void AddNutritionInformation(NutritionInformation nutritionInformation)
    {
        _nutritionInformation = nutritionInformation;
    }
}
