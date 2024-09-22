using FluentValidation;

namespace Foodieland.Application.Recipes.Commands.DeleteRecipe;

public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
{
    public DeleteRecipeCommandValidator()
    {
        RuleFor(x => x.RecipeId)
            .NotEmpty().WithMessage("Recipe ID is required.");

        RuleFor(x => x.CreatorId)
            .NotEmpty().WithMessage("Creator ID is required.");
    }
}