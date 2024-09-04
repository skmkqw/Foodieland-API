using ErrorOr;
using Foodieland.Application.Services.Authentication.Common;

namespace Foodieland.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}