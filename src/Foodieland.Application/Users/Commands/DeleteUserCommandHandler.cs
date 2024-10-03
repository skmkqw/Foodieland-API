using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using MediatR;

namespace Foodieland.Application.Users.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteUserCommandHandler(IUserRepository userRepository, IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }
        
        if (user.Id != request.UserIdFromClaim)
        {
            return Errors.User.Unauthorized;
        }
        
        _recipeRepository.DeleteRecipesByUserId(user.Id);
        
        _userRepository.DeleteUser(user);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}