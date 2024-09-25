using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Domain.ReviewAggregate;

public sealed class Review : AggregateRoot<ReviewId>
{
    public RecipeId Type { get; }

    public UserId CreatorId { get; }

    public string Content { get; }

    public int Rating { get; }
    
    private Review(
        ReviewId id, 
        RecipeId type, 
        UserId creatorId, 
        string content, 
        int rating) : base(id)
    {
        Type = type;
        CreatorId = creatorId;
        Content = content;
        Rating = rating;
    }

    public static Review Create(RecipeId recipeId, UserId creatorId, string content, int rating)
    {
        return new Review(
            ReviewId.CreateUnique(), 
            recipeId,
            creatorId,
            content, 
            rating);
    }
}