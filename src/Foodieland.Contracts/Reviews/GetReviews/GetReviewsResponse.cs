using Foodieland.Contracts.Common;
using Foodieland.Contracts.Reviews.GetReview;

namespace Foodieland.Contracts.Reviews.GetReviews;

public record GetReviewsResponse(List<GetReviewResponse> Reviews, Pagination Pagination);