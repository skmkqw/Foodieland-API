using FluentValidation;

namespace Foodieland.Application.Recipes.Queries.GetUserRecipes;

public class GetUserRecipesQueryValidator : AbstractValidator<GetUserRecipesQuery>
{
    public GetUserRecipesQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID cannot be empty");
        
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("Page number cannot be empty")
            .GreaterThanOrEqualTo(1).WithMessage("Page number must be greater than or equal to 1");
        
        RuleFor(x => x.PageSize)
            .NotEmpty().WithMessage("Page size cannot be empty")
            .GreaterThanOrEqualTo(1).WithMessage("Page size must be greater than or equal to 1")
            .LessThanOrEqualTo(10).WithMessage("Page size must be less than or equal to 10");
    }
}