using FluentValidation;

namespace Foodieland.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
{
    public UpdateRecipeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recipe Id cannot be empty");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Recipe name is required.")
            .MaximumLength(100).WithMessage("Recipe name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Recipe description is required.")
            .MaximumLength(500).WithMessage("Recipe description must not exceed 500 characters.");

        RuleFor(x => x.TimeToCook)
            .GreaterThan(0).WithMessage("Time to cook must be greater than 0.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Creator Id cannot be empty");

        RuleFor(x => x.NutritionInformation)
            .NotNull().WithMessage("Nutrition information is required.");

        RuleFor(x => x.Directions)
            .NotEmpty().WithMessage("At least one cooking direction is required.");

        RuleFor(x => x.Ingredients)
            .NotEmpty().WithMessage("At least one ingredient is required.");
    }
}