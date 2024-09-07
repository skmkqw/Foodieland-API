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
    
    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdateDateTime { get; }
    
    private Review(
        ReviewId id, 
        RecipeId type, 
        UserId creatorId, 
        string content, 
        int rating, 
        DateTime createdDateTime, 
        DateTime updateDateTime) : base(id)
    {
        Type = type;
        CreatorId = creatorId;
        Content = content;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Review Create(RecipeId recipeId, UserId creatorId, string content, int rating)
    {
        return new Review(
            ReviewId.CreateUnique(), 
            recipeId,
            creatorId,
            content, 
            rating,
            DateTime.UtcNow, 
            DateTime.UtcNow);
    }
}