using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.Entities;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Domain.RecipeAggregate;

public sealed class Recipe : AggregateRoot<RecipeId>
{
    public string Name { get; private set;}

    public string Description { get; private set;}

    public int TimeToCook { get; private set;}
    
    public UserId CreatorId { get; private set;}
    
    public NutritionInformation NutritionInformation { get; private set;}
    
    public IReadOnlyList<CookingDirection> Directions => _directions.AsReadOnly();
    
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();
    
    public IReadOnlyList<ReviewId> ReviewIds => _reviewIds.AsReadOnly();

    private List<CookingDirection> _directions;
    
    private List<Ingredient> _ingredients;
    
    private readonly List<ReviewId> _reviewIds = new();
    
    private Recipe(RecipeId id,
        string name,
        string description,
        int timeToCook,
        UserId creatorId,
        NutritionInformation nutritionInformation,
        List<CookingDirection> cookingDirections,
        List<Ingredient> ingredients) : base(id)
    {
        Name = name;
        Description = description;
        TimeToCook = timeToCook;
        CreatorId = creatorId;
        NutritionInformation = nutritionInformation;
        _directions = cookingDirections;
        _ingredients = ingredients;
    }

    public static Recipe Create(string name,
        string description,
        int timeToCook,
        UserId creatorId,
        NutritionInformation nutritionInformation,
        List<CookingDirection> cookingDirections,
        List<Ingredient> ingredients)
    {
        var recipe = new Recipe(RecipeId.CreateUnique(),
            name,
            description,
            timeToCook,
            creatorId,
            nutritionInformation,
            cookingDirections,
            ingredients);
        
        return recipe;
    }

    public void Update(string name,
        string description,
        int timeToCook,
        NutritionInformation nutritionInformation,
        List<CookingDirection> cookingDirections,
        List<Ingredient> ingredients)
    {
        Name = name;
        Description = description;
        TimeToCook = timeToCook;
        NutritionInformation = nutritionInformation;
        _directions = cookingDirections;
        _ingredients = ingredients;
    }
    
    public void AddReview(ReviewId reviewId)
    {
        _reviewIds.Add(reviewId);
    }

    public void RemoveReview(ReviewId reviewId)
    {
        _reviewIds.Remove(reviewId);
    }
    
#pragma warning disable CS8618
    private Recipe() 
#pragma warning restore CS8618
    {
    }
}
