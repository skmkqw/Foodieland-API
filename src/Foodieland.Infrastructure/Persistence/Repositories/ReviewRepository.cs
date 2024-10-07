using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Foodieland.Infrastructure.Persistence.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly FoodielandDbContext _dbContext;

    public ReviewRepository(FoodielandDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddReview(Review review)
    {
        await _dbContext.Reviews.AddAsync(review);
    }

    public async Task<Review?> GetUserReviewForRecipe(RecipeId recipeId, UserId userId)
    {
        return await _dbContext.Reviews.FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.CreatorId == userId);
    }
}