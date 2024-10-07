using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IReviewRepository
{
    Task AddReview(Review review);
    
    Task<Review?> GetUserReviewForRecipe(RecipeId recipeId, UserId userId);
}