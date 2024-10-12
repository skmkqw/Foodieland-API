using Foodieland.Application.Reviews.Commands.CreateReview;
using Foodieland.Application.Reviews.Commands.UpdateReview;
using Foodieland.Application.Reviews.Queries.GetRecipeReviews;
using Foodieland.Application.Reviews.Queries.GetUserReviews;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Reviews.CreateOrUpdateReview;
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

    [AllowAnonymous]
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetUserReviews([FromRoute] Guid userId, [FromQuery] PagedResultRequest queryParams)
    {
        var query = _mapper.Map<GetUserReviewsQuery>((userId, queryParams));
        
        var getUserReviewsResult = await _mediator.Send(query);
        
        return getUserReviewsResult.Match(
            onValue: recipe => Ok(_mapper.Map<GetReviewsResponse>(recipe)),
            onError: errors => Problem(errors));
    }


    [HttpPost("recipes/{recipeId}")]
    public async Task<IActionResult> CreateReview([FromRoute] Guid recipeId, [FromBody] CreateOrUpdateReviewRequest request)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<CreateReviewCommand>((recipeId, userId, request));
        
        var createReviewResult = await _mediator.Send(command);
        
        return createReviewResult.Match(
            onValue: review => Ok(_mapper.Map<CreateOrUpdateReviewResponse>(review)),
            onError: errors => Problem(errors));
    }

    [HttpPut("{reviewId}")]
    public async Task<IActionResult> UpdateReview([FromRoute] Guid reviewId, [FromBody] CreateOrUpdateReviewRequest request)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }

        var command = _mapper.Map<UpdateReviewCommand>((reviewId, userId, request));
        
        var updateReviewResult = await _mediator.Send(command);
        
        return updateReviewResult.Match(
            onValue: review => Ok(_mapper.Map<CreateOrUpdateReviewResponse>(review)),
            onError: errors => Problem(errors));
    }
}