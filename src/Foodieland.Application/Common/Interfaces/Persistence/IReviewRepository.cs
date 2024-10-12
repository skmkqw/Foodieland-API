using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IReviewRepository
{
    Task<Review?> GetReviewById(ReviewId reviewId);
    
    Task<PagedResult<Review>> GetRecipeReviews(RecipeId recipeId, int page, int pageSize);
    
    Task<PagedResult<Review>> GetUserReviews(UserId userId, int page, int pageSize);
    
    Task<Review?> GetUserReviewForRecipe(RecipeId recipeId, UserId userId);
}