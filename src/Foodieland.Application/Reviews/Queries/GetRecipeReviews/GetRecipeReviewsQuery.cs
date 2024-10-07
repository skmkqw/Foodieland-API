using ErrorOr;
using Foodieland.Application.Common.Interfaces.Queries;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using MediatR;

namespace Foodieland.Application.Reviews.Queries.GetRecipeReviews;

public record GetRecipeReviewsQuery(RecipeId RecipeId, int Page, int PageSize) : IRequest<ErrorOr<PagedResult<Review>>>, IPagedQuery;