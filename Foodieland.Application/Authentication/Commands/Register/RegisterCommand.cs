using MediatR;
using ErrorOr;
using Foodieland.Application.Authentication.Common;
using Foodieland.Application.Common.Interfaces.Authentication;

namespace Foodieland.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;