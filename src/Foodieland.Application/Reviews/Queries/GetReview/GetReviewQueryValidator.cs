using FluentValidation;

namespace Foodieland.Application.Reviews.Queries.GetReview;

public class GetReviewQueryValidator : AbstractValidator<GetReviewQuery>
{
    public GetReviewQueryValidator()
    {
        RuleFor(x => x.ReviewId)
            .NotEmpty()
            .WithMessage("Review ID cannot be empty");
    }
}