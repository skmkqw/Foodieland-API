using System.Security.Claims;
using ErrorOr;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Contracts.Recipes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodieland.API.Controllers;

public class RecipesController : ApiController
{
    private readonly IMapper _mapper;
    
    private readonly IMediator _mediator;

    public RecipesController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("/recipes")]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var creatorId))
        {
            return Problem([Error.Unauthorized(description: "Provided authorization token has no valid user id")]);
        }
        
        var command = _mapper.Map<CreateRecipeCommand>((request, creatorId));
        
        var createRecipeResult = await _mediator.Send(command);
        
        return createRecipeResult.Match(
            onValue: recipe => Ok(_mapper.Map<CreateRecipeResponse>(recipe)),
            onError: errors => Problem(errors));
    }
}