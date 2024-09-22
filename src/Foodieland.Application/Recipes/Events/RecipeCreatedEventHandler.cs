using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate.Events;
using MediatR;

namespace Foodieland.Application.Recipes.Events;

public class RecipeCreatedEventHandler : INotificationHandler<RecipeCreated>
{
    private readonly IUserRepository _userRepository;

    public RecipeCreatedEventHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task Handle(RecipeCreated notification, CancellationToken cancellationToken)
    {
        var recipeCreator = _userRepository.GetUserById(notification.Recipe.CreatorId);
        
        recipeCreator!.AddRecipe(notification.Recipe.Id);
        
        return Task.CompletedTask;
    }
}