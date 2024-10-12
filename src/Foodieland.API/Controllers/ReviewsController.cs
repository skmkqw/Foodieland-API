using Foodieland.Application.Reviews.Commands.CreateReview;
using Foodieland.Application.Reviews.Commands.DeleteReview;
using Foodieland.Application.Reviews.Commands.UpdateReview;
using Foodieland.Application.Reviews.Queries.GetRecipeReviews;
using Foodieland.Application.Reviews.Queries.GetReview;
using Foodieland.Application.Reviews.Queries.GetUserReviews;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Reviews.CreateOrUpdateReview;
using Foodieland.Contracts.Reviews.GetReview;
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
    [HttpGet("{reviewId}")]
    public async Task<IActionResult> GetReview([FromRoute] Guid reviewId)
    {
        var query = _mapper.Map<GetReviewQuery>(reviewId);
        
        var getReviewResult = await _mediator.Send(query);

        return getReviewResult.Match(
            onValue: review => Ok(_mapper.Map<GetReviewResponse>(review)),
            onError: errors => Problem(errors));
    }

    [AllowAnonymous]
    [HttpGet("recipes/{recipeId}")]
    public async Task<IActionResult> GetRecipeReviews([FromRoute] Guid recipeId, [FromQuery] PagedResultRequest queryParams)
    {
        var query = _mapper.Map<GetRecipeReviewsQuery>((recipeId, queryParams));
        
        var getRecipeReviewsResult = await _mediator.Send(query);
        
        return getRecipeReviewsResult.Match(
            onValue: reviews => Ok(_mapper.Map<GetReviewsResponse>(reviews)),
            onError: errors => Problem(errors));
    }

    [AllowAnonymous]
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetUserReviews([FromRoute] Guid userId, [FromQuery] PagedResultRequest queryParams)
    {
        var query = _mapper.Map<GetUserReviewsQuery>((userId, queryParams));
        
        var getUserReviewsResult = await _mediator.Send(query);
        
        return getUserReviewsResult.Match(
            onValue: reviews => Ok(_mapper.Map<GetReviewsResponse>(reviews)),
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

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteReview([FromRoute] Guid reviewId)
    {
        var userId = GetUserId();
        if (!userId.HasValue)
        {
            return UnauthorizedUserIdProblem();
        }
        
        var command = _mapper.Map<DeleteReviewCommand>((reviewId, userId));
        
        var deleteReviewResult = await _mediator.Send(command);

        return deleteReviewResult.Match(
            onValue: _ => NoContent(),
            onError: errors => Problem(errors));
    }
}