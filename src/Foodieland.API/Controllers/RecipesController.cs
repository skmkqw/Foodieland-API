using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.Recipes.Commands.DeleteRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipes;
using Foodieland.Application.Recipes.Queries.GetUserRecipes;
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

    [AllowAnonymous]
    [HttpGet("/users/{userId}/recipes")]
    public async Task<IActionResult> GetUserRecipes([FromRoute] Guid userId, [FromQuery] GetRecipesRequest queryParams)
    {
        var query = _mapper.Map<GetUserRecipesQuery>((userId, queryParams));
        
        var getUserRecipesResult = await _mediator.Send(query);
        
        return getUserRecipesResult.Match(
            onValue: recipes => Ok(recipes.Select(r => _mapper.Map<GetRecipeResponse>(r))),
            onError: errors => Problem(errors));
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