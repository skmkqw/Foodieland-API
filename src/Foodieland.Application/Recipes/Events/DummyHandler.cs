using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate.Events;
using MediatR;

namespace Foodieland.Application.Recipes.Events;

public class DummyHandler : INotificationHandler<RecipeCreated>
{
    public Task Handle(RecipeCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}