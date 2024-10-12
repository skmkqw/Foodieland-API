using ErrorOr;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Reviews.Commands.UpdateReview;

public record UpdateReviewCommand(ReviewId ReviewId, UserId UserId, string Content, int Rating) : IRequest<ErrorOr<Review>>;