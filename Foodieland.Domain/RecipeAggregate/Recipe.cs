using Foodieland.Domain.Common.Models;
using Foodieland.Domain.IngredientAggregate.ValueObjects;
using Foodieland.Domain.RecipeAggregate.Entities;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Domain.RecipeAggregate;

public sealed class Recipe : AggregateRoot<RecipeId>
{
    public string Name { get; }

    public string Description { get; }

    public int TimeToCook { get; }
    
    public UserId CreatorId { get; }
    
    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdateDateTime { get; }
    
    public IReadOnlyList<CookingDirection> Directions => _directions.AsReadOnly();
    
    public NutritionInformation? NutritionInformation => _nutritionInformation;

    public IReadOnlyList<IngredientId> IngredientsIds => _ingredientIds.AsReadOnly();
    
    public IReadOnlyList<ReviewId> ReviewIds => _reviewIds.AsReadOnly();

    private NutritionInformation? _nutritionInformation;

    private readonly List<CookingDirection> _directions = new();
    
    private readonly List<IngredientId> _ingredientIds = new();
    
    private readonly List<ReviewId> _reviewIds = new();
    
    private Recipe(RecipeId id,
        string name,
        string description,
        int timeToCook,
        UserId creatorId,
        DateTime createdDateTime,
        DateTime updateDateTime, 
        NutritionInformation? nutritionInformation,
        List<CookingDirection> cookingDirections,
        List<IngredientId> ingredientIds) : base(id)
    {
        Name = name;
        Description = description;
        TimeToCook = timeToCook;
        CreatorId = creatorId;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
        _nutritionInformation = nutritionInformation;
    }

    public static Recipe Create(string name,
        string description,
        int timeToCook,
        UserId creatorId,
        NutritionInformation nutritionInformation,
        List<CookingDirection> cookingDirections,
        List<IngredientId> ingredientIds)
    {
        return new Recipe(RecipeId.CreateUnique(),
            name,
            description,
            timeToCook,
            creatorId,
            DateTime.UtcNow,
            DateTime.UtcNow,
            nutritionInformation,
            cookingDirections,
            ingredientIds);
    }
}
