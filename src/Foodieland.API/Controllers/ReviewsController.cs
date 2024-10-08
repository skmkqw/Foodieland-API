using Foodieland.Application.Reviews.Commands.CreateReview;
using Foodieland.Application.Reviews.Queries.GetRecipeReviews;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Reviews.CreateReview;
using Foodieland.Contracts.Reviews.GetReviews;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodieland.API.Controllers;

[Route("reviews")]
public class ReviewsController : ApiController
{
    private readonly IMapper _mapper;
    
    private readonly IMediator _mediator;

    public ReviewsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("recipes/{recipeId}")]
    public async Task<IActionResult> GetRecipeReviews([FromRoute] Guid recipeId, [FromQuery] PagedResultRequest queryParams)
    {
        var query = _mapper.Map<GetRecipeReviewsQuery>((recipeId, queryParams));
        
        var getRecipeReviewsResult = await _mediator.Send(query);
        
        return getRecipeReviewsResult.Match(
            onValue: recipe => Ok(_mapper.Map<GetReviewsResponse>(recipe)),
            onError: errors => Problem(errors));
    }


    [HttpPost("recipes/{recipeId}")]
    public async Task<IActionResult> CreateReview([FromRoute] Guid recipeId, [FromBody] CreateReviewRequest request)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<CreateReviewCommand>((recipeId, userId, request));
        
        var createReviewResult = await _mediator.Send(command);
        
        return createReviewResult.Match(
            onValue: recipe => Ok(_mapper.Map<CreateReviewResponse>(recipe)),
            onError: errors => Problem(errors));
    }
}