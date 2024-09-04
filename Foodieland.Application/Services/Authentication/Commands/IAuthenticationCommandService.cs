using ErrorOr;
using Foodieland.Application.Services.Authentication.Common;

namespace Foodieland.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}