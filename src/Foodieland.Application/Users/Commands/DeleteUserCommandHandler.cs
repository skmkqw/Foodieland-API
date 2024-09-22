using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.UserAggregate.Events;
using MediatR;

namespace Foodieland.Application.Users.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    
    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var user = _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            return Error.NotFound("User.NotFound", "User not found or doesn't exist");
        }
        
        if (user.Id != request.UserIdFromClaim)
        {
            return Error.Unauthorized("User.Unauthorized", "You are not authorized to delete this account.");
        }
        
        user.AddDomainEvent(new UserDeleted(user));
        
        _userRepository.DeleteUser(user);
        
        return Unit.Value;
    }
}