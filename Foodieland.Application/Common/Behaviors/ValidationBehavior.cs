using ErrorOr;
using FluentValidation;
using Foodieland.Application.Authentication.Commands.Register;
using Foodieland.Application.Authentication.Common;
using MediatR;

namespace Foodieland.Application.Common.Behaviors;

public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, 
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (validationResult.IsValid)
        {
            return await next();
        }
        
        var errors = validationResult.Errors
            .Select(e => Error.Validation(e.PropertyName, e.ErrorMessage))
            .ToList();
        
        return errors;
    }
}