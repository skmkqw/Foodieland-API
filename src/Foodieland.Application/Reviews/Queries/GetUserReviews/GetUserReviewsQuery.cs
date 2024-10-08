using ErrorOr;
using Foodieland.Application.Common.Interfaces.Queries;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Reviews.Queries.GetUserReviews;

public record GetUserReviewsQuery(UserId UserId, int Page, int PageSize) : IRequest<ErrorOr<PagedResult<Review>>>, IPagedQuery;