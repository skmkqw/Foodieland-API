using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.RecipeAggregate.Events;

public record RecipeDeleted(Recipe Recipe) : IDomainEvent;