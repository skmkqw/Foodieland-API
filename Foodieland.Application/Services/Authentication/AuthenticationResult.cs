using Foodieland.Domain.Entities;

namespace Foodieland.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);