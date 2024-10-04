using Foodieland.Domain.ReviewAggregate;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IReviewRepository
{
    void AddReview(Review review);
}