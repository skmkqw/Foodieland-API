using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate.Events;
using MediatR;

namespace Foodieland.Application.Recipes.Events;

public class RecipeDeletedEventHandler : INotificationHandler<RecipeDeleted>
{
    private readonly IUserRepository _userRepository;

    public RecipeDeletedEventHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task Handle(RecipeDeleted notification, CancellationToken cancellationToken)
    {
        var recipeCreator = _userRepository.GetUserById(notification.Recipe.CreatorId);
        
        recipeCreator!.RemoveRecipe(notification.Recipe.Id);
        
        return Task.CompletedTask;
    }
}