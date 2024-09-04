using Foodieland.Application.Authentication.Commands.Register;
using Foodieland.Application.Authentication.Common;
using Foodieland.Application.Authentication.Queries.Login;
using Foodieland.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = Foodieland.Contracts.Authentication.LoginRequest;

namespace Foodieland.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        
        var authResult = await _mediator.Send(command);
          
        
        return authResult.Match(
            result => Ok(MapAuthResponse(result)),
            errors => Problem(errors)
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
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            result => Ok(MapAuthResponse(result)),
            errors => Problem(errors)
            );
    }
}