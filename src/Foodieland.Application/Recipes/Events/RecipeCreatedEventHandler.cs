using Foodieland.Domain.RecipeAggregate.Events;
using MediatR;

namespace Foodieland.Application.Recipes.Events;

public class RecipeCreatedEventHandler : INotificationHandler<RecipeCreated>
{
    public Task Handle(RecipeCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}