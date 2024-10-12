using ErrorOr;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Reviews.Queries.GetReview;

public record GetReviewQuery(ReviewId ReviewId) : IRequest<ErrorOr<Review>>;