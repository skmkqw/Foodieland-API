using Foodieland.Application.Reviews.Commands;
using Foodieland.Application.Reviews.Commands.CreateReview;
using Foodieland.Contracts.Reviews.CreateReview;
using MapsterMapper;
using MediatR;
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


    [HttpPost("recipe/{recipeId}")]
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