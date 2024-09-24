using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Foodieland.Application.Users.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    
    private readonly IRecipeRepository _recipeRepository;
    
    public DeleteUserCommandHandler(IUserRepository userRepository, IRecipeRepository recipeRepository)
    {
        _userRepository = userRepository;
        _recipeRepository = recipeRepository;
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
        
        //TODO INTRODUCE A SEPARATE REPOSITORY METHOD
        var recipes = _recipeRepository.GetUserRecipes(user.Id, 1, int.MaxValue);
        
        foreach (var recipe in recipes.Items)
        {
            _recipeRepository.DeleteRecipe(recipe);
        }
        
        _userRepository.DeleteUser(user);
        
        return Unit.Value;
    }
}