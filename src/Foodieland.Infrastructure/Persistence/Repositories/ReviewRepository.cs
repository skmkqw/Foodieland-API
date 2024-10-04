using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.ReviewAggregate;

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
}