using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.Recipes.Commands.DeleteRecipe;
using Foodieland.Application.Recipes.Commands.UpdateRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipes;
using Foodieland.Application.Recipes.Queries.GetUserRecipes;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Recipes.CreateOrUpdateRecipe;
using Foodieland.Contracts.Recipes.GetRecipe;
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
    public async Task<IActionResult> GetRecipes([FromQuery] PagedResultRequest request)
    {
        var query = _mapper.Map<GetRecipesQuery>(request);
        
        var getRecipesResult = await _mediator.Send(query);
        
        return Ok(_mapper.Map<GetRecipesResponse>(getRecipesResult));
    }

    [AllowAnonymous]
    [HttpGet("/users/{userId}/recipes")]
    public async Task<IActionResult> GetUserRecipes([FromRoute] Guid userId, [FromQuery] PagedResultRequest queryParams)
    {
        var query = _mapper.Map<GetUserRecipesQuery>((userId, queryParams));
        
        var getUserRecipesResult = await _mediator.Send(query);
        
        return getUserRecipesResult.Match(
            onValue: recipes => Ok(_mapper.Map<GetRecipesResponse>(recipes)),
            onError: errors => Problem(errors));
    }

    [HttpPost("/recipes")]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateOrUpdateRecipeRequest request)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<CreateRecipeCommand>((request, userId));
        
        var createRecipeResult = await _mediator.Send(command);
        
        return createRecipeResult.Match(
            onValue: recipe => Ok(_mapper.Map<CreateOrUpdateRecipeResponse>(recipe)),
            onError: errors => Problem(errors));
    }

    [HttpPut("/recipes/{recipeId}")]
    public async Task<IActionResult> UpdateRecipe([FromRoute] Guid recipeId, [FromBody] CreateOrUpdateRecipeRequest request)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }

        var command = _mapper.Map<UpdateRecipeCommand>((request, userId, recipeId));
        
        var updateRecipeResult = await _mediator.Send(command);
        
        return updateRecipeResult.Match(
            onValue: recipe => Ok(_mapper.Map<CreateOrUpdateRecipeResponse>(recipe)),
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