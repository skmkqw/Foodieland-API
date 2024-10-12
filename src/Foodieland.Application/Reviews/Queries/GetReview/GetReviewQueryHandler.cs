using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.ReviewAggregate;
using MediatR;

namespace Foodieland.Application.Reviews.Queries.GetReview;

public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, ErrorOr<Review>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ErrorOr<Review>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetReviewById(request.ReviewId);

        if (review is null)
        {
            return Errors.Review.NotFound;
        }

        return review;
    }
}