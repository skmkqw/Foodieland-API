using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.ReviewAggregate;
using MediatR;

namespace Foodieland.Application.Reviews.Commands;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ErrorOr<Review>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IReviewRepository _reviewRepository;

    public CreateReviewCommandHandler(
        IUnitOfWork unitOfWork,
        IRecipeRepository recipeRepository,
        IUserRepository userRepository,
        IReviewRepository reviewRepository)
    {
        _unitOfWork = unitOfWork;
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<ErrorOr<Review>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewCreator = _userRepository.GetUserById(request.CreatorId);

        if (reviewCreator is null)
        {
            return Errors.User.NotFound;
        }
        
        var reviewedRecipe = await _recipeRepository.GetRecipeById(request.RecipeId);

        if (reviewedRecipe is null)
        {
            return Errors.Recipe.NotFound;
        }
        
        var existingReview = _reviewRepository.GetUserReviewForRecipe(reviewedRecipe.Id, reviewCreator.Id);

        if (existingReview is not null)
        {
            return Errors.Review.DuplicateReview;
        }
        
        var review = Review.Create(
            recipeId: reviewedRecipe.Id, 
            creatorId: reviewCreator.Id, 
            content: request.Content,
            rating: request.Rating);
        
        _reviewRepository.AddReview(review);
        
        reviewedRecipe.AddReview(review.Id);
        reviewCreator.AddReview(review.Id);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return review;
    }
}