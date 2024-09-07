using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Contracts.Recipes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodieland.API.Controllers;

[Route("[controller]")]
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
        var command = _mapper.Map<CreateRecipeCommand>((request, Guid.NewGuid()));
        
        var createRecipeResult = await _mediator.Send(command);
        return Ok(request);
    }
}