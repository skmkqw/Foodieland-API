using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.RecipeAggregate.Events;

public record RecipeCreated(Recipe Recipe) : IDomainEvent;