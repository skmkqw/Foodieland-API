using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.UserAggregate.Events;
using MediatR;

namespace Foodieland.Application.Users.Events;

public class UserDeletedEventHandler : INotificationHandler<UserDeleted>
{
    private readonly IRecipeRepository _recipeRepository;

    public UserDeletedEventHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public Task Handle(UserDeleted notification, CancellationToken cancellationToken)
    {
        var recipes = notification.User.RecipeIds.Select(ri => _recipeRepository.GetRecipeById(ri)).ToList();
        
        recipes.ForEach(r => _recipeRepository.DeleteRecipe(r!));
        
        return Task.CompletedTask;
    }
}