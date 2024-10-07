using ErrorOr;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(UserId UserId, UserId UserIdFromClaim) : IRequest<ErrorOr<Unit>>;