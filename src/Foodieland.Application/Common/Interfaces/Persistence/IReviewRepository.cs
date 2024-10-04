using Foodieland.Domain.ReviewAggregate;

namespace Foodieland.Application.Common.Interfaces.Persistence;

public interface IReviewRepository
{
    Review AddReview(Review review);
}