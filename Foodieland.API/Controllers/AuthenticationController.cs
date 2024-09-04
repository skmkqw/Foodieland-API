using Foodieland.Application.Authentication.Commands.Register;
using Foodieland.Application.Authentication.Common;
using Foodieland.Application.Authentication.Queries.Login;
using Foodieland.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = Foodieland.Contracts.Authentication.LoginRequest;

namespace Foodieland.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var authResult = await _mediator.Send(command);
        
        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
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
        var query = _mapper.Map<LoginQuery>(request);
        
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
            );
    }
}