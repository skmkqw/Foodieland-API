using FluentValidation;
using Foodieland.Application.Common.Validators;

namespace Foodieland.Application.Reviews.Queries.GetRecipeReviews;

public class GetRecipeReviewsQueryValidator : PagedQueryValidator<GetRecipeReviewsQuery>
{
    public GetRecipeReviewsQueryValidator()
    {
        RuleFor(x => x.RecipeId).NotEmpty().WithMessage("Recipe ID cannot be empty");
    }
}