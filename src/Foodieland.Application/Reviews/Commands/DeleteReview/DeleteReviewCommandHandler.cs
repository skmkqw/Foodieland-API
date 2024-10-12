using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using MediatR;

namespace Foodieland.Application.Reviews.Commands.DeleteReview;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, ErrorOr<Unit>>
{
    private readonly IReviewRepository _reviewRepository;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewCommandHandler(IReviewRepository reviewRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
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
        
        _reviewRepository.DeleteReview(review);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}