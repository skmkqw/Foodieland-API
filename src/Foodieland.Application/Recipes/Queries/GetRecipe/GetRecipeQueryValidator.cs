using FluentValidation;

namespace Foodieland.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQueryValidator : AbstractValidator<GetRecipeQuery>
{
    public GetRecipeQueryValidator()
    {
        RuleFor(query => query.RecipeId).NotEmpty().WithMessage("Recipe ID cannot be empty");
    }
}