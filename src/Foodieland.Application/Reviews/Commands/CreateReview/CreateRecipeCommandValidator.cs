using FluentValidation;

namespace Foodieland.Application.Reviews.Commands.CreateReview;

public class CreateRecipeCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.RecipeId).NotEmpty()
            .WithMessage("Recipe id cannot be empty");
        
        RuleFor(x => x.CreatorId).NotEmpty()
            .WithMessage("Creator id cannot be empty");
        
        RuleFor(x => x.Rating).NotEmpty()
            .WithMessage("Rating cannot be empty")
            .GreaterThan(0)
            .WithMessage("Rating must be greater than 0")
            .LessThan(6)
            .WithMessage("Rating must be less than 6");
        
        RuleFor(x => x.Content).NotEmpty()
            .WithMessage("Content cannot be empty")
            .MaximumLength(100)
            .WithMessage("Content must be less than 100 characters");
    }
}