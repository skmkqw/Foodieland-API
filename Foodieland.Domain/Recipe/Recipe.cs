using Foodieland.Domain.Common.Models;
using Foodieland.Domain.Ingredient.ValueObjects;
using Foodieland.Domain.Recipe.Entities;
using Foodieland.Domain.Recipe.ValueObjects;
using Foodieland.Domain.Review.ValueObjects;
using Foodieland.Domain.User.ValueObjects;

namespace Foodieland.Domain.Recipe;

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
        DateTime updateDateTime) : base(id)
    {
        Name = name;
        Description = description;
        TimeToCook = timeToCook;
        CreatorId = creatorId;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Recipe Create(string name, string description, int timeToCook, UserId creatorId)
    {
        return new Recipe(RecipeId.CreateUnique(),
            name,
            description,
            timeToCook,
            creatorId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
