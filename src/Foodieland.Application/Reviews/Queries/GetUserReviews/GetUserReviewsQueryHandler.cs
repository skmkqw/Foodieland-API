using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.ReviewAggregate;
using MediatR;

namespace Foodieland.Application.Reviews.Queries.GetUserReviews;

public class GetUserReviewsQueryHandler : IRequestHandler<GetUserReviewsQuery, ErrorOr<PagedResult<Review>>>
{
    private readonly IReviewRepository _reviewRepository;
    
    private readonly IUserRepository _userRepository;

    public GetUserReviewsQueryHandler(IReviewRepository reviewRepository, IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<PagedResult<Review>>> Handle(GetUserReviewsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }
        
        return await _reviewRepository.GetUserReviews(user.Id, request.Page, request.PageSize);
    }
}