using ErrorOr;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Reviews.Commands;

public record CreateReviewCommand(RecipeId RecipeId, UserId CreatorId, string Content, int Rating) : IRequest<ErrorOr<Review>>;