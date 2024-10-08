using FluentValidation;
using Foodieland.Application.Common.Validators;

namespace Foodieland.Application.Reviews.Queries.GetUserReviews;

public class GetUserReviewsQueryValidator : PagedQueryValidator<GetUserReviewsQuery>
{
    public GetUserReviewsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID cannot be empty");
    }
}