using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
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

    public async Task<Review?> GetReviewById(ReviewId reviewId)
    {
        return await _dbContext.Reviews.FindAsync(reviewId);
    }

    public async Task<PagedResult<Review>> GetRecipeReviews(RecipeId recipeId, int page, int pageSize)
    {
        var totalReviews = _dbContext.Reviews.Count(r => r.RecipeId == recipeId);
        
        var recipeReviews = await _dbContext.Reviews.Where(r => r.RecipeId == recipeId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResult<Review>(recipeReviews, totalReviews, page, pageSize);
    }

    public async Task<PagedResult<Review>> GetUserReviews(UserId userId, int page, int pageSize)
    {
        var totalReviews = _dbContext.Reviews.Count(r => r.CreatorId == userId);
        
        var recipeReviews = await _dbContext.Reviews.Where(r => r.CreatorId == userId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResult<Review>(recipeReviews, totalReviews, page, pageSize);
    }

    public async Task<Review?> GetUserReviewForRecipe(RecipeId recipeId, UserId userId)
    {
        return await _dbContext.Reviews.FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.CreatorId == userId);
    }
    
    public async Task AddReview(Review review)
    {
        await _dbContext.Reviews.AddAsync(review);
    }

    public void UpdateReview(Review review)
    {
        _dbContext.Reviews.Update(review);
    }
}