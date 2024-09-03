using Foodieland.Domain.Entities;

namespace Foodieland.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}