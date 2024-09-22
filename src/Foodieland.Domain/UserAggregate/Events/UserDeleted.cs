using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.UserAggregate.Events;

public record UserDeleted(User User) : IDomainEvent;