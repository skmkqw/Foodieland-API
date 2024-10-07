using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly FoodielandDbContext _dbContext;

    public ReviewRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddReview(Review review)
    {
        _dbContext.Reviews.Add(review);
    }

    public Review? GetUserReviewForRecipe(RecipeId recipeId, UserId userId)
    {
        return _dbContext.Reviews.FirstOrDefault(r => r.RecipeId == recipeId && r.CreatorId == userId);
    }
}