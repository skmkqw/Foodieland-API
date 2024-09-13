using ErrorOr;
using Foodieland.Application.Authentication.Common;
using MediatR;

namespace Foodieland.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email, 
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;