using FluentValidation;
using Foodieland.Application.Common.Validators;

namespace Foodieland.Application.Recipes.Queries.GetUserRecipes;

public class GetUserRecipesQueryValidator : PagedQueryValidator<GetUserRecipesQuery>
{
    public GetUserRecipesQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID cannot be empty");
    }
}