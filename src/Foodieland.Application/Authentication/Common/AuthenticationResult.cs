using Foodieland.Domain.UserAggregate;

namespace Foodieland.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);