using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IReviewRepository
{
    void AddReview(Review review);
    
    Review? GetUserReviewForRecipe(RecipeId recipeId, UserId userId);
}