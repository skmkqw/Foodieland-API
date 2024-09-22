using System.Security.Claims;
using ErrorOr;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.Recipes.Commands.DeleteRecipe;
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
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<CreateRecipeCommand>((request, userId));
        
        var createRecipeResult = await _mediator.Send(command);
        
        return createRecipeResult.Match(
            onValue: recipe => Ok(_mapper.Map<CreateRecipeResponse>(recipe)),
            onError: errors => Problem(errors));
    }

    [HttpDelete("/recipes/{recipeId}")]
    public async Task<IActionResult> DeleteRecipe([FromRoute] Guid recipeId)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<DeleteRecipeCommand>((recipeId, userId));
        
        var deleteRecipeResult = await _mediator.Send(command);
        
        return deleteRecipeResult.Match(
            onValue: _ => NoContent(),
            onError: errors => Problem(errors)); 
    }
}