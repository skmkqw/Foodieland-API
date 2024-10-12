using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.ReviewAggregate;
using MediatR;

namespace Foodieland.Application.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ErrorOr<Review>>
{
    private readonly IReviewRepository _reviewRepository;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Review>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetReviewById(request.ReviewId);

        if (review is null)
        {
            return Errors.Review.NotFound;
        }
        
        var reviewCreator = await _userRepository.GetUserById(request.UserId);

        if (reviewCreator is null || reviewCreator.Id != review.CreatorId)
        {
            return Errors.Review.Unauthorized;
        }
        
        review.Update(request.Content, request.Rating);
        
        _reviewRepository.UpdateReview(review);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return review;
    }
}