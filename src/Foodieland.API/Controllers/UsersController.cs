using Foodieland.Application.Users.Commands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodieland.API.Controllers;

public class UsersController : ApiController
{
    private readonly IMapper _mapper;
    
    private readonly IMediator _mediator;

    public UsersController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpDelete("/users/{userId}")]
    public async Task<IActionResult> DeleteRecipe([FromRoute] Guid userId)
    {
        var userIdFromClaim = GetUserId();
        if (!userIdFromClaim.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<DeleteUserCommand>((userId, userIdFromClaim.Value));
        
        var deleteUserResult = await _mediator.Send(command);
        
        return deleteUserResult.Match(
            onValue: _ => NoContent(),
            onError: errors => Problem(errors)); 
    }
}