using FluentValidation;

namespace Foodieland.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
        
        RuleFor(x => x.UserIdFromClaim)
            .NotEmpty().WithMessage("User ID from token is required.");
    }
}