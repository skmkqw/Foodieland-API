using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.ReviewAggregate;
using MediatR;

namespace Foodieland.Application.Reviews.Queries.GetRecipeReviews;

public class GetRecipeReviewsQueryHandler : IRequestHandler<GetRecipeReviewsQuery, ErrorOr<PagedResult<Review>>>
{
    private readonly IReviewRepository _reviewRepository;
    
    private readonly IRecipeRepository _recipeRepository;
    
    public GetRecipeReviewsQueryHandler(
        IReviewRepository reviewRepository,
        IRecipeRepository recipeRepository)
    {
        _reviewRepository = reviewRepository;
        _recipeRepository = recipeRepository;
    }

    public async Task<ErrorOr<PagedResult<Review>>> Handle(GetRecipeReviewsQuery request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetRecipeById(request.RecipeId);

        if (recipe is null)
        {
            return Errors.Recipe.NotFound;
        }
        
        return await _reviewRepository.GetRecipeReviews(request.RecipeId, request.Page, request.PageSize);
    }
}