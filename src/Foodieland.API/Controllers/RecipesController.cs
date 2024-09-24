using System.Security.Claims;
using ErrorOr;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.Recipes.Commands.DeleteRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipes;
using Foodieland.Contracts.Recipes;
using Foodieland.Contracts.Recipes.Common;
using Foodieland.Contracts.Recipes.CreateRecipe;
using Foodieland.Contracts.Recipes.GetRecipes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [AllowAnonymous]
    [HttpGet("/recipes/{recipeId}")]
    public async Task<IActionResult> GetRecipeById([FromRoute] Guid recipeId)
    {
        var query =_mapper.Map<GetRecipeQuery>(recipeId);
        
        var getRecipeResult = await _mediator.Send(query);
        
        return getRecipeResult.Match(
            onValue: recipe => Ok(_mapper.Map<GetRecipeResponse>(recipe)),
            onError: errors => Problem(errors));
    }
    
    [AllowAnonymous]
    [HttpGet("/recipes")]
    public async Task<IActionResult> GetRecipes([FromQuery] GetRecipesRequest request)
    {
        var query = _mapper.Map<GetRecipesQuery>(request);
        
        var getRecipesResult = await _mediator.Send(query);
        
        return Ok(getRecipesResult.Select(r => _mapper.Map<GetRecipeResponse>(r)));
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