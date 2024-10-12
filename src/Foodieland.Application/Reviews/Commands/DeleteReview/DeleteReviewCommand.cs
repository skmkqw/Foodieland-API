using ErrorOr;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(ReviewId ReviewId, UserId UserId) : IRequest<ErrorOr<Unit>>;