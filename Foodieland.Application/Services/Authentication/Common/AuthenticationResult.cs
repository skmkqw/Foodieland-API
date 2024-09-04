using Foodieland.Domain.Entities;

namespace Foodieland.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);