using ErrorOr;
using Foodieland.Application.Authentication.Commands.Register;
using Foodieland.Application.Authentication.Common;
using MediatR;

namespace Foodieland.Application.Common.Behaviors;

public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, 
        CancellationToken cancellationToken)
    {
        var result = await next();
        return result;
    }
}