using ErrorOr;
using Foodieland.Application.Services.Authentication;
using Foodieland.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = Foodieland.Contracts.Authentication.LoginRequest;

namespace Foodieland.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Password);
        
        return authResult.MatchFirst(
            result => Ok(MapAuthResponse(result)),
            firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
            );
    }

    private static AuthenticationResponse MapAuthResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(
            request.Email, 
            request.Password);

        return authResult.MatchFirst(
            result => Ok(MapAuthResponse(result)), 
            firstError => Problem(statusCode: StatusCodes.Status401Unauthorized, title: firstError.Description))
            ;
    }
}