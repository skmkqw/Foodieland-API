using FluentValidation;

namespace Foodieland.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Recipe name is required.")
            .MaximumLength(100).WithMessage("Recipe name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Recipe description is required.")
            .MaximumLength(500).WithMessage("Recipe description must not exceed 500 characters.");

        RuleFor(x => x.TimeToCook)
            .GreaterThan(0).WithMessage("Time to cook must be greater than 0.");

        RuleFor(x => x.CreatorId)
            .NotEmpty().WithMessage("CreatorId is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid CreatorId.");

        RuleFor(x => x.NutritionInformation)
            .NotNull().WithMessage("Nutrition information is required.");

        RuleFor(x => x.Directions)
            .NotEmpty().WithMessage("At least one cooking direction is required.");

        RuleFor(x => x.Ingredients)
            .NotEmpty().WithMessage("At least one ingredient is required.");
    }
}