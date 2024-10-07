using FluentValidation;

namespace Foodieland.Application.Reviews.Queries.GetRecipeReviews;

public class GetRecipeReviewsQueryValidator : AbstractValidator<GetRecipeReviewsQuery>
{
    public GetRecipeReviewsQueryValidator()
    {
        RuleFor(x => x.RecipeId).NotEmpty().WithMessage("Recipe ID cannot be empty");
        
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("Page number cannot be empty")
            .GreaterThanOrEqualTo(1).WithMessage("Page number must be greater than or equal to 1");
        
        RuleFor(x => x.PageSize)
            .NotEmpty().WithMessage("Page size cannot be empty")
            .GreaterThanOrEqualTo(1).WithMessage("Page size must be greater than or equal to 1")
            .LessThanOrEqualTo(10).WithMessage("Page size must be less than or equal to 10");
    }
}